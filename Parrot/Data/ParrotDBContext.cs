
using Microsoft.EntityFrameworkCore;
using Parrot.Data.Maps;
using Parrot.Model;

namespace Parrot.Data
{
    public class ParrotDBContext: DbContext
    {
        public ParrotDBContext(DbContextOptions<ParrotDBContext> options): base(options) {}

        public DbSet<UserModel> Users { get; set; }
        public DbSet<PostModel> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
