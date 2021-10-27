using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies_Rental.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }

    }
}