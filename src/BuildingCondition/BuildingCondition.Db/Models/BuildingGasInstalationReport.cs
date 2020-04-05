using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingCondition.Db.Models
{
    public class BuildingGasInstalationReport
    {
        public int Id { get; set; }

        [ForeignKey("Building")]
        public int BuildingId { get; set; }
        public Building Building { get; set; }

        [ForeignKey("GasDetector")]
        public int GasDetectorId { get; set; }
        public GasDetector GasDetector { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}