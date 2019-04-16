using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseDemo.Graph;
using DataBaseDemo.Graph.Filter;
using DataBaseDemo.Graph.InputTypes;
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

            services.AddScoped<IDependencyResolver>
                (s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddScoped<InventoryContext>();
            services.AddScoped<ItemType>();
            services.AddScoped<ItemInputType>();

            services.AddScoped<OrderType>();
            services.AddScoped<CustomerType>();
            services.AddScoped<CustomerInput>();
            services.AddScoped<CustomerQueryFilter>();
            services.AddScoped<OrderInput>();
            services.AddScoped<OrderItemInput>();


            services.AddScoped<OrderItemType>();

            services.AddScoped<InventoryQuery>();
            services.AddScoped<InventoryMutation>();
            services.AddScoped<InventorySchema>();
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
