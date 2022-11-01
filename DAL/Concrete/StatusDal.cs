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
    public class StatusDal : IStatusDal
    {
        private readonly IMapper _mapper;

        public StatusDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public StatusDto CreateStatus(StatusDto status)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var statusInDb = _mapper.Map<Status>(status);
                statusInDb.RowInsertTime = DateTime.UtcNow;
                entities.Status.Add(statusInDb);
                entities.SaveChanges();
                return _mapper.Map<StatusDto>(statusInDb);
            }
        }

        public void DeleteStatus(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var stasusf = entities.Status.SingleOrDefault(obj => obj.StatusID == id);
                if (stasusf != null)
                {
                    entities.Status.Remove(stasusf);
                    entities.SaveChanges();
                }
            }
        }

        public List<StatusDto> GetAllStatuses()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var statuses = entities.Status.ToList();
                return _mapper.Map<List<StatusDto>>(statuses);
            }
                
        }

        public StatusDto GetStatus(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var statuses = entities.Status.SingleOrDefault(obj => obj.StatusID == id);
                return _mapper.Map<StatusDto>(statuses);
            }
        }

        public void UpdateStatus(StatusDto status)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var statusf = entities.Status.SingleOrDefault(obj => obj.StatusID == status.StatusID);
                if (statusf != null)
                {
                    statusf.Name = status.Name;
                    entities.SaveChanges();
                }
            }
        }
    }
}
