using BuildingCondition.Db.Models;
using System.Collections.Generic;

namespace BuildingCondition.Interfaces
{
    public interface IQualificationCertificateService
    {
        bool Create(QualificationCertificate qualificationCertificate);
        bool Delete(int id);
        QualificationCertificate Get(int id);
        IList<QualificationCertificate> GetAll();
        bool Update(QualificationCertificate qualificationCertificate);
    }
}
