using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nutricloud_webforms.Repositories;
using nutricloud_webforms.DataBase;
using nutricloud_webforms.Models;
using System.Data.Entity;
using System.IO;
using System.Text;

namespace nutricloud_webforms
{
    public partial class Perfil : System.Web.UI.Page
    {
        #region Metodos Privados
        private void CargaGeneros()
        {
            ListItem li;
            rblGenero.Items.Clear();

            li = new ListItem();
            li.Text = "Masculino";
            li.Value = "m";
            rblGenero.Items.Add(li);

            li = new ListItem();
            li.Text = "Femenino";
            li.Value = "f";
            rblGenero.Items.Add(li);
        }

        private void CargaActividades()
        {
            ListItem li;
            UsuarioRepository ur = new UsuarioRepository();
            rblActividad.Items.Clear();
            foreach (DataBase.usuario_actividad item in ur.ListarActividades())
            {
                li = new ListItem();
                li.Text = item.usuario_actividad1;
                li.Value = item.id_usuario_actividad.ToString();
                rblActividad.Items.Add(li);
            }
        }

        private void CargaObjetivos()
        {
            ListItem li;
            UsuarioRepository ur = new UsuarioRepository();
            rblObjetivo.Items.Clear();
            foreach (var item in ur.ListarObjetivos())
            {
                li = new ListItem();
                li.Text = item.usuario_objetivo1;
                li.Value = item.id_usuario_objetivo.ToString();
                rblObjetivo.Items.Add(li);
            }
        }

        private void CargaForm()
        {
            UsuarioCompleto usuario = (UsuarioCompleto)Session["UsuarioCompleto"];
            usuario_idr idr = new usuario_idr();
            IngestaRepository IdrPersist = new IngestaRepository();
            UsuarioRepository ur = new UsuarioRepository();
            nutricloudEntities c = new nutricloudEntities();

            CargaGeneros();
            CargaActividades();
            CargaObjetivos();

            //Datos generales
            LblFechaRegistro.Text = usuario.Usuario.f_registro.ToString("dd/MM/yyyy hh:mm");
            LblFechaUltimoIngreso.Text = usuario.Usuario.f_ultimo_ingreso != null ? usuario.Usuario.f_ultimo_ingreso.ToString() : "";
            LblEmail.Text = usuario.Usuario.email;
            TxtNombre.Text = !string.IsNullOrEmpty(usuario.Usuario.nombre) ? usuario.Usuario.nombre : "";
            rblGenero.SelectedValue = !string.IsNullOrEmpty(usuario.Usuario.sexo) ? usuario.Usuario.sexo : "";
            TxtFechaNacimiento.Text = usuario.Usuario.f_nacimiento != null ? usuario.Usuario.f_nacimiento.ToString() : "";
            imgPerfil.ImageUrl = "../Content/img/imagenes-de-perfil/" + ur.getNombreImagenUsuario(usuario.Usuario.id_usuario);

            //Datos físicos
            if (usuario.UsuarioDatos != null)
            {
                TxtPeso.Text = usuario.UsuarioDatos.peso_kg.ToString();
                TxtAltura.Text = usuario.UsuarioDatos.altura_cm.ToString();
                rblActividad.SelectedValue = usuario.UsuarioDatos.id_usuario_actividad.ToString();
                rblObjetivo.SelectedValue = usuario.UsuarioDatos.id_usuario_objetivo.ToString();
            }

            idr = IdrPersist.GetIDR(usuario.Usuario.id_usuario);

            //Ingesta diaria recomendada
            if (idr != null)
            {
                CCarbo.Text = Convert.ToString(idr.carbohidratos_totales_g);
                CProt.Text = Convert.ToString(idr.proteinas_g);
                CGrasas.Text = Convert.ToString(idr.grasa_total_g);
                CFibra.Text = Convert.ToString(idr.fibra_dietetica_g);
                CPot.Text = Convert.ToString(idr.potasio_mg);
                CVB1.Text = Convert.ToString(idr.tiamina_mg);
                CVB2.Text = Convert.ToString(idr.riboflavina_mg);
                CVB3.Text = Convert.ToString(idr.niacina_mg);
                CVitc.Text = Convert.ToString(idr.vitamina_c_mg);
                CCalcio.Text = Convert.ToString(idr.calcio_mg);
                CHierro.Text = Convert.ToString(idr.hierro_mg);
                CFosfo.Text = Convert.ToString(idr.fosforo_mg);
                CZinc.Text = Convert.ToString(idr.zinc_mg);
            }
            else
            {
                CCarbo.Text = "0";
                CProt.Text = "0";
                CGrasas.Text = "0";
                CFibra.Text = "0";
                CPot.Text = "0";
                CVB1.Text = "0";
                CVB2.Text = "0";
                CVB3.Text = "0";
                CVitc.Text = "0";
                CCalcio.Text = "0";
                CHierro.Text = "0";
                CFosfo.Text = "0";
                CZinc.Text = "0";
            }
        }

        private usuario MapeaFormUsuarioInfoGral()
        {
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];

            //Datos generales
            UsuarioCompleto.Usuario.nombre = TxtNombre.Text;
            UsuarioCompleto.Usuario.sexo = rblGenero.SelectedValue;
            UsuarioCompleto.Usuario.f_nacimiento = DateTime.Parse(TxtFechaNacimiento.Text);

            return UsuarioCompleto.Usuario;
        }

        private usuario_datos MapeaFormUsuarioDatosFisicos()
        {
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];

            //Datos físicos
            if (UsuarioCompleto.UsuarioDatos == null)
            {
                UsuarioCompleto.UsuarioDatos = new usuario_datos();
            }

            UsuarioCompleto.UsuarioDatos.id_usuario = UsuarioCompleto.Usuario.id_usuario;
            UsuarioCompleto.UsuarioDatos.peso_kg = decimal.Parse(TxtPeso.Text);
            UsuarioCompleto.UsuarioDatos.altura_cm = int.Parse(TxtAltura.Text);
            UsuarioCompleto.UsuarioDatos.id_usuario_actividad = int.Parse(rblActividad.SelectedValue);
            UsuarioCompleto.UsuarioDatos.id_usuario_objetivo = int.Parse(rblObjetivo.SelectedValue);
            UsuarioCompleto.UsuarioDatos.f_ingreso = DateTime.Now;

            return UsuarioCompleto.UsuarioDatos;
        }

        private bool ValidaInfoGral()
        {
            bool errores = false;
            Label lblError;
            ValidRepository vr = new ValidRepository();
            pnlErroresInfoGral.Controls.Clear();

            //Valida vacios
            if (!vr.ValidaVacio(TxtNombre.Text))
            {
                lblError = new Label();
                lblError.Text = "* El nombre no puede estar vacío";
                lblError.CssClass = "text-error";
                pnlErroresInfoGral.Controls.Add(lblError);
                errores = true;
            }

            if (rblGenero.SelectedValue == string.Empty)
            {
                lblError = new Label();
                lblError.Text = "* Debe seleccionar su género";
                lblError.CssClass = "text-error";
                pnlErroresInfoGral.Controls.Add(lblError);
                errores = true;
            }

            if (!vr.ValidaVacio(TxtFechaNacimiento.Text))
            {
                lblError = new Label();
                lblError.Text = "* La fecha de nacimiento no puede estar vacía";
                lblError.CssClass = "text-error";
                pnlErroresInfoGral.Controls.Add(lblError);
                errores = true;
            }

            return !errores;
        }

        private bool ValidaDatosFisicos()
        {
            bool errores = false;
            Label lblError;
            ValidRepository vr = new ValidRepository();
            pnlErroresDatosFisicos.Controls.Clear();

            //Valida vacios
            if (!vr.ValidaVacio(TxtPeso.Text))
            {
                lblError = new Label();
                lblError.Text = "* Su peso no puede estar vacío";
                lblError.CssClass = "text-error";
                pnlErroresDatosFisicos.Controls.Add(lblError);
                errores = true;
            }

            if (!vr.ValidaVacio(TxtAltura.Text))
            {
                lblError = new Label();
                lblError.Text = "* La altura no puede estar vacía";
                lblError.CssClass = "text-error";
                pnlErroresDatosFisicos.Controls.Add(lblError);
                errores = true;
            }

            if (rblActividad.SelectedValue == string.Empty)
            {
                lblError = new Label();
                lblError.Text = "* Debe seleccionar su nivel de actividad";
                lblError.CssClass = "text-error";
                pnlErroresDatosFisicos.Controls.Add(lblError);
                errores = true;
            }

            if (rblObjetivo.SelectedValue == string.Empty)
            {
                lblError = new Label();
                lblError.Text = "* Debe establecer su objetivo";
                lblError.CssClass = "text-error";
                pnlErroresDatosFisicos.Controls.Add(lblError);
                errores = true;
            }

            return !errores;
        }

        private void ActualizarIngesta()
        {
            UsuarioRepository ur = new UsuarioRepository();
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];
            usuario_idr idr = new usuario_idr();
            IngestaRepository IdrPersist = new IngestaRepository();
            double calorias;
            char sexo = Convert.ToChar(UsuarioCompleto.Usuario.sexo);

            calorias = ur.CalcularIngesta(UsuarioCompleto);

            CCarbo.Text = Convert.ToString(((calorias * 45) / 100) / 4);
            CProt.Text = Convert.ToString(((calorias * 35) / 100) / 9);
            CGrasas.Text = Convert.ToString(((calorias * 25) / 100) / 4);

            CAgua.Text = Convert.ToString(calorias);

            if (sexo == 'm')
                CFibra.Text = "30";
            else if (sexo == 'f')
                CFibra.Text = "25";
            else CFibra.Text = "0";

            CPot.Text = "4700";

            int edad = ur.CalcularEdad(UsuarioCompleto.Usuario);

            if (edad < 18)
            {
                if (sexo == 'm')
                {
                    CVB1.Text = "1,4";
                    CVB2.Text = "1,6";
                    CVB3.Text = "18";
                    CVitc.Text = "50";
                    CCalcio.Text = "1200";
                    CHierro.Text = "18";
                    CFosfo.Text = "1200";
                    CZinc.Text = "15";
                }
                else if (sexo == 'f')
                {
                    CVB1.Text = "1,1";
                    CVB2.Text = "1,3";
                    CVB3.Text = "15";
                    CVitc.Text = "50";
                    CCalcio.Text = "1200";
                    CHierro.Text = "18";
                    CFosfo.Text = "1200";
                    CZinc.Text = "15";
                }
                else CFibra.Text = "0";
            }
            else
            {
                if (sexo == 'm')
                {
                    CVB1.Text = "1,2";
                    CVB2.Text = "1,4";
                    CVB3.Text = "16";
                    CVitc.Text = "60";
                    CCalcio.Text = "800";
                    CHierro.Text = "10";
                    CFosfo.Text = "800";
                    CZinc.Text = "15";
                }
                else if (sexo == 'f')
                {
                    CVB1.Text = "1";
                    CVB2.Text = "1,2";
                    CVB3.Text = "13";
                    CVitc.Text = "60";
                    CCalcio.Text = "800";
                    CHierro.Text = "10";
                    CFosfo.Text = "800";
                    CZinc.Text = "15";
                }
                else CFibra.Text = "0";
            }

            CCol.Text = "300";

            switch (UsuarioCompleto.UsuarioDatos.id_usuario_actividad)
            {
                case 1:
                    CSodio.Text = "1800";
                    break;
                case 2:
                    CSodio.Text = "2000";
                    break;
                case 3:
                    CSodio.Text = "2100";
                    break;
                case 4:
                    CSodio.Text = "2300";
                    break;
                case 5:
                    CSodio.Text = "2500";
                    break;
                default:
                    CSodio.Text = "0";
                    break;
            }

            idr.id_usuario = Convert.ToInt32(UsuarioCompleto.Usuario.id_usuario);
            idr.energia_kcal = Convert.ToDecimal(calorias);
            idr.carbohidratos_totales_g = Convert.ToDecimal(CCarbo.Text);
            idr.proteinas_g = Convert.ToDecimal(CProt.Text);
            idr.grasa_total_g = Convert.ToDecimal(CGrasas.Text);
            idr.fibra_dietetica_g = Convert.ToDecimal(CFibra.Text);
            idr.potasio_mg = Convert.ToDecimal(CPot.Text);
            idr.tiamina_mg = Convert.ToDecimal(CVB1.Text);
            idr.riboflavina_mg = Convert.ToDecimal(CVB2.Text);
            idr.niacina_mg = Convert.ToDecimal(CVB3.Text);
            idr.vitamina_c_mg = Convert.ToDecimal(CVitc.Text);
            idr.calcio_mg = Convert.ToDecimal(CCalcio.Text);
            idr.hierro_mg = Convert.ToDecimal(CHierro.Text);
            idr.fosforo_mg = Convert.ToDecimal(CFosfo.Text);
            idr.zinc_mg = Convert.ToDecimal(CZinc.Text);
            idr.agua_g = Convert.ToDecimal(CAgua.Text);
            idr.sodio_mg = Convert.ToDecimal(CSodio.Text);
            idr.colesterol_mg = Convert.ToDecimal(CCol.Text);

            if (IdrPersist.GetIDR(UsuarioCompleto.Usuario.id_usuario) == null)
                IdrPersist.InsertarIngesta(idr);
            else
                IdrPersist.ActualizarIngesta(idr);
        }

        #endregion

        #region Eventos

        protected void Page_PreInit(object sender, EventArgs e)
        {
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];

            if (UsuarioCompleto == null)
                Response.Redirect("~/Default.aspx");
            else
            {
                if (UsuarioCompleto.Usuario.id_usuario_tipo == 1)
                {
                    this.Page.MasterPageFile = "~/HeaderFooter.Master";
                }
                else if (UsuarioCompleto.Usuario.id_usuario_tipo == 2)
                {
                    this.Page.MasterPageFile = "~/MasterPro.Master";
                    //Response.Redirect("~/Profesionales/Home.aspx");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];

            if (UsuarioCompleto.Usuario.id_usuario_tipo == 1)
            {
                divDatosFisicos.Visible = true;
                divIngestaDiaria.Visible = true;
            }
            else if (UsuarioCompleto.Usuario.id_usuario_tipo == 2)
            {
                divDatosFisicos.Visible = false;
                divIngestaDiaria.Visible = false;
            }

            if (!IsPostBack)
            {
                CargaForm();
            }
        }

        protected void btnActualizarInfoGral_Click(object sender, EventArgs e)
        {
            UsuarioCompleto usuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];
            usuario_imagen usuarioImagen = new usuario_imagen();

            if (ValidaInfoGral())
            {
                UsuarioRepository ur = new UsuarioRepository();
                ur.ActualizarUsuario(MapeaFormUsuarioInfoGral());

                if (fileImgPerfil.HasFile)
                {
                    StringBuilder fileName = new StringBuilder();
                    fileName.Append(usuarioCompleto.Usuario.id_usuario + "-");
                    fileName.Append(DateTime.Now.Year);
                    fileName.Append("." + DateTime.Now.Month);
                    fileName.Append("." + DateTime.Now.Day);
                    fileName.Append("." + DateTime.Now.Hour);
                    fileName.Append("." + DateTime.Now.Minute);
                    fileName.Append("." + DateTime.Now.Second);
                    fileName.Append("." + DateTime.Now.Millisecond);
                    fileName.Append(Path.GetExtension(fileImgPerfil.PostedFile.FileName));

                    string serverPath = Server.MapPath("~/Content/img/imagenes-de-perfil/");
                    string path = Path.Combine(serverPath, fileName.ToString());
                    fileImgPerfil.SaveAs(path);

                    usuarioImagen.nombre_imagen = fileName.ToString();

                }
                else
                {
                    usuarioImagen.nombre_imagen = null;
                }

                usuarioImagen.id_usuario = usuarioCompleto.Usuario.id_usuario;
                ur.actualizarFotoDePerfil(usuarioImagen);
                imgPerfil.ImageUrl = "../Content/img/imagenes-de-perfil/" + ur.getNombreImagenUsuario(usuarioCompleto.Usuario.id_usuario);


                if (ValidaDatosFisicos()) //validacion para calculo de ingesta
                {
                    ActualizarIngesta();
                }

                lblAviso.Visible = true;
                lblAviso.Text = "¡Se ha actualizado la información correctamente!";
            }
            else
            {
                lblAviso.Visible = true;
                lblAviso.Text = "Ha ocurrido un error, inténtalo nuevamente.";
            }
        }

        protected void btnActualizarDatosFisicos_Click(object sender, EventArgs e)
        {
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];
            if (ValidaDatosFisicos())
            {
                UsuarioRepository ur = new UsuarioRepository();
                if (UsuarioCompleto.UsuarioDatos == null)
                    ur.InsertarDatosUsuario(MapeaFormUsuarioDatosFisicos());
                else
                    ur.ActualizarDatosUsuario(MapeaFormUsuarioDatosFisicos());
                if (ValidaInfoGral())
                {
                    ActualizarIngesta();
                }
                LblAviso2.Visible = true;
                LblAviso2.Text = "¡Se ha actualizado la información correctamente!";
            }
            else
            {
                LblAviso2.Visible = true;
                LblAviso2.Text = "Ha ocurrido un error, inténtalo nuevamente.";
            }


        }

        #endregion
    }
}