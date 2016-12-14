using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nutricloud_webforms.Repositories;
using nutricloud_webforms.DataBase;
using nutricloud_webforms.Models;

namespace nutricloud_webforms.Pages
{
    public partial class Recetas : System.Web.UI.Page
    {
        private RecetaRepository repository = new RecetaRepository();

        void Page_PreInit(object sender, EventArgs e)
        {
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];

            if (UsuarioCompleto == null)
                Response.Redirect("../Default.aspx");
            else
            {
                if (UsuarioCompleto.Usuario.id_usuario_tipo == 1)
                    this.Page.MasterPageFile = "~/HeaderFooter.Master";
                else if (UsuarioCompleto.Usuario.id_usuario_tipo == 2)
                    Response.Redirect("Profesionales/Home.aspx");
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            List<usuario_receta> list = repository.Listar().OrderByDescending(l => l.f_publicacion).ToList(); ;

            foreach (var r in list)
            {
                if (r.imagen_receta != null && r.imagen_receta != "")
                {
                    r.imagen_receta = "../../content/img/recetas/" + r.imagen_receta;
                }
                else
                {
                    r.imagen_receta = "../../content/img/sin-imagen.jpg";
                }

                if (r.receta.Length > 100)
                {
                    r.receta = r.receta.Substring(0, 100) + "...";
                }
            }

            if (list.Count() > 0)
            {
                RepeaterRecetas.DataSource = list;
                RepeaterRecetas.DataBind();
            }
            else
            {
                msjNoHayRecetas.Text = "No hay recetas todavía";
            }

        }

        public void VerReceta(object sender, EventArgs e)
        {
            LinkButton link = (LinkButton)sender;
            String idReceta = link.CommandArgument;
            Response.Redirect("Receta.aspx?idReceta=" + idReceta);
        }
    }
}