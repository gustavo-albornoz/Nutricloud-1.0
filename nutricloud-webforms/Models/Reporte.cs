using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nutricloud_webforms.Models
{
    public class Reporte
    {
        [JsonIgnore]
        public decimal calorias { get; set; }
        [JsonIgnore]
        public decimal sodio { get; set; }
        [JsonIgnore]
        public decimal potasio { get; set; }
        [JsonIgnore]
        public decimal calcio { get; set; }
        [JsonIgnore]
        public decimal fosforo { get; set; }
        [JsonIgnore]
        public decimal hierro { get; set; }
        [JsonIgnore]
        public decimal zinc { get; set; }
        [JsonIgnore]
        public decimal tiamina { get; set; }
        [JsonIgnore]
        public decimal rivofla { get; set; }
        [JsonIgnore]
        public decimal niacina { get; set; }
        [JsonIgnore]
        public decimal vitaminaC { get; set; }
        public decimal colesterol { get; set; }
        public decimal agua { get; set; }
        public decimal grasa { get; set; }
        public decimal carbohidratos { get; set; }
        public decimal fibra { get; set; }
        public decimal proteina { get; set; }     
    }
}