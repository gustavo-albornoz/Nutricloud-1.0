﻿using System;
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

       /* protected void Download_Click (object sender, EventArgs e)
        {
            Label TxtUrl = new Label();

            TxtUrl.Text = "http://localhost:20676/Pages/Reportes.aspx";

            HtmlToPdf converter = new HtmlToPdf();

            PdfDocument doc = converter.ConvertUrl(TxtUrl.Text);

            // save pdf document
            doc.Save(Response, false, "Reporte.pdf");

            // close pdf document
            doc.Close();
        }*/

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static string cargaRepoDia()
        {
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)HttpContext.Current.Session["UsuarioCompleto"];
            Reporte reportedia = new Reporte();
            ReporteRepository r = new ReporteRepository();
            Reportes relocal = new Reportes();

            Reporte reporDia = r.calcularNutrientesDiarios(UsuarioCompleto.Usuario.id_usuario, relocal.fechaAnterior(1));

            var json = JsonConvert.SerializeObject(reporDia,Formatting.Indented);

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
 