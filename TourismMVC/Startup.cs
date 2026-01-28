using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TourismMVC.Startup))]
namespace TourismMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
