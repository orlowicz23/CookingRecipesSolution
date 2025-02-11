using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CookingRecipes.Web.Middleware
{
    public class Log
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

     public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
{
    _next = next;
    _logger = logger;
}

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context);

            stopwatch.Stop();
            var elapsedMs = stopwatch.ElapsedMilliseconds;
            _logger.LogInformation(
                $"[{context.Request.Method}] {context.Request.Path} took {elapsedMs} ms.");
        }
    }
}
