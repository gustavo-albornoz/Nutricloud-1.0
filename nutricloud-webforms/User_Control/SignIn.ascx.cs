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
    public partial class SignIn : System.Web.UI.UserControl
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    CargaTiposUsuario();
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void registrarse_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaForm())
                {
                    DataBase.usuario u = MapeaFormUsuario();
                    UsuarioRepository ur = new UsuarioRepository();
                    ur.Insertar(u);

                    Sesion(u);

                    Response.Redirect("~/Pages/Perfil.aspx", false);
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
        #endregion

        #region Metodos propios
        private void CargaTiposUsuario()
        {
            ListItem li;
            UsuarioRepository ur = new UsuarioRepository();

            try
            {
                rblTipoUsuario.Items.Clear();
                foreach (DataBase.usuario_tipo item in ur.ListarTipoUsuario())
                {
                    li = new ListItem();
                    li.Text = item.usuario_tipo1;
                    li.Value = item.id_usuario_tipo.ToString();
                    rblTipoUsuario.Items.Add(li);
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
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
                if (!vr.ValidaVacio(txtEmail.Text))
                {
                    lblError = new Label();
                    lblError.Text = "* El email no puede estar vacío";
                    lblError.CssClass = "text-error";
                    pnlErrores.Controls.Add(lblError);
                    errores = true;
                }
                else
                {
                    if (!vr.ValidaMail(txtEmail.Text))
                    {
                        lblError = new Label();
                        lblError.Text = "* Email Inválido";
                        lblError.CssClass = "text-error";
                        pnlErrores.Controls.Add(lblError);
                        errores = true;
                    }
                }

                if (!vr.ValidaVacio(txtPassword.Text))
                {
                    lblError = new Label();
                    lblError.Text = "* La contraseña no puede estar vacía";
                    lblError.CssClass = "text-error";
                    pnlErrores.Controls.Add(lblError);
                    errores = true;
                }
                else
                {
                    //Valida longitud de password, que tenga entre 4 y 12 caracteres, por ejemplo
                    if (!vr.ValidaRangoLen(txtPassword.Text, 4, 12))
                    {
                        lblError = new Label();
                        lblError.Text = "* La contraseña debe tener entre 4 y 12 caracteres";
                        lblError.CssClass = "text-error";
                        pnlErrores.Controls.Add(lblError);
                        errores = true;
                    }
                }

                //Valida iguales
                if (!vr.ValidaIguales(txtPassword.Text, txtPassword2.Text))
                {
                    lblError = new Label();
                    lblError.Text = "* Las contraseñas tienen que coincidir";
                    lblError.CssClass = "text-error";
                    pnlErrores.Controls.Add(lblError);
                    errores = true;
                }

                if (rblTipoUsuario.SelectedValue == string.Empty)
                {
                    lblError = new Label();
                    lblError.Text = "* Debe seleccionar un tipo de usuario";
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

        private DataBase.usuario MapeaFormUsuario()
        {
            DataBase.usuario u = new DataBase.usuario();

            try
            {
                u.email = txtEmail.Text;
                u.clave = txtPassword.Text;
                u.id_usuario_tipo = int.Parse(rblTipoUsuario.SelectedValue);

                return u;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Sesion(DataBase.usuario u)
        {
            UsuarioCompleto uc = new UsuarioCompleto();

            try
            {
                uc.Usuario = u;
                Session.Add("UsuarioCompleto", uc);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}