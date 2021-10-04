using Client_orders.Abstraction;
using Client_orders.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Client_orders.DATA;
using Client_orders.Models.ViewModels;
using Client_orders.Abstraction.ClientModels;
using Client_orders.Abstraction.OrderModels;


namespace Client_orders.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IClientRepository _clientRepository;


        public HomeController(ILogger<HomeController> logger,IOrderRepository orderRepository,IClientRepository clientRepository)
        {
            _orderRepository = orderRepository;
            _clientRepository = clientRepository;

            _logger = logger;
        }
     
        public IActionResult Index()
        {
            
            return View(_clientRepository.GetClients.ToList());
        }
        [HttpGet]
        public  IActionResult CreateClient()
        {
                  return View();
        }

        [HttpPost]
        public IActionResult CreateClient(Client_orders.Abstraction.ClientModels.CreateClientModel model)
        {
           
                _clientRepository.CreateClient(model);
                return Redirect("/Home/Index");
            
        }
        [HttpGet]
        public IActionResult EditClient(int id)
        {
            
            return View(_clientRepository.GetClient(id));
        }

        [HttpPost]
        public IActionResult EditClient(Client_orders.Abstraction.ClientModels.UpdateClientModel model)
        {
            _clientRepository.UpdateClient(model);
            return Redirect("/Home/Index");

        }
        
        public IActionResult DeleteClient(int id)
        {
            if (_orderRepository.GetOrders.FirstOrDefault(e => e.ClientId == id)!=null)
               {
                TempData["msg"] = "<script>alert('У этого клиента имеются заказы!');</script>";
               // ViewBag.alertMessage = "У этого клиента имеются заказы!";
                return Redirect("/Home/Index");

            }
            else
            { _clientRepository.DeleteClient(id); }
                       
            return Redirect("/Home/Index");

        }
        public IActionResult DeleteOrder(int orderId, int clientId)
        {
            _orderRepository.DeleteOrder(orderId);
            return Redirect("/Home/DetailsClient/"+ clientId.ToString());
        }

        [HttpGet]
        public IActionResult DetailsClient(int id)
        {
                        
            return View(new DetailsClientViewModel { 
                    Client= _clientRepository.GetClient(id),
                    Orders= _orderRepository.GetOrders.Where(e => e.ClientId == id).ToList()
            });
        }
        [HttpGet] 
        public IActionResult EditOrder(int id)
        {
            ViewBag.ClientId = id.ToString();
            return View(_orderRepository.GetOrders.FirstOrDefault(e=>e.OrderId==id));
        }

        [HttpPost]
        public IActionResult EditOrder(Client_orders.Abstraction.OrderModels.UpdateOrderModel model)
        {
            _orderRepository.UpdateOrder(model);
            return Redirect("/Home/DetailsClient/"+model.ClientId.ToString());

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CreateOrder(int clientId)
        {
            return View(new Order() {
                //CreatedOn = DateTime.Now,
                ClientId = clientId,
                Status = Status.InProgress
            });
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderModel model)
        {
            _orderRepository.CreateOrder(model);
            return Redirect("/Home/DetailsClient/" + model.ClientId);
        }
    }
}
