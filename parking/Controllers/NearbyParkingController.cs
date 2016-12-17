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
using parking.Models.TOs;
using AutoMapper;

namespace parking.Controllers
{
    [Authorize]
    public class NearbyParkingController : Controller
    {
        private Context db;

        private IMapper myMapper;

        public NearbyParkingController(IMapper mapper, Context injectedDb)
        {
            myMapper = mapper;
            db = injectedDb;
        }

        // GET: NearbyParking
        public async Task<ActionResult> Index()
        {
            var allParkingLots = (await db.ParkingLots
                .OrderBy(pl => pl.Name)
                .ToListAsync())
                .Select(pl => myMapper.Map<ParkingLot, ParkingLotForMap>(pl))
                .ToList();
            return Json(allParkingLots, JsonRequestBehavior.AllowGet);
        }
    }

}
