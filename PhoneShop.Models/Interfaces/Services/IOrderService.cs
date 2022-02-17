using System.Linq;

namespace PhoneShop.Models.Interfaces.Services
{
    public interface IOrderService
    {
        public Order Create(int customerId);
        public Order Create(int customerId, double vatPercentage);
        public Order Create(Order order);
        public Order Get(int id);
        public IQueryable<Order> GetAll();
        public Order Update(Order order);
        public Order Delete(int id, int reason);
        public Order Delete(Order order);
        public Order Undelete(int id);
        public Order Undelete(Order order);
    }
}
