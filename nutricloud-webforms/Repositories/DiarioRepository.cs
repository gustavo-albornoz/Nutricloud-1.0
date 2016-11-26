using nutricloud_webforms.Models;
using nutricloud_webforms.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 

namespace nutricloud_webforms.Repositories
{
    public class DiarioRepository
    {

        DataBase.nutricloudEntities c = new DataBase.nutricloudEntities();

        public void IngresarAlimentoDiario (DataBase.usuario_alimento diario)
        {
            try
            {
                c.usuario_alimento.Add(diario);
                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EliminarAlimentoUsuario(int id_usuario_alimento)
        {
            try
            {
                var query = (from ua in c.usuario_alimento
                            where ua.id_usuario_alimento == id_usuario_alimento
                            select ua).FirstOrDefault();

                c.usuario_alimento.Remove(query);
                c.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void actualizarDiario(List<Diario> diario)
        {

            UsuarioCompleto usuario = (UsuarioCompleto)HttpContext.Current.Session["UsuarioCompleto"];

            foreach (Diario d in diario)
            {
                if (d.idUsuarioAlimento == "" || d.idUsuarioAlimento == null)
                {
                    usuario_alimento ua = new usuario_alimento();
                    DateTime f = DateTime.Parse(d.fecha);

                    ua.id_usuario = usuario.Usuario.id_usuario;
                    ua.id_alimento = int.Parse(d.idAlimento);
                    ua.id_comida_tipo = int.Parse(d.tipoDeComida);
                    ua.cantidad = int.Parse(d.cantidad);
                    ua.f_ingreso = f;

                    c.usuario_alimento.Add(ua);
                    c.SaveChanges();
                }

            }
        }
    }
}