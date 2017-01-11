using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fantastyka2.Startup))]
namespace Fantastyka2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
