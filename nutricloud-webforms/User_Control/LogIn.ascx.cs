using nutricloud_webforms.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nutricloud_webforms.Repositories;
using nutricloud_webforms.Models;

namespace nutricloud_webforms
{
    public partial class LogIn : System.Web.UI.UserControl
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Aceptar_Click(object sender, EventArgs e)
        {
            UsuarioRepository ur = new UsuarioRepository();
            usuario_datos ud = new usuario_datos();

            try
            {
                pnlErrores.Controls.Clear();

                if (ValidaForm())
                {
                    usuario u = ur.BuscarUsuarioLogIn(MapeaFormUsuario());

                    if (u != null)
                    {
                        ud = ur.BuscarUsuarioDatos(u.id_usuario);
                        Sesion(u, ud);

                        if (u.id_usuario_tipo == 1) //Paciente
                        {
                            if (ud == null)
                            {
                                Response.Redirect("~/Pages/Perfil.aspx", false);
                            }
                            else
                            {
                                Response.Redirect("~/Pages/Home.aspx", false);
                            }
                        }
                        if (u.id_usuario_tipo == 2) //Profesional
                        {
                            if (ud == null)
                            {
                                Response.Redirect("~/Pages/Perfil.aspx", false);
                            }
                            else
                            {
                                Response.Redirect("~/Profesionales/Home.aspx", false);
                            }
                            //Response.Redirect("~/Profesionales/Home.aspx", false);
                        }

                    }

                    else
                    {
                        Label lblError = new Label();
                        lblError.Text = "* Email/Contraseña Incorrectos";
                        lblError.CssClass = "text-error";
                        pnlErrores.Controls.Add(lblError);
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
        #endregion

        #region Metodos propios
        public usuario MapeaFormUsuario()
        {
            try
            {
                usuario u = new usuario();
                u.email = TxtEmail.Text;
                u.clave = TxtPass.Text;
                return u;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ValidaForm()
        {
            bool errores = false;
            Label lblError;
            ValidRepository vr = new ValidRepository();

            try
            {
                pnlErrores.Controls.Clear();

                //Valida vacios
                if (!vr.ValidaVacio(TxtEmail.Text))
                {
                    lblError = new Label();
                    lblError.Text = "* El email no puede estar vacío";
                    lblError.CssClass = "text-error";
                    pnlErrores.Controls.Add(lblError);
                    errores = true;
                }

                if (!vr.ValidaVacio(TxtPass.Text))
                {
                    lblError = new Label();
                    lblError.Text = "* La contraseña no puede estar vacía";
                    lblError.CssClass = "text-error";
                    pnlErrores.Controls.Add(lblError);
                    errores = true;
                }

                return !errores;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Sesion(usuario u, usuario_datos ud)
        {
            UsuarioCompleto uc = new UsuarioCompleto();

            try
            {
                uc.Usuario = u;
                uc.UsuarioDatos = ud;

                Session.Add("UsuarioCompleto", uc);
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
        #endregion
    }
}