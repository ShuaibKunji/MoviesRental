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
            customer = this.checkCust(customer);
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index", "Customers", new { id = customer.CustomerID });
            }

            return View("Index",customer);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include ="email,password")] Credentials user)
        {
            var temp = db.Customers.Where(a => a.Email == user.email).FirstOrDefault();
            if (temp == null)
                ModelState.AddModelError("Email", "This account does not exist");
            else if (temp.Password != user.password)
                ModelState.AddModelError("Password", "Password is incorrect");
            if (ModelState.IsValid)
            {
                if (temp.CustomerID == 1)
                    return RedirectToAction("Index", "Admin");
                else
                    return RedirectToAction("Index", "Customers", new { id = temp.CustomerID });
            }
            return View("Index", user);
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