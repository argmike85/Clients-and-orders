using Client_orders.Abstraction;
using Client_orders.Abstraction.OrderModels;
using Client_orders.DATA;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_orders.Models
{
    public class OrderRepository : IOrderRepository
    {
        private ClientOrderContext context;
        public OrderRepository(ClientOrderContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> GetOrders => context.Orders.AsQueryable();
        Task IOrderRepository.CreateOrder(CreateOrderModel model)
        {
            context.Orders.AddRange(new Order()
            {
                Name = model.Name,
                CreatedOn = model.CreatedOn,
                Status = model.Status,
                ClientId = model.ClientId
            });
            context.SaveChanges();
            return Unit.Task;


        }
     

        Task IOrderRepository.DeleteOrder(int id)
        {

            var order = context.Orders.FirstOrDefault(e => e.OrderId == id);
            if (order != null)
            {
                context.Orders.RemoveRange(order);
                context.SaveChanges();
            }


            return Unit.Task;

        }

        Task IOrderRepository.UpdateOrder(UpdateOrderModel model)
        {
            context.Orders.Update(new Order()
            {
                OrderId = model.OrderId,
                Name = model.Name,
                CreatedOn = model.CreatedOn,
                Status = model.Status,
                ClientId = model.ClientId
            });
            context.SaveChanges();
            return Unit.Task;
        }
    }
}
