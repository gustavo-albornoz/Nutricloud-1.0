using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nutricloud_webforms.DataBase;
using nutricloud_webforms.Models;
using System.Globalization;
using System.Data.Entity.Core.Objects;

namespace nutricloud_webforms.Repositories
{
    public class ReporteRepository
    {
       private nutricloudEntities c = new nutricloudEntities();

       private ObjectResult<sp_listar_alimento_dia_Result> listarAlimentosPorDia(int idusu,DateTime fecha)
        {
            return c.sp_listar_alimento_dia(idusu, fecha);
            

        }

       public Reporte calcularNutrientesDiarios(int idusu, DateTime fecha)
        {
            decimal calorias = 0;
            decimal agua = 0;
            decimal calcio = 0;
            decimal carbo = 0;
            decimal colesterol = 0;
            decimal fosforo = 0;
            decimal fibra = 0;
            decimal grasa = 0;
            decimal hierro = 0;
            decimal niacina = 0;
            decimal potasio = 0;
            decimal proteina = 0;
            decimal sodio = 0;
            decimal tiamina = 0;
            decimal vitc = 0;
            decimal zinc = 0;
            decimal rivoflavina = 0;

            Reporte repo = new Reporte();

            foreach (sp_listar_alimento_dia_Result sumatoria in listarAlimentosPorDia(idusu,fecha))
            {
               calorias = Convert.ToDecimal((sumatoria.energia_kcal * sumatoria.cantidad / sumatoria.porcion) + calorias);
               agua = Convert.ToDecimal((sumatoria.agua_g * sumatoria.cantidad / sumatoria.porcion) + agua);
               calcio = Convert.ToDecimal((sumatoria.calcio_mg * sumatoria.cantidad / sumatoria.porcion) + calcio);
               carbo = Convert.ToDecimal((sumatoria.carbohidratos_disponibles_g * sumatoria.cantidad / sumatoria.porcion) + sumatoria.carbohidratos_totales_g + carbo);
               colesterol = Convert.ToDecimal((sumatoria.colesterol_mg * sumatoria.cantidad / sumatoria.porcion) + colesterol);
               fosforo = Convert.ToDecimal((sumatoria.fosforo_mg * sumatoria.cantidad / sumatoria.porcion) + fosforo);
               fibra = Convert.ToDecimal((sumatoria.fibra_dietetica_g * sumatoria.cantidad / sumatoria.porcion) + fibra);
               grasa = Convert.ToDecimal((sumatoria.grasa_total_g * sumatoria.cantidad / sumatoria.porcion) + grasa);
               hierro = Convert.ToDecimal((sumatoria.hierro_mg * sumatoria.cantidad / sumatoria.porcion) + hierro);
               niacina = Convert.ToDecimal((sumatoria.niacina_mg * sumatoria.cantidad / sumatoria.porcion) + niacina);
               potasio = Convert.ToDecimal((sumatoria.potasio_mg * sumatoria.cantidad / sumatoria.porcion) + potasio);
               proteina = Convert.ToDecimal((sumatoria.proteinas_g * sumatoria.cantidad / sumatoria.porcion) + proteina);
               sodio = Convert.ToDecimal((sumatoria.sodio_mg * sumatoria.cantidad / sumatoria.porcion) + sodio);
               tiamina = Convert.ToDecimal((sumatoria.tiamina_mg * sumatoria.cantidad / sumatoria.porcion) + tiamina);
               vitc = Convert.ToDecimal((sumatoria.vitamina_c_mg * sumatoria.cantidad / sumatoria.porcion) + vitc);
               zinc = Convert.ToDecimal((sumatoria.zinc_mg * sumatoria.cantidad / sumatoria.porcion) + zinc);
               rivoflavina = Convert.ToDecimal((sumatoria.rivoflavina_mg * sumatoria.cantidad / sumatoria.porcion) + rivoflavina);
             }

            repo.agua = agua;
            repo.calcio = Decimal.Multiply(calcio, Convert.ToDecimal(0.001));
            repo.carbohidratos = carbo;
            repo.colesterol = Decimal.Multiply(colesterol, Convert.ToDecimal(0.001));
            repo.calorias = calorias;
            repo.fibra = fibra;
            repo.fosforo = Decimal.Multiply(fosforo, Convert.ToDecimal(0.001));
            repo.grasa = grasa;
            repo.hierro = Decimal.Multiply(hierro, Convert.ToDecimal(0.001));
            repo.niacina = Decimal.Multiply(niacina, Convert.ToDecimal(0.001));
            repo.potasio = Decimal.Multiply(potasio, Convert.ToDecimal(0.001));
            repo.proteina = proteina;
            repo.rivofla = Decimal.Multiply(rivoflavina, Convert.ToDecimal(0.001));
            repo.sodio = Decimal.Multiply(sodio, Convert.ToDecimal(0.001));
            repo.tiamina = Decimal.Multiply(tiamina, Convert.ToDecimal(0.001));
            repo.vitaminaC = Decimal.Multiply(vitc, Convert.ToDecimal(0.001));
            repo.zinc = Decimal.Multiply(zinc, Convert.ToDecimal(0.001));

            return repo;

        }

       private ObjectResult<sp_listar_alimento_quincena_Result> listarAlimentosQuincena(int idusu, DateTime fecha1, DateTime fecha2)
        {
            return c.sp_listar_alimento_quincena(idusu, fecha1, fecha2);

        }

       public Reporte calcularNutrientesQuinceDias(int idusu, DateTime fecha1, DateTime fecha2)
        {
       
            decimal calorias = 0;
            decimal agua = 0;
            decimal calcio = 0;
            decimal carbo = 0;
            decimal colesterol = 0;
            decimal fosforo = 0;
            decimal fibra = 0;
            decimal grasa = 0;
            decimal hierro = 0;
            decimal niacina = 0;
            decimal potasio = 0;
            decimal proteina = 0;
            decimal sodio = 0;
            decimal tiamina = 0;
            decimal vitc = 0;
            decimal zinc = 0;
            decimal rivoflavina = 0;

            Reporte repo = new Reporte();

            foreach (sp_listar_alimento_quincena_Result sumatoria in listarAlimentosQuincena(idusu, fecha1, fecha2))
            {
                calorias = Convert.ToDecimal((sumatoria.energia_kcal * sumatoria.cantidad / sumatoria.porcion) + calorias);
                agua = Convert.ToDecimal((sumatoria.agua_g * sumatoria.cantidad / sumatoria.porcion) + agua);
                calcio = Convert.ToDecimal((sumatoria.calcio_mg * sumatoria.cantidad / sumatoria.porcion) + calcio);
                carbo = Convert.ToDecimal((sumatoria.carbohidratos_disponibles_g * sumatoria.cantidad / sumatoria.porcion) + sumatoria.carbohidratos_totales_g + carbo);
                colesterol = Convert.ToDecimal((sumatoria.colesterol_mg * sumatoria.cantidad / sumatoria.porcion) + colesterol);
                fosforo = Convert.ToDecimal((sumatoria.fosforo_mg * sumatoria.cantidad / sumatoria.porcion) + fosforo);
                fibra = Convert.ToDecimal((sumatoria.fibra_dietetica_g * sumatoria.cantidad / sumatoria.porcion) + fibra);
                grasa = Convert.ToDecimal((sumatoria.grasa_total_g * sumatoria.cantidad / sumatoria.porcion) + grasa);
                hierro = Convert.ToDecimal((sumatoria.hierro_mg * sumatoria.cantidad / sumatoria.porcion) + hierro);
                niacina = Convert.ToDecimal((sumatoria.niacina_mg * sumatoria.cantidad / sumatoria.porcion) + niacina);
                potasio = Convert.ToDecimal((sumatoria.potasio_mg * sumatoria.cantidad / sumatoria.porcion) + potasio);
                proteina = Convert.ToDecimal((sumatoria.proteinas_g * sumatoria.cantidad / sumatoria.porcion) + proteina);
                sodio = Convert.ToDecimal((sumatoria.sodio_mg * sumatoria.cantidad / sumatoria.porcion) + sodio);
                tiamina = Convert.ToDecimal((sumatoria.tiamina_mg * sumatoria.cantidad / sumatoria.porcion) + tiamina);
                vitc = Convert.ToDecimal((sumatoria.vitamina_c_mg * sumatoria.cantidad / sumatoria.porcion) + vitc);
                zinc = Convert.ToDecimal((sumatoria.zinc_mg * sumatoria.cantidad / sumatoria.porcion) + zinc);
                rivoflavina = Convert.ToDecimal((sumatoria.rivoflavina_mg * sumatoria.cantidad / sumatoria.porcion) + rivoflavina);
            }

            repo.agua = agua/15;
            repo.calcio = (Decimal.Multiply(calcio, Convert.ToDecimal(0.001)))/15;
            repo.carbohidratos = carbo/ 15;
            repo.colesterol = (Decimal.Multiply(colesterol, Convert.ToDecimal(0.001))) / 15;
            repo.calorias = calorias / 15;
            repo.fibra = fibra / 15;
            repo.fosforo = (Decimal.Multiply(fosforo, Convert.ToDecimal(0.001))) / 15;
            repo.grasa = grasa / 15;
            repo.hierro = (Decimal.Multiply(hierro, Convert.ToDecimal(0.001))) / 15;
            repo.niacina = (Decimal.Multiply(niacina, Convert.ToDecimal(0.001))) / 15;
            repo.potasio = (Decimal.Multiply(potasio, Convert.ToDecimal(0.001))) / 15;
            repo.proteina = proteina / 15;
            repo.rivofla = (Decimal.Multiply(rivoflavina, Convert.ToDecimal(0.001))) / 15;
            repo.sodio = (Decimal.Multiply(sodio, Convert.ToDecimal(0.001))) / 15;
            repo.tiamina = (Decimal.Multiply(tiamina, Convert.ToDecimal(0.001))) / 15;
            repo.calorias = (Decimal.Multiply(vitc, Convert.ToDecimal(0.001))) / 15;
            repo.zinc = (Decimal.Multiply(zinc, Convert.ToDecimal(0.001))) / 15;

            return repo;

        }


    }
}