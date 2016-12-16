using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace parking.Models.Domain
{
    public class ParkingLotStatus
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public int ParkingLotId { get; set; }

        public ParkingLot ParkingLot { get; set; }

        public int FreeSpaces { get; set; }

        public DateTime ReporingDateTime { get; set; }

        public byte[] Photo { get; set; }
    }
}