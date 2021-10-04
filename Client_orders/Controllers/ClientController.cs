using Client_orders.Abstraction;
using Client_orders.Abstraction.ClientModels;
using Client_orders.DATA;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_orders.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository client)
        {
            _clientRepository = client;
        }

        [HttpGet]
        public List<Client> GetClientsAsync()
        {
            return _clientRepository.GetClients.ToList();
        }
        [HttpPost]
        public async void CreateClientAsync([FromBody]CreateClientModel model)
        {
             await _clientRepository.CreateClient(model);

        }
        [HttpPut]
        public async void UpdateClientAsync([FromBody]UpdateClientModel model)
        {
            await _clientRepository.UpdateClient(model);
        }
        [HttpDelete]
        public async void DeleteClientAsync(int id)
        {
            await _clientRepository.DeleteClient(id);
        }



    }
}
