using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using BuildingCondition.Mvc.Models.ViewModels.ApartmentViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BuildingCondition.Mvc.Controllers
{
    [Authorize(Roles = "ActiveUser")]
    public class ApartmentController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IApartmentElectricalInstalationReportService apartmentElectricalInstalationReportService;
        private readonly IApartmentGasInstalationReportService apartmentGasInstalationReportService;
        private readonly IApartmentService apartmentService;
        private readonly IBuildingManagerService buildingManagerService;
        private readonly IBuildingService buildingService;
        private readonly IGasDetectorService gasDetectorService;
        private readonly IUserService userService;

        public ApartmentController(UserManager<IdentityUser> _userManager,
            IApartmentElectricalInstalationReportService _apartmentElectricalInstalationReportService,
            IApartmentGasInstalationReportService _apartmentGasInstalationReportService,
            IApartmentService _apartmentService,
            IBuildingManagerService _buildingManagerService,
            IBuildingService _buildingService,
            IGasDetectorService _gasDetectorService,
            IUserService _userService)
        {
            userManager = _userManager;
            apartmentElectricalInstalationReportService = _apartmentElectricalInstalationReportService;
            apartmentGasInstalationReportService = _apartmentGasInstalationReportService;
            apartmentService = _apartmentService;
            buildingManagerService = _buildingManagerService;
            buildingService = _buildingService;
            gasDetectorService = _gasDetectorService;
            userService = _userService;
        }

        /// <param name="id">Building.Id</param>
        [Authorize(Roles = "ApartmentAdd")]
        [HttpGet]
        public IActionResult Add(int id)
        {
            Apartment apartment = new Apartment()
            {
                BuildingId = id
            };

            return View(apartment);
        }

        [Authorize(Roles = "ApartmentAdd")]
        [HttpPost]
        public IActionResult Add(Apartment apartment)
        {
            if(ModelState.IsValid)
            {
                apartmentService.Create(apartment);

                Building building = buildingService.Get(apartment.BuildingId);

                building.BuildingManager = buildingManagerService.Get(building.BuildingManagerId);

                building.Apartments = apartmentService.GetAllByBuildingId(apartment.BuildingId);

                return RedirectToAction("Details", "Building", building);
            }

            return View(apartment);
        }

        [Authorize(Roles = "ApartmentAddGasReport")]
        [HttpGet]
        public IActionResult AddGasReport(int id)
        {
            ApartmentAddGasReportViewModel apartmentAddGasReportViewModel = new ApartmentAddGasReportViewModel()
            {
                ApartmentId = id,
                UserId = userManager.GetUserId(HttpContext.User),
                DateOfInspection = DateTime.UtcNow,
                DateOfNextInspection = DateTime.UtcNow.AddYears(1),
                GasDetectors = gasDetectorService.GetAllWithValidCalibration().ToList()
            };

            return View(apartmentAddGasReportViewModel);
        }

        [Authorize(Roles = "ApartmentAddGasReport")]
        [HttpPost]
        public IActionResult AddGasReport(ApartmentAddGasReportViewModel apartmentAddGasReportViewModel)
        {

            if(apartmentAddGasReportViewModel.ForPremisesOrCollectiveOrSeal == true &&
                apartmentAddGasReportViewModel.AssessmentOfGasMeterAccuracy == true &&
                apartmentAddGasReportViewModel.TheGasMeterConnectionsWithTheInstallation == true &&
                apartmentAddGasReportViewModel.VentilationOfTheGasMeterCabinet == true &&
                apartmentAddGasReportViewModel.SecuringTheGasMeterAgainstUnauthorizedAccessAndAccessToTheGasMeter == true &&
                apartmentAddGasReportViewModel.ConditionOfPipeWallsAndFittings == true &&
                apartmentAddGasReportViewModel.InstallationTightness == true &&
                apartmentAddGasReportViewModel.ConditionOfAnticorrosiveCoating == true &&
                apartmentAddGasReportViewModel.IntersectionsOfGasInstallationsWithOtherPipes == true &&
                apartmentAddGasReportViewModel.FasteningGasInstallationsAndPipes == true &&
                apartmentAddGasReportViewModel.CookerFittingsAccessibilityToTheShutoffValve == true &&
                apartmentAddGasReportViewModel.CookerFittingsTheTightnessOfTheGasShutoffValve == true &&
                apartmentAddGasReportViewModel.CookerFittingsOperationOfTheGasShutoffValve == true &&
                apartmentAddGasReportViewModel.CookerFittingsRoomVentilationWithGasReceiverVentilationGrille == true &&
                apartmentAddGasReportViewModel.CookerFittingsTechnicalConditionOfGasDevicesAndConnectionsToFlueGasDucts == true &&
                apartmentAddGasReportViewModel.BathroomStoveFittingsAccessibilityToTheShutoffValve == true &&
                apartmentAddGasReportViewModel.BathroomStoveFittingsTheTightnessOfTheGasShutoffValve == true &&
                apartmentAddGasReportViewModel.BathroomStoveFittingsOperationOfTheGasShutoffValve == true &&
                apartmentAddGasReportViewModel.BathroomStoveFittingsRoomVentilationWithGasReceiverVentilationGrille == true &&
                apartmentAddGasReportViewModel.BathroomStoveFittingsTechnicalConditionOfGasDevicesAndConnectionsToFlueGasDucts == true &&
                apartmentAddGasReportViewModel.KitchenStoveFittingsAccessibilityToTheShutoffValve == true &&
                apartmentAddGasReportViewModel.KitchenStoveFittingsTheTightnessOfTheGasShutoffValve == true &&
                apartmentAddGasReportViewModel.KitchenStoveFittingsOperationOfTheGasShutoffValve == true &&
                apartmentAddGasReportViewModel.KitchenStoveFittingsRoomVentilationWithGasReceiverVentilationGrille == true &&
                apartmentAddGasReportViewModel.KitchenStoveFittingsTechnicalConditionOfGasDevicesAndConnectionsToFlueGasDucts == true &&
                string.IsNullOrEmpty(apartmentAddGasReportViewModel.GaseousFuelConcentration) == true &&
                string.IsNullOrEmpty(apartmentAddGasReportViewModel.Location) == true &&
                apartmentAddGasReportViewModel.DeadlineForDeletion == null &&
                apartmentAddGasReportViewModel.ShutOffTheGasSupply == false)
            {
                apartmentAddGasReportViewModel.FurtherOperationOfTheInstallationInThePremises = true;
            }
            else
            {
                apartmentAddGasReportViewModel.FurtherOperationOfTheInstallationInThePremises = false;
            }

            apartmentAddGasReportViewModel.GasDetectors = gasDetectorService.GetAllWithValidCalibration().ToList();


            return View(apartmentAddGasReportViewModel);
        }

        [Authorize(Roles = "ApartmentAddGasReport")]
        [HttpPost]
        public IActionResult AddGasReportConfirm(ApartmentAddGasReportViewModel apartmentAddGasReportViewModel)
        {
            apartmentGasInstalationReportService.Create(apartmentAddGasReportViewModel);

            Apartment apartment = apartmentService.Get(apartmentAddGasReportViewModel.ApartmentId);

            apartment.Building = buildingService.Get(apartment.BuildingId);

            apartment.Building.BuildingManager = buildingManagerService.Get(apartment.Building.BuildingManagerId);

            apartment.ApartmentElectricalInstalationReports = apartmentElectricalInstalationReportService.GetAllByApartmentId(apartment.Id);

            apartment.ApartmentGasInstalationReports = apartmentGasInstalationReportService.GetAllByApartmentId(apartment.Id);

            return RedirectToAction("Details", "Apartment", apartment);
        }

        [Authorize(Roles = "ApartmentDelete")]
        [HttpGet]
        public IActionResult Delete(int buildingId, int apartmentId)
        {
            apartmentService.Delete(apartmentId);

            Building building = buildingService.Get(buildingId);

            building.BuildingManager = buildingManagerService.Get(building.BuildingManagerId);

            building.Apartments = apartmentService.GetAllByBuildingId(buildingId);

            return RedirectToAction("Details", "Building", building);
        }

        [Authorize(Roles = "ApartmentDeleteGasReport")]
        [HttpGet]
        public IActionResult DeleteGasReport(int apartmentId, int gasReportId)
        {
            apartmentGasInstalationReportService.Delete(gasReportId);

            Apartment apartment = apartmentService.Get(apartmentId);

            apartment.Building = buildingService.Get(apartment.BuildingId);

            apartment.Building.BuildingManager = buildingManagerService.Get(apartment.Building.BuildingManagerId);

            apartment.ApartmentElectricalInstalationReports = apartmentElectricalInstalationReportService.GetAllByApartmentId(apartment.Id);

            apartment.ApartmentGasInstalationReports = apartmentGasInstalationReportService.GetAllByApartmentId(apartment.Id);

            return RedirectToAction("Details", "Apartment", apartment);
        }

        [Authorize(Roles = "ApartmentDetails")]
        [HttpGet]
        public IActionResult Details(int id)
        {
            Apartment apartment = apartmentService.Get(id);

            apartment.Building = buildingService.Get(apartment.BuildingId);

            apartment.Building.BuildingManager = buildingManagerService.Get(apartment.Building.BuildingManagerId);

            apartment.ApartmentElectricalInstalationReports = apartmentElectricalInstalationReportService.GetAllByApartmentId(id);

            apartment.ApartmentGasInstalationReports = apartmentGasInstalationReportService.GetAllByApartmentId(id);

            return View(apartment);
        }

        [Authorize(Roles = "ApartmentDetailsGasReport")]
        [HttpGet]
        public IActionResult DetailsGasReport(int id)
        {
            ApartmentGasInstalationReport apartmentGasInstalationReport = apartmentGasInstalationReportService.Get(id);

            apartmentGasInstalationReport.User = userService.Get(apartmentGasInstalationReport.UserId);

            apartmentGasInstalationReport.GasDetector = gasDetectorService.Get(apartmentGasInstalationReport.GasDetectorId);

            apartmentGasInstalationReport.Apartment = apartmentService.Get(apartmentGasInstalationReport.ApartmentId);

            apartmentGasInstalationReport.Apartment.Building = buildingService.Get(apartmentGasInstalationReport.Apartment.BuildingId);

            apartmentGasInstalationReport.Apartment.Building.BuildingManager = buildingManagerService.Get(apartmentGasInstalationReport.Apartment.Building.BuildingManagerId);

            return View(apartmentGasInstalationReport);
        }

        [Authorize(Roles = "ApartmentEdit")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(apartmentService.Get(id));
        }

        [Authorize(Roles = "ApartmentEdit")]
        [HttpPost]
        public IActionResult Edit(Apartment apartment)
        {
            if(ModelState.IsValid)
            {
                apartmentService.Update(apartment);

                Building building = buildingService.Get(apartment.BuildingId);

                building.BuildingManager = buildingManagerService.Get(building.BuildingManagerId);

                building.Apartments = apartmentService.GetAllByBuildingId(apartment.BuildingId);

                return RedirectToAction("Details", "Building", building);
            }

            return View(apartment);
        }

        [Authorize(Roles = "ApartmentEditGasReport")]
        [HttpGet]
        public IActionResult EditGasReport(int id)
        {
            ApartmentGasInstalationReport apartmentGasInstalationReport = apartmentGasInstalationReportService.Get(id);

            ApartmentEditGasReportViewModel apartmentEditGasReportViewModel = new ApartmentEditGasReportViewModel()
            {
                Id = apartmentGasInstalationReport.Id,
                DateOfInspection = apartmentGasInstalationReport.DateOfInspection,
                ForPremisesOrCollectiveOrSeal = apartmentGasInstalationReport.ForPremisesOrCollectiveOrSeal,
                AssessmentOfGasMeterAccuracy = apartmentGasInstalationReport.AssessmentOfGasMeterAccuracy,
                TheGasMeterConnectionsWithTheInstallation = apartmentGasInstalationReport.TheGasMeterConnectionsWithTheInstallation,
                VentilationOfTheGasMeterCabinet = apartmentGasInstalationReport.VentilationOfTheGasMeterCabinet,
                SecuringTheGasMeterAgainstUnauthorizedAccessAndAccessToTheGasMeter = apartmentGasInstalationReport.SecuringTheGasMeterAgainstUnauthorizedAccessAndAccessToTheGasMeter,
                ConditionOfPipeWallsAndFittings = apartmentGasInstalationReport.ConditionOfPipeWallsAndFittings,
                InstallationTightness = apartmentGasInstalationReport.InstallationTightness,
                ConditionOfAnticorrosiveCoating = apartmentGasInstalationReport.ConditionOfAnticorrosiveCoating,
                IntersectionsOfGasInstallationsWithOtherPipes = apartmentGasInstalationReport.IntersectionsOfGasInstallationsWithOtherPipes,
                FasteningGasInstallationsAndPipes = apartmentGasInstalationReport.FasteningGasInstallationsAndPipes,
                CookerFittingsAccessibilityToTheShutoffValve = apartmentGasInstalationReport.CookerFittingsAccessibilityToTheShutoffValve,
                CookerFittingsTheTightnessOfTheGasShutoffValve = apartmentGasInstalationReport.CookerFittingsTheTightnessOfTheGasShutoffValve,
                CookerFittingsOperationOfTheGasShutoffValve = apartmentGasInstalationReport.CookerFittingsOperationOfTheGasShutoffValve,
                CookerFittingsRoomVentilationWithGasReceiverVentilationGrille = apartmentGasInstalationReport.CookerFittingsRoomVentilationWithGasReceiverVentilationGrille,
                CookerFittingsTechnicalConditionOfGasDevicesAndConnectionsToFlueGasDucts = apartmentGasInstalationReport.CookerFittingsTechnicalConditionOfGasDevicesAndConnectionsToFlueGasDucts,
                BathroomStoveFittingsAccessibilityToTheShutoffValve = apartmentGasInstalationReport.BathroomStoveFittingsAccessibilityToTheShutoffValve,
                BathroomStoveFittingsTheTightnessOfTheGasShutoffValve = apartmentGasInstalationReport.BathroomStoveFittingsTheTightnessOfTheGasShutoffValve,
                BathroomStoveFittingsOperationOfTheGasShutoffValve = apartmentGasInstalationReport.BathroomStoveFittingsOperationOfTheGasShutoffValve,
                BathroomStoveFittingsRoomVentilationWithGasReceiverVentilationGrille = apartmentGasInstalationReport.BathroomStoveFittingsRoomVentilationWithGasReceiverVentilationGrille,
                BathroomStoveFittingsTechnicalConditionOfGasDevicesAndConnectionsToFlueGasDucts = apartmentGasInstalationReport.BathroomStoveFittingsTechnicalConditionOfGasDevicesAndConnectionsToFlueGasDucts,
                KitchenStoveFittingsAccessibilityToTheShutoffValve = apartmentGasInstalationReport.KitchenStoveFittingsAccessibilityToTheShutoffValve,
                KitchenStoveFittingsTheTightnessOfTheGasShutoffValve = apartmentGasInstalationReport.KitchenStoveFittingsTheTightnessOfTheGasShutoffValve,
                KitchenStoveFittingsOperationOfTheGasShutoffValve = apartmentGasInstalationReport.KitchenStoveFittingsOperationOfTheGasShutoffValve,
                KitchenStoveFittingsRoomVentilationWithGasReceiverVentilationGrille = apartmentGasInstalationReport.KitchenStoveFittingsRoomVentilationWithGasReceiverVentilationGrille,
                KitchenStoveFittingsTechnicalConditionOfGasDevicesAndConnectionsToFlueGasDucts = apartmentGasInstalationReport.KitchenStoveFittingsTechnicalConditionOfGasDevicesAndConnectionsToFlueGasDucts,
                GaseousFuelConcentration = apartmentGasInstalationReport.GaseousFuelConcentration,
                Location = apartmentGasInstalationReport.Location,
                DeadlineForDeletion = apartmentGasInstalationReport.DeadlineForDeletion,
                ShutOffTheGasSupply = apartmentGasInstalationReport.ShutOffTheGasSupply,
                CommentsAndPostInspectionRecommendationsToBeMadeByTheManagerOrOwner = apartmentGasInstalationReport.CommentsAndPostInspectionRecommendationsToBeMadeByTheManagerOrOwner,
                CommentsAndPostInspectionRecommendationsToBeMadeByTheGasSupplier = apartmentGasInstalationReport.CommentsAndPostInspectionRecommendationsToBeMadeByTheGasSupplier,
                CommentsAndPostInspectionRecommendationsToBeMadeByTheApartmentUser = apartmentGasInstalationReport.CommentsAndPostInspectionRecommendationsToBeMadeByTheApartmentUser,
                FurtherOperationOfTheInstallationInThePremises = apartmentGasInstalationReport.FurtherOperationOfTheInstallationInThePremises,
                DateOfNextInspection = apartmentGasInstalationReport.DateOfNextInspection,
                SignatureOfThePremisesUser = apartmentGasInstalationReport.SignatureOfThePremisesUser,
                ApartmentId = apartmentGasInstalationReport.ApartmentId,
                GasDetectorId = apartmentGasInstalationReport.GasDetectorId,
                UserId = apartmentGasInstalationReport.UserId,
                GasDetectors = gasDetectorService.GetAllWithValidCalibration().ToList()
            };


            return View(apartmentEditGasReportViewModel);
        }

        [Authorize(Roles = "ApartmentEditGasReport")]
        [HttpPost]
        public IActionResult EditGasReport(ApartmentEditGasReportViewModel apartmentEditGasReportViewModel)
        {

            if (apartmentEditGasReportViewModel.ForPremisesOrCollectiveOrSeal == true &&
                apartmentEditGasReportViewModel.AssessmentOfGasMeterAccuracy == true &&
                apartmentEditGasReportViewModel.TheGasMeterConnectionsWithTheInstallation == true &&
                apartmentEditGasReportViewModel.VentilationOfTheGasMeterCabinet == true &&
                apartmentEditGasReportViewModel.SecuringTheGasMeterAgainstUnauthorizedAccessAndAccessToTheGasMeter == true &&
                apartmentEditGasReportViewModel.ConditionOfPipeWallsAndFittings == true &&
                apartmentEditGasReportViewModel.InstallationTightness == true &&
                apartmentEditGasReportViewModel.ConditionOfAnticorrosiveCoating == true &&
                apartmentEditGasReportViewModel.IntersectionsOfGasInstallationsWithOtherPipes == true &&
                apartmentEditGasReportViewModel.FasteningGasInstallationsAndPipes == true &&
                apartmentEditGasReportViewModel.CookerFittingsAccessibilityToTheShutoffValve == true &&
                apartmentEditGasReportViewModel.CookerFittingsTheTightnessOfTheGasShutoffValve == true &&
                apartmentEditGasReportViewModel.CookerFittingsOperationOfTheGasShutoffValve == true &&
                apartmentEditGasReportViewModel.CookerFittingsRoomVentilationWithGasReceiverVentilationGrille == true &&
                apartmentEditGasReportViewModel.CookerFittingsTechnicalConditionOfGasDevicesAndConnectionsToFlueGasDucts == true &&
                apartmentEditGasReportViewModel.BathroomStoveFittingsAccessibilityToTheShutoffValve == true &&
                apartmentEditGasReportViewModel.BathroomStoveFittingsTheTightnessOfTheGasShutoffValve == true &&
                apartmentEditGasReportViewModel.BathroomStoveFittingsOperationOfTheGasShutoffValve == true &&
                apartmentEditGasReportViewModel.BathroomStoveFittingsRoomVentilationWithGasReceiverVentilationGrille == true &&
                apartmentEditGasReportViewModel.BathroomStoveFittingsTechnicalConditionOfGasDevicesAndConnectionsToFlueGasDucts == true &&
                apartmentEditGasReportViewModel.KitchenStoveFittingsAccessibilityToTheShutoffValve == true &&
                apartmentEditGasReportViewModel.KitchenStoveFittingsTheTightnessOfTheGasShutoffValve == true &&
                apartmentEditGasReportViewModel.KitchenStoveFittingsOperationOfTheGasShutoffValve == true &&
                apartmentEditGasReportViewModel.KitchenStoveFittingsRoomVentilationWithGasReceiverVentilationGrille == true &&
                apartmentEditGasReportViewModel.KitchenStoveFittingsTechnicalConditionOfGasDevicesAndConnectionsToFlueGasDucts == true &&
                string.IsNullOrEmpty(apartmentEditGasReportViewModel.GaseousFuelConcentration) == true &&
                string.IsNullOrEmpty(apartmentEditGasReportViewModel.Location) == true &&
                apartmentEditGasReportViewModel.DeadlineForDeletion == null &&
                apartmentEditGasReportViewModel.ShutOffTheGasSupply == false)
            {
                apartmentEditGasReportViewModel.FurtherOperationOfTheInstallationInThePremises = true;
            }
            else
            {
                apartmentEditGasReportViewModel.FurtherOperationOfTheInstallationInThePremises = false;
            }

            apartmentGasInstalationReportService.Update(apartmentEditGasReportViewModel);

            Apartment apartment = apartmentService.Get(apartmentEditGasReportViewModel.ApartmentId);

            apartment.Building = buildingService.Get(apartment.BuildingId);

            apartment.Building.BuildingManager = buildingManagerService.Get(apartment.Building.BuildingManagerId);

            apartment.ApartmentElectricalInstalationReports = apartmentElectricalInstalationReportService.GetAllByApartmentId(apartment.Id);

            apartment.ApartmentGasInstalationReports = apartmentGasInstalationReportService.GetAllByApartmentId(apartment.Id);

            return RedirectToAction("Details", "Apartment", apartment);
        }

        [Authorize(Roles = "ApartmentEditGasReport")]
        [HttpPost]
        public IActionResult EditGasReportConfirm(ApartmentEditGasReportViewModel apartmentEditGasReportViewModel)
        {
            apartmentGasInstalationReportService.Update(apartmentEditGasReportViewModel);

            Apartment apartment = apartmentService.Get(apartmentEditGasReportViewModel.ApartmentId);

            apartment.Building = buildingService.Get(apartment.BuildingId);

            apartment.Building.BuildingManager = buildingManagerService.Get(apartment.Building.BuildingManagerId);

            apartment.ApartmentElectricalInstalationReports = apartmentElectricalInstalationReportService.GetAllByApartmentId(apartment.Id);

            apartment.ApartmentGasInstalationReports = apartmentGasInstalationReportService.GetAllByApartmentId(apartment.Id);

            return RedirectToAction("Details", "Apartment", apartment);
        }
    }
}