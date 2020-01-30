using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Core
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IToDoService, ToDoService>();
            services.AddTransient<ILookupService, LookupService>();
        }
    }
}
