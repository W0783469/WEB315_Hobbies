using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }
        public string Location { get; set; }
        public decimal cost { get; set; }
    }
}