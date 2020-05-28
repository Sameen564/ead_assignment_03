using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Linq.Mapping;
using cms.Models;
using Microsoft.Ajax.Utilities;

namespace cms.Controllers
{
    public class HomeController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult addteacher()
        {
            return View();
        }
        public ActionResult teacheradd()
        {
            
            String name = Request.Form["username"];
            String number = Request.Form["contact"];
            String email = Request.Form["email"];
            String type = Request.Form["category"];
            Table t = new Table();
            t.username = name;
            t.email = email;
            t.category = type;
            t.contact = number;
            db.Tables.InsertOnSubmit(t);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        public ActionResult update()
        {
            return View();
        }
        public ActionResult updateteacher()
        {
            String name = Request.Form["uname"];
            String naam = Request.Form["unaam"];
            String number = Request.Form["con"];
            String email = Request.Form["email"];
            String type = Request.Form["category"];
            String no = Request["id"];
            int id = Convert.ToInt32(no);
            Table t = db.Tables.First(a => a.username.Equals(naam));
            t.username = name;
            t.email = email;
            t.category = type;
            t.contact = number;
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        public ActionResult viewteacher()
        {
            List<Table> db_tab = db.Tables.ToList<Table>();
            List<Table> tab = new List<Table>();
            if (db_tab != null)
            {
                foreach (var q in db_tab)
                {

                    tab.Add(q);
                }
            }
            if (tab != null)
                return View(db.Tables.DistinctBy(i=>i.category).ToList());
            else return View();
        }
        public ActionResult showteacher()
        {
            String type = Request.Form["category"];
            List<Table> db_tab = db.Tables.ToList<Table>();
            List<Table> tab = new List<Table>();
            if (db_tab != null)
            {
                foreach (var q in db_tab)
                {
                    if(q.category== type)
                    tab.Add(q);
                }
            }
            if (tab != null)
                return View(tab);
            else return View();
        }
    } 
}