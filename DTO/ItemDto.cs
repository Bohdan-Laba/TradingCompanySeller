using System;

namespace TradingCompany.DTO
{
    public class ItemDto
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int SellerID { get; set; }
        public bool Availability { get; set; }
        public DateTime RowInsertTime { get; set; }

    }
}
