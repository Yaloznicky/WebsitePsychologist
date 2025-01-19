using Microsoft.EntityFrameworkCore;

namespace WebsitePsychologist.Models
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Theme>? Themes { get; set; }
        public DbSet<Review>? Reviews { get; set; }
    }
}
