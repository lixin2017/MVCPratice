using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Practice.Web.Startup))]
namespace Practice.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
