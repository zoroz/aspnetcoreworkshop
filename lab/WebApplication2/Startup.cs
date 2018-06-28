using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication2.Models;
using WebApplication2.Respository;

namespace WebApplication2
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddDbContext<BooksContext>(b=>b.UseSqlServer(_configuration.GetConnectionString("Default")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BooksContext context)
        {
            app.UseDeveloperExceptionPage();

            //app.UseMvc(b => { b.MapRoute("add", "add/3/{val}", new {Controller="home", Action="Add"}); });
            app.UseMvcWithDefaultRoute();

            context.Database.EnsureCreated();

            var items = context.Database.GetPendingMigrations();
            if(items.Count() > 0)
                context.Database.Migrate();
        }
    }
}
