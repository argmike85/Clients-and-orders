using Client_orders.Abstraction;
using Client_orders.Abstraction.ClientModels;
using Client_orders.DATA;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_orders.Models
{
    public class ClientRepository : IClientRepository
    {
        private ClientOrderContext context;
        public ClientRepository(ClientOrderContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Client> GetClients => context.Clients.AsQueryable();

        

        Task IClientRepository.CreateClient(CreateClientModel model)
        {
            context.Clients.AddRange(new Client()
            {
                Name = model.Name,
                BirthDate = model.BirthDate,
                Email = model.Email,
                Inn = model.Inn,
                PhoneNumber = model.PhoneNumber
            });
            context.SaveChanges();
            return Unit.Task;
        }

        Task IClientRepository.DeleteClient(int id)
        {
            var client = context.Clients.FirstOrDefault(e => e.ClientId == id);
            if (client != null)
            {
                context.Clients.RemoveRange(client);
                context.SaveChanges();
            }


            return Unit.Task;
        }

        Client IClientRepository.GetClient(int id)
        {
            return context.Clients.FirstOrDefault(e => e.ClientId == id);
        }

        Task IClientRepository.UpdateClient(UpdateClientModel model)
        {
            context.Clients.UpdateRange(new Client()
            {
                ClientId = model.ClientId,
                Name = model.Name,
                BirthDate = model.BirthDate,
                Email = model.Email,
                Inn = model.Inn,
                PhoneNumber = model.PhoneNumber
            });
            context.SaveChanges();
            return Unit.Task;
        }
    }
}
