using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using BuildingCondition.Mvc.Models.ViewModels.DeviceViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BuildingCondition.Mvc.Controllers
{
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

        [HttpGet]
        public IActionResult AddElectrical()
        {
            return View();
        }

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

        [HttpGet]
        public IActionResult AddGas()
        {
            return View();
        }

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

        [HttpGet]
        public IActionResult DeleteElectrical(int id)
        {
            electricalInstallationParametersMeterService.Delete(id);

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult DeleteGas(int id)
        {
            gasDetectorService.Delete(id);

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult EditElectrical(int id)
        {
            return View(electricalInstallationParametersMeterService.Get(id));
        }

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

        [HttpGet]
        public IActionResult EditGas(int id)
        {
            return View(gasDetectorService.Get(id));
        }

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

        public IActionResult List()
        {
            DeviceListViewModel deviceListViewModel = new DeviceListViewModel();

            deviceListViewModel.ElectricalInstallationParametersMeters = electricalInstallationParametersMeterService.GetAll();

            deviceListViewModel.GasDetectors = gasDetectorService.GetAll();

            return View(deviceListViewModel);
        }
    }
}