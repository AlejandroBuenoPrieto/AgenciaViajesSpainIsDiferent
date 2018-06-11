using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgenciaViajesSpainIsDiferent.Startup))]
namespace AgenciaViajesSpainIsDiferent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
