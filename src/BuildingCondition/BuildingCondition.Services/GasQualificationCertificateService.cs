using BuildingCondition.Db.Context;
using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BuildingCondition.Services
{
    public class GasQualificationCertificateService : IGasQualificationCertificateService
    {
        private readonly BuildingConditionContext context;

        public GasQualificationCertificateService(BuildingConditionContext _context)
        {
            context = _context;
        }

        public bool Create(GasQualificationCertificate gasQualificationCertificate)
        {
            context.GasQualificationCertificates.Add(gasQualificationCertificate);

            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var gasQualificationCertificate = context.GasQualificationCertificates.SingleOrDefault(a => a.Id == id);

            if (gasQualificationCertificate == null)
            {
                return false;
            }

            context.GasQualificationCertificates.Remove(gasQualificationCertificate);

            return context.SaveChanges() > 0;
        }

        public GasQualificationCertificate Get(int id)
        {
            return context.GasQualificationCertificates.SingleOrDefault(a => a.Id == id);
        }

        public IList<GasQualificationCertificate> GetAll()
        {
            return context.GasQualificationCertificates.ToList();
        }

        public IList<GasQualificationCertificate> GetAllByUserId(string id)
        {
            return context.GasQualificationCertificates.Where(a => a.UserId == id).ToList();
        }

        public bool Update(GasQualificationCertificate gasQualificationCertificate)
        {
            context.GasQualificationCertificates.Update(gasQualificationCertificate);

            return context.SaveChanges() > 0;
        }
    }
}
