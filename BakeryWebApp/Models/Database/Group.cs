using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BakeryWebApp.Models.Database
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        [Required(ErrorMessage = "Group name is required.")]
        [Length(1, 128, ErrorMessage = "Group name must be between 1 and 128 characters.")]
        public string GroupName { get; set; } = "Unnamed Group";

        public ICollection<Product> Products { get; set; }

        public int CategoryId { get; set; }
        public Category GroupCategory { get; set; }

    }
}
