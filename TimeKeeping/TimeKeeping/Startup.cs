using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimeKeeping.Startup))]
namespace TimeKeeping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
