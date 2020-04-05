using BuildingCondition.Db.Models;
using System.Collections.Generic;

namespace BuildingCondition.Interfaces
{
    public interface IBuildingManagerService
    {
        bool Create(BuildingManager buildingManager);
        bool Delete(int id);
        BuildingManager Get(int id);
        IList<BuildingManager> GetAll();
        bool Update(BuildingManager buildingManager);
    }
}
