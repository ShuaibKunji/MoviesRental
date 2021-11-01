using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesRental.Models
{
    public class Movie
    {
        public int MovieID { get; set; }

        [Required(ErrorMessage = "Please enter the title of the movie")]
        public string MName { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Please enter a short decription of the movie")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the number of copies")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter an appropriate value")]
        public int Copies { get; set; }
    }
}