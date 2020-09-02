using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoreAsp.Startup))]
namespace StoreAsp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
