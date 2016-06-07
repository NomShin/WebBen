using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hakuturu.Startup))]
namespace Hakuturu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
