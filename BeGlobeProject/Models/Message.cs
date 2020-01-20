using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeGlobeProject.Models
{
    public class Message
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }

        public string  EmailAdress { get; set; }
        public string MessageText { get; set; }
        public bool Readed { get; set; }
    }
}