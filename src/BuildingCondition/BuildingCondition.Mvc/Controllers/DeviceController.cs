using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using BuildingCondition.Mvc.Models.ViewModels.DeviceViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingCondition.Mvc.Controllers
{
    [Authorize(Roles = "ActiveUser")]
    public class DeviceController : Controller
    {
        private readonly IElectricalInstallationParametersMeterService electricalInstallationParametersMeterService;
        private readonly IGasDetectorService gasDetectorService;

        public DeviceController(IElectricalInstallationParametersMeterService _electricalInstallationParametersMeterService,
            IGasDetectorService _gasDetectorService)
        {
            electricalInstallationParametersMeterService = _electricalInstallationParametersMeterService;
            gasDetectorService = _gasDetectorService;
        }

        [Authorize(Roles = "DeviceAddElectrical")]
        [HttpGet]
        public IActionResult AddElectrical()
        {
            return View();
        }

        [Authorize(Roles = "DeviceAddElectrical")]
        [HttpPost]
        public IActionResult AddElectrical(ElectricalInstallationParametersMeter electricalInstallationParametersMeter)
        {
            if(ModelState.IsValid)
            {
                electricalInstallationParametersMeterService.Create(electricalInstallationParametersMeter);

                return RedirectToAction("List");
            }

            return View(electricalInstallationParametersMeter);
        }

        [Authorize(Roles = "DeviceAddGas")]
        [HttpGet]
        public IActionResult AddGas()
        {
            return View();
        }

        [Authorize(Roles = "DeviceAddGas")]
        [HttpPost]
        public IActionResult AddGas(GasDetector gasDetector)
        {
            if(ModelState.IsValid)
            {
                gasDetectorService.Create(gasDetector);

                return RedirectToAction("List");
            }

            return View();
        }

        [Authorize(Roles = "DeviceDeleteElectrical")]
        [HttpGet]
        public IActionResult DeleteElectrical(int id)
        {
            electricalInstallationParametersMeterService.Delete(id);

            return RedirectToAction("List");
        }

        [Authorize(Roles = "DeviceDeleteGas")]
        [HttpGet]
        public IActionResult DeleteGas(int id)
        {
            gasDetectorService.Delete(id);

            return RedirectToAction("List");
        }

        [Authorize(Roles = "DeviceEditElectrical")]
        [HttpGet]
        public IActionResult EditElectrical(int id)
        {
            return View(electricalInstallationParametersMeterService.Get(id));
        }

        [Authorize(Roles = "DeviceEditElectrical")]
        [HttpPost]
        public IActionResult EditElectrical(ElectricalInstallationParametersMeter electricalInstallationParametersMeter)
        {
            if(ModelState.IsValid)
            {
                electricalInstallationParametersMeterService.Update(electricalInstallationParametersMeter);

                return RedirectToAction("List");
            }

            return View(electricalInstallationParametersMeter);
        }

        [Authorize(Roles = "DeviceEditGas")]
        [HttpGet]
        public IActionResult EditGas(int id)
        {
            return View(gasDetectorService.Get(id));
        }

        [Authorize(Roles = "DeviceEditGas")]
        [HttpPost]
        public IActionResult EditGas(GasDetector gasDetector)
        {
            if(ModelState.IsValid)
            {
                gasDetectorService.Update(gasDetector);

                return RedirectToAction("List");
            }

            return View(gasDetector);
        }

        [Authorize(Roles = "DeviceList")]
        public IActionResult List()
        {
            DeviceListViewModel deviceListViewModel = new DeviceListViewModel();

            deviceListViewModel.ElectricalInstallationParametersMeters = electricalInstallationParametersMeterService.GetAll();

            deviceListViewModel.GasDetectors = gasDetectorService.GetAll();

            return View(deviceListViewModel);
        }
    }
}