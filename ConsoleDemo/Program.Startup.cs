using ConsoleDemo.Enumerable;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace ConsoleDemo
{
    partial class Program
    {
        private static readonly string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=True;";
        private static readonly LoggerFactory LocalLoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });
        private static IProductService productService;

        static void Main(string[] args)
        {
            Startup();

            CombineTests();
        }

        private static void Startup()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<NorthwindContext>(options => options
                                .UseSqlServer(connectionString)
                                .UseLoggerFactory(LocalLoggerFactory)
                            )
                .AddTransient<IProductService, ProductService>()
                .BuildServiceProvider();

            productService = serviceProvider.GetService<IProductService>();
        }
    }
}
