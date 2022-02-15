using System.Linq;

namespace PhoneShop.Models.Interfaces.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        public TEntity Create(TEntity entity);
        public TEntity Get(int id);
        public IQueryable<TEntity> GetAll();
        public TEntity Update(Brand brand);
        public void Delete(int id);
        public void Delete(TEntity entity);
    }
}
