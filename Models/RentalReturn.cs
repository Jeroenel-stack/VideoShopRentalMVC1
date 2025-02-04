using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VideoShopRentalMVC1.Models
{
    public class RentalReturn
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RentalId { get; set; }
        public virtual Rental Rental { get; set; }  // Navigation to Rental

        [Required]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }  // Direct link to Customer

        [Required]
        public DateTime ReturnDate { get; set; }    // Date of return

        public decimal LateFee { get; set; }        // Late fee if applicable

        // For tracking specific movies returned (supports partial returns)
        public virtual ICollection<RentalDetail> ReturnedDetails { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
