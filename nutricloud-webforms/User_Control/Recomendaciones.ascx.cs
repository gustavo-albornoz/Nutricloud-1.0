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
                    pnlCalorias.CssClass += " lime accent-1";
                    pCalorias.InnerHtml = "Estas consumiendo una cantidad menor de calorias a la recomendada.";
                }
                else
                {
                    pnlCalorias.CssClass += " red accent-1";
                    pCalorias.InnerHtml = "Estas consumiendo una cantidad mayor de calorias a la recomendada.";
                }

                if (idrusuario.carbohidratos_totales_g > reporteUsuario.carbo)
                {
                    pnlCarbohidratos.CssClass += " lime accent-1";
                    pCarbohidratos.InnerHtml = "Estas consumiendo una cantidad menor de carbohidratos a la recomendada. Recomendamos los siguientes alimentos ricos en carbohidratos: <br/> - Manzana <br/> - Arroz integral <br/> - Nueces y semillas <br/> - Berenjena";
                }
                else
                {
                    pnlCarbohidratos.CssClass += " red accent-1";
                    pCarbohidratos.InnerHtml = "Estas consumiendo una cantidad mayor de carbohidratos a la recomendada. Recomendamos que reduzcas el consumo de los siguientes alimentos: <br/> - Pastas blancas <br/> - Cereal refinado <br/> - Pan blanco <br/> - Productos procesados de papa";
                }

                if (idrusuario.proteinas_g > reporteUsuario.proteina)
                {
                    pnlProteinas.CssClass += " lime accent-1";
                    pProteinas.InnerHtml = "Estas consumiendo una cantidad menor de proteinas a la recomendada. Recomendamos los siguientes alimentos ricos en proteina: <br/> - Pollo <br/> - Clara de huevo <br/> - Pescado <br/> - Lentejas <br/> - Brocoli <br/> - Mani";
                }
                else
                {
                    pnlProteinas.CssClass += " red accent-1";
                    pProteinas.InnerHtml = "Estas consumiendo una cantidad mayor de proteinas a la recomendada. Recomendamos los siguientes alimentos: <br/> - Verduras de hoja <br/> - Hortalizas";
                }

                if (idrusuario.grasa_total_g > reporteUsuario.grasa)
                {
                    pnlGrasas.CssClass += " lime accent-1";
                    pGrasas.InnerHtml = "Estas consumiendo una cantidad menor de grasas a la recomendada. Debes llevar un consumo de grasas equilibradas. Recomendamos: <br/> - Nueces, frutos secos <br/> - Pescado <br/> - Carnes rojas";
                }
                else
                {
                    pnlGrasas.CssClass += " red accent-1";
                    pGrasas.InnerHtml = "Estas consumiendo una cantidad mayor de grasas a la recomendada. Debes llevar un consumo de grasas equilibradas. Recomendamos que regules el consumo de carnes rojas, alimentos procesados (dulces, galletitas) y productos panificados";
                }

                if (idrusuario.fibra_dietetica_g >= reporteUsuario.fibra)
                {
                    pnlFibra.CssClass += " lime accent-1";
                    pFibra.InnerHtml = "Un consumo bajo en fibra provoca severos problemas en la digestion y aumenta el riesgo de diabetes. Recomendamos que consumas los siguientes alimentos ricos en fibra: <br/> - Verduras (tomate, lechuga, zanahoria) <br/> - Frutas (ciruela, pera, durazno, manzana)";
                }
                else
                {
                    pnlFibra.CssClass += " red accent-1";
                    pFibra.InnerHtml = "Un consumo alto de fibra puede llevar a problemas digestivos, especialmente en la digestion de vitaminas y minerales. Reduzca el consumo de alimentos ricos en fibra.";
                }

                if (idrusuario.agua_g > reporteUsuario.agua)
                {
                    pnlAgua.CssClass += " lime accent-1";
                    pAgua.InnerHtml = "Detectamos un bajo consumo de liquidos en tu dieta. Esto puede conllevar a problemas digestivos, mayor estres y mayor propension a alergias. Aumente urgentemente el consumo de agua.";
                }
                else if (idrusuario.agua_g * 2 < reporteUsuario.agua)
                {
                    pnlAgua.CssClass += " red accent-1";
                    pAgua.InnerHtml = "Detectamos un consumo excesivo de agua. Te recomendamos volver a los valores de ingesta diaria recomendada de agua.";
                }
                else
                {
                    pnlAgua.CssClass += " green accent-1";
                    pAgua.InnerHtml = "El consumo de agua es correcto.";
                }

                if (idrusuario.potasio_mg >= reporteUsuario.potasio)
                {
                    pnlPotasio.CssClass += " lime accent-1";
                    pPotasio.InnerHtml = "Estas consumiendo una cantidad baja de potasio. Recomendamos los siguientes alimentos: <br/> - Banana <br/> - Acelga <br/> - Espinaca";
                }
                else
                {
                    pnlPotasio.CssClass += " green accent-1";
                    pPotasio.InnerHtml = "El consumo de potasio es correcto.";
                }

                if (idrusuario.sodio_mg >= reporteUsuario.potasio)
                {
                    pnlSodio.CssClass += " lime accent-1";
                    pSodio.InnerHtml = "Estas consumiendo sodio por debajo de lo recomendado. Compensa esta falta ingieriendo mas sal de mesa, bebidas isotonicas, quesos y caldos.";
                }
                else
                {
                    pnlSodio.CssClass += " red accent-1";
                    pSodio.InnerHtml = "Estas consumiendo muchos alimentos con sodio, lo cual puede llevar a la hipertension arterial y problemas oseos. Reduce el consumo de sal de mesa y de embutidos.";
                }

                if (idrusuario.calcio_mg >= reporteUsuario.calcio)
                {
                    pnlCalcio.CssClass += " lime accent-1";
                    pCalcio.InnerHtml = "Estas consumiendo bajos niveles de calcio. Recomendamos que compenses esta falta ingiriendo: <br/> - Mayonesa <br/> - lechuga <br/> - pasas de uva <br/> - alga <br/> - hinojo <br/> - leche";
                }
                else
                {
                    pnlCalcio.CssClass += " green accent-1";
                    pCalcio.InnerHtml = "El consumo de calcio es correcto.";
                }

                if (idrusuario.hierro_mg >= reporteUsuario.hierro)
                {
                    pnlHierro.CssClass += " lime accent-1";
                    pHierro.InnerHtml = "Estas consumiendo alimentos bajos en hierro. Compensa esta falta con estos alimentos: <br/> - Huevos <br/> - Pescado <br/> - Legumbres (soja, lentejas, garbanzos) <br/> - Espinaca <br/> - Acelga <br/> - Carnes rojas";
                }
                else
                {
                    pnlHierro.CssClass += " green accent-1";
                    pHierro.InnerHtml = "El consumo de hierro es correcto.";
                }

                if (idrusuario.fosforo_mg >= reporteUsuario.fosforo)
                {
                    pnlFosforo.CssClass += " lime accent-1";
                    pFosforo.InnerHtml = "Estas consumiendo alimentos bajos en fosforo. Para compensar esta falta puede consumir: <br/> - Carnes rojas <br/> - Cereales de salvado y avena <br/> - Leches y derivados";
                }
                else
                {
                    pnlFosforo.CssClass += " green accent-1";
                    pFosforo.InnerHtml = "El consumo de fósforo es correcto.";
                }

                if (idrusuario.colesterol_mg <= reporteUsuario.colesterol)
                {
                    pnlColesterol.CssClass += " red accent-1";
                    pColesterol.InnerHtml = "Un consumo excesivo de alimentos ricos en grasas saturadas contribuye al aumento de los niveles de colesterol. Para reducir estos niveles recomendamos que baje el consumo de alimentos procesados, harinas refinadas, mantecas y carnes rojas. Consulte con su medico su nivel actual de colesterol en sangre.";
                }
                else
                {
                    pnlColesterol.CssClass += " green accent-1";
                    pColesterol.InnerHtml = "El consumo de grasas saturadas está controlado.";
                }
            }
        }
    }
}