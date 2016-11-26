using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nutricloud_webforms.Repositories;
using nutricloud_webforms.Models;
using nutricloud_webforms.DataBase;

namespace nutricloud_webforms.User_Control
{
    public partial class Carga_rapida : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{ 
            //    UsuarioCompleto usuario = (UsuarioCompleto)Session["UsuarioCompleto"];
            //    FavoritosRepository fr = new FavoritosRepository();

            //    List<alimento> Favs = fr.ListarFavoritos(usuario.Usuario.id_usuario);

            //    lblMsjSinResultados.Text = "";

            //    if (Favs.Count() > 0)
            //    {
            //        repalimentos.DataSource = Favs;
            //        repalimentos.DataBind();
            //    }
            //    else
            //    {
            //        lblMsjSinResultados.Text = "No se encontraron resultados";
            //    }
            //}   
        }
    }
}