using HRMS.Api.ResponseWrapper;
using System.Net;
using System.Text.Json;

namespace HRMS.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IWebHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IWebHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

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

                var response = env.IsDevelopment() ?
                    new ApiError((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace) :
                    new ApiError((int)HttpStatusCode.InternalServerError);

               var json = JsonSerializer.Serialize(response);

                await context.Response.WriteAsJsonAsync(json);
            }
        }
    }
}
