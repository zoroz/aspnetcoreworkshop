using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebApplication1
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class FancyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<FancyMiddleware> _log;

        public FancyMiddleware(RequestDelegate next, ILogger<FancyMiddleware> log)
        {
            _next = next;
            _log = log;
        }

        public Task Invoke(HttpContext httpContext)
        {
            _log.LogInformation($"Request query:{httpContext.Request.QueryString}");
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class FancyMiddlewareExtensions
    {
        public static IApplicationBuilder UseFancyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FancyMiddleware>();
        }
    }
}
