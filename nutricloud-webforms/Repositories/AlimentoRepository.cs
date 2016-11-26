using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Core.Objects;
using nutricloud_webforms.DataBase;

namespace nutricloud_webforms.Repositories
{
    public class AlimentoRepository
    {
        private nutricloudEntities c = new nutricloudEntities();

        //mostrar todos los alimentos
        public List<alimento> ListarAlimento()
        {
            try
            {
                return (from a in c.alimento select a).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //muestra un solo alimento
        public alimento ListarUnAlimento(int idali)
        {
            try
            {
                return (from a in c.alimento where a.id_alimento == idali select a).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ObjectResult<sp_alimento_diario_Result> ListarDiario(int id_usuario, int id_comida_tipo, DateTime fecha)
        {
            
                return c.sp_alimento_diario(id_usuario,id_comida_tipo,fecha);
            
        }

        public List<comida_tipo> ListarTipoComida()
        {
            try
            {
                return (from ct in c.comida_tipo
                        select ct).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //buscar y listar alimentos por nombre ingresado
        public List<alimento> BuscarAlimento(string parametro)
        {
            try
            {
                return (from a in c.alimento where a.nombre_alimento.Contains(parametro) select a).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public alimento BuscarAlimentoId(string parametro)
        {
            try
            {
                int param = Convert.ToInt32(parametro);
                return (from a in c.alimento where a.id_alimento == param select a).First();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}