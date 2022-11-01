using AutoMapper;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.DTO;

namespace DAL.Concrete
{
    public class RoleDal : IRoleDal
    {
        private readonly IMapper _mapper;

        public RoleDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public RoleDto CreateRole(RoleDto role)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var roleInDB = _mapper.Map<Role>(role);
                roleInDB.RowInsertTime = DateTime.UtcNow;
                entities.Roles.Add(roleInDB);
                entities.SaveChanges();
                return _mapper.Map<RoleDto>(roleInDB);
            }
        }

        public void DeleteRole(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var rolef = entities.Roles.SingleOrDefault(obj => obj.RoleID == id);
                if (rolef != null)
                {
                    entities.Roles.Remove(rolef);
                    entities.SaveChanges();
                }
            }
        }

        public List<RoleDto> GetAllRoles()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var roles = entities.Roles.ToList();
                return _mapper.Map<List<RoleDto>>(roles);
            }
        }

        public RoleDto GetRole(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var rolef = entities.Roles.SingleOrDefault(obj => obj.RoleID == id);
                return _mapper.Map<RoleDto>(rolef);
            }
        }

        public void UpdateRole(RoleDto role)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var rolef = entities.Roles.SingleOrDefault(obj => obj.RoleID == role.RoleID);
                if (rolef != null)
                {
                    rolef.Name = role.Name;
                    entities.SaveChanges();
                }
            }
        }
    }
}
