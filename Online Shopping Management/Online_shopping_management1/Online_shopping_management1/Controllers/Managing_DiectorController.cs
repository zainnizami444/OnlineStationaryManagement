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
    public class Managing_DiectorController : Controller
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
                    return RedirectToAction("Index", "Managing_Director");
                }
                catch (Exception ex)
                {
                    ViewBag.Ex = "Enter The Password";
                    return View(ex);

                }
            }

            return View(Es);
        }


        public ActionResult AcceptOrReject(int? id)
        {
            Order_table order_table = db.Order_table.Find(id);

            ViewBag.Empid = new SelectList(db.Emps, "empid", "emp_name", order_table.Empid);
            ViewBag.Stationary_id = new SelectList(db.Stationaries, "s_id", "Stationary_Name", order_table.Stationary_id);
            ViewBag.Statid = new SelectList(db.Stats, "stid", "Status_name", order_table.Statid);
            return View(order_table);

        }
        [HttpPost]
        public ActionResult AcceptOrReject(Order_table ot, Stationary st, int id, Stat sa, Emp ea)
        {


            db.Entry(ot).State = EntityState.Modified;
            ot.Date_Of_Order = DateTime.Now;
            db.SaveChanges();


            ViewBag.Empid = new SelectList(db.Emps, "empid", "emp_name", ot.Empid);
            ViewBag.Stationary_id = new SelectList(db.Stationaries, "s_id", "Stationary_Name", ot.Stationary_id);
            ViewBag.Statid = new SelectList(db.Stats, "stid", "Status_name", ot.Statid);
            return RedirectToAction("View_Orders", "Managing_Diector");

        }

        public ActionResult View_Orders(Emp es)
        {

            return View(db.Order_table.Where(x => x.Emp.emp_role == "Business Director").ToList());
        }
        [HttpPost]
        public ActionResult View_Orders(Emp es, Order_table ot)
        {
            var result = db.Order_table.Where(x => x.Empid == es.empid).SingleOrDefault();
            Session["Emp_id"] = result.Empid;
            Session["date"] = result.Date_Of_Order;
            Session["Stationary_id"] = result.Stationary_id;
            Session["oid"] = result.oid;
            Session["quantity"] = result.Quantity;
            return View();
        }
        public ActionResult F_A_Q()
        {
            return View();
        }
    }
}