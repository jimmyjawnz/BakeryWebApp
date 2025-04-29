using BakeryWebApp.Models.Database;
using System.ComponentModel.DataAnnotations;

namespace BakeryWebApp.Models
{
    public class FrontTillViewModel
    {
        public List<Product> AvailableProducts { get; set; } = [];

        public List<Product> CustomerCart { get; set; } = [];

        public List<Product> AvailableOrders { get; set; } = [];

        public double CartTotal { get; set; }


        public string CustomerName { get; set; } = string.Empty;
        [Phone]
        public string CustomerPhoneNumber { get; set; } = string.Empty;
        


    }
}
