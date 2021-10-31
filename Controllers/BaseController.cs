using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoviesRental.Models;
using MoviesRental.DAL;
using System.Data.Entity;

namespace MoviesRental.Controllers
{
    public abstract class BaseController : Controller
    {
        private StoreContext db = new StoreContext();
        public virtual void UpdateMovieCount(int id, int d)
        {
            Movie m = db.Movies.Find(id);
            m.Copies += d;
            db.Movies.Attach(m);
            db.Entry(m).State = EntityState.Modified;
            db.SaveChanges();
        }

        public virtual void RemoveCust(int id)
        {
            List<Ledger> tbr = db.Ledgers.ToList().FindAll(
                delegate (Ledger l)
                {
                    return l.CustomerID == id;
                }
                );
            if (tbr != null)
            {
                foreach (var i in tbr)
                {
                    UpdateMovieCount(i.MovieID, 1);
                    db.Ledgers.Remove(i);
                }
            }
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
        }
    }
}