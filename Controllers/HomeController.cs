using MoviesRental.DAL;
using MoviesRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesRental.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();
        public ActionResult Index()
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

            return View(customer);
        }
    }
}