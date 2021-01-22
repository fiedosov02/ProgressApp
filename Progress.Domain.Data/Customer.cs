using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Progress.Domain.Data
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Write a task")]
        public string Task { get; set; }
        [Required(ErrorMessage = "Write a start date")]
        public DateTime Time { get; set; }
        public string ResultTime { get; set; }
        [Required(ErrorMessage = "Write how many days you have to solve the problem")]
        public  double TimeForTask{ get; set; }     
        public string Email { get; set; }    
        public string  Password { get; set; }
    }
}
