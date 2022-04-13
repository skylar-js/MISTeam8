using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MISTeam8.Models
{
	public class Recognition

	{
        public int RecognitionID { get; set; }

        [Display (Name = "Recepient Name")]
        public Guid UserID { get; set; }
        [Display(Name = "Award")]
        public CoreValue award { get; set; }
        [Display(Name = "Recognizor")]
        public Guid recognizorID { get; set; }
        
       // public Guid recognized { get; set; }
       [Required]
        [Display(Name = "Date Recognized")]
        [DisplayFormat(DataFormatString = "{0:d}")]

        public DateTime DateRecongized { get; set; }
        [Display(Name = "Details of Recognition")]
        [Required]
        public string Details { get; set; }
        [ForeignKey("UserID")]
        public virtual User Users { get; set; }
        [ForeignKey("recognizorID")] 
        public virtual User Recognizor { get; set; }

        public enum CoreValue 
        { 
            Excellence = 1,
            Integrity = 2,
            Stewardship = 3,
            Culture = 4,
            Ignite = 5,
            Innovate = 6,
            Balance = 7
        }
        


    }
}