using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nutricloud_webforms.Repositories;
using nutricloud_webforms.Models;
using System.Text;
using System.Web.Services;
using System.Data.Entity.Core.Objects;
using nutricloud_webforms.DataBase;

namespace nutricloud_webforms.Pages
{
    public partial class Notificaciones : System.Web.UI.Page
    {
        private NotificacionRepository notificacionRepository = new NotificacionRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            NotificacionRepository repository = new NotificacionRepository();
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];
        }

        [WebMethod]
        public static List<Notificacion> getNotificaciones()
        {
            NotificacionRepository notificacionRepository = new NotificacionRepository();
            List<Notificacion> notificaciones = notificacionRepository.listarNotificacionesDeNotas(1);
            // HttpContext.Current.Response.Redirect("Nota.aspx?id=");
            return notificaciones;
        }

        [WebMethod]
        public static void marcarComoLeida(int id, string tipo)
        {
            NotificacionRepository notificacionRepository = new NotificacionRepository();
            notificacionRepository.marcarComoLeida(id, tipo);
        }

    }
}