using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Models
{
    public class ModelContext : DbContext
    {

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Publication> Publications { get; set; }
    }
}
