using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseDemo.Graph;
using DataBaseDemo.Graph.Query;
using DataBaseDemo.Graph.Types;
using DataBaseDemo.Services;
using GraphiQl;
using GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DataBaseDemo.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public const string GraphQlPath = "/graphql";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IDependencyResolver>
                (s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddSingleton<InventoryContext>();
            services.AddSingleton<ItemType>();
            //services.AddSingleton<ItemInputType>();

            services.AddSingleton<OrderType>();
            services.AddSingleton<CustomerType>();

            services.AddSingleton<OrderItemType>();

            services.AddSingleton<InventoryQuery>();
            //services.AddSingleton<InventoryMutation>();
            services.AddSingleton<InventorySchema>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphiQl(GraphQlPath);

            app.UseMvc();
        }
    }
}
