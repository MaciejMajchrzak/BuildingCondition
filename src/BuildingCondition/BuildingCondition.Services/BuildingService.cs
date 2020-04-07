using BuildingCondition.Db.Context;
using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BuildingCondition.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly BuildingConditionContext context;

        public BuildingService(BuildingConditionContext _context)
        {
            context = _context;
        }

        public bool Create(Building building)
        {
            context.Buildings.Add(building);

            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var building = context.Buildings.SingleOrDefault(a => a.Id == id);

            if (building == null)
            {
                return false;
            }

            context.Buildings.Remove(building);

            return context.SaveChanges() > 0;
        }

        public Building Get(int id)
        {
            return context.Buildings.SingleOrDefault(a => a.Id == id);
        }

        public IList<Building> GetAll()
        {
            return context.Buildings.ToList();
        }

        public IList<Building> GetAllByBuildingManagerId(int id)
        {
            return context.Buildings.Where(a => a.BuildingManagerId == id).ToList();
        }

        public bool Update(Building building)
        {
            context.Buildings.Update(building);

            return context.SaveChanges() > 0;
        }
    }
}
