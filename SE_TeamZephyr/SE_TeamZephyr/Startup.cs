using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SE_TeamZephyr.Startup))]
namespace SE_TeamZephyr
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
