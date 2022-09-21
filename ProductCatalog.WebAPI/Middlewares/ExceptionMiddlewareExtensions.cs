using Microsoft.AspNetCore.Builder;

namespace ProductCatalog.WebAPI.Middlewares
{
    //Farklı farklı middleware yapıları eklenirse sisteme direk buradan eklensin diye oluşturuldu.
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }

}
