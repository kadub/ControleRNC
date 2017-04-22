using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ControleRNC_WEB.Startup))]
namespace ControleRNC_WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
