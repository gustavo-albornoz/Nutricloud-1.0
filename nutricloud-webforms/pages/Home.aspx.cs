using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Text;
using nutricloud_webforms.Repositories;
using nutricloud_webforms.Models;
using nutricloud_webforms.DataBase;
using System.Web.Script.Services;

namespace nutricloud_webforms
{
    public partial class Home : System.Web.UI.Page
    {
        AlimentoRepository ar = new AlimentoRepository();

        void Page_PreInit(object sender, EventArgs e)
        {
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];
            Session["fecha_diario"] = null;

            if (UsuarioCompleto == null)
                Response.Redirect("../Default.aspx");
            else
            {
                if (UsuarioCompleto.Usuario.id_usuario_tipo == 1)
                    this.Page.MasterPageFile = "~/HeaderFooter.Master";
                else if (UsuarioCompleto.Usuario.id_usuario_tipo == 2)
                    Response.Redirect("blog.aspx");
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Favorito> cargaRapida()
        {
            UsuarioCompleto usuario = (UsuarioCompleto)HttpContext.Current.Session["UsuarioCompleto"];
            FavoritosRepository fr = new FavoritosRepository();

            List<Favorito> Favs = fr.ListarFavoritos(usuario.Usuario.id_usuario);

            return Favs;
        }

        [WebMethod]
        public static string getAlimentos(string fecha)
        {
            UsuarioCompleto usuario = (UsuarioCompleto)HttpContext.Current.Session["UsuarioCompleto"];

            AlimentoRepository ar = new AlimentoRepository();
            StringBuilder sb = new StringBuilder();
            DateTime f;

            if (usuario != null)
            {
                int idUsuario = usuario.Usuario.id_usuario;

                try
                {
                    f = DateTime.Parse(fecha);
                    HttpContext.Current.Session["fecha_diario"] = f;
                }
                catch (Exception)
                {
                    if (HttpContext.Current.Session["fecha_diario"] == null)
                    {
                        f = DateTime.Now;
                        HttpContext.Current.Session["fecha_diario"] = f;
                    }
                    else
                    {
                        f = (DateTime)HttpContext.Current.Session["fecha_diario"];
                    }
                }

                //if (HttpContext.Current.Session["fecha_diario"] == null)
                //{
                //    try
                //    {
                //        f = DateTime.Parse(fecha);
                //        HttpContext.Current.Session["fecha_diario"] = f;
                //    }
                //    catch (Exception)
                //    {
                //        f = DateTime.Now;
                //        HttpContext.Current.Session["fecha_diario"] = f;
                //    }
                //}
                //else
                //{
                //    f = (DateTime)HttpContext.Current.Session["fecha_diario"];
                //}

                foreach (var tipoComida in ar.ListarTipoComida())
                {
                    sb.Append("<div class='row tipoComida' id='" + tipoComida.id_comida_tipo + "'>");
                    sb.Append("<input type='hidden' class='idTipoComida' value='" + tipoComida.id_comida_tipo + "' />");
                    sb.Append("<div class='col s12 m12'>");
                    sb.Append("<div class='card'>");
                    sb.Append("<div class='fast-charge'>");
                    sb.Append("<a class='waves-effect waves-light btn orange lighten-1 modal-trigger cargaRapida' data-tipo-comida='" + tipoComida.id_comida_tipo + "' href=\"#modal_fav\"><i class=\"material-icons left-i\">star</i>Carga Rápida</a>");
                    sb.Append("</div>");
                    sb.Append("<div id='" + tipoComida.id_comida_tipo + "-listado' class='card-content orange-text text-darken-3'>");
                    sb.Append("<img src='../Content/img/" + tipoComida.imagen + "' class='responsive-img icon-food' />");
                    sb.Append("<h4>" + tipoComida.comida_tipo1 + "</h4>");

                    Decimal totalCalorias = 0;
                    var listarDiario = ar.ListarDiario(idUsuario, tipoComida.id_comida_tipo, f);

                    foreach (var comida in listarDiario)
                    {
                        totalCalorias = totalCalorias + Convert.ToDecimal(comida.energia_kcal);

                        sb.Append("<div class='row item-alimento'>");
                        sb.Append("<div class='col s8'>");
                        sb.Append("<a class='alimento' href = 'Alimento.aspx?Idalimento=" + comida.id_alimento + "'>" + comida.nombre_alimento + "</a>");
                        sb.Append("<input type='hidden' class='idAlimento' value='" + comida.id_alimento + "' />");
                        sb.Append("<input type='hidden' class='idUsuarioAlimento' value='" + comida.id_usuario_alimento + "' />");
                        sb.Append("</div>");
                        sb.Append("<div class='col s4' style='text-align: right'>");
                        sb.Append("<span class='cantidadCalorias'>" + comida.energia_kcal + "</span><span> kcal</span>");
                        sb.Append("</div>");
                        sb.Append("<div class='col s8'>");
                        sb.Append("<span class='cantidadPorcion'>" + comida.cantidad + "</span><span> " + comida.unidad_medida + "</span>");
                        sb.Append("</div>");
                        sb.Append("<div class='col s4'>");
                        sb.Append("<a class='btn-eliminar' onclick='eliminar(" + comida.id_usuario_alimento + ")'><i class='material-icons'>delete</i></a>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                    }

                    sb.Append("</div>");
                    sb.Append("<div class='card-action action-home'>");
                    sb.Append("<a href='#'>Total Calorías</a>");
                    sb.Append("<a href='#' class='total_cal'>" + totalCalorias + "</a>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                }

                return sb.ToString();
            }
            else return "0";
        }

        [WebMethod]
        public static void actualizarDiario(List<Diario> diario)
        {
            UsuarioCompleto usuario = (UsuarioCompleto)HttpContext.Current.Session["UsuarioCompleto"];
            DiarioRepository diarioRepository = new DiarioRepository();
            diarioRepository.actualizarDiario(diario);
        }

        [WebMethod]
        public static void deleteAlimentos(int id_usuario_alimento)
        {
            DiarioRepository dr = new DiarioRepository();
            dr.EliminarAlimentoUsuario(id_usuario_alimento);
        }
    }
}
