using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using parking.Models.Domain;
using System.Data.Entity.Infrastructure;

namespace parking.Controllers
{   
    [Authorize]
    public class NearbyParkingController : Controller
    {
        private Context db = new Context();

        // GET: NearbyParking
        public async Task<ActionResult> Index()
        {
            var allParkingLots = await db.ParkingLots
                .OrderBy(pl => pl.Name)
                .Select(pl => new ParkingLot
                {
                    Id = pl.Id,
                    Name = pl.Name,
                    Latitude = pl.Latitude,
                    Longitude=pl.Longitude
                })
                .ToListAsync();
          //  return View(await db.ParkingLots.ToListAsync());
            return Json(allParkingLots, JsonRequestBehavior.AllowGet);
        }
    }
        
}
