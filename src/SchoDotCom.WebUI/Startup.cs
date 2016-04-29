using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoDotCom.WebUI.Startup))]
namespace SchoDotCom.WebUI
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
			Seed(app);
		}
	}
}
