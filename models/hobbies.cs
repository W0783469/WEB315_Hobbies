using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB315_Hobbies.Models
{
    public class hobbies
    {
        public int ID { get; set; }
         [Display(Name = "New Title")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }
        public string Location { get; set; }
        public decimal cost { get; set; }
        public string preferences { get; set; }

    }
}