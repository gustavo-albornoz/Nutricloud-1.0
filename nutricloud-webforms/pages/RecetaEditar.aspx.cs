using System;
using nutricloud_webforms.Repositories;
using nutricloud_webforms.DataBase;
using nutricloud_webforms.Models;
using System.IO;
using System.Text;

namespace nutricloud_webforms.Pages
{
    public partial class RecetaEditar : System.Web.UI.Page
    {
        private RecetaRepository recetaRepository = new RecetaRepository();
        private usuario_receta receta;

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
            int id = int.Parse(Request.QueryString["idReceta"]);
            this.receta = recetaRepository.getReceta(id);

            if (!IsPostBack)
            {
                titulo_receta.Text = this.receta.titulo_receta;
                descripcion_receta.Text = this.receta.descripcion_receta;
                receta_texto.Text = this.receta.receta;
            }
        }

        protected void onload(object sender, EventArgs e)
        {
            // no se para que se usa tdv 
            //string x = "hola";
        }

        protected void EditarReceta(object sender, EventArgs e)
        {
            usuario_receta receta = new usuario_receta();
            receta = this.receta;
            UsuarioCompleto usuario = (UsuarioCompleto)Session["UsuarioCompleto"];

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

            try
            {
                recetaRepository.updateReceta(receta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}