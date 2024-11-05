using Hydra.WebApi.Errors;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Hydra.WebApi.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next, ILogger<Exception> logger, IHostEnvironment env)
    {
        public async Task Invoke(HttpContext context)
        {
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				logger.LogError(ex, ex.Message);
				context.Response.ContentType = "application/json";
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

				var responce = env.IsDevelopment()
					? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace)
					: new ApiException(context.Response.StatusCode, ex.Message, "Internal server error");

				var options = new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				};
				var json = JsonSerializer.Serialize(responce, options);

				await context.Response.WriteAsync(json);
            }
        }
    }
}
