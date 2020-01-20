using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeGlobeProject.Models
{
    public class WorkWM
    {
        public List<Photo> Photos { get; set; }
        public List<Work> Works { get; set; }
        public Work Work { get; set; }
        public int PhotoCount { get; set; }

    }
}