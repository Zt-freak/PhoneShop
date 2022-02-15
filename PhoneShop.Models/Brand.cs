using System.ComponentModel.DataAnnotations;

namespace PhoneShop.Models
{
    public class Brand : Entity
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
