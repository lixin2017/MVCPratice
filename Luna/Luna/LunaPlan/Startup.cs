using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Luna.Startup))]
namespace Luna
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
