using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviesRental.DAL;
using MoviesRental.Models;

namespace MoviesRental.Controllers
{
    public class CustomersController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
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
