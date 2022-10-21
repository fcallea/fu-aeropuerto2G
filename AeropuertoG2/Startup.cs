using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AeropuertoG2.Startup))]
namespace AeropuertoG2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
