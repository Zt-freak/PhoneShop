using System.ComponentModel.DataAnnotations;

namespace PhoneShop.Models
{
    public class Employee : User
    {
        public double Salary { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
