using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneShop.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
        public DateTime UpdateDateTime { get; set; } = DateTime.Now;
    }
}
