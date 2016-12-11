using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nutricloud_webforms.Repositories;
using nutricloud_webforms.Models;
using nutricloud_webforms.DataBase;

namespace nutricloud_webforms.User_Control
{
    public partial class Mensajes : System.Web.UI.UserControl
    {
        ConversacionRepository cr = new ConversacionRepository();
        ValidRepository vr = new ValidRepository();
        UsuarioCompleto usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.usuario = (UsuarioCompleto)Session["UsuarioCompleto"];

                if (usuario.Usuario.id_usuario_tipo == 1)
                {
                    btnNuevo.Visible = true;
                }
                if (usuario.Usuario.id_usuario_tipo == 2)
                {
                    btnNuevo.Visible = false;
                }

                if (!IsPostBack)
                {
                    CargaConversaciones();
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        private void CargaConversaciones()
        {
            try
            {
                rConversaciones.DataSource = cr.ListarConversaciones(this.usuario);
                rConversaciones.DataBind();
                CargaNotificacionesMensajes();
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void btnenviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (vr.ValidaVacio(TxtAsunto.Text) && vr.ValidaVacio(TxtMensaje.Text))
                {
                    int id_conversacion = cr.Insertar(MapeaMensajeEnviado(), this.usuario);
                    Actualiza(id_conversacion);
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void lnkConversacion_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton convSelec = sender as LinkButton;
                CargaMensajes(int.Parse(convSelec.CommandArgument));
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        private void CargaMensajes(int id_conversacion)
        {
            try
            {
                consulta_conversacion cc = cr.GetConversacion(id_conversacion);

                Panel pnlMensaje;
                Label lblMensaje;
                Label lblFecha;

                TxtAsunto.Text = cc.asunto;
                TxtAsunto.Enabled = false;

                foreach (var item in cr.ListarMensajes(id_conversacion, usuario))
                {
                    pnlMensaje = new Panel();
                    pnlMensaje.CssClass = "msj";

                    if (this.usuario.Usuario.id_usuario == item.id_usuario_remitente)
                    {
                        pnlMensaje.CssClass += " msj-enviado";
                    }
                    else
                    {
                        pnlMensaje.CssClass += " msj-recibido";
                    }

                    lblMensaje = new Label();
                    lblMensaje.Text = item.mensaje;

                    lblFecha = new Label();
                    lblFecha.Text = item.f_mensaje.ToString();
                    lblFecha.CssClass = "msj-fecha";

                    pnlMensaje.Controls.Add(lblMensaje);
                    pnlMensaje.Controls.Add(lblFecha);

                    pnlMsjs.Controls.Add(pnlMensaje);
                }

                if (cc.cerrada)
                {
                    lblCerrada.Visible = true;
                    btnCerrar.Visible = false;
                    pnlNuevoMsj.Visible = false;
                }
                else
                {
                    if (this.usuario.Usuario.id_usuario == cc.id_usuario_destinatario ||
                        this.usuario.Usuario.id_usuario == cc.id_usuario_remitente)
                    {
                        lblCerrada.Visible = false;
                        btnCerrar.Visible = true;
                        pnlNuevoMsj.Visible = true;
                    }
                    else
                    {
                        lblCerrada.Visible = false;
                        btnCerrar.Visible = false;
                        pnlNuevoMsj.Visible = true;
                    }
                }

                SetSessionIdConversacion(id_conversacion);
                CargaConversaciones();
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        private Mensaje MapeaMensajeEnviado()
        {
            Mensaje msj = new Mensaje();

            try
            {
                msj.id_conversacion = GetSessionIdConversacion();
                msj.Asunto = TxtAsunto.Text;
                msj.Texto = TxtMensaje.Text;
                msj.id_remitente = usuario.Usuario.id_usuario;
                return msj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Actualiza(int id_conversacion)
        {
            try
            {
                //CargaConversaciones();
                CargaMensajes(id_conversacion);
                TxtMensaje.Text = string.Empty;
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        private void LimpiaControles()
        {
            try
            {
                pnlMsjs.Controls.Clear();
                TxtAsunto.Text = string.Empty;
                TxtAsunto.Enabled = true;
                TxtMensaje.Text = string.Empty;
                lblCerrada.Visible = false;
                pnlNuevoMsj.Visible = true;
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Add("id_conversacion", null);
                LimpiaControles();
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        private int GetSessionIdConversacion()
        {
            try
            {
                return Session["id_conversacion"] != null ? int.Parse(Session["id_conversacion"].ToString()) : 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SetSessionIdConversacion(int id_conversacion)
        {
            try
            {
                if (Session["id_conversacion"] == null)
                {
                    Session.Add("id_conversacion", id_conversacion);
                }
                else
                {
                    Session["id_conversacion"] = id_conversacion;
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void btnCerrar_Click1(object sender, EventArgs e)
        {
            try
            {
                int id_conversacion = (int)Session["id_conversacion"];
                cr.CerrarConversacion(id_conversacion);
                Actualiza(id_conversacion);
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void rConversaciones_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                int id_conv = int.Parse(((LinkButton)e.Item.FindControl("LnkConv")).CommandArgument);
                int cant = cr.ConversacionSinLeer(id_conv, usuario);
                Label lblMsjsNoLeidos = (Label)e.Item.FindControl("lblMsjsNoLeidos");

                if (cant > 0)
                {
                    lblMsjsNoLeidos.Visible = true;
                    lblMsjsNoLeidos.Text = cant.ToString();
                }
                else
                {
                    lblMsjsNoLeidos.Visible = false;
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        private void CargaNotificacionesMensajes()
        {
            Label lblNotificaciones;
            UpdatePanel upNotificaciones;
            int msjs;

            try
            {
                if (usuario == null)
                {
                    msjs = 0;
                }
                else
                {
                    msjs = cr.MensajesNoLeidos(usuario);
                    upNotificaciones = (UpdatePanel)Page.Master.FindControl("upNotificaciones");
                    lblNotificaciones = (Label)Page.Master.FindControl("lblNotificaciones");

                    if (msjs > 0)
                    {
                        lblNotificaciones.Text = msjs.ToString();
                        lblNotificaciones.Visible = true;
                    }
                    else
                    {
                        lblNotificaciones.Visible = false;
                    }

                    upNotificaciones.Update();
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}