using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OgnreciNotMVC.Startup))]
namespace OgnreciNotMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
