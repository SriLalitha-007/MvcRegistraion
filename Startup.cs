using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcRegistraion.Models;
using MvcRegistraion.Services;


namespace MvcRegistraion
{
    public class Startup
    {
        public void ConfigureRoutes(IApplicationBuilder app)
        {
            // ...


            app.UseEndpoints(endpoints =>
            {
                // /{id?}
                endpoints.MapControllerRoute(
                    name: "Home",
                    pattern: "home",
                    defaults: new { controller = "Home", action = "Home" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "",
                    defaults: new { controller = "Registration", action = "Index" });
            });

        }
    }
}