using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Please enter your name")]
        public String Name { get; set;  }
        [Required(ErrorMessage = "Please enter your email")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone")]
        public String Phone { get; set; }
        [Required(ErrorMessage = "Please enter your hasGradute")]
        public Boolean? hasGraduate { get; set; }
    }
}
