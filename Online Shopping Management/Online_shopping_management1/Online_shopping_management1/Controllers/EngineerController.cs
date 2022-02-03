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
    public class EngineerController : Controller
    {
        online_stationaryEntities1 db = new online_stationaryEntities1();
        public ActionResult profile()

        {
            ViewBag.msg = "Profile";
            if (Session["Empid"] != null)
            {

                int id = Convert.ToInt32(Session["user_id"]);
                Emp E1 = db.Emps.Find(id);
                return View(E1);
            }
            else
            {
                return RedirectToAction("login", "Main");
            }
        }
        public ActionResult Index(Emp e1, Order_table orderTable)
        {
            if (Session["user_id"] != null)
            {
                ViewBag.Msg = "Home";

                Session["Empid"] = e1.empid;

                return View(db.Order_table.ToList());

            }
            else
            {
                return RedirectToAction("login", "Main");
            }

        }
        public ActionResult Request_Stationary()
        {
            ViewBag.s_id = new SelectList(db.Stationaries, "s_id", "Stationary_Name");
            return View();
        }
        [HttpPost]
        public ActionResult Request_Stationary(Order_table ot, Stationary st, Stat sa)
        {

            ot.Date_Of_Order = DateTime.Now;
            ot.Stationary_id = st.s_id;
            ot.Statid = 1;
            ViewBag.s_id = new SelectList(db.Stationaries, "s_id", "Stationary_Name");
            ot.Empid = Convert.ToInt32(Session["user_id"]);
            db.Order_table.Add(ot);
            db.SaveChanges();
            return RedirectToAction("View_Request", "Engineer");
        }
        public ActionResult Change_Password()
        {

            int id = Convert.ToInt32(Session["user_id"]);
            Emp e1 = db.Emps.Find(id);

            return View(e1);
        }
        [HttpPost]
        public ActionResult Change_password(Emp Es)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String Passwordhash = Crypto.HashPassword(Es.Pass);
                    Es.Pass = Passwordhash;
                    db.Entry(Es).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Engineer");
                }
                catch (Exception ex)
                {
                    ViewBag.Ex = "Enter The Password";
                    return View(ex);

                }
            }

            return View(Es);
        }
        public ActionResult View_Request(Order_table ot, Stationary st)
        {

            int id = Convert.ToInt32(Session["user_id"]);


            return View(db.Order_table.Where(x => x.Emp.empid == id).ToList());
        }

     
        public ActionResult Edit(int id)
        {
            Order_table ot = db.Order_table.Find(id);
            ViewBag.s_id = new SelectList(db.Stationaries, "s_id", "Stationary_Name");
            return View(ot);
        }
        [HttpPost]
        public ActionResult Edit(Order_table ot, Stationary st, int id)
        {

            db.Entry(ot).State = EntityState.Modified;
            ot.Date_Of_Order = DateTime.Now;
            ot.Stationary_id = st.s_id;
            ot.Statid = 1;
            ViewBag.s_id = new SelectList(db.Stationaries, "s_id", "Stationary_Name");
            ot.Empid = Convert.ToInt32(Session["user_id"]);
            db.SaveChanges();
            return RedirectToAction("View_Request", "Engineer");

        }
   
        public ActionResult Cancel(int id)
        {
            Order_table ot = db.Order_table.Find(id);
            return View(ot);
        }
        [HttpPost]
        public ActionResult Cancel(int id, Order_table ot)
        {



            ot = db.Order_table.Find(id);
            db.Entry(ot).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("View_Request", "Engineer");

        }
        public ActionResult F_A_Q()
        {
            return View();
        }

    }
}