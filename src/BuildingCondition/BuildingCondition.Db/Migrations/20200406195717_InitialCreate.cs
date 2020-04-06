using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingCondition.Db.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingManagers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingManagers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectricalInstallationParametersMeters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastCalibrationDate = table.Column<DateTime>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    NextCalibrationDate = table.Column<DateTime>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricalInstallationParametersMeters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GasDetectors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastCalibrationDate = table.Column<DateTime>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    NextCalibrationDate = table.Column<DateTime>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GasDetectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QualificationCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateNumber = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualificationCertificates_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    BuildingNumber = table.Column<string>(nullable: true),
                    BuildingManagerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_BuildingManagers_BuildingManagerId",
                        column: x => x.BuildingManagerId,
                        principalTable: "BuildingManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentNumber = table.Column<string>(nullable: true),
                    GateNumber = table.Column<string>(nullable: true),
                    BuildingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartments_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildingElectricalInstalationReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<int>(nullable: false),
                    ElectricalInstallationParametersMeterId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingElectricalInstalationReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingElectricalInstalationReports_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingElectricalInstalationReports_ElectricalInstallationParametersMeters_ElectricalInstallationParametersMeterId",
                        column: x => x.ElectricalInstallationParametersMeterId,
                        principalTable: "ElectricalInstallationParametersMeters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingElectricalInstalationReports_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuildingGasInstalationReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<int>(nullable: false),
                    GasDetectorId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingGasInstalationReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingGasInstalationReports_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingGasInstalationReports_GasDetectors_GasDetectorId",
                        column: x => x.GasDetectorId,
                        principalTable: "GasDetectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingGasInstalationReports_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentElectricalInstalationReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentId = table.Column<int>(nullable: false),
                    ElectricalInstallationParametersMeterId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentElectricalInstalationReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentElectricalInstalationReports_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartmentElectricalInstalationReports_ElectricalInstallationParametersMeters_ElectricalInstallationParametersMeterId",
                        column: x => x.ElectricalInstallationParametersMeterId,
                        principalTable: "ElectricalInstallationParametersMeters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartmentElectricalInstalationReports_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentGasInstalationReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfInspection = table.Column<DateTime>(nullable: false),
                    ForPremisesOrCollectiveOrSeal = table.Column<bool>(nullable: false),
                    AssessmentOfGasMeterAccuracy = table.Column<bool>(nullable: false),
                    TheGasMeterConnectionsWithTheInstallation = table.Column<bool>(nullable: false),
                    VentilationOfTheGasMeterCabinet = table.Column<bool>(nullable: false),
                    SecuringTheGasMeterAgainstUnauthorizedAccessAndAccessToTheGasMeter = table.Column<bool>(nullable: false),
                    ConditionOfPipeWallsAndFittings = table.Column<bool>(nullable: false),
                    InstallationTightness = table.Column<bool>(nullable: false),
                    ConditionOfAnticorrosiveCoating = table.Column<bool>(nullable: false),
                    IntersectionsOfGasInstallationsWithOtherPipes = table.Column<bool>(nullable: false),
                    FasteningGasInstallationsAndPipes = table.Column<bool>(nullable: false),
                    CookerFittingsAccessibilityToTheShutoffValve = table.Column<bool>(nullable: false),
                    CookerFittingsTheTightnessOfTheGasShutoffValve = table.Column<bool>(nullable: false),
                    CookerFittingsOperationOfTheGasShutoffValve = table.Column<bool>(nullable: false),
                    CookerFittingsRoomVentilationWithGasReceiverVentilationGrille = table.Column<bool>(nullable: false),
                    CookerFittingsTechnicalConditionOfGasDevicesAndConnectionsToFlueGasDucts = table.Column<bool>(nullable: false),
                    BathroomStoveFittingsAccessibilityToTheShutoffValve = table.Column<bool>(nullable: false),
                    BathroomStoveFittingsTheTightnessOfTheGasShutoffValve = table.Column<bool>(nullable: false),
                    BathroomStoveFittingsOperationOfTheGasShutoffValve = table.Column<bool>(nullable: false),
                    BathroomStoveFittingsRoomVentilationWithGasReceiverVentilationGrille = table.Column<bool>(nullable: false),
                    BathroomStoveFittingsTechnicalConditionOfGasDevicesAndConnectionsToFlueGasDucts = table.Column<bool>(nullable: false),
                    KitchenStoveFittingsAccessibilityToTheShutoffValve = table.Column<bool>(nullable: false),
                    KitchenStoveFittingsTheTightnessOfTheGasShutoffValve = table.Column<bool>(nullable: false),
                    KitchenStoveFittingsOperationOfTheGasShutoffValve = table.Column<bool>(nullable: false),
                    KitchenStoveFittingsRoomVentilationWithGasReceiverVentilationGrille = table.Column<bool>(nullable: false),
                    KitchenStoveFittingsTechnicalConditionOfGasDevicesAndConnectionsToFlueGasDucts = table.Column<bool>(nullable: false),
                    GaseousFuelConcentration = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    DeadlineForDeletion = table.Column<DateTime>(nullable: true),
                    ShutOffTheGasSupply = table.Column<bool>(nullable: false),
                    CommentsAndPostInspectionRecommendationsToBeMadeByTheManagerOrOwner = table.Column<string>(nullable: true),
                    CommentsAndPostInspectionRecommendationsToBeMadeByTheGasSupplier = table.Column<string>(nullable: true),
                    CommentsAndPostInspectionRecommendationsToBeMadeByTheApartmentUser = table.Column<string>(nullable: true),
                    FurtherOperationOfTheInstallationInThePremises = table.Column<bool>(nullable: false),
                    DateOfNextInspection = table.Column<DateTime>(nullable: false),
                    SignatureOfThePremisesUser = table.Column<string>(nullable: true),
                    ApartmentId = table.Column<int>(nullable: false),
                    GasDetectorId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentGasInstalationReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentGasInstalationReports_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartmentGasInstalationReports_GasDetectors_GasDetectorId",
                        column: x => x.GasDetectorId,
                        principalTable: "GasDetectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartmentGasInstalationReports_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentElectricalInstalationReports_ApartmentId",
                table: "ApartmentElectricalInstalationReports",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentElectricalInstalationReports_ElectricalInstallationParametersMeterId",
                table: "ApartmentElectricalInstalationReports",
                column: "ElectricalInstallationParametersMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentElectricalInstalationReports_UserId",
                table: "ApartmentElectricalInstalationReports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentGasInstalationReports_ApartmentId",
                table: "ApartmentGasInstalationReports",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentGasInstalationReports_GasDetectorId",
                table: "ApartmentGasInstalationReports",
                column: "GasDetectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentGasInstalationReports_UserId",
                table: "ApartmentGasInstalationReports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_BuildingId",
                table: "Apartments",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingElectricalInstalationReports_BuildingId",
                table: "BuildingElectricalInstalationReports",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingElectricalInstalationReports_ElectricalInstallationParametersMeterId",
                table: "BuildingElectricalInstalationReports",
                column: "ElectricalInstallationParametersMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingElectricalInstalationReports_UserId",
                table: "BuildingElectricalInstalationReports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingGasInstalationReports_BuildingId",
                table: "BuildingGasInstalationReports",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingGasInstalationReports_GasDetectorId",
                table: "BuildingGasInstalationReports",
                column: "GasDetectorId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingGasInstalationReports_UserId",
                table: "BuildingGasInstalationReports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_BuildingManagerId",
                table: "Buildings",
                column: "BuildingManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_QualificationCertificates_UserId",
                table: "QualificationCertificates",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentElectricalInstalationReports");

            migrationBuilder.DropTable(
                name: "ApartmentGasInstalationReports");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BuildingElectricalInstalationReports");

            migrationBuilder.DropTable(
                name: "BuildingGasInstalationReports");

            migrationBuilder.DropTable(
                name: "QualificationCertificates");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ElectricalInstallationParametersMeters");

            migrationBuilder.DropTable(
                name: "GasDetectors");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "BuildingManagers");
        }
    }
}
