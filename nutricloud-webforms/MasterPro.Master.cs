using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nutricloud_webforms.Repositories;
using nutricloud_webforms.Models;

namespace nutricloud_webforms
{
    public partial class MasterPro : System.Web.UI.MasterPage
    {
        UsuarioCompleto UsuarioCompleto;
        ConversacionRepository cr = new ConversacionRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];
            CargaNotificacionesMensajes();
        }

        public void CargaNotificacionesMensajes()
        {
            int msjs;

            if (UsuarioCompleto == null)
            {
                msjs = 0;
            }
            else
            {
                msjs = cr.MensajesNoLeidos(UsuarioCompleto);

                if (msjs > 0)
                {
                    lblNotificaciones.Visible = true;
                    lblNotificaciones.Text = msjs.ToString();
                }
                else
                {
                    lblNotificaciones.Visible = false;
                }
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }
}