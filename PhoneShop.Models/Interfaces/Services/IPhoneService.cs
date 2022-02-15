using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShop.Models.Interfaces.Services
{
    public interface IPhoneService
    {
        public Phone Create(string type, double price, string color, string description, int brandId);
        public Phone Create(string type, double price, string color, string description, Brand brand);
        public Phone Create(Phone phone);
        public Phone Get(int id);
        public IQueryable<Phone> GetAll();
        public Phone Update(Phone phone);
        public Phone Delete(int id);
        public Phone Delete(Phone phone);
        public Phone Undelete(int id);
        public Phone Undelete(Phone phone);
    }
}
