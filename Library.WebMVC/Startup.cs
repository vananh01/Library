using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Library.WebMVC.Startup))]
namespace Library.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
