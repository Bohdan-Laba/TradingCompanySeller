using TradingCompany.DTO;
using System.Collections.Generic;


namespace DAL.Interfaces
{
    public interface IItemDal
    {
        List<ItemDto> GetAllItems();
        ItemDto CreateItem(ItemDto Item);   
        ItemDto GetItem(int id);
        void UpdateItem(ItemDto Item);
        void DeleteItem(int id);
    }
}
