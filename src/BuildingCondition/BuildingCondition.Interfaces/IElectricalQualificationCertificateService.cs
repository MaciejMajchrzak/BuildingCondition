using BuildingCondition.Db.Models;
using System.Collections.Generic;

namespace BuildingCondition.Interfaces
{
    public interface IElectricalQualificationCertificateService
    {
        bool Create(ElectricalQualificationCertificate electricalQualificationCertificate);
        bool Delete(int id);
        ElectricalQualificationCertificate Get(int id);
        IList<ElectricalQualificationCertificate> GetAll();
        IList<ElectricalQualificationCertificate> GetAllByUserId(string id);
        bool Update(ElectricalQualificationCertificate electricalQualificationCertificate);
    }
}
