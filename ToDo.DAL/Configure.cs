using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Models;

namespace ToDo.DAL
{
    /// <summary>
    /// Service configuration for the DAL layer
    /// </summary>
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            //configure dbcontext with the connection string
            services
                .AddDbContext<ToDoDbContext>(options => options.UseSqlServer(connectionString));

            //configure the DI container for repository classes
            services.AddScoped<IRepository<ToDoItem>, EntityRepository<ToDoItem>>();
            services.AddScoped<IRepository<LookupItem>, EntityRepository<LookupItem>>();

        }
    }
}
