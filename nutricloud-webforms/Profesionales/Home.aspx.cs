using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nutricloud_webforms.Models;

namespace nutricloud_webforms.Profesionales
{
    public partial class Home : System.Web.UI.Page
    {

        void Page_PreInit(object sender, EventArgs e)
        {
            try
            {
                UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];

                if (UsuarioCompleto == null)
                    Response.Redirect("~/Default.aspx");
                else
                {
                    if (UsuarioCompleto.Usuario.id_usuario_tipo == 1)
                        Response.Redirect("~/Pages/Home.aspx");
                    else if (UsuarioCompleto.Usuario.id_usuario_tipo == 2)
                        this.Page.MasterPageFile = "~/MasterPro.Master";
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}