using AutoMapper;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using TradingCompany.DTO;

namespace DAL.Concrete
{
    public class UserDal : IUserDal
    {
        private readonly IMapper _mapper;

        public UserDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserDto CreateUser(UserDto user)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var userInDB = _mapper.Map<User>(user);
                userInDB.RowInsertTime = DateTime.UtcNow;
                userInDB.RowUpdateTime = DateTime.UtcNow;
                entities.Users.Add(userInDB);
                entities.SaveChanges();
                return _mapper.Map<UserDto>(userInDB);
            }
        }

        public void DeleteUser(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var userf = entities.Users.SingleOrDefault(obj => obj.UserID == id);
                if (userf != null)
                {
                    entities.Users.Remove(userf);
                    entities.SaveChanges();
                }
            }
        }

        public List<UserDto> GetAllUsers()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var users = entities.Users.ToList();
                return _mapper.Map<List<UserDto>>(users);
            }
        }

        public UserDto GetUserById(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var user = entities.Users.SingleOrDefault(obj => obj.UserID == id);
                return _mapper.Map<UserDto>(user);
            }
        }

        public UserDto GetUserByLogin(string login)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var user = entities.Users.SingleOrDefault(obj => obj.Login == login);
                return _mapper.Map<UserDto>(user);
            }
        }

        public void UpdateUser(UserDto user)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var userf = entities.Users.SingleOrDefault(obj => obj.UserID == user.UserID);
                if (userf != null)
                {
                    userf.Login = user.Login;
                    userf.Email = user.Email;
                    userf.Password = user.Password;
                    userf.RowUpdateTime = DateTime.UtcNow;
                    entities.SaveChanges();
                }
            }
        }
    }
}
