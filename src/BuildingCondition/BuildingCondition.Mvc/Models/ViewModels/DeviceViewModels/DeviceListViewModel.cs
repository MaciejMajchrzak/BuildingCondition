using BuildingCondition.Db.Models;
using System.Collections.Generic;

namespace BuildingCondition.Mvc.Models.ViewModels.DeviceViewModels
{
    public class DeviceListViewModel
    {
        public ICollection<ElectricalInstallationParametersMeter> ElectricalInstallationParametersMeters { get; set; }
        public ICollection<GasDetector> GasDetectors { get; set; }
    }
}
