using System.Linq;

namespace PhoneShop.Models.Interfaces.Services
{
    public interface IBrandService
    {
        public Brand Create(string name);
        public Brand Create(Brand brand);
        public Brand Get(int id);
        public IQueryable<Brand> GetAll();
        public Brand Update(int id, string name);
        public Brand Update(Brand brand);
        public void Delete(int id);
        public void Delete(Brand brand);
    }
}
