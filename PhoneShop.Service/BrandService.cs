using PhoneShop.Models;
using PhoneShop.Models.Interfaces.Services;
using PhoneShop.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneShop.Service
{
    public class BrandService : IBrandService
    {
        private static IRepository<Brand> _brandRepo;
        public BrandService(IRepository<Brand> brandRepo)
        {
            _brandRepo = brandRepo;
        }
        public Brand Create(string name) => Create(new Brand() { Name = name });

        public Brand Create(Brand brand)
        {
            if (brand.Id != 0)
                throw new ArgumentException();

            if (string.IsNullOrWhiteSpace(brand.Name))
                throw new ArgumentNullException();

            _brandRepo.Insert(brand);
            _brandRepo.SaveChanges();
            return brand;
        }

        public void Delete(int id)
        {
            Brand deleteBrand = _brandRepo.GetById(id);
            Delete(deleteBrand);
        }

        public void Delete(Brand brand)
        {
            _brandRepo.Remove(brand);
            _brandRepo.SaveChanges();
        }

        public Brand Get(int id)
        {
            if (!(id > 0))
                throw new ArgumentException();

            Brand resultBrand = _brandRepo.GetById(id);

            if (resultBrand == null)
                throw new KeyNotFoundException();

            return resultBrand;
        }

        public IQueryable<Brand> GetAll()
        {
            return _brandRepo.GetAll();
        }

        public Brand Update(int id, string name)
        {
            Brand updateBrand = Get(id);
            updateBrand.Name = name;

            return Update(updateBrand);
        }

        public Brand Update(Brand brand)
        {
            return _brandRepo.Update(brand);
        }
    }
}
