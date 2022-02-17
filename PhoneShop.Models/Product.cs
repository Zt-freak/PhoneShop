using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneShop.Models
{
    public class Product : Entity
    {
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Color is required")]
        public string Color { get; set; }
        public string Camera { get; set; }
        public string Processor { get; set; }
        public string ScreenResolution { get; set; }
        public double Discount { get; set; }
        public int DiscountType { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public bool Deleted { get; set; } = false;
        [Url]
        public string Image { get; set; }

        [Required(ErrorMessage = "Brand is required")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
