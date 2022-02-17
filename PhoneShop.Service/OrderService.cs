using PhoneShop.Models;
using PhoneShop.Models.Interfaces.Services;
using PhoneShop.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneShop.Service
{
    public class OrderService : IOrderService
    {
        private static IRepository<Order> _orderRepo;
        public OrderService(IRepository<Order> orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public Order Create(int customerId) => Create(customerId, 0);

        public Order Create(int customerId, double vatPercentage) => Create(new Order() { CustomerId = customerId, VatPercentage = vatPercentage });

        public Order Create(Order order)
        {
            if (order.Id != 0)
                throw new ArgumentException();

            _orderRepo.Insert(order);
            _orderRepo.SaveChanges();
            return order;
        }

        public Order Delete(int id, int reason)
        {
            Order deleteOrder = _orderRepo.GetById(id);
            deleteOrder.Reason = reason;
            return Delete(deleteOrder);
        }

        public Order Delete(Order order)
        {
            order.Deleted = true;
            return Update(order);
        }

        public Order Get(int id)
        {
            if (!(id > 0))
                throw new ArgumentException();

            Order resultOrder = _orderRepo.GetById(id);

            if (resultOrder == null)
                throw new KeyNotFoundException();

            return resultOrder;
        }

        public IQueryable<Order> GetAll()
        {
            return _orderRepo.GetAll();
        }

        public Order Undelete(int id)
        {
            Order undeleteOrder = _orderRepo.GetById(id);
            undeleteOrder.Reason = 0;
            return Undelete(undeleteOrder);
        }

        public Order Undelete(Order order)
        {
            order.Deleted = false;
            return Update(order);
        }

        public Order Update(Order order)
        {
            return _orderRepo.Update(order);
        }
    }
}
