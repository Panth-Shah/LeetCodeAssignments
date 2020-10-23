using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeePortal.Models;
using EmployeePortal.Factory.FactoryMethod;
using EmployeePortal.Managers;
using EmployeePortal.Factory.AbstractFactory;
using EmployeePortal.Builder.IBuilder;
using EmployeePortal.Builder.ConcreteBuilder;
using EmployeePortal.Builder.Director;

namespace EmployeePortal.Controllers
{
    public class EmployeesController : BaseController
    {
        private EmployeePortalEntities db = new EmployeePortalEntities();

        // GET: Employees
        [HttpGet]
        public ActionResult BuildSystem(int? employeeID)
        {
            Employee employee = db.Employees.Find(employeeID);
            if (employee.ComputerDetails.Contains("Leptop"))
            {
                return View("BuildLeptop", employeeID);
            }
            else
            {
                return View("BuildDesktop", employeeID);
            }
        }
        [HttpPost]
        public ActionResult BuildDesktop(FormCollection formcollection)
        {
            //Step 1
            Employee employee = db.Employees.Find(Convert.ToInt32(formcollection["employeeID"]));
            //Step 2 Concrete Build
            ISystemBuilder systemBuilder = new DesktopBuilder();
            //Step 3: Director
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.BuildSystem(systemBuilder, formcollection);
            //Step 4: Reuturn System Built
            ComputerSystem system = systemBuilder.GetSystem();

            employee.SystemConfiguration = string.Format("RAM : {0}, Keyboard: {1}, Mouse: {2}, Touchscreen: {3}, HDDDrive: {4}", 
                system.RAM, system.KeyBoard, system.Mouse, system.TouchScreen, system.HDDSize);
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Employee_Type);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeTypeID = new SelectList(db.Employee_Type, "Id", "EmployeeType");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,JobDescription,Number,Department,HourlyPay,Bonus,EmployeeTypeID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                BaseEmployeeFactory employeeManagerFactory = new EmployeeManagerFactory().CreateFactory(employee);
                employeeManagerFactory.ApplySalary();
                IComputerFactory factory = new EmployeeSystemFactory().Create(employee);
                EmployeeSystemManager manager = new EmployeeSystemManager(factory);
                employee.ComputerDetails = manager.GetSystemDetails();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeTypeID = new SelectList(db.Employee_Type, "Id", "EmployeeType", employee.EmployeeTypeID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeTypeID = new SelectList(db.Employee_Type, "Id", "EmployeeType", employee.EmployeeTypeID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,JobDescription,Number,Department,HourlyPay,Bonus,EmployeeTypeID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeTypeID = new SelectList(db.Employee_Type, "Id", "EmployeeType", employee.EmployeeTypeID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
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
