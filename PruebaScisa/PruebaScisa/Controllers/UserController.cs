using PruebaScisa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaScisa.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext(); 

        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetUsers()
        {
            var users = db.Users.Select(u => new
            {
                id = u.Id,
                userName = u.UserName,
                password = u.Password,
                type = u.Type
            }).ToList();
            return Json(new { data = users }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult AddUser(Users user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                return Json(new { success = false, message = "Invalid model state" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public ActionResult GetUserById(int id)
        {
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound(); // Or return an appropriate error response
            }

            var userData = new
            {
                id = user.Id,
                userName = user.UserName,
                password = user.Password,
                type = user.Type
            };

            return Json(userData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateUser(Users user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                return Json(new { success = false, message = "Invalid model state" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                return Json(new { success = false, message = "User not found" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
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
