using System;
using System.ComponentModel.DataAnnotations;

namespace WEB315_Hobbies.Models
{
    public class hobbies
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }
        public string Location { get; set; }
        public decimal cost { get; set; }
    }
}