namespace parking.Migrations
{
    using Models.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<parking.Models.Domain.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(parking.Models.Domain.Context context)
        {
            var braduParkingLot = new ParkingLot {
                Latitude = 44.832725,
                Longitude = 24.881553,
                MaxSpaces = 30,
                Name = "Bradu VIP Parking",
                Token = "secretbradu"
            };

            context.ParkingLots.AddOrUpdate(pl => new { pl.Name, pl.Latitude, pl.Longitude }, braduParkingLot);


            context.SaveChanges();

        }
    }
}
