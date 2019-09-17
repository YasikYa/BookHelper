using Owin;
using MyVocabulary.IdentityConfig;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;

namespace MyVocabulary
{
    public class IdentityStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<AppDbContext>(AppDbContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Accaunt/Login")
            });
        }
    }
}