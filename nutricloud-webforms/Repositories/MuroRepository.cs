using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nutricloud_webforms.DataBase;

namespace nutricloud_webforms.Repositories
{
    class MuroRepository
    {
        private nutricloudEntities c = new nutricloudEntities();

        public List<v_usuario_muro> ListarMuro(int id_usuario_seguidor)
        {
            try
            {
                return (from vum in c.v_usuario_muro
                        where vum.id_usuario_seguidor == id_usuario_seguidor
                        orderby vum.f_publicacion descending
                        select vum).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<usuario_muro> ListarMuroUsuario(int id_usuario_seguido)
        {
            try
            {
                return (from um in c.usuario_muro
                        where um.id_usuario == id_usuario_seguido
                        orderby um.f_publicacion descending
                        select um).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertarEstado(usuario_muro um)
        {
            try
            {
                c.usuario_muro.Add(um);
                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Siguiendo(usuario_usuario uu)
        {
            try
            {
                var query = (from us in c.usuario_usuario
                             where us.id_usuario_seguidor == uu.id_usuario_seguidor
                             && us.id_usuario_seguido == uu.id_usuario_seguido
                             select us).Count();

                if (query > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Seguir(usuario_usuario uu)
        {
            try
            {
                if (Siguiendo(uu))
                {
                    var query = (from us in c.usuario_usuario
                                 where us.id_usuario_seguidor == uu.id_usuario_seguidor
                                 && us.id_usuario_seguido == uu.id_usuario_seguido
                                 select us).FirstOrDefault();

                    c.usuario_usuario.Remove(query);
                    c.SaveChanges();
                }
                else
                {
                    c.usuario_usuario.Add(uu);
                    c.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
