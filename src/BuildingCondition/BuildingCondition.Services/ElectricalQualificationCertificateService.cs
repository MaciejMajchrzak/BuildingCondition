using BuildingCondition.Db.Context;
using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BuildingCondition.Services
{
    public class ElectricalQualificationCertificateService : IElectricalQualificationCertificateService
    {
        private readonly BuildingConditionContext context;

        public ElectricalQualificationCertificateService(BuildingConditionContext _context)
        {
            context = _context;
        }

        public bool Create(ElectricalQualificationCertificate electricalQualificationCertificate)
        {
            context.ElectricalQualificationCertificates.Add(electricalQualificationCertificate);

            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var electricalQualificationCertificate = context.ElectricalQualificationCertificates.SingleOrDefault(a => a.Id == id);

            if (electricalQualificationCertificate == null)
            {
                return false;
            }

            context.ElectricalQualificationCertificates.Remove(electricalQualificationCertificate);

            return context.SaveChanges() > 0;
        }

        public ElectricalQualificationCertificate Get(int id)
        {
            return context.ElectricalQualificationCertificates.SingleOrDefault(a => a.Id == id);
        }

        public IList<ElectricalQualificationCertificate> GetAll()
        {
            return context.ElectricalQualificationCertificates.ToList();
        }

        public IList<ElectricalQualificationCertificate> GetAllByUserId(string id)
        {
            return context.ElectricalQualificationCertificates.Where(a => a.UserId == id).ToList();
        }

        public bool Update(ElectricalQualificationCertificate electricalQualificationCertificate)
        {
            context.ElectricalQualificationCertificates.Update(electricalQualificationCertificate);

            return context.SaveChanges() > 0;
        }
    }
}
