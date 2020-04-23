using BuildingCondition.Db.Models;
using System.Collections.Generic;

namespace BuildingCondition.Interfaces
{
    public interface IGasQualificationCertificateService
    {
        bool Create(GasQualificationCertificate gasQualificationCertificate);
        bool Delete(int id);
        GasQualificationCertificate Get(int id);
        IList<GasQualificationCertificate> GetAll();
        IList<GasQualificationCertificate> GetAllByUserId(string id);
        bool Update(GasQualificationCertificate gasQualificationCertificate);
    }
}
