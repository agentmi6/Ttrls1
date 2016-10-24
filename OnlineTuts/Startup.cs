using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineTuts.Startup))]
namespace OnlineTuts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
