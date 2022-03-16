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

        public Guid UserID { get; set; }
        public CoreValue award { get; set; }
        public Guid recognizor { get; set; }
        public Guid recognized { get; set; }
        public DateTime DateRecongized { get; set; }
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