using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nutricloud_webforms.Models
{
    public class Favorito
    {
        public string nombre { get; set; }
        public int id { get; set; }
        public decimal? kcal { get; set; }
    }
}