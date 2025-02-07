using System.ComponentModel.DataAnnotations;

namespace VideoShopRentalMVC1.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Genre { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public double Price { get; set; }
        public string? ThumbnailUrl { get; set; }

    }
}
