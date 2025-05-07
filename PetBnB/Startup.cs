using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetBnB.Startup))]
namespace PetBnB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
