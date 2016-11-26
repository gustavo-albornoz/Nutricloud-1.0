using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nutricloud_webforms.Models
{
    public class Reporte
    {

        public decimal energia_kcal { get; set; }        
        public decimal sodio { get; set; }
        public decimal potasio { get; set; }
        public decimal calcio { get; set; }
        public decimal fosforo { get; set; }
        public decimal hierro { get; set; }
        public decimal zinc { get; set; }
        public decimal tiamina { get; set; }
        public decimal rivofla { get; set; }
        public decimal niacina { get; set; }
        public decimal vitc { get; set; }
        public decimal colesterol { get; set; }
        public decimal agua { get; set; }
        public decimal grasa { get; set; }
        public decimal carbo { get; set; }
        public decimal fibra { get; set; }
        public decimal proteina { get; set; }
        public string genero { get; set; }
    }
}