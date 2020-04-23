using BuildingCondition.Db.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuildingCondition.Db.Context
{
    public class BuildingConditionContext : IdentityDbContext
    {
        public BuildingConditionContext(DbContextOptions<BuildingConditionContext> options) : base(options)
        {

        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ApartmentElectricalInstalationReport> ApartmentElectricalInstalationReports { get; set; }
        public DbSet<ApartmentGasInstalationReport> ApartmentGasInstalationReports { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<BuildingElectricalInstalationReport> BuildingElectricalInstalationReports { get; set; }
        public DbSet<BuildingGasInstalationReport> BuildingGasInstalationReports { get; set; }
        public DbSet<BuildingManager> BuildingManagers { get; set; }
        public DbSet<ElectricalInstallationParametersMeter> ElectricalInstallationParametersMeters { get; set; }
        public DbSet<ElectricalQualificationCertificate> ElectricalQualificationCertificates { get; set; }
        public DbSet<GasDetector> GasDetectors { get; set; }
        public DbSet<GasQualificationCertificate> GasQualificationCertificates { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
