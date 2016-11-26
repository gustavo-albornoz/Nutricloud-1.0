using nutricloud_webforms.DataBase;
using nutricloud_webforms.Models;
using nutricloud_webforms.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nutricloud_webforms.Pages
{
    public partial class NotaAlta : System.Web.UI.Page
    {
        private BlogRepository blogRepository = new BlogRepository();
        private NotificacionRepository notificacionRepository = new NotificacionRepository();

        void Page_PreInit(object sender, EventArgs e)
        {
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];

            if (UsuarioCompleto == null)
                Response.Redirect("../Default.aspx");
            else
            {
                if (UsuarioCompleto.Usuario.id_usuario_tipo == 1)
                    Response.Redirect("Home.aspx");
                else if (UsuarioCompleto.Usuario.id_usuario_tipo == 2)
                    this.Page.MasterPageFile = "~/MasterPro.Master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Guardar(object sender, EventArgs e)
        {
            UsuarioCompleto usuario = (UsuarioCompleto)Session["UsuarioCompleto"];
            blog_nota nota = new blog_nota();

            /* Guardar imagen */
            if (imagen.HasFile)
            {
                StringBuilder fileName = new StringBuilder();
                fileName.Append(usuario.Usuario.id_usuario + "-");
                fileName.Append(DateTime.Now.Year);
                fileName.Append("." + DateTime.Now.Month);
                fileName.Append("." + DateTime.Now.Day);
                fileName.Append("." + DateTime.Now.Hour);
                fileName.Append("." + DateTime.Now.Minute);
                fileName.Append("." + DateTime.Now.Second);
                fileName.Append("." + DateTime.Now.Millisecond);
                fileName.Append(Path.GetExtension(imagen.PostedFile.FileName));

                string serverPath = Server.MapPath("~/Content/img/notas/");
                string path = Path.Combine(serverPath, fileName.ToString());
                imagen.SaveAs(path);
                nota.imagen_nota = fileName.ToString();
            }


            nota.nota = texto.Text;
            nota.titulo_nota = titulo.Text;
            nota.descripcion_nota = descripcion.Text;
            nota.id_usuario = usuario.Usuario.id_usuario;
            nota.f_publicacion = DateTime.Now;

            blogRepository.add(nota);

            //TODO mostar mensaje de exito y redirigir hacia atras
        }
    }
}