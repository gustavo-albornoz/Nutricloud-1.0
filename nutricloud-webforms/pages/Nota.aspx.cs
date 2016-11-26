using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nutricloud_webforms.Repositories;
using nutricloud_webforms.DataBase;
using nutricloud_webforms.Models;
using System.Globalization;

namespace nutricloud_webforms.pages
{
    public partial class Nota : System.Web.UI.Page
    {
        private BlogRepository repository = new BlogRepository();
        private blog_nota nota;

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
                    this.Page.MasterPageFile = "~/MasterPro.Master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];

            int id = int.Parse(Request.QueryString["id"]);
            this.nota = repository.get(id);
            int Dia = this.nota.f_publicacion.Day;
            String Mes = this.nota.f_publicacion.ToString("MMMM",CultureInfo.CreateSpecificCulture("es"));
            int Anio = this.nota.f_publicacion.Year;
            nota_titulo.InnerHtml = this.nota.titulo_nota;
            texto.InnerHtml = this.nota.nota;
            descripcion.InnerHtml = this.nota.descripcion_nota;
            fechanota.Text = String.Join(" de ",Dia,Mes,Anio);

            if (this.nota.imagen_nota != null && this.nota.imagen_nota != "")
            {
                imagen.ImageUrl = "../../content/img/notas/" + this.nota.imagen_nota;
            }

            if (UsuarioCompleto.Usuario.id_usuario_tipo == 1)
            {
                LiEditar.Visible = false;
                LiEliminar.Visible = false;
            }
        }

        public void Editar(object sender, EventArgs e)
        {
            Response.Redirect("NotaEditar.aspx?id=" + this.nota.id_blog_nota);
        }

        public void Eliminar(object sender, EventArgs e)
        {

            try
            {
                repository.delete(this.nota);
                // Elimino la imagen de la nota
                string serverPath = Server.MapPath("~/Content/img/notas/");
                File.Delete(serverPath + this.nota.imagen_nota);

                //TODO mostrar msj de exito y redirigir
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //TODO mostrar msj de error y redirigir
            }

        }
    }
}