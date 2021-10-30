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
        public ActionResult Index(int id)
        {
            CustomerViewModel cust = new CustomerViewModel();
            cust.movies = getMovies();
            cust.borrowed = getBorrowed(id);
            cust.custID = id;
            return View(cust);
        }
        
        public List<Movie> getMovies()
        {
            List<Movie> movies = new List<Movie>();
            foreach (var m in db.Movies)
            {
                if (m.Copies > 0)
                    movies.Add(new Movie { MName = m.MName, Description = m.Description, Copies = m.Copies, ReleaseDate = m.ReleaseDate });
            }
            return (movies);
        }

        public List<Register> getBorrowed(int id)
        {
            List<Register> registers = new List<Register>();
            foreach(var item in db.Ledgers)
            {
                if (item.CustomerID == id)
                    registers.Add(new Register { Movie = db.Movies.Find(item.MovieID).MName, Customer = db.Customers.Find(item.CustomerID).CName, BD = item.BorrowDate });
            }
            return (registers);
        }

        public ActionResult AccountSettings(int id)
        {
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
                return RedirectToAction("Index","Customers", new { id = customer.CustomerID });
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
