using BuildingCondition.Db.Context;
using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BuildingCondition.Services
{
    public class GasDetectorService : IGasDetectorService
    {
        private readonly BuildingConditionContext context;

        public GasDetectorService(BuildingConditionContext _context)
        {
            context = _context;
        }

        public bool Create(GasDetector gasDetector)
        {
            context.GasDetectors.Add(gasDetector);

            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var gasDetector = context.GasDetectors.SingleOrDefault(a => a.Id == id);

            if (gasDetector == null)
            {
                return false;
            }

            context.GasDetectors.Remove(gasDetector);

            return context.SaveChanges() > 0;
        }

        public GasDetector Get(int id)
        {
            return context.GasDetectors.SingleOrDefault(a => a.Id == id);
        }

        public IList<GasDetector> GetAll()
        {
            return context.GasDetectors.ToList();
        }

        public bool Update(GasDetector gasDetector)
        {
            context.GasDetectors.Update(gasDetector);

            return context.SaveChanges() > 0;
        }
    }
}
