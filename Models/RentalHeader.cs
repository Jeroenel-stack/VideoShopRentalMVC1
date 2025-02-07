using System.ComponentModel.DataAnnotations;

namespace VideoShopRentalMVC1.Models
{
    public partial class RentalHeader
    {


        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer? CustomerDetails { get; set; }  

        [Required]
        public DateTime RentedDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }

        public ICollection<RentalDetail>? RentalDetails { get; set; }

    }
}
