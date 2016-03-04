using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PeopleProTraining.Dal.Models;
using PeopleProTraining.Dal.Interfaces;
using PeopleProTraining.Dal.Infrastructure;

namespace PeopleProTraining.Controllers
{
    public class BuildingsController : Controller
    {
        private IPeopleProRepo p_repo;


        public BuildingsController() : this(new PeopleProRepo()) { }

        public BuildingsController(IPeopleProRepo repo)
        {
            p_repo = repo;
        }

        // GET: Buildings
        public ActionResult Index()
        {
            var buildings = p_repo.GetBuildings();
            return View(buildings);
        }

        // GET: Buildings/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = p_repo.GetBuilding(id.Value);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // GET: Buildings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Buildings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,BuildingID,AddressLine1,AddressLine2,City,State,ZipCode,Country")] Building building)
        {
            if (ModelState.IsValid)
            {
                p_repo.SaveBuilding(building);
                return RedirectToAction("Index");
            }

            return View(building);
        }

        // GET: Buildings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = p_repo.GetBuilding(id.Value);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // POST: Buildings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,BuildingID,AddressLine1,AddressLine2,City,State,ZipCode,Country")] Building building)
        {
            if (ModelState.IsValid)
            {
                p_repo.SaveBuilding(building);
                return RedirectToAction("Index");
            }
            return View(building);
        }

        // GET: Buildings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = p_repo.GetBuilding(id.Value);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // POST: Buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = p_repo.GetBuilding(id.Value);
            if (building == null)
            {
                return HttpNotFound();
            }
            throw new NotImplementedException();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                p_repo.Dispose(disposing);
            }
            base.Dispose(disposing);
        }
    }
}
