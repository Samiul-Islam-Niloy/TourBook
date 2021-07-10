using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourBook_V9.Models
{
    public class CreateEvent
    {
        [Key]
        public int EventID { get; set; }
      
        
        public string Date { get; set; }
        [Required]
       
        public string Time { get; set; }
        [Required]
       
        public string Start_from { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        public int Cost { get; set; }
        [Required]
        public int Days { get; set; }
        [Required]
        public int total_member { get; set; }
        public string EventCreator { get; set; }

    }
}