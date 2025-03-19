using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace BakeryWebApp.Models
{
    public class EditProductModelView
    {
        public int ProductId { get; }

        [Required(ErrorMessage = "Product name is required.")]
        [Length(1, 128, ErrorMessage = "Product name must be between 1 and 128 characters.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product price is required.")]
        [DataType(DataType.Currency, ErrorMessage = "Product price is required.")]
        [Range(0.0d, Double.MaxValue, ErrorMessage = "Product price must be a positive value.")]
        public double ProductPrice { get; set; }

        [AllowNull]
        [MaxLength(255, ErrorMessage = "Product description must be under 255 characters.")]
        public string? ProductDescription { get; set; }

        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "Product group is required.")]
        [DeniedValues(0, ErrorMessage = "Please select a group.")]
        public int GroupId { get; set; }
        public Group? ProductGroup { get; set; }

        public string Slug
        {
            get
            {
                return "";
            }
        } 
    }
}
