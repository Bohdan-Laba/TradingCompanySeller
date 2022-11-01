using AutoMapper;
using DAL.Interfaces;
using TradingCompany.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DAL.Concrete
{
    public class OrderDal : IOrderDal
    {
        private readonly IMapper _mapper;

        public OrderDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public OrderDto CreateOrder(OrderDto order)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var orderInDB = _mapper.Map<Order>(order);
                orderInDB.RowInsertTime = DateTime.UtcNow;
                entities.Orders.Add(orderInDB);
                entities.SaveChanges();
                return _mapper.Map<OrderDto>(orderInDB);
            }
        }

        public void DeleteOrder(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var orderf = entities.Orders.SingleOrDefault(obj => obj.OrderID == id);
                if (orderf != null)
                {
                    entities.Orders.Remove(orderf);
                    entities.SaveChanges();
                }
            }
        }

        public List<OrderDto> GetAllOrders()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var orders = entities.Orders.ToList();
                return _mapper.Map<List<OrderDto>>(orders);
            }
        }

        public OrderDto GetOrder(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var order = entities.Orders.SingleOrDefault(obj => obj.OrderID == id);
                return _mapper.Map<OrderDto>(order);
            }
        }

        public void UpdateOrder(OrderDto order)
        {

            using (var entities = new TradingCompanyEntities())
            {
                var orderf = entities.Orders.SingleOrDefault(obj => obj.OrderID == order.OrderID);
                if (orderf != null)
                {
                    orderf.StatusID = order.StatusID;
                    orderf.TotalPrice = order.TotalPrice;
                    orderf.RowInsertTime = DateTime.UtcNow;
                    entities.SaveChanges();
                }
            }
        }
    }
}
