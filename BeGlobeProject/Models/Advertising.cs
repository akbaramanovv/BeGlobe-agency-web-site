using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeGlobeProject.Models
{
    public class Advertising
    {
        public int ID { get; set; }
        [Required]

        public string Header { get; set; }
        public string Photo { get; set; }


        [NotMapped] 
        public HttpPostedFileBase Image { get; set; }
        [Required]
        public string Description { get; set; }
    }
}