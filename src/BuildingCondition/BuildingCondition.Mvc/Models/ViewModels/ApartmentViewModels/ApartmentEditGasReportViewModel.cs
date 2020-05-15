using BuildingCondition.Db.Models;
using System.Collections.Generic;

namespace BuildingCondition.Mvc.Models.ViewModels.ApartmentViewModels
{
    public class ApartmentEditGasReportViewModel : ApartmentGasInstalationReport
    {
        public List<GasDetector> GasDetectors { get; set; }
    }
}
