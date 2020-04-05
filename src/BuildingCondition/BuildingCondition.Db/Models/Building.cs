using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingCondition.Db.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }

        [ForeignKey("BuildingManager")]
        public int BuildingManagerId { get; set; }
        public BuildingManager BuildingManager { get; set; }

        public ICollection<Apartment> Apartments { get; set; }
        public ICollection<BuildingElectricalInstalationReport> BuildingElectricalInstalationReports { get; set; }
        public ICollection<BuildingGasInstalationReport> BuildingGasInstalationReports { get; set; }
    }
}