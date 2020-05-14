using BuildingCondition.Db.Models;
using System.Collections.Generic;

namespace BuildingCondition.Interfaces
{
    public interface IApartmentGasInstalationReportService
    {
        bool Create(ApartmentGasInstalationReport apartmentGasInstalationReport);
        bool Delete(int id);
        ApartmentGasInstalationReport Get(int id);
        IList<ApartmentGasInstalationReport> GetAll();
        IList<ApartmentGasInstalationReport> GetAllByApartmentId(int id);
        bool Update(ApartmentGasInstalationReport apartmentGasInstalationReport);
    }
}
