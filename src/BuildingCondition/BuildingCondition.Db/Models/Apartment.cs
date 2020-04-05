using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingCondition.Db.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public string ApartmentNumber { get; set; }
        public string GateNumber { get; set; }

        [ForeignKey("Building")]
        public int BuildingId { get; set; }
        public Building Building { get; set; }

        public ICollection<ApartmentElectricalInstalationReport> ApartmentElectricalInstalationReports { get; set; }
        public ICollection<ApartmentGasInstalationReport> ApartmentGasInstalationReports { get; set; }
    }
}