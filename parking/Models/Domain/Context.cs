namespace parking.Models.Domain
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<ParkingLot> ParkingLots { get; set; }
        public virtual DbSet<ParkingLotStatus> ParkingLotStatuses { get; set; }
        public virtual DbSet<UserPreference> UserPreferences { get; set; }
    }
}