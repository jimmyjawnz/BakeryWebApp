using BakeryWebApp.Models.Database;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BakeryWebApp.Models
{
    public class AddProductViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [Length(1, 128, ErrorMessage = "Name must be between 1 and 128 characters.")]
        public string Name { get; set; } = "Unnamed Product";

        [Required(ErrorMessage = "Price is required.")]
        [DataType(DataType.Currency)]
        [Range(0.0d, Double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public double Price { get; set; }

        [AllowNull]
        [MaxLength(128, ErrorMessage = "Description must be under 128 characters.")]
        public string? Description { get; set; }

        [DefaultValue(true)]
        public bool IsAvailable { get; set; } = true;

        [Required(ErrorMessage = "Group is required")]
        public int GroupId { get; set; }
        public Group ProductGroup { get; set; }
    }
}
