using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MISTeam8.Models
{
    public class User
    {
        public Guid ID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string firstname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }
        public string fullname
        {
            get
            {
                return lastname + ", " + firstname;
            }

        }
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Tenure")]
        public DateTime tenure { get; set; }
        [Required]
        [Display(Name = "Position")]
        public string position { get; set; }





        // test thom luce
        // thom is a massive bitch and likes feet
        // my balls are super blue like bleu cheese
        //hi
    }
}