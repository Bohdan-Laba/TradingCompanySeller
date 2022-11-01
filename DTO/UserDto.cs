using System;

namespace TradingCompany.DTO
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public DateTime RowInsertTime { get; set; }

    }
}
