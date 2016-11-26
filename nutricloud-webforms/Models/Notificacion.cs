using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nutricloud_webforms.Models
{
    public class Notificacion
    {
        private const string tipo_blog = "BLOG_NOTA";
        public bool leida { get; set; }
        public DateTime fecha { get; set; }
        public Object notificacion { get; set; }
        public string tipo { get; set; }
        public int id { get; set; }
    }
}