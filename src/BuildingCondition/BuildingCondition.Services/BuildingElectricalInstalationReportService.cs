using BuildingCondition.Db.Context;
using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BuildingCondition.Services
{
    public class BuildingElectricalInstalationReportService : IBuildingElectricalInstalationReportService
    {
        private readonly BuildingConditionContext context;

        public BuildingElectricalInstalationReportService(BuildingConditionContext _context)
        {
            context = _context;
        }

        public bool Create(BuildingElectricalInstalationReport buildingElectricalInstalationReport)
        {
            context.BuildingElectricalInstalationReports.Add(buildingElectricalInstalationReport);

            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var buildingElectricalInstalationReport = context.BuildingElectricalInstalationReports.SingleOrDefault(a => a.Id == id);

            if (buildingElectricalInstalationReport == null)
            {
                return false;
            }

            context.BuildingElectricalInstalationReports.Remove(buildingElectricalInstalationReport);

            return context.SaveChanges() > 0;
        }

        public BuildingElectricalInstalationReport Get(int id)
        {
            return context.BuildingElectricalInstalationReports.SingleOrDefault(a => a.Id == id);
        }

        public IList<BuildingElectricalInstalationReport> GetAll()
        {
            return context.BuildingElectricalInstalationReports.ToList();
        }

        public BuildingElectricalInstalationReport GetLatest()
        {
            return context.BuildingElectricalInstalationReports.SingleOrDefault();
        }

        public bool Update(BuildingElectricalInstalationReport buildingElectricalInstalationReport)
        {
            context.BuildingElectricalInstalationReports.Update(buildingElectricalInstalationReport);

            return context.SaveChanges() > 0;
        }
    }
}
