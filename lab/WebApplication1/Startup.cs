using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(c => c.AddDebug());
            services.AddTransient<IMyFirstService, MyFirstService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMyFirstService myService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseFancyMiddleware();
            app.Map("/map1", b => { b.Run(c => c.Response.WriteAsync("first map1")); });

            app.Map("/myservice", b2 =>
            {
                b2.Run(async c =>
{
var t = await myService.DoWork();
await c.Response.WriteAsync($"Hello from service with {t}");
});
            });

            app.MapWhen(c => { return c.Request.Path.StartsWithSegments("/sample4") && c.Request.Method == "POST"; },
                b => { b.Run(c => { return c.Response.WriteAsync($"User entered:{c.Request.Form["text1"]}"); }); });

            app.MapWhen(c => { return c.Request.Path.StartsWithSegments("/form") && c.Request.Method == "GET"; },
                b1 =>
                {
                    b1.Run(c => { return c.Response.WriteAsync(File.ReadAllText("wwwroot/htmlpage.html")); });
                });

            app.Run(async (context) =>
                {
                    context.Request.Query.TryGetValue("x", out StringValues val);
                    var v = val == StringValues.Empty ? null : HtmlEncoder.Default.Encode(val);
                    await context.Response.WriteAsync($"Hello World! {v}");
                });
        }
    }
}
