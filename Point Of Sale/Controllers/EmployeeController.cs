﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Point_Of_Sale;

namespace Point_Of_Sale.Controllers
{
    public class EmployeeController : Controller
    {
        private POS_WebEntities db = new POS_WebEntities();

        // GET: Employee
        public ActionResult Index()
        {
            if(Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Index";
                Session["DefaultControll"] = "Employee";
                return RedirectToAction("Login");
            }

            var employees = db.Employees.Include(e => e.City).Include(e => e.EmployeeAdmin);
            return View(employees.ToList());
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.LoginModel loginModel)
        {
            if(ModelState.IsValid)
            {
                var employee = db.Employees.Where(e => e.EmployeeEmail.ToLower() == loginModel.Email.ToLower() && e.EmployeePassword == loginModel.Password).FirstOrDefault();

                if (employee == null)
                {
                    ViewBag.error = "Invalid Email or Password";
                }

                else if(employee.EmployeeAdmin == null)
                {
                    ViewBag.error = "You have to login with Admin Account";
                }

                else
                {
                    Session["Id"] = employee.ID;
                    Session["EmployeeName"] = employee.EmployeeName;
                    Session["type"] = "Admin";

                    if(Session["DefaultView"] == null || Session["DefaultView"].ToString() == "")
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    return RedirectToAction(Session["DefaultView"].ToString(), Session["DefaultControll"].ToString());
                }
            }
            return View(loginModel);
        }

        [HttpGet]
        public ActionResult MyAccount()
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "MyAccount";
                Session["DefaultControll"] = "Employee";
                return RedirectToAction("Login");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["Id"] = "";
            Session["EmployeeName"] = "";
            Session["type"] = "";
            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Details";
                Session["DefaultControll"] = "Employee";
                return RedirectToAction("Login");
            }

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

        // GET: Employee/Create
        public ActionResult Create()
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Create";
                Session["DefaultControll"] = "Employee";
                return RedirectToAction("Login");
            }

            ViewBag.EmployeeCityID = new SelectList(db.Cities, "ID", "CityName");
            ViewBag.ID = new SelectList(db.EmployeeAdmins, "EmployeeID", "EmployeeID");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee, HttpPostedFileBase EmployeePicture)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Create";
                Session["DefaultControll"] = "Employee";
                return RedirectToAction("Login");
            }

            employee.EmployeeJoinDate = DateTime.Now;
            employee.EmployeePicture = System.IO.Path.GetFileName(EmployeePicture.FileName);

            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                EmployeePicture.SaveAs(Server.MapPath("../Images/Uploads/" + employee.ID.ToString() + "_" + employee.EmployeePicture));
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeCityID = new SelectList(db.Cities, "ID", "CityName", employee.EmployeeCityID);
            ViewBag.ID = new SelectList(db.EmployeeAdmins, "EmployeeID", "EmployeeID", employee.ID);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Edit";
                Session["DefaultControll"] = "Employee";
                return RedirectToAction("Login");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeCityID = new SelectList(db.Cities, "ID", "CityName", employee.EmployeeCityID);
            ViewBag.ID = new SelectList(db.EmployeeAdmins, "EmployeeID", "EmployeeID", employee.ID);
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee, HttpPostedFileBase EP)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Edit";
                Session["DefaultControll"] = "Employee";
                return RedirectToAction("Login");
            }

            employee.EmployeeJoinDate = DateTime.Now;
            employee.EmployeePicture = System.IO.Path.GetFileName(EP.FileName);

            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                EP.SaveAs(Server.MapPath("../Images/Uploads/" + employee.ID.ToString() + "_" + employee.EmployeePicture));
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeCityID = new SelectList(db.Cities, "ID", "CityName", employee.EmployeeCityID);
            ViewBag.ID = new SelectList(db.EmployeeAdmins, "EmployeeID", "EmployeeID", employee.ID);
            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Delete";
                Session["DefaultControll"] = "Employee";
                return RedirectToAction("Login");
            }

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

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Delete";
                Session["DefaultControll"] = "Employee";
                return RedirectToAction("Login");
            }

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
