using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusTicket.Web.Startup))]
namespace BusTicket.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
