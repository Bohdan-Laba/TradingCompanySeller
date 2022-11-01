using System.Collections.Generic;
using TradingCompany.DTO;

namespace DAL.Interfaces
{
    public interface IUserDal
    {
        List<UserDto> GetAllUsers();
        UserDto CreateUser(UserDto user);
        UserDto GetUserById(int id);
        UserDto GetUserByLogin(string login);
        void UpdateUser(UserDto user);
        void DeleteUser(int id);
    }
}
