using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nutricloud_webforms.Models;
using nutricloud_webforms.DataBase;
using nutricloud_webforms.Repositories;
using SelectPdf;
using System.Web.Services;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections;
using Newtonsoft.Json;
using System.Web.Script.Services;

namespace nutricloud_webforms.Pages
{
    public partial class ReportesPDF : System.Web.UI.Page
    {
        nutricloudEntities c = new nutricloudEntities();
        ReporteRepository r = new ReporteRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            int idUsuario = int.Parse(Request.QueryString["id"]);
            UsuarioCompleto uc = new UsuarioCompleto();
            uc.Usuario = new usuario();
            uc.Usuario.id_usuario = idUsuario;
            Session.Add("UsuarioCompleto", uc);

            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];

            Reporte reportedia = new Reporte();
            Reporte reportequincena = new Reporte();

            reportedia = r.calcularNutrientesDiarios(UsuarioCompleto.Usuario.id_usuario, fechaAnterior(1));
            reportequincena = r.calcularNutrientesQuinceDias(UsuarioCompleto.Usuario.id_usuario, fechaAnterior(15), DateTime.Today);

            CaloriasD.Text = reportedia.calorias.ToString("F");
            ProteinasD.Text = reportedia.proteina.ToString("F");
            CarbohidratosD.Text = reportedia.carbohidratos.ToString("F");
            GrasasD.Text = reportedia.grasa.ToString("F");
            PotasioD.Text = reportedia.potasio.ToString("F");
            CalcioD.Text = reportedia.calcio.ToString("F");
            FosforoD.Text = reportedia.fosforo.ToString("F");
            HierroD.Text = reportedia.hierro.ToString("F");
            AguaD.Text = reportedia.agua.ToString("F");
            ColesterolD.Text = reportedia.colesterol.ToString("F");
            VitaCD.Text = reportedia.vitaminaC.ToString("F");
            SodioD.Text = reportedia.sodio.ToString("F");
            FibraD.Text = reportedia.fibra.ToString("F");

            CaloriasQ.Text = reportequincena.calorias.ToString("F");
            ProteinasQ.Text = reportequincena.proteina.ToString("F");
            CarbohidratosQ.Text = reportequincena.carbohidratos.ToString("F");
            GrasasQ.Text = reportequincena.grasa.ToString("F");
            PotasioQ.Text = reportequincena.potasio.ToString("F");
            CalcioQ.Text = reportequincena.calcio.ToString("F");
            FosforoQ.Text = reportequincena.fosforo.ToString("F");
            HierroQ.Text = reportequincena.hierro.ToString("F");
            AguaQ.Text = reportequincena.agua.ToString("F");
            ColesterolQ.Text = reportequincena.colesterol.ToString("F");
            VitaCQ.Text = reportequincena.vitaminaC.ToString("F");
            SodioQ.Text = reportequincena.sodio.ToString("F");
            FibraQ.Text = reportequincena.fibra.ToString("F");

            DateTime hoyMenosQuince = DateTime.Now.AddDays(-15);
            DateTime hoyMenosUno = DateTime.Now.AddDays(-1);

            fechasUltimaQuincena.Text = "(" + hoyMenosQuince.ToString("dd/MM/yyyy") + " - " + DateTime.Now.ToString("dd/MM/yyyy") + ")";
            fechaDiaAnterior.Text = "(" + hoyMenosUno.ToString("dd/MM/yyyy") + ")";
        }

        public DateTime fechaAnterior(int dias)
        {
            DateTime pasada = DateTime.Today.AddDays(-dias);

            return pasada;
        }

        protected int restarDias(DateTime fecha)
        {
            int diferencia = DateTime.Today.Day - fecha.Day;

            return diferencia;

        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public static string cargaRepoDia()
        {
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)HttpContext.Current.Session["UsuarioCompleto"];
            Reporte reportedia = new Reporte();
            ReporteRepository r = new ReporteRepository();
            Reportes relocal = new Reportes();

            Reporte reporDia = r.calcularNutrientesDiarios(UsuarioCompleto.Usuario.id_usuario, relocal.fechaAnterior(1));

            var json = JsonConvert.SerializeObject(reporDia, Formatting.Indented);

            return json;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public static string cargaRepoQuince()
        {
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)HttpContext.Current.Session["UsuarioCompleto"];
            ReporteRepository r = new ReporteRepository();
            Reportes relocal = new Reportes();

            Reporte reporte1 = new Reporte();
            Reporte reporte2 = new Reporte();
            Reporte reporte3 = new Reporte();
            Reporte reporte4 = new Reporte();
            Reporte reporte5 = new Reporte();

            reporte1 = r.calcularNutrientesDiarios(UsuarioCompleto.Usuario.id_usuario, relocal.fechaAnterior(1));
            reporte2 = r.calcularNutrientesDiarios(UsuarioCompleto.Usuario.id_usuario, relocal.fechaAnterior(4));
            reporte3 = r.calcularNutrientesDiarios(UsuarioCompleto.Usuario.id_usuario, relocal.fechaAnterior(8));
            reporte4 = r.calcularNutrientesDiarios(UsuarioCompleto.Usuario.id_usuario, relocal.fechaAnterior(12));
            reporte5 = r.calcularNutrientesDiarios(UsuarioCompleto.Usuario.id_usuario, relocal.fechaAnterior(15));

            Dictionary<String, Decimal> lista1 = new Dictionary<String, Decimal>
            {
                {relocal.fechaAnterior(15).ToString("yyyy-MM-dd hh:mm"),reporte5.proteina },
                {relocal.fechaAnterior(12).ToString("yyyy-MM-dd hh:mm"),reporte4.proteina },
                {relocal.fechaAnterior(8).ToString("yyyy-MM-dd hh:mm"),reporte3.proteina },
                {relocal.fechaAnterior(4).ToString("yyyy-MM-dd hh:mm"),reporte2.proteina },
                {relocal.fechaAnterior(1).ToString("yyyy-MM-dd hh:mm"),reporte1.proteina }
            };

            Dictionary<String, Decimal> lista2 = new Dictionary<String, Decimal>
            {
                {relocal.fechaAnterior(15).ToString("yyyy-MM-dd hh:mm"),reporte5.carbohidratos },
                {relocal.fechaAnterior(12).ToString("yyyy-MM-dd hh:mm"),reporte4.carbohidratos },
                {relocal.fechaAnterior(8).ToString("yyyy-MM-dd hh:mm"),reporte3.carbohidratos },
                {relocal.fechaAnterior(4).ToString("yyyy-MM-dd hh:mm"),reporte2.carbohidratos },
                {relocal.fechaAnterior(1).ToString("yyyy-MM-dd hh:mm"),reporte1.carbohidratos }
            };

            Dictionary<String, Decimal> lista3 = new Dictionary<String, Decimal>
            {
                {relocal.fechaAnterior(15).ToString("yyyy-MM-dd hh:mm"),reporte5.grasa },
                {relocal.fechaAnterior(12).ToString("yyyy-MM-dd hh:mm"),reporte4.grasa },
                {relocal.fechaAnterior(8).ToString("yyyy-MM-dd hh:mm"),reporte3.grasa },
                {relocal.fechaAnterior(4).ToString("yyyy-MM-dd hh:mm"),reporte2.grasa },
                {relocal.fechaAnterior(1).ToString("yyyy-MM-dd hh:mm"),reporte1.grasa }
            };

            Dictionary<String, Decimal> lista4 = new Dictionary<String, Decimal>
            {
                {relocal.fechaAnterior(15).ToString("yyyy-MM-dd hh:mm"),reporte5.agua },
                {relocal.fechaAnterior(12).ToString("yyyy-MM-dd hh:mm"),reporte4.agua },
                {relocal.fechaAnterior(8).ToString("yyyy-MM-dd hh:mm"),reporte3.agua },
                {relocal.fechaAnterior(4).ToString("yyyy-MM-dd hh:mm"),reporte2.agua },
                {relocal.fechaAnterior(1).ToString("yyyy-MM-dd hh:mm"),reporte1.agua }
            };

            Dictionary<String, Decimal> lista5 = new Dictionary<String, Decimal>
            {
                {relocal.fechaAnterior(15).ToString("yyyy-MM-dd hh:mm"),reporte5.fibra },
                {relocal.fechaAnterior(12).ToString("yyyy-MM-dd hh:mm"),reporte4.fibra },
                {relocal.fechaAnterior(8).ToString("yyyy-MM-dd hh:mm"),reporte3.fibra },
                {relocal.fechaAnterior(4).ToString("yyyy-MM-dd hh:mm"),reporte2.fibra },
                {relocal.fechaAnterior(1).ToString("yyyy-MM-dd hh:mm"),reporte1.fibra }
            };

            List<Object> listafull = new List<Object>();
            listafull.Add(lista1);
            listafull.Add(lista2);
            listafull.Add(lista3);
            listafull.Add(lista4);
            listafull.Add(lista5);

            var json = JsonConvert.SerializeObject(listafull, Formatting.Indented);

            return json;
        }

    }
}
