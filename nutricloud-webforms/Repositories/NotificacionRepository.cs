using nutricloud_webforms.DataBase;
using nutricloud_webforms.Models;
using nutricloud_webforms.Pages;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace nutricloud_webforms.Repositories
{
    public class NotificacionRepository
    {
        private nutricloudEntities c = new nutricloudEntities();

        public List<Notificacion> listarNotificacionesDeNotas(int id_usuario)
        {
            try
            {
                var result = c.sp_notificacion_blog_nota_obtener(id_usuario).ToList();

                List<Notificacion> notificaciones = new List<Notificacion>();

                foreach (sp_notificacion_blog_nota_obtener_Result r in result)
                {
                    Notificacion notificacion = new Notificacion();
                    notificacion.leida = r.leida_notificacion;
                    notificacion.fecha = r.fecha_notificacion;
                    notificacion.tipo = "BLOG_NOTA";
                    notificacion.notificacion = r;
                    notificacion.id = r.id_notificacion;

                    notificaciones.Add(notificacion);
                }

                return notificaciones.OrderByDescending(r => r.fecha).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int getCantidadNotificacionesNoLeidas(int id_usuario)
        {
            try
            {
                return c.sp_notificacion_blog_nota_obtener_cantidad_notificaciones_no_leidas(id_usuario).First().Value;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void notificarNotaAPacientes(int idNota)
        {
            try
            {
                // usuarios del tipo paciente
                var idsUsuarios = (from u in c.usuario
                                   where u.id_usuario_tipo == 1
                                   select u.id_usuario).ToList();

                // les notifico a cada usuario la nota nueva
                foreach (var idUsuario in idsUsuarios)
                {
                    c.sp_notificacion_blog_nota_insertar(idNota, idUsuario);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool getAvisos(int idUsuario)
        {
            try
            {
                usuario user = c.usuario.Find(idUsuario);

                if (user.f_nacimiento == null || user.f_nacimiento == null)
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void marcarComoLeida(int id, string tipo)
        {
            try
            {
                if (tipo == "BLOG_NOTA")
                {
                    var notificacion = c.notificacion_blog_nota.Find(id);
                    notificacion.leido = true;

                    try
                    {
                        c.Entry(notificacion);
                        c.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw (e);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}