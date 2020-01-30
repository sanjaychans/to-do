using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Models;

namespace ToDo.DAL
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services
                .AddDbContext<ToDoDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IRepository<ToDoItem>, EntityRepository<ToDoItem>>();
            services.AddScoped<IRepository<LookupItem>, EntityRepository<LookupItem>>();

        }
    }
}
