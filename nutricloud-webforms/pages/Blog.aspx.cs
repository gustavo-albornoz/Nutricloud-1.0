using nutricloud_webforms.DataBase;
using nutricloud_webforms.Models;
using nutricloud_webforms.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nutricloud_webforms.Pages
{
    public partial class Blog : System.Web.UI.Page
    {
        private BlogRepository repository = new BlogRepository();
        UsuarioCompleto ur = new UsuarioCompleto();

        void Page_PreInit(object sender, EventArgs e)
        {
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];

            if (UsuarioCompleto == null)
                this.Page.MasterPageFile = "~/Anon.Master";
            else
            {
                if (UsuarioCompleto.Usuario.id_usuario_tipo == 1)
                    this.Page.MasterPageFile = "~/HeaderFooter.Master";
                else if (UsuarioCompleto.Usuario.id_usuario_tipo == 2)
                    this.Page.MasterPageFile = "~/MasterPro.Master";
            } 

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            List<blog_nota> list = repository.Listar();
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];

            foreach (var r in list)
            {
                if (r.imagen_nota != null && r.imagen_nota != "")
                {
                    r.imagen_nota = "../../content/img/notas/" + r.imagen_nota;
                }
                 else
                {
                    r.imagen_nota = "../../content/img/sin-imagen.jpg";
                }

                if (r.descripcion_nota.Length > 100)
                {
                    r.descripcion_nota = r.descripcion_nota.Substring(0, 100) + "...";
                }
            }

            if (list.Count() > 0)
            {
                RepeaterNotas.DataSource = list;
                RepeaterNotas.DataBind();
            }
            else
            {
                msjNoHayNotas.Text = "No hay notas todavía";
            }

            if (UsuarioCompleto == null)
            {
                receta.Visible = false;
                nota.Visible = false;
            }
            else
            {
                if (UsuarioCompleto.Usuario.id_usuario_tipo == 1)
                    nota.Visible = false;
                else
                {
                    if (UsuarioCompleto.Usuario.id_usuario_tipo == 2)
                        receta.Visible = false;
                }
            }

        }

        public void Ver(object sender, EventArgs e)
        {
            LinkButton link = (LinkButton)sender;
            String id = link.CommandArgument;
            Response.Redirect("Nota.aspx?id=" + id);
        }
    }
}