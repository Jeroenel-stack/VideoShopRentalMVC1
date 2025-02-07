using System.ComponentModel.DataAnnotations;

namespace VideoShopRentalMVC1.Models
{
   
        public class RentalDetail
        {
        [Key]
        public int Id { get; set; }

        
        [Required]
        public int RentalHeaderId { get; set; }
        public RentalHeader? RentalHeader { get; set; }  

      
        [Required]
        public int MovieId { get; set; }
        public Movie? Movie { get; set; } 

        [Required]
        public double Price { get; set; }


    }
    
}
