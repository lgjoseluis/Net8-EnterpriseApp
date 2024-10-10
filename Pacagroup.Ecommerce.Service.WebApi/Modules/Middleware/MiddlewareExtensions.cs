using Pacagroup.Ecommerce.Service.WebApi.Modules.GlobalException;

namespace Pacagroup.Ecommerce.Service.WebApi.Modules.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
