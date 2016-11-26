using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nutricloud_webforms.Models
{
    public class Mensaje
    {
        public int id_conversacion { get; set; }
        public string Asunto { get; set; }
        public string Texto { get; set; }
        public int id_remitente { get; set; }
    }
}
