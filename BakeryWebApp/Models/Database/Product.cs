using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;

namespace BakeryWebApp.Models.Database
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [Length(1, 128, ErrorMessage = "Product name must be between 1 and 128 characters.")]
        public string ProductName { get; set; } = "Unnamed Product";

        [Required(ErrorMessage = "Product price is required.")]
        [DataType(DataType.Currency, ErrorMessage = "Product price is required.")]
        [Range(0.0d, double.MaxValue, ErrorMessage = "Product price must be a positive value.")]
        [DefaultValue(0.00d)]
        public double ProductPrice { get; set; } = 0.00d;

        [AllowNull]
        [MaxLength(255, ErrorMessage = "Product description must be under 255 characters.")]
        public string? ProductDescription { get; set; }

        [DefaultValue(true)]
        public bool IsAvailable { get; set; } = true;

        [Required(ErrorMessage = "Product group is required.")]
        [DeniedValues(0, ErrorMessage = "Please select a group.")]
        public int GroupId { get; set; }
        public Group? ProductGroup { get; set; }

        public string Slug
        {
            get
            {
                if (ProductName.IsNullOrEmpty()) { return "nan"; }
                return ProductName.ToLower().Replace(" ", "") + "-" + ProductId.ToString();
            }
        }

        public string GroupSlug
        {
            get
            {
                if (ProductGroup is null) { return "nan"; }
                return ProductGroup.GroupName + " " + ProductGroup.GroupCategory.CategoryName;
            }
        }
    }
}
