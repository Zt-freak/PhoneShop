using PhoneShop.Models;
using PhoneShop.Models.Interfaces.Services;
using PhoneShop.Repository.Interfaces;
using System;
using System.Collections.Generic;
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
            Department deleteDepartment = _departmentRepo.GetById(id);
            Delete(deleteDepartment);
        }

        public void Delete(Department department)
        {
            _departmentRepo.Remove(department);
            _departmentRepo.SaveChanges();
        }

        public Department Get(int id)
        {
            if (!(id > 0))
                throw new ArgumentException();

            Department resultDepartment = _departmentRepo.GetById(id);

            if (resultDepartment == null)
                throw new KeyNotFoundException();

            return resultDepartment;
        }

        public IQueryable<Department> GetAll()
        {
            return _departmentRepo.GetAll();
        }

        public Department Update(int id, string name)
        {
            Department updateDepartment = Get(id);
            updateDepartment.Name = name;

            return Update(updateDepartment);
        }

        public Department Update(Department brand)
        {
            return _departmentRepo.Update(brand);
        }
    }
}
