using System.Linq;

namespace PhoneShop.Models.Interfaces.Services
{
    public interface IDepartmentService
    {
        public Department Create(string name);
        public Department Create(Department department);
        public Department Get(int id);
        public IQueryable<Department> GetAll();
        public Department Update(int id, string name);
        public Department Update(Department department);
        public void Delete(int id);
        public void Delete(Department department);
    }
}
