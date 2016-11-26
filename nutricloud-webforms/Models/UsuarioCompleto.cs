using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nutricloud_webforms.Models
{
    /// <summary>
    /// En esta clase ponemos todos los datos que necesitamos en la página
    /// para tener todos los datos del usuario en la sesion
    /// </summary>
    public class UsuarioCompleto
    {
        public DataBase.usuario Usuario { get; set; }
        public DataBase.usuario_datos UsuarioDatos { get; set; }
    }
}
