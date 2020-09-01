using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUD_CF.Startup))]
namespace CRUD_CF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
