using System.ComponentModel.DataAnnotations;

namespace BakeryWebApp.Models.Database
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string CustomerPhoneNumber { get; set; } = string.Empty;
    }
}
