using System.Collections.Generic;
using TradingCompany.DTO;

namespace DAL.Interfaces
{
    public interface IRoleDal
    {
        List<RoleDto> GetAllRoles();
        RoleDto CreateRole(RoleDto role);
        RoleDto GetRole(int id);
        void UpdateRole(RoleDto role);
        void DeleteRole(int id);
    }
}
