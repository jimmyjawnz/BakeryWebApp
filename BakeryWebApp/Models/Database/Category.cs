using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BakeryWebApp.Models.Database
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [Length(1, 128, ErrorMessage = "Category name must be between 1 and 128 characters.")]
        public string CategoryName { get; set; } = "Unnamed Category";

        public ICollection<Group> Groups { get; set; }
    }
}
