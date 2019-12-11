using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proyectofinalweb.Startup))]
namespace proyectofinalweb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
