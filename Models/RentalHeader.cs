using System.ComponentModel.DataAnnotations;

namespace VideoShopRentalMVC1.Models
{
    public partial class RentalHeader
    {
       
        
            [Key]
            public int Id { get; set; }
            [Required]
            public string? CustomerId { get; set; }
            [Required]
            public string? Customers { get; set; }
            [Required]
            public DateOnly RentedDate { get; set; }
            [Required]
            public DateOnly ReturnDate { get; set; }

            public ICollection<RentalDetail>? RentalDetails { get; set; }
        
    }
}
