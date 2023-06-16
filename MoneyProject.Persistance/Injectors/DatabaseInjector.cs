using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyProject.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyProject.Persistance.Injectors
{
    public static class DatabaseInjector
    {
        public static void AddPostgresSql(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<MContext>(options => options.UseNpgsql(config.GetConnectionString("Local")));
        }
    }
}
