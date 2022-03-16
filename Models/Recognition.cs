using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MISTeam8.Models
{
	public class Recognition

	{
        [Required]
        public int RecognitionID { get; set; }

        [Display (Name = "Recepient Name")]
        public Guid UserID { get; set; }
        [Display(Name = "Award")]
        public CoreValue award { get; set; }
        [Display(Name = "Recognizor")]
        public Guid recognizor { get; set; }
        
        public Guid recognized { get; set; }
        [Display(Name = "Date Recognized")]
        public DateTime DateRecongized { get; set; }
        [Display(Name = "Details of Recognition")]
        public string Details { get; set; }

        public virtual User Users { get; set; }
        public enum CoreValue 
        { 
            Excellence = 1,
            Integrity = 2,
            Stewardship = 3,
            Innovate = 4,
            Balance = 5
        }
        


    }
}