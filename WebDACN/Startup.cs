using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebDACN.Startup))]
namespace WebDACN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
