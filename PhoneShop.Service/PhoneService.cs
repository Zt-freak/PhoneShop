using PhoneShop.Models;
using PhoneShop.Models.Interfaces.Services;
using PhoneShop.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneShop.Service
{
    public class PhoneService : IPhoneService
    {
        private static IRepository<Phone> _phoneRepo;
        public PhoneService(IRepository<Phone> phoneRepo)
        {
            _phoneRepo = phoneRepo;
        }

        public Phone Create(string type, double price, string color, string description, int brandId) => Create(new Phone() { Type = type, Price = price, Color = color, Description = description, BrandId = brandId });

        public Phone Create(string type, double price, string color, string description, Brand brand) => Create(new Phone() { Type = type, Price = price, Color = color, Description = description, BrandId = brand.Id });

        public Phone Create(Phone phone)
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

        public Phone Delete(int id)
        {
            Phone deleteOrder = _phoneRepo.GetById(id);
            return Delete(deleteOrder);
        }

        public Phone Delete(Phone phone)
        {
            phone.Deleted = true;
            return Update(phone);
        }

        public Phone Get(int id)
        {
            if (!(id > 0))
                throw new ArgumentException();

            Phone resultPhone = _phoneRepo.GetById(id);

            if (resultPhone == null)
                throw new KeyNotFoundException();

            return resultPhone;
        }

        public IQueryable<Phone> GetAll()
        {
            throw new NotImplementedException();
        }

        public Phone Undelete(int id)
        {
            Phone undeleteOrder = _phoneRepo.GetById(id);
            return Undelete(undeleteOrder);
        }

        public Phone Undelete(Phone phone)
        {
            phone.Deleted = false;
            return Update(phone);
        }

        public Phone Update(Phone phone)
        {
            return _phoneRepo.Update(phone);
        }
    }
}
