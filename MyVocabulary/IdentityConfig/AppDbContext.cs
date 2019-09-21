using Microsoft.AspNet.Identity.EntityFramework;
using MyVocabulary.Models;
using System.Data.Entity;

namespace MyVocabulary.IdentityConfig
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext() : base("name=MyVocabularyConnection")
        {
            Database.SetInitializer(new AppContextInitializer());
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<File>().HasRequired(f => f.User).WithMany(u => u.Files).HasForeignKey(f => f.UserId);
            modelBuilder.Entity<File>().HasRequired(f => f.Extension).WithMany(e => e.Files).HasForeignKey(f => f.ExtensionId);

        }

        #region custom DbSets

        public DbSet<File> Files { get; set; }

        public DbSet<Extension> Extensions { get; set; }

        #endregion
    }

    public class AppContextInitializer : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            Extension ext = new Extension { ExtensionString = ".pdf" };
            context.Extensions.Add(ext);
            base.Seed(context);
        }
    }
}