using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;

namespace BakeryWebApp.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [Length(1, 128, ErrorMessage = "Product name must be between 1 and 128 characters.")]
        public string ProductName { get; set; } = "Unnamed Product";

        [Required(ErrorMessage = "Product price is required.")]
        [DataType(DataType.Currency)]
        [Range(0.0d, Double.MaxValue, ErrorMessage = "Product price must be a positive value.")]
        public double ProductPrice { get; set; }

        [AllowNull]
        [MaxLength(128, ErrorMessage = "Product description must be under 128 characters.")]
        public string? ProductDescription { get; set; }

        [DefaultValue(false)]
        public bool IsAvailable { get; set; } = false;

        public int GroupId { get; set; }
        [Required(ErrorMessage = "Product group is required.")]
        public Group ProductGroup { get; set; }
    }
}
