using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCaNhan.Startup))]
namespace WebCaNhan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
