using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SinaNews.Startup))]
namespace SinaNews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
