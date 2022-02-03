using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Online_shopping_management1.Models;
namespace Online_shopping_management1.Controllers
{
    public class AdminController : Controller
    {
        online_stationaryEntities1 db = new online_stationaryEntities1();

        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(admin_table ad)
        {
            try {
                var result = db.admin_table.Where(x => x.admin_Email == ad.admin_Email && x.Pass == ad.Pass).SingleOrDefault();
                if (result != null)
                {
                    Session["Adid"] = result.adid;
                    return RedirectToAction("View_Stationary","Admin");
                }
                else
                {
                    ViewBag.msg = "invalid login";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.msg = "Invalid Email Or Password";
                return View(ex);
            }


        }
        public ActionResult Employee_Edit(int? id)
        {
            Emp emp = db.Emps.Find(id);
            return View(emp);
        }

        // POST: Emps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Employee_Edit([Bind(Include = "empid,emp_name,emp_role,emp_contact,Email_Adress,Username,Pass")] Emp emp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
        }


        public ActionResult Create_Employee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create_employee(Emp e1)
            {
            ViewBag.msg = "Register Employee";
             db.Emps.Add(e1);     
             string empPassword = Crypto.HashPassword(e1.Pass);
             e1.Pass = empPassword;
             db.SaveChanges();
             return RedirectToAction("View_Employees","Admin");
            }
        public ActionResult Stationary()
        {
           return View();
        }
        [HttpPost]
        public ActionResult Stationary(Stationary stat)
        {

            db.Stationaries.Add(stat);
            db.SaveChanges();
            return Redirect("View_Stationary");
        }
        public ActionResult View_Stationary()
        {
            if (Session["Adid"] != null)
            {
                ViewBag.msg = "Stationary";
                return View(db.Stationaries.ToList());
            }
            else
            {
                return RedirectToAction("login","Admin");
            }
            
        
        }
        public ActionResult View_Employees()
        {
           
            return View(db.Emps.ToList());

        }
        public ActionResult Edit_Stationary(int id)
        {
            Stationary st = db.Stationaries.Find(id);
            return View(st);

        }
        [HttpPost]
        public ActionResult Edit_Stationary(Stationary st)
        {
            db.Entry(st).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("View_Stationary","Admin");

        }
        public ActionResult logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("login","Admin");
        }
    }
}