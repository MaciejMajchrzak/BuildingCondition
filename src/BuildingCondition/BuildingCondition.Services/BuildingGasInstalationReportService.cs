using BuildingCondition.Db.Context;
using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BuildingCondition.Services
{
    public class BuildingGasInstalationReportService : IBuildingGasInstalationReportService
    {
        private readonly BuildingConditionContext context;

        public BuildingGasInstalationReportService(BuildingConditionContext _context)
        {
            context = _context;
        }

        public bool Create(BuildingGasInstalationReport buildingGasInstalationReport)
        {
            context.BuildingGasInstalationReports.Add(buildingGasInstalationReport);

            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var buildingGasInstalationReport = context.BuildingGasInstalationReports.SingleOrDefault(a => a.Id == id);

            if (buildingGasInstalationReport == null)
            {
                return false;
            }

            context.BuildingGasInstalationReports.Remove(buildingGasInstalationReport);

            return context.SaveChanges() > 0;
        }

        public BuildingGasInstalationReport Get(int id)
        {
            return context.BuildingGasInstalationReports.SingleOrDefault(a => a.Id == id);
        }

        public IList<BuildingGasInstalationReport> GetAll()
        {
            return context.BuildingGasInstalationReports.ToList();
        }

        public bool Update(BuildingGasInstalationReport buildingGasInstalationReport)
        {
            context.BuildingGasInstalationReports.Update(buildingGasInstalationReport);

            return context.SaveChanges() > 0;
        }
    }
}
