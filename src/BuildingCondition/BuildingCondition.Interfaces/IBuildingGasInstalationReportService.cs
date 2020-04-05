using BuildingCondition.Db.Models;
using System.Collections.Generic;

namespace BuildingCondition.Interfaces
{
    public interface IBuildingGasInstalationReportService
    {
        bool Create(BuildingGasInstalationReport buildingGasInstalationReport);
        bool Delete(int id);
        BuildingGasInstalationReport Get(int id);
        IList<BuildingGasInstalationReport> GetAll();
        bool Update(BuildingGasInstalationReport buildingGasInstalationReport);
    }
}
