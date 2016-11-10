using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FirstIteration.Startup))]
namespace FirstIteration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
