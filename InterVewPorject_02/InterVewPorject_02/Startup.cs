using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InterVewPorject_02.Startup))]
namespace InterVewPorject_02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
