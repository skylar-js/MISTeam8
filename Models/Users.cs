using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("UserID")]
        public ICollection<Recognition> Recognition { get; set; }
        [ForeignKey("recognizorID")]
        public ICollection<Recognition> Recognizor { get; set; }
    }

    // Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
}