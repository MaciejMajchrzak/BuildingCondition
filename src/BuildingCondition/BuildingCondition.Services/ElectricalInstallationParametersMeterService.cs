using BuildingCondition.Db.Context;
using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BuildingCondition.Services
{
    public class ElectricalInstallationParametersMeterService : IElectricalInstallationParametersMeterService
    {
        private readonly BuildingConditionContext context;

        public ElectricalInstallationParametersMeterService(BuildingConditionContext _context)
        {
            context = _context;
        }

        public bool Create(ElectricalInstallationParametersMeter electricalInstallationParametersMeter)
        {
            context.ElectricalInstallationParametersMeters.Add(electricalInstallationParametersMeter);

            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var electricalInstallationParametersMeter = context.ElectricalInstallationParametersMeters.SingleOrDefault(a => a.Id == id);

            if (electricalInstallationParametersMeter == null)
            {
                return false;
            }

            context.ElectricalInstallationParametersMeters.Remove(electricalInstallationParametersMeter);

            return context.SaveChanges() > 0;
        }

        public ElectricalInstallationParametersMeter Get(int id)
        {
            return context.ElectricalInstallationParametersMeters.SingleOrDefault(a => a.Id == id);
        }

        public IList<ElectricalInstallationParametersMeter> GetAll()
        {
            return context.ElectricalInstallationParametersMeters.ToList();
        }

        public bool Update(ElectricalInstallationParametersMeter electricalInstallationParametersMeter)
        {
            context.ElectricalInstallationParametersMeters.Update(electricalInstallationParametersMeter);

            return context.SaveChanges() > 0;
        }
    }
}
