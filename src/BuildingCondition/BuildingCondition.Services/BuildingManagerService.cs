using BuildingCondition.Db.Context;
using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BuildingCondition.Services
{
    public class BuildingManagerService : IBuildingManagerService
    {
        private readonly BuildingConditionContext context;

        public BuildingManagerService(BuildingConditionContext _context)
        {
            context = _context;
        }

        public bool Create(BuildingManager buildingManager)
        {
            context.BuildingManagers.Add(buildingManager);

            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var buildingManager = context.BuildingManagers.SingleOrDefault(a => a.Id == id);

            if (buildingManager == null)
            {
                return false;
            }

            context.BuildingManagers.Remove(buildingManager);

            return context.SaveChanges() > 0;
        }

        public BuildingManager Get(int id)
        {
            return context.BuildingManagers.SingleOrDefault(a => a.Id == id);
        }

        public IList<BuildingManager> GetAll()
        {
            return context.BuildingManagers.ToList();
        }

        public bool Update(BuildingManager buildingManager)
        {
            context.BuildingManagers.Update(buildingManager);

            return context.SaveChanges() > 0;
        }
    }
}
