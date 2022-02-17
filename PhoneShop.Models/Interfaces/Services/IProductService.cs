using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShop.Models.Interfaces.Services
{
    public interface IProductService
    {
        public Product Create(string type, double price, string color, string description, int brandId);
        public Product Create(string type, double price, string color, string description, Brand brand);
        public Product Create(Product phone);
        public Product Get(int id);
        public IQueryable<Product> GetAll();
        public Product Update(Product phone);
        public Product Delete(int id);
        public Product Delete(Product phone);
        public Product Undelete(int id);
        public Product Undelete(Product phone);
    }
}
