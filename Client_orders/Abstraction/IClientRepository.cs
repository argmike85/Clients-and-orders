using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client_orders.Abstraction.ClientModels;
using Client_orders.DATA;

namespace Client_orders.Abstraction
{
    public interface IClientRepository
    {
        IQueryable<Client> GetClients { get; }
        Client GetClient(int id);
        Task DeleteClient(int id);
        Task UpdateClient(UpdateClientModel model);
        Task CreateClient(CreateClientModel model);
    }
}
