using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BuildingCondition.Db.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<ApartmentElectricalInstalationReport> ApartmentElectricalInstalationReports { get; set; }
        public ICollection<ApartmentGasInstalationReport> ApartmentGasInstalationReports { get; set; }
        public ICollection<BuildingElectricalInstalationReport> BuildingElectricalInstalationReports { get; set; }
        public ICollection<BuildingGasInstalationReport> BuildingGasInstalationReports { get; set; }
        public ICollection<ElectricalQualificationCertificate> ElectricalQualificationCertificates { get; set; }
        public ICollection<GasQualificationCertificate> GasQualificationCertificates { get; set; }
    }
}