using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingCondition.Db.Models
{
    public class ApartmentGasInstalationReport
    {
        public int Id { get; set; }
        public DateTime DateOfInspection { get; set; }
        public bool ForPremisesOrCollectiveOrSeal { get; set; }
        public bool AssessmentOfGasMeterAccuracy { get; set; }
        public bool TheGasMeterConnectionsWithTheInstallation { get; set; }
        public bool VentilationOfTheGasMeterCabinet { get; set; }
        public bool SecuringTheGasMeterAgainstUnauthorizedAccessAndAccessToTheGasMeter { get; set; }
        public bool ConditionOfPipeWallsAndFittings { get; set; }
        public bool InstallationTightness { get; set; }
        public bool ConditionOfAnticorrosiveCoating { get; set; }
        public bool IntersectionsOfGasInstallationsWithOtherPipes { get; set; }
        public bool FasteningGasInstallationsAndPipes { get; set; }
        public bool CookerFittingsAccessibilityToTheShutoffValve { get; set; }
        public bool CookerFittingsTheTightnessOfTheGasShutoffValve { get; set; }
        public bool CookerFittingsOperationOfTheGasShutoffValve { get; set; }
        public bool CookerFittingsRoomVentilationWithGasReceiverVentilationGrille { get; set; }
        public bool CookerFittingsTechnicalConditionOfGasDevicesAndConnectionsToFlueGasDucts { get; set; }
        public bool BathroomStoveFittingsAccessibilityToTheShutoffValve { get; set; }
        public bool BathroomStoveFittingsTheTightnessOfTheGasShutoffValve { get; set; }
        public bool BathroomStoveFittingsOperationOfTheGasShutoffValve { get; set; }
        public bool BathroomStoveFittingsRoomVentilationWithGasReceiverVentilationGrille { get; set; }
        public bool BathroomStoveFittingsTechnicalConditionOfGasDevicesAndConnectionsToFlueGasDucts { get; set; }
        public bool KitchenStoveFittingsAccessibilityToTheShutoffValve { get; set; }
        public bool KitchenStoveFittingsTheTightnessOfTheGasShutoffValve { get; set; }
        public bool KitchenStoveFittingsOperationOfTheGasShutoffValve { get; set; }
        public bool KitchenStoveFittingsRoomVentilationWithGasReceiverVentilationGrille { get; set; }
        public bool KitchenStoveFittingsTechnicalConditionOfGasDevicesAndConnectionsToFlueGasDucts { get; set; }
        public string GaseousFuelConcentration { get; set; }
        public string Location { get; set; }
        public DateTime? DeadlineForDeletion { get; set; }
        public bool ShutOffTheGasSupply { get; set; }
        public string CommentsAndPostInspectionRecommendationsToBeMadeByTheManagerOrOwner { get; set; }
        public string CommentsAndPostInspectionRecommendationsToBeMadeByTheGasSupplier { get; set; }
        public string CommentsAndPostInspectionRecommendationsToBeMadeByTheApartmentUser { get; set; }
        public bool FurtherOperationOfTheInstallationInThePremises { get; set; }
        public DateTime DateOfNextInspection { get; set; }
        public string SignatureOfThePremisesUser { get; set; }

        [ForeignKey("Apartment")]
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

        [ForeignKey("GasDetector")]
        public int GasDetectorId { get; set; }
        public GasDetector GasDetector{ get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}