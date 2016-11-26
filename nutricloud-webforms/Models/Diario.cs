using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nutricloud_webforms.Models
{
    public class Diario
    {
        public string fecha { get; set; }
        public string calorias { get; set; }
        public string cantidad { get; set; }
        public string tipoDeComida { get; set; }
        public string idAlimento { get; set; }
        public string idUsuarioAlimento { get; set; }
    }
}