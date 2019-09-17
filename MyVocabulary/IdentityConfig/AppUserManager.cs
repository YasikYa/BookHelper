using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MyVocabulary.Models;

namespace MyVocabulary.IdentityConfig
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store) : base(store)
        {

        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            AppDbContext store = context.Get<AppDbContext>();
            AppUserManager userManager = new AppUserManager(new UserStore<AppUser>(store));

            return userManager;
        }
    }
}