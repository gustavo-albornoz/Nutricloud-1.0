using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nutricloud_webforms.Models
{
    public class ReporteCompleto
    {
        public decimal calorias { get; set; }
        public decimal sodio { get; set; }
        public decimal potasio { get; set; }
        public decimal calcio { get; set; }
        public decimal fosforo { get; set; }
        public decimal hierro { get; set; }
        public decimal vitaminaC { get; set; }
        public decimal colesterol { get; set; }
        public decimal agua { get; set; }
        public decimal grasa { get; set; }
        public decimal carbohidratos { get; set; }
        public decimal fibra { get; set; }
        public decimal proteina { get; set; }
    }
}