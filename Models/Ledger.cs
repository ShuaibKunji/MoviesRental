using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoviesRental.Models;

namespace MoviesRental.Models
{
    public class Ledger
    {
        public int ID { get; set; }
        public DateTime BorrowDate { get; set; }
        public int MovieID { get; set; }
        public int CustomerID { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Customer Customer { get; set; }

    }
}