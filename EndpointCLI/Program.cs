using Demo.Core.ApplicationService;
using Demo.Core.Contracts;
using Demo.Infra.Data;
using Demo.Infra.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace EndpointCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContextOptionsBuilder<DemoContext> options =
                new DbContextOptionsBuilder<DemoContext>();
            options.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BIMDemo2;Data Source=.");
            DemoContext context = new DemoContext(options.Options);

            //demoContext.Database.EnsureDeleted();
            //demoContext.Database.EnsureCreated();

            IAccountRepository repository = new AccountRepository(context);
           // IAccountFacade facade = new AccountFacade(repository);



            //Guid guid= facade.Transfer(1, 2, 4000);

            //Console.WriteLine(guid);

        }
    }
}
