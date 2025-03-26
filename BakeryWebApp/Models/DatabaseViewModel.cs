using BakeryWebApp.Models.Database;

namespace BakeryWebApp.Models
{
    public class DatabaseViewModel
    {
        public List<Product> Products { get; set; } = [];
        public List<Category> Categories { get; set; } = [];
    }
}
