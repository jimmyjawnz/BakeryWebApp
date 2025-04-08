using BakeryWebApp.Models.Database;
using System.ComponentModel.DataAnnotations;

namespace BakeryWebApp.Models
{
    public class CategoryGroupDataModel
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public Group Group { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
