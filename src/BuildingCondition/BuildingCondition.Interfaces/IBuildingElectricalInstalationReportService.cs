using BuildingCondition.Db.Models;
using System.Collections.Generic;

namespace BuildingCondition.Interfaces
{
    public interface IBuildingElectricalInstalationReportService
    {
        bool Create(BuildingElectricalInstalationReport buildingElectricalInstalationReport);
        bool Delete(int id);
        BuildingElectricalInstalationReport Get(int id);
        IList<BuildingElectricalInstalationReport> GetAll();
        BuildingElectricalInstalationReport GetLatest();
        bool Update(BuildingElectricalInstalationReport buildingElectricalInstalationReport);
    }
}
