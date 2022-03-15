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

        public Guid ID { get; set; }
        public string CoreValue { get; set; }
        public DateTime DateRecongized { get; set; }
        public string Details { get; set; }

        public virtual User Users { get; set; }




    }
}