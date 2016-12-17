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

namespace parking.Controllers
{
    [Authorize]
    public class ParkingLotsController : Controller
    {
        private readonly Context db; //readonly TODO

        public ParkingLotsController(Context injectedDb)
        {
            db = injectedDb;
        }

        // GET: ParkingLots
        public async Task<ActionResult> Index()
        {
            var allParkingLots = await db.ParkingLots
                .OrderBy(pl => pl.Name)
                .ToListAsync();
            return View(allParkingLots);
        }

        // GET: ParkingLots/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLot parkingLot = await db.ParkingLots.FindAsync(id);
            if (parkingLot == null)
            {
                return HttpNotFound();
            }
            return View(parkingLot);
        }

        // GET: ParkingLots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParkingLots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Create(ParkingLot parkingLot)
        {
            if (ModelState.IsValid)
            {
                db.ParkingLots.Add(parkingLot);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(parkingLot);
        }

        // GET: ParkingLots/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLot parkingLot = await db.ParkingLots.FindAsync(id);
            if (parkingLot == null)
            {
                return HttpNotFound();
            }
            return View(parkingLot);
        }

        // POST: ParkingLots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Edit(ParkingLot parkingLot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkingLot).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(parkingLot);
        }

        // GET: ParkingLots/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingLot parkingLot = await db.ParkingLots.FindAsync(id);
            if (parkingLot == null)
            {
                return HttpNotFound();
            }
            return View(parkingLot);
        }

        // POST: ParkingLots/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ParkingLot parkingLot = await db.ParkingLots.FindAsync(id);
            db.ParkingLots.Remove(parkingLot);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
