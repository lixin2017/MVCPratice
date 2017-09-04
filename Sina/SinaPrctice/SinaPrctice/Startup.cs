using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SinaPrctice.Startup))]
namespace SinaPrctice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
