using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IBlood002.Startup))]
namespace IBlood002
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
