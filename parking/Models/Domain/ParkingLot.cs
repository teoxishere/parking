using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace parking.Models.Domain
{
    public class ParkingLot
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        public int MaxSpaces { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [MaxLength(64)]
        [Required]
        public string Token { get; set; }

        public virtual ICollection<ParkingLotStatus> ParkingLotStatuses { get; set; }
    }
}