using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL.Interfaces;
using TradingCompany.DTO;

namespace DAL.Concrete
{
    public class ItemDal : IItemDal
    {

        private readonly IMapper _mapper;

        public ItemDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ItemDto CreateItem(ItemDto item)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var itemInDB = _mapper.Map<Item>(item);
                itemInDB.Availability = true;
                itemInDB.RowInsertTime = DateTime.UtcNow;
                itemInDB.RowUpdateTime = DateTime.UtcNow;
                entities.Items.Add(itemInDB);
                entities.SaveChanges();
                return _mapper.Map<ItemDto>(itemInDB);
            }
        }

        public void DeleteItem(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var itemf = entities.Items.SingleOrDefault(obj => obj.ItemID == id);
                if (itemf != null)
                {
                    entities.Items.Remove(itemf);
                    entities.SaveChanges();
                }
            }
        }

        public List<ItemDto> GetAllItems()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var items = entities.Items.ToList();
                return _mapper.Map<List<ItemDto>>(items);
            }
        }

        public ItemDto GetItem(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var items = entities.Items.SingleOrDefault(obj => obj.ItemID == id);
                return _mapper.Map<ItemDto>(items);
            }
        }

        public void UpdateItem(ItemDto item)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var itemf = entities.Items.SingleOrDefault(obj => obj.ItemID == item.ItemID);
                if (itemf != null)
                {

                    itemf.Name = item.Name;
                    itemf.Price = item.Price;
                    itemf.SellerID = item.SellerID;
                    itemf.Availability = item.Availability;
                    itemf.RowUpdateTime = DateTime.UtcNow;
                    entities.SaveChanges();
                }
            }
        }
    }
}
