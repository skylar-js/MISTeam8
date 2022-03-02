using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISTeam8.Models
{
     public class Recognition
    {
        [Required]
        [Display(Name = "Recongizer" )]
        public string UserID { get; set; }
        [Required]
        [Display(Name ="Recongized")]
        public string RecongizedID { get; set; }
        [Required]
        [Display(Name = "Core Value")]

        public string CoreValue { get; set; }
        [Required]
        [Display(Name = "Date Recongized")]
        public DateTime DateRecongized { get; set; }
        [Required]
        public string Details { get; set; }
        

    }
}

