using BuildingCondition.Db.Context;
using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BuildingCondition.Services
{
    public class QualificationCertificateService : IQualificationCertificateService
    {
        private readonly BuildingConditionContext context;

        public QualificationCertificateService(BuildingConditionContext _context)
        {
            context = _context;
        }

        public bool Create(QualificationCertificate qualificationCertificate)
        {
            context.QualificationCertificates.Add(qualificationCertificate);

            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var qualificationCertificate = context.QualificationCertificates.SingleOrDefault(a => a.Id == id);

            if (qualificationCertificate == null)
            {
                return false;
            }

            context.QualificationCertificates.Remove(qualificationCertificate);

            return context.SaveChanges() > 0;
        }

        public QualificationCertificate Get(int id)
        {
            return context.QualificationCertificates.SingleOrDefault(a => a.Id == id);
        }

        public IList<QualificationCertificate> GetAll()
        {
            return context.QualificationCertificates.ToList();
        }

        public bool Update(QualificationCertificate qualificationCertificate)
        {
            context.QualificationCertificates.Update(qualificationCertificate);

            return context.SaveChanges() > 0;
        }
    }
}
