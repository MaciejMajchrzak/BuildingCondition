using System;
using System.Collections.Generic;

namespace BuildingCondition.Db.Models
{
    public class GasDetector
    {
        public int Id { get; set; }
        public DateTime LastCalibrationDate { get; set; }
        public string Model { get; set; }
        public DateTime NextCalibrationDate { get; set; }
        public string SerialNumber { get; set; }

        public ICollection<ApartmentGasInstalationReport> ApartmentGasInstalationReports{ get; set; }
        public ICollection<BuildingGasInstalationReport> BuildingGasInstalationReports { get; set; }
    }
}