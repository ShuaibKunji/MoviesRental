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

        public ActionResult Movies()
        {
            return View(db.Movies.ToList());
        }

        public ActionResult Customers()
        {
            return View(db.Customers.ToList());
        }
    }
}