using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nutricloud_webforms.Repositories;
using nutricloud_webforms.Models;
using nutricloud_webforms.DataBase;

namespace nutricloud_webforms.Pages
{
    public partial class PerfilSocial : System.Web.UI.Page
    {
        MuroRepository mr = new Repositories.MuroRepository();
        UsuarioRepository ur = new UsuarioRepository();
        UsuarioCompleto usuario;
        usuario usuario_seguido;
        usuario_usuario uu;

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
                        Response.Redirect("../Profesionales/Home.aspx");
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
                uu = new usuario_usuario();
                uu.id_usuario_seguidor = usuario.Usuario.id_usuario;
                uu.id_usuario_seguido = int.Parse(Request.QueryString["id"]);

                usuario_seguido = ur.BuscarUsuario(uu.id_usuario_seguido);
                lblNombre.Text = usuario_seguido.nombre;

                CargaMuro();
                TextoBotonSeguir();
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void btnSeguir_Click(object sender, EventArgs e)
        {
            try
            {
                mr.Seguir(uu);
                TextoBotonSeguir();
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        private void TextoBotonSeguir()
        {
            try
            {
                if (uu.id_usuario_seguido != uu.id_usuario_seguidor)
                {
                    btnSeguir.Visible = true;

                    if (mr.Siguiendo(uu))
                    {
                        btnSeguir.Text = "Dejar de seguir";
                        //btnSeguir.CssClass = "btn waves-effect white green-nutri-text";
                    }
                    else
                    {
                        btnSeguir.Text = "Seguir";
                        //btnSeguir.CssClass = "btn waves-effect green-nutri";
                    }
                }
                else
                {
                    btnSeguir.Visible = false;
                }
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
                rMuro.DataSource = mr.ListarMuroUsuario(uu.id_usuario_seguido);
                rMuro.DataBind();
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}