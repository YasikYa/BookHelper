using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyVocabulary.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Files = new List<File>();
        }

        public virtual ICollection<File> Files { get; set; }
    }
}