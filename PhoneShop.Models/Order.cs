using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShop.Models
{
    public class Order : Entity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Total price is required")]
        public double TotalPrice { get; set; }

        [Required(ErrorMessage = "VAT percentage is required")]
        public double VatPercentage { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Deleted { get; set; } = false;
        public int Reason { get; set; }
    }
}
