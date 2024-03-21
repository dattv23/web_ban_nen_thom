using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebTiemThom.Startup))]
namespace WebTiemThom
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
