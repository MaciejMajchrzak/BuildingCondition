using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingCondition.Db.Models
{
    public class BuildingElectricalInstalationReport
    {
        public int Id { get; set; }

        [ForeignKey("Building")]
        public int BuildingId { get; set; }
        public Building Building { get; set; }

        [ForeignKey("ElectricalInstallationParametersMeter")]
        public int ElectricalInstallationParametersMeterId { get; set; }
        public ElectricalInstallationParametersMeter ElectricalInstallationParametersMeter { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}