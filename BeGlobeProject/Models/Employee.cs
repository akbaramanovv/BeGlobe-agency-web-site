using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeGlobeProject.Models
{
    public class Employee 
    {
        public int ID  { get; set; }
        public string Photo { get; set; }
        [MaxLength(50)]
        public string EmployeeName { get; set; }
        [MaxLength(50)]

        public string Surname { get; set; }

        [ForeignKey("Positionn")]
        public int PositionID { get; set; }

        public Positionn Positionn { get; set; }
    }
}