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
    public class EmployeesController : Controller
    {

        private IPeopleProRepo p_repo;


        public EmployeesController() : this(new PeopleProRepo()) { }

        public EmployeesController(IPeopleProRepo repo)
        {
            p_repo = repo;
        }

        // GET: Employees
        public ActionResult Index()
        {
            var employees = p_repo.GetEmployees();
            return View(employees);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = p_repo.GetEmployee(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentDepartmentID = new SelectList(p_repo.GetDepartments(), "DepartmentID", "Name");
            ViewBag.BuildingBuildingID = new SelectList(p_repo.GetBuildings(), "BuildingID", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,DepartmentDepartmentID,BuildingBuildingID,FirstName,LastName,DoB,RoomNumber,Title,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                p_repo.SaveEmployee(employee);
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentDepartmentID = new SelectList(p_repo.GetDepartments(), "DepartmentID", "Name", employee.DepartmentDepartmentID);
            ViewBag.BuildingBuildingID = new SelectList(p_repo.GetBuildings(), "BuildingID", "Name", employee.BuildingBuildingID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = p_repo.GetEmployee(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentDepartmentID = new SelectList(p_repo.GetDepartments(), "DepartmentID", "Name", employee.DepartmentDepartmentID);
            ViewBag.BuildingBuildingID = new SelectList(p_repo.GetBuildings(), "BuildingID", "Name", employee.BuildingBuildingID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,DepartmentDepartmentID,BuildingBuildingID,FirstName,LastName,DoB,RoomNumber,Title,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                p_repo.SaveEmployee(employee);
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentDepartmentID = new SelectList(p_repo.GetDepartments(), "DepartmentID", "Name", employee.DepartmentDepartmentID);
            ViewBag.BuildingBuildingID = new SelectList(p_repo.GetBuildings(), "BuildingID", "Name", employee.BuildingBuildingID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = p_repo.GetEmployee(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = p_repo.GetEmployee(id.Value);
            if (employee == null)
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
