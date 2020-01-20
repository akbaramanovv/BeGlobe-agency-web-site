using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeGlobeProject.Models
{
    public class Logo
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public string Image { get; set; }
        public byte[] Photo { get; set; }
    }
}