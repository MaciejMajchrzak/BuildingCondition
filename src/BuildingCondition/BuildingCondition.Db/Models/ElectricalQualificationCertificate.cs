using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingCondition.Db.Models
{
    public class ElectricalQualificationCertificate
    {
        public int Id { get; set; }

        public string CertificateNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime ReleaseDate { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
