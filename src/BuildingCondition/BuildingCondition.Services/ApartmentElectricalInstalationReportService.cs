using BuildingCondition.Db.Context;
using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BuildingCondition.Services
{
    public class ApartmentElectricalInstalationReportService : IApartmentElectricalInstalationReportService
    {
        private readonly BuildingConditionContext context;

        public ApartmentElectricalInstalationReportService(BuildingConditionContext _context)
        {
            context = _context;
        }

        public bool Create(ApartmentElectricalInstalationReport apartmentElectricalInstalationReport)
        {
            context.ApartmentElectricalInstalationReports.Add(apartmentElectricalInstalationReport);

            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var apartmentElectricalInstalationReport = context.ApartmentElectricalInstalationReports.SingleOrDefault(a => a.Id == id);

            if (apartmentElectricalInstalationReport == null)
            {
                return false;
            }

            context.ApartmentElectricalInstalationReports.Remove(apartmentElectricalInstalationReport);

            return context.SaveChanges() > 0;
        }

        public ApartmentElectricalInstalationReport Get(int id)
        {
            return context.ApartmentElectricalInstalationReports.SingleOrDefault(a => a.Id == id);
        }

        public IList<ApartmentElectricalInstalationReport> GetAll()
        {
            return context.ApartmentElectricalInstalationReports.ToList();
        }

        public bool Update(ApartmentElectricalInstalationReport apartmentElectricalInstalationReport)
        {
            context.ApartmentElectricalInstalationReports.Update(apartmentElectricalInstalationReport);

            return context.SaveChanges() > 0;
        }
    }
}
