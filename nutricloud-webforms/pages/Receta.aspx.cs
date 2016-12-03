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
    public partial class Receta : System.Web.UI.Page
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
            int Dia = this.receta.f_publicacion.Day;
            String Mes = this.receta.f_publicacion.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            int Anio = this.receta.f_publicacion.Year;
            receta_titulo.InnerHtml = this.receta.titulo_receta;
            receta_texto.InnerHtml = this.receta.receta;
            receta_descripcion.InnerHtml = this.receta.descripcion_receta;
            fechanota.Text = String.Join(" de ", Dia, Mes, Anio);

            if (this.receta.imagen_receta != null && this.receta.imagen_receta != "")
            {
                imgReceta.ImageUrl = "../../content/img/recetas/" + this.receta.imagen_receta;
                imgReceta.CssClass = "imgentrada responsive-img";
            }
            else
            {
                imgReceta.ImageUrl = "../../content/img/sin-imagen.jpg";
                imgReceta.CssClass = "imgentrada responsive-img";
            }
        }

        public void EditarReceta(object sender, EventArgs e)
        {
            Response.Redirect("RecetaEditar.aspx?idReceta=" + this.receta.id_usuario_receta);
        }

        public void EliminarReceta(object sender, EventArgs e)
        {

            try
            {
                recetaRepository.deleteReceta(this.receta);
                // Elimino la imagen de la receta
                string serverPath = Server.MapPath("~/Content/img/recetas/");
                File.Delete(serverPath + this.receta.imagen_receta);

                //TODO mostrar msj de exito y redirigirbklhoihoihkjklkl
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //TODO mostrar msj de error y redirigir
            }

        }
    }
}