using nutricloud_webforms.DataBase;
using nutricloud_webforms.Models;
using nutricloud_webforms.Repositories;
using System;
using System.IO;
using System.Text;

namespace nutricloud_webforms.pages
{
    public partial class RecetaAlta : System.Web.UI.Page
    {

        private RecetaRepository recetaRepository = new RecetaRepository();

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

        }

        protected void SubirEntrada(object sender, EventArgs e)
        {
            UsuarioCompleto usuario = (UsuarioCompleto)Session["UsuarioCompleto"];
            usuario_receta receta = new usuario_receta();

            /* Guardar imagen */
            if (imagenReceta.HasFile)
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
                fileName.Append(Path.GetExtension(imagenReceta.PostedFile.FileName));

                string serverPath = Server.MapPath("~/Content/img/recetas/");
                string path = Path.Combine(serverPath, fileName.ToString());
                imagenReceta.SaveAs(path);
                receta.imagen_receta = fileName.ToString();
            }


            receta.receta = receta_texto.Text;
            receta.titulo_receta = titulo_receta.Text;
            receta.descripcion_receta = descripcion_receta.Text;
            receta.id_usuario = usuario.Usuario.id_usuario;
            receta.f_publicacion = DateTime.Now;

            recetaRepository.addReceta(receta);

            //TODO mostar mensaje de exito y redirigir hacia atras
        }
    }
}