using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesRental.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string MName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public int Copies { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}