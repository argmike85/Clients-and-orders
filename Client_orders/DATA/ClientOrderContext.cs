using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Client_orders.DATA
{
    public class ClientOrderContext:DbContext
    {
        public ClientOrderContext(DbContextOptions<ClientOrderContext> options)
           : base(options) { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
    }

    public class ApplicationDbContextFactory
         : IDesignTimeDbContextFactory<ClientOrderContext>
    {

        public ClientOrderContext CreateDbContext(string[] args) =>
            Program.BuildWebHost(args).Services
                .GetRequiredService<ClientOrderContext>();
    }
}
