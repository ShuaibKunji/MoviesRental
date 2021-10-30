using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesRental.Models
{
    public class CustomerViewModel
    {
        public List<Movie> movies { get; set; }
        public List<Register> borrowed { get; set; }

        public int custID { get; set; }
    }
}