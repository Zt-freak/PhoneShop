using PhoneShop.Models;
using PhoneShop.Models.Interfaces.Services;
using PhoneShop.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneShop.Service
{
    public class ProductService : IProductService
    {
        private static IRepository<Product> _phoneRepo;
        public ProductService(IRepository<Product> phoneRepo)
        {
            _phoneRepo = phoneRepo;
        }

        public Product Create(string type, double price, string color, string description, int brandId) => Create(new Product() { Type = type, Price = price, Color = color, Description = description, BrandId = brandId });

        public Product Create(string type, double price, string color, string description, Brand brand) => Create(new Product() { Type = type, Price = price, Color = color, Description = description, BrandId = brand.Id });

        public Product Create(Product phone)
        {
            if (phone.Id != 0)
                throw new ArgumentException();

            if (string.IsNullOrWhiteSpace(phone.Description))
                throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(phone.Color))
                throw new ArgumentNullException();
            if (phone.BrandId == 0)
                throw new ArgumentException();

            _phoneRepo.Insert(phone);
            _phoneRepo.SaveChanges();
            return phone;
        }

        public Product Delete(int id)
        {
            Product deleteOrder = _phoneRepo.GetById(id);
            return Delete(deleteOrder);
        }

        public Product Delete(Product phone)
        {
            phone.Deleted = true;
            return Update(phone);
        }

        public Product Get(int id)
        {
            if (!(id > 0))
                throw new ArgumentException();

            Product resultPhone = _phoneRepo.GetById(id);

            if (resultPhone == null)
                throw new KeyNotFoundException();

            return resultPhone;
        }

        public IQueryable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product Undelete(int id)
        {
            Product undeleteOrder = _phoneRepo.GetById(id);
            return Undelete(undeleteOrder);
        }

        public Product Undelete(Product phone)
        {
            phone.Deleted = false;
            return Update(phone);
        }

        public Product Update(Product phone)
        {
            return _phoneRepo.Update(phone);
        }
    }
}
