using PruebaScisa.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaScisa.Controllers
{
    
    public class LoginController : Controller
    {

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult TryLogin(string user, string pass)
        {
            using (var db = new ApplicationDBContext())
            {
                var singleUser = (from u in db.Users where u.UserName == user && u.Password ==pass select u).FirstOrDefault();
                var result = new {R=0};
                if (singleUser != null)
                {
                    result = new
                    {
                        R = 1
                    };
                    Session["Name"] = singleUser.UserName;
                    Session["Type"] = singleUser.Type;
                }
                else
                {
                    result = new
                    {
                        R = 0
                    };
                }

                return Json(result);

            }


        }
        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
