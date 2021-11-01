using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MoviesRental.Models;

namespace MoviesRental.DAL
{
    public class StoreInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var movies = new List<Movie>
            {
                new Movie
                {
                    MName = "Interstellar",
                    ReleaseDate = DateTime.Parse("2014-11-07"),
                    Description = "When Earth becomes uninhabitable in the future, a farmer and ex-NASA pilot, Joseph Cooper, is tasked to pilot a spacecraft, along with a team of researchers, to find a new planet for humans.",
                    Copies = 5
                },
                new Movie
                {
                    MName = "Titanic",
                    ReleaseDate = DateTime.Parse("1997-12-17"),
                    Description = "Seventeen-year-old Rose hails from an aristocratic family and is set to be married. When she boards the Titanic, she meets Jack Dawson, an artist, and falls in love with him.",
                    Copies = 5
                },
                new Movie
                {
                    MName = "Avatar",
                    ReleaseDate = DateTime.Parse("2009-12-18"),
                    Description = "Jake, who is paraplegic, replaces his twin on the Na'vi inhabited Pandora for a corporate mission. After the natives accept him as one of their own, he must decide where his loyalties lie.",
                    Copies = 5
                },
                new Movie
                {
                    MName = "Shrek",
                    ReleaseDate = DateTime.Parse("2001-04-22"),
                    Description = "Shrek, an ogre, embarks on a journey with a donkey to rescue Princess Fiona from a vile lord and regain his swamp.",
                    Copies = 5
                },
                new Movie
                {
                    MName = "Tenet",
                    ReleaseDate = DateTime.Parse("2020-04-12"),
                    Description = "When a few objects that can be manipulated and used as weapons in the future fall into the wrong hands, a CIA operative, known as the Protagonist, must save the world.",
                    Copies = 5
                }
            };
            movies.ForEach(s => context.Movies.Add(s));
            context.SaveChanges();
            var custs = new List<Customer>
            {
                new Customer
                {
                    CName = "Admin",
                    Email = "admin@mvcmr.com",
                    Password = "Admin@123",
                    Address = "456/B, Clemmington Street, Nottingham",
                    Phone = "9463258712"
                },
                new Customer
                {
                    CName = "Test Cust1",
                    Email = "tcust1@mvcmr.com",
                    Password = "Tcust1@123",
                    Address = "357/A, Vermont Street, Scheffield",
                    Phone = "8453216978"
                },
                new Customer
                {
                    CName = "Test Cust2",
                    Email = "tcust2@mvcmr.com",
                    Password = "Tcust2@123",
                    Address = "357/B, Vermont Street, Scheffield",
                    Phone = "7359438614"
                }
            };
            custs.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();
            var transacs = new List<Ledger>
            {
                new Ledger
                {
                    BorrowDate = DateTime.Parse("2021-10-28"),
                    CustomerID = 3,
                    MovieID = 3
                },
                new Ledger
                {
                    BorrowDate = DateTime.Parse("2021-10-27"),
                    CustomerID = 2,
                    MovieID = 2
                }
            };
            transacs.ForEach(s => context.Ledgers.Add(s));
            context.SaveChanges();
        }
    }
}