using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Muebleria.Startup))]
namespace Muebleria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
