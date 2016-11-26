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
                Response.Redirect("../Default.aspx");
            else
            {
                if (UsuarioCompleto.Usuario.id_usuario_tipo == 1)
                    this.Page.MasterPageFile = "~/HeaderFooter.Master";
                else if (UsuarioCompleto.Usuario.id_usuario_tipo == 2)
                    Response.Redirect("Profesionales/Home.aspx");
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
            this.Chart1.Series["Nutrientes-dia"].Points.AddXY("Calcio", reportedia.calcio);
            this.Chart1.Series["Nutrientes-dia"].Points.AddXY("Colesterol", reportedia.colesterol);
            this.Chart1.Series["Nutrientes-dia"].Points.AddXY("Hierro", reportedia.hierro);
            this.Chart1.Series["Nutrientes-dia"].Points.AddXY("Potasio", reportedia.potasio);
            this.Chart1.Series["Nutrientes-dia"].Points.AddXY("Fosforo", reportedia.fosforo);
            this.Chart1.Series["Nutrientes-dia"].Points.AddXY("Vitamina C", reportedia.vitc);

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

            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Grasas", reportequincena.grasa);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Carbohidratos", reportequincena.carbo);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Proteinas", reportequincena.proteina);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Fibra", reportequincena.fibra);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Agua", reportequincena.agua);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Calcio", reportequincena.calcio);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Colesterol", reportequincena.colesterol);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Hierro", reportequincena.hierro);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Potasio", reportequincena.potasio);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Fosforo", reportequincena.fosforo);
            this.Chart2.Series["Nutrientes-quince"].Points.AddXY("Vitamina C", reportequincena.vitc);

            CaloriasQ.Text = Convert.ToString(reportequincena.energia_kcal);
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

            Label LblEval;
            Panel2.Controls.Clear();

            if (Convert.ToDecimal(idrusuario.energia_kcal)/2 > reporteUsuario.energia_kcal)
            {
                LblEval = new Label();
                LblEval.Text = "Los valores no son los minimos como para poder evaluar. Completa tu ingesta mas detalladamente.";
                Panel2.Controls.Add(LblEval);
            } else
            {
                if (idrusuario.energia_kcal > reporteUsuario.energia_kcal)
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo una cantidad menor de calorias a la recomendada.";
                    Panel2.Controls.Add(LblEval);
                } else
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo una cantidad mayor de calorias a la recomendada.";
                    Panel2.Controls.Add(LblEval);
                }

                if (idrusuario.carbohidratos_totales_g > reporteUsuario.carbo)
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo una cantidad menor de carbohidratos a la recomendada. Recomendamos los siguientes alimentos ricos en carbohidratos: <br/> - Manzana <br/> - Arroz integral <br/> - Nueces y semillas <br/> - Berenjena <br/>";
                    Panel2.Controls.Add(LblEval);
                }
                else
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo una cantidad mayor de carbohidratos a la recomendada. Recomendamos que reduzcas el consumo de los siguientes alimentos: <br/> - Pastas blancas <br/> - Cereal refinado <br/> - Pan blanco <br/> - Productos procesados de papa <br/>";
                    Panel2.Controls.Add(LblEval);
                }
                if (idrusuario.proteinas_g > reporteUsuario.proteina)
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo una cantidad menor de proteinas a la recomendada. Recomendamos los siguientes alimentos ricos en proteina: <br/> - Pollo <br/> - Clara de huevo <br/> - Pescado <br/> - Lentejas <br/> - Brocoli <br/> - Mani <br/>";
                    Panel2.Controls.Add(LblEval);
                }
                else
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo una cantidad mayor de proteinas a la recomendada. Recomendamos los siguientes alimentos: <br/> - Verduras de hoja <br/> - Hortalizas <br/>";
                    Panel2.Controls.Add(LblEval);
                }
                if (idrusuario.grasa_total_g > reporteUsuario.grasa)
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo una cantidad menor de grasas a la recomendada. Debes llevar un consumo de grasas equilibradas. Recomendamos: <br/> - Nueces, frutos secos <br/> - Pescado <br/> - Carnes rojas <br/>";
                    Panel2.Controls.Add(LblEval);
                } else
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo una cantidad mayor de grasas a la recomendada. Debes llevar un consumo de grasas equilibradas. Recomendamos que regules el consumo de carnes rojas, alimentos procesados (dulces, galletitas) y productos panificados";
                    Panel2.Controls.Add(LblEval);
                }
                if (idrusuario.fibra_dietetica_g >= reporteUsuario.fibra)
                {
                    LblEval = new Label();
                    LblEval.Text = "Un consumo bajo en fibra provoca severos problemas en la digestion y aumenta el riesgo de diabetes. Recomendamos que consumas los siguientes alimentos ricos en fibra: <br/> - Verduras (tomate, lechuga, zanahoria) <br/> - Frutas (ciruela, pera, durazno, manzana) <br/>";
                    Panel2.Controls.Add(LblEval);
                } else
                {
                    LblEval = new Label();
                    LblEval.Text = "Un consumo alto de fibra puede llevar a problemas digestivos, especialmente en la digestion de vitaminas y minerales. Reduzca el consumo de alimentos ricos en fibra.";
                    Panel2.Controls.Add(LblEval);
                }
                if (idrusuario.agua_g > reporteUsuario.agua)
                {
                    LblEval = new Label();
                    LblEval.Text = "Detectamos un bajo consumo de liquidos en tu dieta. Esto puede conllevar a problemas digestivos, mayor estres y mayor propension a alergias. Aumente urgentemente el consumo de agua";
                    Panel2.Controls.Add(LblEval);
                }
                else if(idrusuario.agua_g*2 < reporteUsuario.agua)
                {
                    LblEval = new Label();
                    LblEval.Text = "Detectamos un consumo excesivo de agua. Te recomendamos volver a los valores de ingesta diaria recomendada de agua";
                    Panel2.Controls.Add(LblEval);
                }
                if(idrusuario.potasio_mg >= reporteUsuario.potasio)
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo una cantidad baja de potasio. Recomendamos los siguientes alimentos: <br/> - Banana <br/> - Acelga <br/> - Espinaca";
                    Panel2.Controls.Add(LblEval);
                }
                if(idrusuario.sodio_mg >= reporteUsuario.potasio)
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo sodio por debajo de lo recomendado. Compensa esta falta ingieriendo mas sal de mesa, bebidas isotonicas, quesos y caldos";
                    Panel2.Controls.Add(LblEval);
                }
                else
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo muchos alimentos con sodio, lo cual puede llevar a la hipertension arterial y problemas oseos. Reduce el consumo de sal de mesa y de embutidos";
                    Panel2.Controls.Add(LblEval);
                }
                if(idrusuario.calcio_mg >= reporteUsuario.calcio)
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo bajos niveles de calcio. Recomendamos que compenses esta falta ingiriendo: <br/> - Mayonesa <br/> - lechuga <br/> - pasas de uva <br/> - alga <br/> - hinojo <br/> - leche";
                    Panel2.Controls.Add(LblEval);
                }
                if(idrusuario.hierro_mg >= reporteUsuario.hierro)
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo alimentos bajos en hierro. Compensa esta falta con estos alimentos: <br/> - Huevos <br/> - Pescado <br/> - Legumbres (soja, lentejas, garbanzos) <br/> - Espinaca <br/> - Acelga <br/> - Carnes rojas <br/>";
                    Panel2.Controls.Add(LblEval);
                }
                if(idrusuario.fosforo_mg >= reporteUsuario.fosforo)
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo alimentos bajos en fosforo. Para compensar esta falta puede consumir: <br/> - Carnes rojas <br/> - Cereales de salvado y avena <br/> - Leches y derivados <br/>";
                    Panel2.Controls.Add(LblEval);
                }
                if(idrusuario.colesterol_mg <= reporteUsuario.colesterol)
                {
                    LblEval = new Label();
                    LblEval.Text = "Un consumo excesivo de alimentos ricos en grasas saturadas contribuye al aumento de los niveles de colesterol. Para reducir estos niveles recomendamos que baje el consumo de alimentos procesados, harinas refinadas, mantecas y carnes rojas. Consulte con su medico su nivel actual de colesterol en sangre.";
                    Panel2.Controls.Add(LblEval);
                }
            }

        }

        public void evaluacionQuince()
        {
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];
            IngestaRepository Ingesta = new IngestaRepository();
            Reporte reporteUsuario = r.calcularNutrientesQuinceDias(UsuarioCompleto.Usuario.id_usuario, fechaAnterior(15), DateTime.Today);
            usuario_idr idrusuario = Ingesta.GetIDR(UsuarioCompleto.Usuario.id_usuario);

            Label LblEval;
            Panel1.Controls.Clear();

            if (idrusuario.energia_kcal / 2 > reporteUsuario.energia_kcal)
            {
                LblEval = new Label();
                LblEval.Text = "Los valores no son los minimos como para poder evaluar. Completa tu ingesta mas detalladamente.";
                Panel1.Controls.Add(LblEval);
            }
            else
            {
                if (idrusuario.energia_kcal > reporteUsuario.energia_kcal)
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo una cantidad menor de calorias a la recomendada.";
                    Panel1.Controls.Add(LblEval);
                }
                else
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo una cantidad mayor de calorias a la recomendada.";
                    Panel1.Controls.Add(LblEval);
                }

                if (idrusuario.carbohidratos_totales_g > reporteUsuario.carbo)
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo una cantidad menor de carbohidratos a la recomendada. Recomendamos los siguientes alimentos ricos en carbohidratos: <br/> - Manzana <br/> - Arroz integral <br/> - Nueces y semillas <br/> - Berenjena <br/>";
                    Panel1.Controls.Add(LblEval);
                }
                else
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo una cantidad mayor de carbohidratos a la recomendada. Recomendamos que reduzcas el consumo de los siguientes alimentos: <br/> - Pastas blancas <br/> - Cereal refinado <br/> - Pan blanco <br/> - Productos procesados de papa <br/>";
                    Panel1.Controls.Add(LblEval);
                }
                if (idrusuario.proteinas_g > reporteUsuario.proteina)
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo una cantidad menor de proteinas a la recomendada. Recomendamos los siguientes alimentos ricos en proteina: <br/> - Pollo <br/> - Clara de huevo <br/> - Pescado <br/> - Lentejas <br/> - Brocoli <br/> - Mani <br/>";
                    Panel1.Controls.Add(LblEval);
                }
                else
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo una cantidad mayor de proteinas a la recomendada. Recomendamos los siguientes alimentos: <br/> - Verduras de hoja <br/> - Hortalizas <br/>";
                    Panel1.Controls.Add(LblEval);
                }
                if (idrusuario.grasa_total_g > reporteUsuario.grasa)
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo una cantidad menor de grasas a la recomendada. Debes llevar un consumo de grasas equilibradas. Recomendamos: <br/> - Nueces, frutos secos <br/> - Pescado <br/> - Carnes rojas <br/>";
                    Panel1.Controls.Add(LblEval);
                }
                else
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo una cantidad mayor de grasas a la recomendada. Debes llevar un consumo de grasas equilibradas. Recomendamos que regules el consumo de carnes rojas, alimentos procesados (dulces, galletitas) y productos panificados";
                    Panel1.Controls.Add(LblEval);
                }
                if (idrusuario.fibra_dietetica_g >= reporteUsuario.fibra)
                {
                    LblEval = new Label();
                    LblEval.Text = "Un consumo bajo en fibra provoca severos problemas en la digestion y aumenta el riesgo de diabetes. Recomendamos que consumas los siguientes alimentos ricos en fibra: <br/> - Verduras (tomate, lechuga, zanahoria) <br/> - Frutas (ciruela, pera, durazno, manzana) <br/>";
                    Panel1.Controls.Add(LblEval);
                }
                else
                {
                    LblEval = new Label();
                    LblEval.Text = "Un consumo alto de fibra puede llevar a problemas digestivos, especialmente en la digestion de vitaminas y minerales. Reduzca el consumo de alimentos ricos en fibra.";
                    Panel1.Controls.Add(LblEval);
                }
                if (idrusuario.agua_g > reporteUsuario.agua)
                {
                    LblEval = new Label();
                    LblEval.Text = "Detectamos un bajo consumo de liquidos en tu dieta. Esto puede conllevar a problemas digestivos, mayor estres y mayor propension a alergias. Aumente urgentemente el consumo de agua";
                    Panel1.Controls.Add(LblEval);
                }
                else if (idrusuario.agua_g * 2 < reporteUsuario.agua)
                {
                    LblEval = new Label();
                    LblEval.Text = "Detectamos un consumo excesivo de agua. Te recomendamos volver a los valores de ingesta diaria recomendada de agua";
                    Panel1.Controls.Add(LblEval);
                }
                if (idrusuario.potasio_mg >= reporteUsuario.potasio)
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo una cantidad baja de potasio. Recomendamos los siguientes alimentos: <br/> - Banana <br/> - Acelga <br/> - Espinaca";
                    Panel1.Controls.Add(LblEval);
                }
                if (idrusuario.sodio_mg >= reporteUsuario.potasio)
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo sodio por debajo de lo recomendado. Compensa esta falta ingieriendo mas sal de mesa, bebidas isotonicas, quesos y caldos";
                    Panel1.Controls.Add(LblEval);
                }
                else
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo muchos alimentos con sodio, lo cual puede llevar a la hipertension arterial y problemas oseos. Reduce el consumo de sal de mesa y de embutidos";
                    Panel1.Controls.Add(LblEval);
                }
                if (idrusuario.calcio_mg >= reporteUsuario.calcio)
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo bajos niveles de calcio. Recomendamos que compenses esta falta ingiriendo: <br/> - Mayonesa <br/> - lechuga <br/> - pasas de uva <br/> - alga <br/> - hinojo <br/> - leche";
                    Panel1.Controls.Add(LblEval);
                }
                if (idrusuario.hierro_mg >= reporteUsuario.hierro)
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo alimentos bajos en hierro. Compensa esta falta con estos alimentos: <br/> - Huevos <br/> - Pescado <br/> - Legumbres (soja, lentejas, garbanzos) <br/> - Espinaca <br/> - Acelga <br/> - Carnes rojas <br/>";
                    Panel1.Controls.Add(LblEval);
                }
                if (idrusuario.fosforo_mg >= reporteUsuario.fosforo)
                {
                    LblEval = new Label();
                    LblEval.Text = "Estas consumiendo alimentos bajos en fosforo. Para compensar esta falta puede consumir: <br/> - Carnes rojas <br/> - Cereales de salvado y avena <br/> - Leches y derivados <br/>";
                    Panel1.Controls.Add(LblEval);
                }
                if (idrusuario.colesterol_mg <= reporteUsuario.colesterol)
                {
                    LblEval = new Label();
                    LblEval.Text = "Un consumo excesivo de alimentos ricos en grasas saturadas contribuye al aumento de los niveles de colesterol. Para reducir estos niveles recomendamos que baje el consumo de alimentos procesados, harinas refinadas, mantecas y carnes rojas. Consulte con su medico su nivel actual de colesterol en sangre.";
                    Panel1.Controls.Add(LblEval);
                }

            }
        }
    }
}
 