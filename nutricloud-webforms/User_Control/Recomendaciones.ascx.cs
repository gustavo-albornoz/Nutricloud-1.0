using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nutricloud_webforms.DataBase;
using nutricloud_webforms.Models;

namespace nutricloud_webforms.User_Control
{
    public partial class Recomendaciones : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void CargaRecomendaciones(usuario_idr idrusuario, Reporte reporteUsuario)
        {
            if (idrusuario == null || Convert.ToDecimal(idrusuario.energia_kcal) / 2 > reporteUsuario.energia_kcal)
            {
                lblErrorAyer.Visible = true;
                divRecomendaciones.Visible = false;
            }
            else
            {
                lblErrorAyer.Visible = false;
                divRecomendaciones.Visible = true;

                if (idrusuario.energia_kcal > reporteUsuario.energia_kcal)
                {
                    ttCalorias.Attributes.Add("class", "btn tooltipped col s12 m6 l3 lime accent-1");
                    ttCalorias.Attributes.Add("data-tooltip", "Estas consumiendo una cantidad menor de calorias a la recomendada");
                }
                else
                {
                    ttCalorias.Attributes.Add("class", "btn tooltipped col s12 m6 l3 red accent-1");
                    ttCalorias.Attributes.Add("data-tooltip", "Estas consumiendo una cantidad mayor de calorias a la recomendada");
                }

                if (idrusuario.carbohidratos_totales_g > reporteUsuario.carbo)
                {
                    ttCarbohidratos.Attributes.Add("class", "btn tooltipped col s12 m6 l3 lime accent-1");
                    ttCarbohidratos.Attributes.Add("data-tooltip", "Estas consumiendo una cantidad menor de carbohidratos a la recomendada. Recomendamos los siguientes alimentos ricos en carbohidratos: <br/> - Manzana <br/> - Arroz integral <br/> - Nueces y semillas <br/> - Berenjena");
                }
                else
                {
                    ttCarbohidratos.Attributes.Add("class", "btn tooltipped col s12 m6 l3 red accent-1");
                    ttCarbohidratos.Attributes.Add("data-tooltip", "Estas consumiendo una cantidad mayor de carbohidratos a la recomendada. Recomendamos que reduzcas el consumo de los siguientes alimentos: <br/> - Pastas blancas <br/> - Cereal refinado <br/> - Pan blanco <br/> - Productos procesados de papa");
                }

                if (idrusuario.proteinas_g > reporteUsuario.proteina)
                {
                    ttProteinas.Attributes.Add("class", "btn tooltipped col s12 m6 l3 lime accent-1");
                    ttProteinas.Attributes.Add("data-tooltip", "Estas consumiendo una cantidad menor de proteinas a la recomendada. Recomendamos los siguientes alimentos ricos en proteina: <br/> - Pollo <br/> - Clara de huevo <br/> - Pescado <br/> - Lentejas <br/> - Brocoli <br/> - Mani");
                }
                else
                {
                    ttProteinas.Attributes.Add("class", "btn tooltipped col s12 m6 l3 red accent-1");
                    ttProteinas.Attributes.Add("data-tooltip", "Estas consumiendo una cantidad mayor de proteinas a la recomendada. Recomendamos los siguientes alimentos: <br/> - Verduras de hoja <br/> - Hortalizas");
                }

                if (idrusuario.grasa_total_g > reporteUsuario.grasa)
                {
                    ttGrasas.Attributes.Add("class", "btn tooltipped col s12 m6 l3 lime accent-1");
                    ttGrasas.Attributes.Add("data-tooltip", "Estas consumiendo una cantidad menor de grasas a la recomendada. Debes llevar un consumo de grasas equilibradas. Recomendamos: <br/> - Nueces, frutos secos <br/> - Pescado <br/> - Carnes rojas");
                }
                else
                {
                    ttGrasas.Attributes.Add("class", "btn tooltipped col s12 m6 l3 red accent-1");
                    ttGrasas.Attributes.Add("data-tooltip", "Estas consumiendo una cantidad mayor de grasas a la recomendada. Debes llevar un consumo de grasas equilibradas. Recomendamos que regules el consumo de carnes rojas, alimentos procesados (dulces, galletitas) y productos panificados");
                }

                if (idrusuario.fibra_dietetica_g >= reporteUsuario.fibra)
                {
                    ttFibra.Attributes.Add("class", "btn tooltipped col s12 m6 l3 lime accent-1");
                    ttFibra.Attributes.Add("data-tooltip", "Un consumo bajo en fibra provoca severos problemas en la digestion y aumenta el riesgo de diabetes. Recomendamos que consumas los siguientes alimentos ricos en fibra: <br/> - Verduras (tomate, lechuga, zanahoria) <br/> - Frutas (ciruela, pera, durazno, manzana)");
                }
                else
                {
                    ttFibra.Attributes.Add("class", "btn tooltipped col s12 m6 l3 red accent-1");
                    ttFibra.Attributes.Add("data-tooltip", "Un consumo alto de fibra puede llevar a problemas digestivos, especialmente en la digestion de vitaminas y minerales. Reduzca el consumo de alimentos ricos en fibra");
                }

                if (idrusuario.agua_g > reporteUsuario.agua)
                {
                    ttAgua.Attributes.Add("class", "btn tooltipped col s12 m6 l3 lime accent-1");
                    ttAgua.Attributes.Add("data-tooltip", "Detectamos un bajo consumo de liquidos en tu dieta. Esto puede conllevar a problemas digestivos, mayor estres y mayor propension a alergias. Aumente urgentemente el consumo de agua");
                }
                else if (idrusuario.agua_g * 2 < reporteUsuario.agua)
                {
                    ttAgua.Attributes.Add("class", "btn tooltipped col s12 m6 l3 red accent-1");
                    ttAgua.Attributes.Add("data-tooltip", "Detectamos un consumo excesivo de agua. Te recomendamos volver a los valores de ingesta diaria recomendada de agua");
                }
                else
                {
                    ttAgua.Attributes.Add("class", "btn tooltipped col s12 m6 l3 green accent-1");
                    ttAgua.Attributes.Add("data-tooltip", "El consumo de agua es correcto");
                }

                if (idrusuario.potasio_mg >= reporteUsuario.potasio)
                {
                    ttPotasio.Attributes.Add("class", "btn tooltipped col s12 m6 l3 lime accent-1");
                    ttPotasio.Attributes.Add("data-tooltip", "Estas consumiendo una cantidad baja de potasio. Recomendamos los siguientes alimentos: <br/> - Banana <br/> - Acelga <br/> - Espinaca");
                }
                else
                {
                    ttPotasio.Attributes.Add("class", "btn tooltipped col s12 m6 l3 green accent-1");
                    ttPotasio.Attributes.Add("data-tooltip", "El consumo de potasio es correcto");
                }

                if (idrusuario.sodio_mg >= reporteUsuario.potasio)
                {
                    ttSodio.Attributes.Add("class", "btn tooltipped col s12 m6 l3 lime accent-1");
                    ttSodio.Attributes.Add("data-tooltip", "Estas consumiendo sodio por debajo de lo recomendado. Compensa esta falta ingieriendo mas sal de mesa, bebidas isotonicas, quesos y caldos");
                }
                else
                {
                    ttSodio.Attributes.Add("class", "btn tooltipped col s12 m6 l3 red accent-1");
                    ttSodio.Attributes.Add("data-tooltip", "Estas consumiendo muchos alimentos con sodio, lo cual puede llevar a la hipertension arterial y problemas oseos. Reduce el consumo de sal de mesa y de embutidos");
                }

                if (idrusuario.calcio_mg >= reporteUsuario.calcio)
                {
                    ttCalcio.Attributes.Add("class", "btn tooltipped col s12 m6 l3 lime accent-1");
                    ttCalcio.Attributes.Add("data-tooltip", "Estas consumiendo bajos niveles de calcio. Recomendamos que compenses esta falta ingiriendo: <br/> - Mayonesa <br/> - lechuga <br/> - pasas de uva <br/> - alga <br/> - hinojo <br/> - leche");
                }
                else
                {
                    ttCalcio.Attributes.Add("class", "btn tooltipped col s12 m6 l3 green accent-1");
                    ttCalcio.Attributes.Add("data-tooltip", "El consumo de calcio es correcto");
                }

                if (idrusuario.hierro_mg >= reporteUsuario.hierro)
                {
                    ttHierro.Attributes.Add("class", "btn tooltipped col s12 m6 l3 lime accent-1");
                    ttHierro.Attributes.Add("data-tooltip", "Estas consumiendo alimentos bajos en hierro. Compensa esta falta con estos alimentos: <br/> - Huevos <br/> - Pescado <br/> - Legumbres (soja, lentejas, garbanzos) <br/> - Espinaca <br/> - Acelga <br/> - Carnes rojas");
                }
                else
                {
                    ttHierro.Attributes.Add("class", "btn tooltipped col s12 m6 l3 green accent-1");
                    ttHierro.Attributes.Add("data-tooltip", "El consumo de hierro es correcto");
                }

                if (idrusuario.fosforo_mg >= reporteUsuario.fosforo)
                {
                    ttFosforo.Attributes.Add("class", "btn tooltipped col s12 m6 l3 lime accent-1");
                    ttFosforo.Attributes.Add("data-tooltip", "Estas consumiendo alimentos bajos en fosforo. Para compensar esta falta puede consumir: <br/> - Carnes rojas <br/> - Cereales de salvado y avena <br/> - Leches y derivados");
                }
                else
                {
                    ttFosforo.Attributes.Add("class", "btn tooltipped col s12 m6 l3 green accent-1");
                    ttFosforo.Attributes.Add("data-tooltip", "El consumo de fósforo es correcto");
                }

                if (idrusuario.colesterol_mg <= reporteUsuario.colesterol)
                {
                    ttColesterol.Attributes.Add("class", "btn tooltipped col s12 m6 l3 red accent-1");
                    ttColesterol.Attributes.Add("data-tooltip", "Un consumo excesivo de alimentos ricos en grasas saturadas contribuye al aumento de los niveles de colesterol. Para reducir estos niveles recomendamos que baje el consumo de alimentos procesados, harinas refinadas, mantecas y carnes rojas. Consulte con su medico su nivel actual de colesterol en sangre");
                }
                else
                {
                    ttColesterol.Attributes.Add("class", "btn tooltipped col s12 m6 l3 green accent-1");
                    ttColesterol.Attributes.Add("data-tooltip", "El consumo de grasas saturadas está controlado");
                }
            }
        }
    }
}