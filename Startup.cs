using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MISTeam8.Startup))]
namespace MISTeam8
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
