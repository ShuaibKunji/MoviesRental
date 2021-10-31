using MoviesRental.DAL;
using MoviesRental.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesRental.Controllers
{
    public class HomeController : BaseController
    {
        private StoreContext db = new StoreContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "CustomerID,CName,Email,Password,Address,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index", "Customers", new { id = customer.CustomerID });
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include ="email,password")] Credentials user)
        {
            if(ModelState.IsValid)
            {
                var temp = db.Customers.Where(a => a.Email == user.email).FirstOrDefault();
                if (temp == null)
                    return RedirectToAction("Index", "Home");
                else if (temp.Password == user.password)
                {
                    if (temp.CustomerID == 1)
                        return RedirectToAction("Index", "Admin");
                    else
                        return RedirectToAction("Index", "Customers", new { id = temp.CustomerID });
                }
                else
                    return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
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