using PhoneShop.Models;
using PhoneShop.Models.Interfaces.Services;
using PhoneShop.Repository.Interfaces;
using System;
using System.Linq;

namespace PhoneShop.Service
{
    public class DepartmentService : IDepartmentService
    {
        private static IRepository<Department> _departmentRepo;
        public DepartmentService(IRepository<Department> departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        public Department Create(string name) => Create(new Department() { Name = name });

        public Department Create(Department department)
        {
            if (department.Id != 0)
                throw new ArgumentException();

            if (string.IsNullOrWhiteSpace(department.Name))
                throw new ArgumentNullException();

            _departmentRepo.Insert(department);
            _departmentRepo.SaveChanges();
            return department;
        }

        public void Delete(int id)
        {
            Department deleteBrand = _departmentRepo.GetById(id);
            Delete(deleteBrand);
        }

        public void Delete(Department department)
        {
            _departmentRepo.Remove(department);
            _departmentRepo.SaveChanges();
        }

        public Department Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public Department Update(int id, string name)
        {
            throw new NotImplementedException();
        }

        public Department Update(Department brand)
        {
            throw new NotImplementedException();
        }
    }
}
