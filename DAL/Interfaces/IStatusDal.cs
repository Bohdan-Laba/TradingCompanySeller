using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.DTO;

namespace DAL.Interfaces
{
    public interface IStatusDal
    {
        List<StatusDto> GetAllStatuses();
        StatusDto CreateStatus(StatusDto status);
        StatusDto GetStatus(int id);
        void UpdateStatus(StatusDto status);
        void DeleteStatus(int id);
    }
}
