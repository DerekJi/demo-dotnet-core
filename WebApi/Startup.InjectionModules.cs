using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi
{
    public partial class Startup
    {
        public partial class Startup
        {
            public void InejctInfrastructures(IServiceCollection services)
            {
                //services.AddTransient<ILogActionFilter, NLogActionFilter>();

                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                services.AddScoped<IBaseService, BaseService>();

                this.InjectDbContext(services);

                services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

                services.AddTransient<IProductsService, ProductsService>();

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="services"></param>
            protected void InjectDbContext(IServiceCollection services)
            {
                var connectionString = this.Configuration.GetConnectionString("Default");
                services.AddDbContext<MssqlDbContext>(options => options.UseSqlServer(connectionString));
                services.AddDbContext<DbContext>(options => options.UseSqlServer(connectionString));
            }
        }
    }
}
