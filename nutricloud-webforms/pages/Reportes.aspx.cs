using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nutricloud_webforms.Models;
using nutricloud_webforms.DataBase;
using nutricloud_webforms.Repositories;

namespace nutricloud_webforms
{
    public partial class Reportes : System.Web.UI.Page
    {
        nutricloudEntities c = new nutricloudEntities();
        ReporteRepository r = new ReporteRepository();

        void Page_PreInit(object sender, EventArgs e)
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

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];
            Reporte reportedia = new Reporte();
            Reporte reportequincena = new Reporte();
            //DateTime fecha = (DateTime)Session["fecha_diario"];

            Chart1.Series["Nutrientes-dia"]["PieLabelStyle"] = "Outside";
            Chart1.Series["Nutrientes-dia"]["IsValueShownAsLabel"] = "true";

            reportedia = r.calcularNutrientesDiarios(UsuarioCompleto.Usuario.id_usuario, fechaAnterior(1));
            reportequincena = r.calcularNutrientesQuinceDias(UsuarioCompleto.Usuario.id_usuario, fechaAnterior(15), DateTime.Today);


            this.Chart1.Series["Nutrientes-dia"].Points.AddXY("Carbohidratos", reportedia.carbo);
            this.Chart1.Series["Nutrientes-dia"].Points.AddXY("Proteinas", reportedia.proteina);
            this.Chart1.Series["Nutrientes-dia"].Points.AddXY("Grasas", reportedia.grasa);
            this.Chart1.Series["Nutrientes-dia"].Points.AddXY("FIbra", reportedia.fibra);
            this.Chart1.Series["Nutrientes-dia"].Points.AddXY("Agua", reportedia.agua);
            this.Chart1.Series["Nutrientes-dia"].Points.AddXY("Sodio", reportedia.sodio / 100);
            this.Chart1.Series["Nutrientes-dia"].Points.AddXY("Calcio", reportedia.calcio / 100);
            this.Chart1.Series["Nutrientes-dia"].Points.AddXY("Colesterol", reportedia.colesterol / 100);
            this.Chart1.Series["Nutrientes-dia"].Points.AddXY("Hierro", reportedia.hierro / 100);
            this.Chart1.Series["Nutrientes-dia"].Points.AddXY("Potasio", reportedia.potasio / 100);
            this.Chart1.Series["Nutrientes-dia"].Points.AddXY("Fosforo", reportedia.fosforo / 100);
            this.Chart1.Series["Nutrientes-dia"].Points.AddXY("Vitamina C", reportedia.vitc / 100);

            CaloriasD.Text = Convert.ToString(reportedia.energia_kcal);
            ProteinasD.Text = Convert.ToString(reportedia.proteina);
            CarbohidratosD.Text = Convert.ToString(reportedia.carbo);
            GrasasD.Text = Convert.ToString(reportedia.grasa);
            PotasioD.Text = Convert.ToString(reportedia.potasio);
            CalcioD.Text = Convert.ToString(reportedia.calcio);
            FosforoD.Text = Convert.ToString(reportedia.fosforo);
            HierroD.Text = Convert.ToString(reportedia.hierro);
            AguaD.Text = Convert.ToString(reportedia.agua);
            ColesterolD.Text = Convert.ToString(reportedia.colesterol);
            VitaCD.Text = Convert.ToString(reportedia.vitc);
            SodioD.Text = Convert.ToString(reportedia.sodio);
            FibraD.Text = Convert.ToString(reportedia.fibra);

            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Grasas", reportequincena.grasa);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Carbohidratos", reportequincena.carbo);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Proteinas", reportequincena.proteina);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Fibra", reportequincena.fibra);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Agua", reportequincena.agua);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Calcio", reportequincena.calcio / 100);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Colesterol", reportequincena.colesterol / 100);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Sodio", reportequincena.sodio / 100);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Hierro", reportequincena.hierro / 100);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Potasio", reportequincena.potasio / 100);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Fosforo", reportequincena.fosforo / 100);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Vitamina C", reportequincena.vitc / 100);

            CaloriasQ.Text = /*Convert.ToString(reportequincena.energia_kcal)*/reportequincena.energia_kcal.ToString("#.##");
            ProteinasQ.Text = Convert.ToString(reportequincena.proteina);
            CarbohidratosQ.Text = Convert.ToString(reportequincena.carbo);
            GrasasQ.Text = Convert.ToString(reportequincena.grasa);
            PotasioQ.Text = Convert.ToString(reportequincena.potasio);
            CalcioQ.Text = Convert.ToString(reportequincena.calcio);
            FosforoQ.Text = Convert.ToString(reportequincena.fosforo);
            HierroQ.Text = Convert.ToString(reportequincena.hierro);
            AguaQ.Text = Convert.ToString(reportequincena.agua);
            ColesterolQ.Text = Convert.ToString(reportequincena.colesterol);
            VitaCQ.Text = Convert.ToString(reportequincena.vitc);
            SodioQ.Text = Convert.ToString(reportequincena.sodio);
            FibraQ.Text = Convert.ToString(reportequincena.fibra);


            evaluacionDia();
            evaluacionQuince();


        }

        protected DateTime fechaAnterior(int dias)
        {
            DateTime pasada = DateTime.Today.AddDays(-dias);

            return pasada;
        }

        protected int restarDias(DateTime fecha)
        {
            int diferencia = DateTime.Today.Day - fecha.Day;

            return diferencia;

        }

        public void evaluacionDia()
        {
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];
            IngestaRepository Ingesta = new IngestaRepository();
            Reporte reporteUsuario = r.calcularNutrientesDiarios(UsuarioCompleto.Usuario.id_usuario, fechaAnterior(1));
            usuario_idr idrusuario = Ingesta.GetIDR(UsuarioCompleto.Usuario.id_usuario);

            RecomendacionesAyer.CargaRecomendaciones(idrusuario, reporteUsuario);
        }

        public void evaluacionQuince()
        {
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];
            IngestaRepository Ingesta = new IngestaRepository();
            Reporte reporteUsuario = r.calcularNutrientesQuinceDias(UsuarioCompleto.Usuario.id_usuario, fechaAnterior(15), DateTime.Today);
            usuario_idr idrusuario = Ingesta.GetIDR(UsuarioCompleto.Usuario.id_usuario);

            RecomendacionesQuince.CargaRecomendaciones(idrusuario, reporteUsuario);
        }
    }
}
