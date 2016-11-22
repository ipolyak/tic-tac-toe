using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TicTacToeServer.Startup))]
namespace TicTacToeServer
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
