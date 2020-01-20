using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeGlobeProject.Models
{
    public class Work
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [Display(Name = "Work  Photo")]
        public byte[] WorkPhoto { get; set; }

        [Display(Name = "Work page Full Photo")]

        public byte[] WorkFullImage { get; set; }



        [NotMapped]
        public HttpPostedFileBase Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase Image2 { get; set; }
        public ICollection<Photo> Images { get; set; }
    }
}