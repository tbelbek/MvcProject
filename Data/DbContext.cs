using Microsoft.AspNet.Identity.EntityFramework;
using Data.Entity;
using System.Data.Entity;

namespace Data
{
    public class DbContext : IdentityDbContext<User>
    {
        public DbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Stuff> Stuffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}