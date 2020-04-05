using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingCondition.Db.Models
{
    public class ApartmentElectricalInstalationReport
    {
        public int Id { get; set; }

        [ForeignKey("Apartment")]
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

        [ForeignKey("ElectricalInstallationParametersMeter")]
        public int ElectricalInstallationParametersMeterId { get; set; }
        public ElectricalInstallationParametersMeter ElectricalInstallationParametersMeter { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}