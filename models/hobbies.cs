using System;
using System.ComponentModel.DataAnnotations;

namespace WEB315_Hobbies.Models
{
    public class hobbies
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
       [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }
        [StringLength(32, MinimumLength = 4)]
         [Required]
        public string Location { get; set; }
        [Required]
        public decimal cost { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), Required]
        
        [StringLength(32, MinimumLength = 4)]
        public string placetype {get;set;}
         [Range(1, 100)]
        [Required]
        public int  visitcount {get;set;}
    }
}