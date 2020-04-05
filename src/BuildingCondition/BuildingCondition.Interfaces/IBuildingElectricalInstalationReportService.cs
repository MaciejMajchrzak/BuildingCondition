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
        bool Update(BuildingElectricalInstalationReport buildingElectricalInstalationReport);
    }
}
