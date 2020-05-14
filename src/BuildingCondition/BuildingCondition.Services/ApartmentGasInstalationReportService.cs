using BuildingCondition.Db.Context;
using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BuildingCondition.Services
{
    public class ApartmentGasInstalationReportService : IApartmentGasInstalationReportService
    {
        private readonly BuildingConditionContext context;

        public ApartmentGasInstalationReportService(BuildingConditionContext _context)
        {
            context = _context;
        }

        public bool Create(ApartmentGasInstalationReport apartmentGasInstalationReport)
        {
            context.ApartmentGasInstalationReports.Add(apartmentGasInstalationReport);

            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var apartmentGasInstalationReport = context.ApartmentGasInstalationReports.SingleOrDefault(a => a.Id == id);

            if (apartmentGasInstalationReport == null)
            {
                return false;
            }

            context.ApartmentGasInstalationReports.Remove(apartmentGasInstalationReport);

            return context.SaveChanges() > 0;
        }

        public ApartmentGasInstalationReport Get(int id)
        {
            return context.ApartmentGasInstalationReports.SingleOrDefault(a => a.Id == id);
        }

        public IList<ApartmentGasInstalationReport> GetAll()
        {
            return context.ApartmentGasInstalationReports.ToList();
        }

        public IList<ApartmentGasInstalationReport> GetAllByApartmentId(int id)
        {
            return context.ApartmentGasInstalationReports.Where(a => a.Id == id).ToList();
        }

        public bool Update(ApartmentGasInstalationReport apartmentGasInstalationReport)
        {
            context.ApartmentGasInstalationReports.Update(apartmentGasInstalationReport);

            return context.SaveChanges() > 0;
        }
    }
}
