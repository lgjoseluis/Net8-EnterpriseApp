
using Pacagroup.Ecommerce.Transversal.Common;
using System.Net;
using System.Text.Json;

namespace Pacagroup.Ecommerce.Service.WebApi.Modules.GlobalException
{
    public class GlobalExceptionHandler : IMiddleware
    {
        private readonly IAppLogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(IAppLogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try 
            {
                await next(context);
            }
            catch(Exception ex) 
            { 
                string message = ex.Message;

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                _logger.LogError(message, ex);

                var response = new Response<Object>()
                {
                    Message = message
                };

                await JsonSerializer.SerializeAsync(context.Response.Body, response);
            }
        }
    }
}
