using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApiColegio.Startup))]
namespace ApiColegio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
