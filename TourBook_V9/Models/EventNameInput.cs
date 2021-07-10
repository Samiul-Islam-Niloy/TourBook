using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;

namespace TourBook_V9.Models
{
    public class EventNameInput
    {
        [Key]
        public int NID { get; set; }
        public string Name { get; set; }
    }
}