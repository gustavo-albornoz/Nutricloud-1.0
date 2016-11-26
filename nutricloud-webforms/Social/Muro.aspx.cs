using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Text;
using System.Web.Script.Serialization;
using nutricloud_webforms.Repositories;
using nutricloud_webforms.Models;
using nutricloud_webforms.DataBase;

namespace nutricloud_webforms
{
    public partial class Muro : System.Web.UI.Page
    {
        MuroRepository mr = new MuroRepository();
        UsuarioCompleto usuario;

        void Page_PreInit(object sender, EventArgs e)
        {
            try
            {
                UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];

                if (UsuarioCompleto == null)
                    Response.Redirect("~/Default.aspx");
                else
                {
                    if (UsuarioCompleto.Usuario.id_usuario_tipo == 1)
                        this.Page.MasterPageFile = "~/HeaderFooter.Master";
                    else if (UsuarioCompleto.Usuario.id_usuario_tipo == 2)
                        Response.Redirect("~/Profesionales/Home.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.usuario = (UsuarioCompleto)Session["UsuarioCompleto"];

                if (!IsPostBack)
                {
                    CargaMuro();
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                usuario_muro um = new usuario_muro();
                um.id_usuario = this.usuario.Usuario.id_usuario;
                um.estado = TxtEstado.Text;
                um.f_publicacion = DateTime.Now;

                mr.InsertarEstado(um);

                TxtEstado.Text = string.Empty;

                CargaMuro();
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        private void CargaMuro()
        {
            try
            {
                rMuro.DataSource = mr.ListarMuro(usuario.Usuario.id_usuario);
                rMuro.DataBind();
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        [WebMethod]
        public static string GetUsuarios(string nombre)
        {
            UsuarioRepository ur = new UsuarioRepository();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<General> lista = new List<General>();
            string usuario_nombre = string.Empty;
            General uds;

            try
            {
                foreach (var usuario in ur.ListarUsuarios(nombre))
                {
                    usuario_nombre = usuario.nombre;

                    if (usuario_nombre == string.Empty || usuario_nombre == null)
                    {
                        usuario_nombre = "Anónimo";
                    }

                    uds = new General();
                    uds.Detalle = usuario_nombre + " - " + usuario.email;
                    uds.Id = usuario.id_usuario.ToString();

                    lista.Add(uds);
                }

                return serializer.Serialize(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}