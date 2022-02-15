using PhoneShop.Models;
using PhoneShop.Models.Interfaces.Services;
using PhoneShop.Repository.Interfaces;
using System;
using System.Linq;

namespace PhoneShop.Service
{
    public class Service<TEntity> : IService<TEntity> where TEntity : Entity
    {
        private static IRepository<TEntity> _entityRepo;

        public Service(IRepository<TEntity> entityRepo)
        {
            _entityRepo = entityRepo;
        }

        public TEntity Create(TEntity entity)
        {
            if (entity.Id != 0)
                throw new ArgumentException();

            _entityRepo.Insert(entity);
            _entityRepo.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public TEntity Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public TEntity Update(Brand brand)
        {
            throw new System.NotImplementedException();
        }
    }
}
