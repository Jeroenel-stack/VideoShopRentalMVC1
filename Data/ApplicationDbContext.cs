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
        public DbSet<VideoShopRentalMVC1.Models.Rental> Rental { get; set; } = default!;
        public DbSet<VideoShopRentalMVC1.Models.RentalDetail> RentalDetail { get; set; } = default!;
        public DbSet<VideoShopRentalMVC1.Models.RentalReturn> RentalReturn { get; set; } = default!;
    }
}
