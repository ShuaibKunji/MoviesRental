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
    public class AdminController : BaseController
    {
        private StoreContext db = new StoreContext();

        public ActionResult Index()
        {
            var reg = new List<Register> { };
            foreach(var item in db.Ledgers)
            {
                reg.Add(new Register { Movie = db.Movies.Find(item.MovieID).MName, Customer = db.Customers.Find(item.CustomerID).CName, BD = item.BorrowDate});
            }
            return View(reg);
        }

        public ActionResult Movies()
        {
            return View(db.Movies.ToList());
        }

        public ActionResult Customers()
        {
            return View(db.Customers.ToList());
        }
        public ActionResult MovieDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ActionResult MovieCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MovieCreate([Bind(Include = "MovieID,MName,ReleaseDate,Description,Copies")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Movies");
            }

            return View(movie);
        }

        public ActionResult MovieEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MovieEdit([Bind(Include = "MovieID,MName,ReleaseDate,Description,Copies")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Movies");
            }
            return View(movie);
        }

        public ActionResult MovieDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost, ActionName("MovieDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult MovieDeleteConfirmed(int id)
        {
            List<Ledger> tbr = db.Ledgers.ToList().FindAll(
                delegate (Ledger l)
                {
                    return l.MovieID == id;
                }
                );
            foreach (var i in tbr)
                db.Ledgers.Remove(i);
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Movies");
        }
        public ActionResult CustDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult CustCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustCreate([Bind(Include = "CustomerID,CName,Email,Password,Address,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Customers");
            }

            return View(customer);
        }

        public ActionResult CustEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustEdit([Bind(Include = "CustomerID,CName,Email,Password,Address,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Customers");
            }
            return View(customer);
        }

        public ActionResult CustDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("CustDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult CustDeleteConfirmed(int id)
        {
            this.RemoveCust(id);
            return RedirectToAction("Customers");
        }

        public ActionResult AccountSettings(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer cust = db.Customers.Find(id);
            if (cust == null)
            {
                return HttpNotFound();
            }
            return View(cust);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccountSettings([Bind(Include = "CustomerID,CName,Email,Password,Address,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Customers");
            }
            return View(customer);
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
