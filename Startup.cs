using Demo.IService;
using Demo.Models;
using Demo.Service;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IEmployee, EmployeeService>();
            services.AddScoped<Query>();
            //(p => SchemaBuilder.New().AddServices(p).
            //AddType<EmployeeType>().
            //AddQueryType<Query>().
            //Create()
            //)
            services.AddGraphQLServer().AddQueryType<Query>().AddType<EmployeeType>();
            //services.AddMvc(options =>
            //{
            //    options.EnableEndpointRouting = false;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UsePlayground(new PlaygroundOptions()
            {
                Path = "/playground",
                QueryPath = "/api"
            });
            app.UseGraphQL("/api");
            app.UseRouting();
            //app.UseMvc(o =>
            //{
            //    o.MapRoute("defaults", "{controller=Home}/{action=Index}");
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
