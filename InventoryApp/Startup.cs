using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin;
using Microsoft.Owin.Builder;
using Owin;

[assembly: OwinStartup(typeof(InventoryApp.Startup))]

namespace InventoryApp
{
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      // Configure Web API for self-host. 
      HttpConfiguration config = new HttpConfiguration();
      config.EnableCors(new EnableCorsAttribute("http://localhost:4200", headers: "*", methods: "*"));
      config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
      SwaggerConfig.Register(config);
      app.UseWebApi(config);
    }
  }
}
