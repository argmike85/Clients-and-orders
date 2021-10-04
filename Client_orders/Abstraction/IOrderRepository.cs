using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client_orders.Abstraction.OrderModels;
using Client_orders.DATA;


namespace Client_orders.Abstraction
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetOrders { get; }
        Task DeleteOrder(int id);
        Task UpdateOrder(UpdateOrderModel model);
        Task CreateOrder(CreateOrderModel model);
    }
}
