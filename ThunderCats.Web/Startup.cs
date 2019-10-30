using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThunderCats.Web.Startup))]
namespace ThunderCats.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);






           //----------------------------------------------
        }
    }
}
