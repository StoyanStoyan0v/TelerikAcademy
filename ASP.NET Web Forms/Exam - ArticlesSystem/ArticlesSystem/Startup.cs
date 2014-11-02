using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArticlesSystem.Startup))]
namespace ArticlesSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
