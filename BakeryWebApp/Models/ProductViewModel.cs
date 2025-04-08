using BakeryWebApp.Models.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace BakeryWebApp.Models
{
    public class ProductViewModel
    {
        public List<Product> ProductList { get; set; } = [];
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [Length(1, 35, ErrorMessage = "Product name must be between 1 and 35 characters.")]
        public string ProductName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Product price is required.")]
        [DataType(DataType.Currency, ErrorMessage = "Product price is required.")]
        [Range(0.0d, double.MaxValue, ErrorMessage = "Product price must be a positive value.")]
        public double ProductPrice { get; set; }

        [AllowNull]
        [MaxLength(35, ErrorMessage = "Product description must be under 35 characters.")]
        public string? ProductDescription { get; set; }

        [DefaultValue(true)]
        public bool IsAvailable { get; set; } = true;

        [Required(ErrorMessage = "Product group is required.")]
        [DeniedValues(0, ErrorMessage = "Please select a group.")]
        public int GroupId { get; set; }
    }
}
