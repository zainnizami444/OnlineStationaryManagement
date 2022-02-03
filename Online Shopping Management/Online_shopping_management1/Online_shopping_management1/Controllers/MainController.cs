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
    public class MainController : Controller
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
                return RedirectToAction("login","Main");
            }
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Emp es)
        {
            var result = db.Emps.Where(x => x.Email_Adress == es.Email_Adress).SingleOrDefault();
            try
            {
                if (Crypto.VerifyHashedPassword(result.Pass, es.Pass) && result.emp_role == "Manager")
                {
                    Session["user_id"] = result.empid;
                    Session["user"] = result.Username;
                    Session["Person_Role"] = result.emp_role;



                    return RedirectToAction("Index","Main");

                }
                else if (Crypto.VerifyHashedPassword(result.Pass, es.Pass) && result.emp_role == "Manager Director")
                {
                    Session["user_id"] = result.empid;
                    Session["user"] = result.Username;
                    Session["Person_Role"] = result.emp_role;

                    return RedirectToAction("Index", "Managing_Diector");
                

                }
                else if (Crypto.VerifyHashedPassword(result.Pass, es.Pass) && result.emp_role == "Business Director")
                {
                    Session["user_id"] = result.empid;
                    Session["user"] = result.Username;
                    Session["Person_Role"] = result.emp_role;

                    return RedirectToAction("Index", "Business_Director");

                }
                else if (Crypto.VerifyHashedPassword(result.Pass, es.Pass) && result.emp_role == "Engineer")
                {
                    Session["user_id"] = result.empid;
                    Session["user"] = result.Username;
                    Session["Person_Role"] = result.emp_role;

                    return RedirectToAction("Index", "Engineer");

                }
                else
                {
                    ViewBag.msg = "Invalid Username";

                }
            }
            catch (Exception ex)
            {
                Session["Invalid"] = "Invalid Login";
                return View(ex);

            }
            return View();
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
                return RedirectToAction("login","Main");
            }

        }
        public ActionResult Request_Stationary()
        {
            ViewBag.s_id = new SelectList(db.Stationaries, "s_id", "Stationary_Name");
            return View();
        }
        [HttpPost]
        public ActionResult Request_Stationary(Order_table ot, Stationary st,Stat sa)
        {

            ot.Date_Of_Order = DateTime.Now;
            ot.Stationary_id = st.s_id;
            ot.Statid = 1;
            ViewBag.s_id = new SelectList(db.Stationaries, "s_id", "Stationary_Name");
            ot.Empid = Convert.ToInt32(Session["user_id"]);
            db.Order_table.Add(ot);
            db.SaveChanges();
            return RedirectToAction("View_Request", "Main");
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
                    return RedirectToAction("Index", "Main");
                }
                catch (Exception ex) 
                {
                    ViewBag.Ex = "Enter The Password";
                    return View(ex);
                
                }
            }

            return View(Es);
        }
        public ActionResult View_Request(Order_table ot,Stationary st)
        {

            int id = Convert.ToInt32(Session["user_id"]);

           
            return View(db.Order_table.Where(x=>x.Emp.empid == id).ToList());
        }
       
        public ActionResult Order_View(Order_table ot)
        {

            return View(db.Order_table.ToList().OrderByDescending(x => x.oid));
        }
        public ActionResult Edit(int id)
        {
            Order_table ot = db.Order_table.Find(id);
            ViewBag.s_id = new SelectList(db.Stationaries, "s_id", "Stationary_Name");
            return View(ot);
        }
        [HttpPost]
        public ActionResult Edit(Order_table ot,Stationary st,int id)
        {
           
                db.Entry(ot).State = EntityState.Modified;
                ot.Date_Of_Order = DateTime.Now;
                ot.Stationary_id = st.s_id;
                ot.Statid =1;
                ViewBag.s_id = new SelectList(db.Stationaries, "s_id", "Stationary_Name");
                ot.Empid = Convert.ToInt32(Session["user_id"]);
                db.SaveChanges();
                return RedirectToAction("View_Request","Main");
           
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
        public ActionResult AcceptOrReject(Order_table ot, Stationary st, int id,Stat sa , Emp ea)
        {


                db.Entry(ot).State = EntityState.Modified;
                ot.Date_Of_Order = DateTime.Now;
                db.SaveChanges();
             
          
            ViewBag.Empid = new SelectList(db.Emps, "empid", "emp_name", ot.Empid);
            ViewBag.Stationary_id = new SelectList(db.Stationaries, "s_id", "Stationary_Name", ot.Stationary_id);
            ViewBag.Statid = new SelectList(db.Stats, "stid", "Status_name", ot.Statid);
         return RedirectToAction("View_Orders", "Main");

        }
        public ActionResult Cancel(int id )
        {
           Order_table ot = db.Order_table.Find(id);
            return View(ot);
        }
        [HttpPost]
        public ActionResult Cancel(int id,Order_table ot)
        {


            
                ot = db.Order_table.Find(id);
                db.Entry(ot).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("View_Request", "Main");
   
        }
        public ActionResult View_Orders(Emp es)
        {
            
            return View(db.Order_table.Where(x=>x.Emp.emp_role=="Engineer").ToList());
        }
        [HttpPost]
        public ActionResult View_Orders(Emp es ,Order_table ot)
        {
            var result = db.Order_table.Where(x => x.Empid == es.empid).SingleOrDefault();
            Session["Emp_id"] = result.Empid;
            Session["date"] = result.Date_Of_Order;
            Session["Stationary_id"] = result.Stationary_id;
            Session["oid"] = result.oid;
            Session["quantity"] = result.Quantity;
            return View();
        }
       
        public ActionResult logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("login","Main");
        }
      
        public ActionResult Forget_password()
        {
            
            return View();
        }
        [HttpPost]
        public   ActionResult Forget_password(Emp es)
        {
            var result = db.Emps.Where(x => x.Email_Adress == es.Email_Adress).SingleOrDefault();
            if (result != null)
            {

                Session["Forget_Password_id"] = result.empid;
                return RedirectToAction("Forget_password_change","Main");

            }
            else 
            {
                ViewBag.msg = "Invaild Email";
            
            }
                
           
            return View();
        }
        public ActionResult Forget_password_change()
        {
            int id = Convert.ToInt32(Session["Forget_Password_id"]);

            Emp e1 = db.Emps.Find(id);

            return View(e1);
        }
        [HttpPost]
        public ActionResult Forget_password_change(Emp Es)
        {
            if (ModelState.IsValid)
            {
                String Passwordhash = Crypto.HashPassword(Es.Pass);
                Es.Pass = Passwordhash;
                db.Entry(Es).State = EntityState.Modified;
                db.SaveChanges();
                
                return RedirectToAction("login","Main");
            }

            return View(Es);
        }
        public ActionResult F_A_Q(){
            return View();
        }
    }
}