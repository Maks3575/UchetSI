using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UchetSI.Data.Models;

namespace UchetSI.Data.Models
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options
            ) : base(options) {

        }

        public DbSet<Location> Locations { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<TypeLocation> TypeLocations { get; set; } = null!;
        public DbSet<History> Histories { get; set; } = null!;
        public DbSet<DescriptionMI> DescriptionMIs { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;

        public DbSet<MeashuringTool> MeashuringTools { get; set; } = null!;
        public DbSet<Maker> Makers { get; set; } = null!;

        public DbSet<OutputSignal> OutputSignals { get; set; } = null!;
        public DbSet<MeasurementLimit> MeasurementLimits { get; set; } = null!;
        public DbSet<DescriptionOfEquipment> DescriptionOfEquipments{ get; set; } = null!;
        public DbSet<TypeOfEquipment> TypeOfEquipments { get; set; } = null!;
        public DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; } = null!;
        public DbSet<VerificationInterval> VerificationInterval { get; set; } = null!;
        public DbSet<StatusOfMT> StatusOfMTs { get; set; } = null!;
       
        public ApplicationContext()
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<Location>().HasData(new Location { LocationId = 1, NameLocation = "Ярегаэнергонефть" });

            //modelBuilder.Entity<Location>().HasData(new Location { LocationId = 2, NameLocation = "ПГУ Север" });


            //modelBuilder.Entity<Position>().HasData(new Position { Id = 1, NamePosition = "LT311", LocatonId = 2, Paz = true });
            //modelBuilder.Entity<Position>().HasData(new Position { Id = 2, NamePosition = "LT444", LocatonId = 2, Paz = true });
        }
    }
       
}
