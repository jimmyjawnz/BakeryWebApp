using System.ComponentModel.DataAnnotations;

namespace BakeryWebApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

    }
}
