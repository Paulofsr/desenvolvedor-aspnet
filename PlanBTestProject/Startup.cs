using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlanBTestProject.Startup))]
namespace PlanBTestProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
