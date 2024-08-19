using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
    
namespace TertuliatalkAPI.Middlewares;
public class GlobalLogger
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalLogger> _logger;
    
    public GlobalLogger(RequestDelegate next, ILogger<GlobalLogger> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("$Handling request: {requestMethod} {requestPath} [{date}]", 
            context.Request.Method, context.Request.Path, DateTime.UtcNow);
        await _next(context);
    }
}
