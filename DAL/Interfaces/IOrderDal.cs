using TradingCompany.DTO;
using System.Collections.Generic;


namespace DAL.Interfaces
{
    public interface IOrderDal
    {
        List<OrderDto> GetAllOrders();
        OrderDto CreateOrder(OrderDto order);
        OrderDto GetOrder(int id);
        void UpdateOrder(OrderDto order);
        void DeleteOrder(int id);
    }
}
