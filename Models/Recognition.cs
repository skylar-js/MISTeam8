using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISTeam8.Models
{
	public class Recognition
	{
        public int UserID { get; set; }
        public int RecongizedID { get; set; }
        public int CoreValue { get; set; }
        public int DateRecongized { get; set; }
        public int Details { get; set; }

        public virtual User User { get; set; }




    }
}