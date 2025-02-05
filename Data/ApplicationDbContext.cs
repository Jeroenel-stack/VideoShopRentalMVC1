using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideoShopRentalMVC1.Models;

namespace VideoShopRentalMVC1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<VideoShopRentalMVC1.Models.Customer> Customer { get; set; } = default!;
        public DbSet<VideoShopRentalMVC1.Models.Movie> Movie { get; set; } = default!;
        public DbSet<VideoShopRentalMVC1.Models.RentalHeader> Rental { get; set; } = default!;
        public DbSet<VideoShopRentalMVC1.Models.RentalDetail> RentalDetail { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole
                    { Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole
                    { Name = "User", NormalizedName = "USER" },
                    new IdentityRole
                    { Name = "Guest", NormalizedName = "GUEST" },
                    new IdentityRole
                    { Name = "Moderator", NormalizedName = "MODERATOR" });
        }
    }
}
