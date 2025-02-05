using System.ComponentModel.DataAnnotations;

namespace VideoShopRentalMVC1.Models
{
   
        public class RentalDetail
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public int? RentalHeaderId { get; set; }
            [Required]
            public int MovieId { get; set; }
            [Required]
            public string? Movies { get; set; }
            [Required]
            public double Price { get; set; }

            public ICollection<RentalHeader>? RentalHeader { get; set; }


        }
    
}
