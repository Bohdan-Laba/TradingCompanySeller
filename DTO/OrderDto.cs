using System;

namespace TradingCompany.DTO
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public float TotalPrice { get; set; }
        public int StatusID { get; set; }
        public DateTime RowInsertDate { get; set; }
    }
}
