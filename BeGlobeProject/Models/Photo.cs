using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeGlobeProject.Models
{
    public class Photo
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] FileName { get; set; }

        [ForeignKey("Work")]
        public int WorkID { get; set; }
        public Work Work  { get; set; }
        [NotMapped]
        public string Image { get; set; }
    }
}