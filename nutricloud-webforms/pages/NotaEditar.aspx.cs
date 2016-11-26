using System;
using nutricloud_webforms.Repositories;
using nutricloud_webforms.DataBase;
using nutricloud_webforms.Models;
using System.IO;
using System.Text;

namespace nutricloud_webforms.Pages
{
    public partial class NotaEditar : System.Web.UI.Page
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
                    Response.Redirect("Home.aspx");
                else if (UsuarioCompleto.Usuario.id_usuario_tipo == 2)
                    this.Page.MasterPageFile = "~/MasterPro.Master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            this.nota = repository.get(id);

            if (!IsPostBack)
            {
                titulo.Text = this.nota.titulo_nota;
                descripcion.Text = this.nota.descripcion_nota;
                texto.Text = this.nota.nota;
            }
        }

        protected void Editar(object sender, EventArgs e)
        {
            blog_nota nota = new blog_nota();
            nota = this.nota;
            UsuarioCompleto usuario = (UsuarioCompleto)Session["UsuarioCompleto"];

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

            try
            {
                repository.update(nota);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}