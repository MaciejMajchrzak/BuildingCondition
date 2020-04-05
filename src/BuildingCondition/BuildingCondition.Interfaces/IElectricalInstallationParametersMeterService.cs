using BuildingCondition.Db.Models;
using System.Collections.Generic;

namespace BuildingCondition.Interfaces
{
    public interface IElectricalInstallationParametersMeterService
    {
        bool Create(ElectricalInstallationParametersMeter electricalInstallationParametersMeter);
        bool Delete(int id);
        ElectricalInstallationParametersMeter Get(int id);
        IList<ElectricalInstallationParametersMeter> GetAll();
        bool Update(ElectricalInstallationParametersMeter electricalInstallationParametersMeter);
    }
}
