using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_orders.DATA
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ClientOrderContext context = app.ApplicationServices
                .GetRequiredService<ClientOrderContext>();
            context.Database.Migrate();
            if (!context.Clients.Any())
            {
                context.Clients.AddRange(

                            new Client()
                            {
                                Name = "mike",
                                BirthDate = DateTime.Now.AddDays(-30),
                                Email ="argmike85@gmail.com",
                                Inn="1234567890",
                                PhoneNumber="89146404512",
                                Orders = new List<Order>
                    {
                        new Order(){Name="пряники",},
                        new Order(){Name="печенье"}
                  }


                            },
                            new Client()
                            {
                                Name="bob",
                                BirthDate= DateTime.Now.AddDays(-60),
                                Email = "bob85@gmail.com",
                                Inn = "1234567890",
                                PhoneNumber = "89146404512",
                                Orders = new List<Order>
                                 {
                        new Order(){Name="конфеты",},
                        new Order(){Name="шоколадки"}
                  }


                            }

                );
                context.SaveChanges();
            }
        }
    }

}
