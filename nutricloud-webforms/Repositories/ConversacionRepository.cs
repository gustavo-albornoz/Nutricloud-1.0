using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nutricloud_webforms.DataBase;
using nutricloud_webforms.Models;

namespace nutricloud_webforms.Repositories
{
    public class ConversacionRepository
    {
        nutricloudEntities c = new nutricloudEntities();

        public int Insertar(Mensaje mensaje, UsuarioCompleto usuario)
        {
            consulta_conversacion cc;
            DateTime fecha = DateTime.Now;

            try
            {
                if (mensaje.id_conversacion == 0)
                {
                    cc = new consulta_conversacion();
                    cc.asunto = mensaje.Asunto;
                    cc.id_usuario_remitente = mensaje.id_remitente;
                    cc.f_ultimo_mensaje = fecha;
                    cc.cerrada = false;

                    c.consulta_conversacion.Add(cc);
                    c.SaveChanges();

                    mensaje.id_conversacion = cc.id_consulta_conversacion;
                }
                else
                {
                    cc = (from co in c.consulta_conversacion
                          where co.id_consulta_conversacion == mensaje.id_conversacion
                          select co).FirstOrDefault();

                    if (cc.id_usuario_destinatario == null && cc.id_usuario_remitente != mensaje.id_remitente)
                    {
                        cc.id_usuario_destinatario = mensaje.id_remitente;
                    }

                    cc.f_ultimo_mensaje = fecha;

                    c.Entry(cc);
                    c.SaveChanges();
                }

                consulta_mensaje cm = new consulta_mensaje();
                cm.mensaje = mensaje.Texto;
                cm.f_mensaje = fecha;
                cm.id_consulta_conversacion = mensaje.id_conversacion;
                cm.id_usuario_remitente = mensaje.id_remitente;
                cm.leido = false;

                c.consulta_mensaje.Add(cm);
                c.SaveChanges();

                return mensaje.id_conversacion;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<consulta_conversacion> ListarConversaciones(UsuarioCompleto usuario)
        {
            try
            {
                if (usuario.Usuario.id_usuario_tipo == 1) //Paciente
                {
                    return (from co in c.consulta_conversacion
                            where co.id_usuario_remitente == usuario.Usuario.id_usuario
                            orderby co.f_ultimo_mensaje descending
                            select co).ToList();
                }
                if (usuario.Usuario.id_usuario_tipo == 2) //Profesional
                {
                    return (from co in c.consulta_conversacion
                            where (co.id_usuario_destinatario == null && !co.cerrada) ||
                            co.id_usuario_destinatario == usuario.Usuario.id_usuario
                            orderby co.f_ultimo_mensaje descending
                            select co).ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<consulta_mensaje> ListarMensajes(int id_consulta_conversacion, UsuarioCompleto usuario)
        {
            try
            {
                bool proDes = false;

                if (usuario.Usuario.id_usuario_tipo == 2) //Profesional
                {
                    consulta_conversacion co = (from cc in c.consulta_conversacion
                                                where cc.id_consulta_conversacion == id_consulta_conversacion
                                                select cc).FirstOrDefault();
                    proDes = (co.id_usuario_destinatario == usuario.Usuario.id_usuario);
                }


                var query = (from cm in c.consulta_mensaje
                             where cm.id_consulta_conversacion == id_consulta_conversacion
                             orderby cm.f_mensaje ascending
                             select cm).ToList();

                if (proDes || usuario.Usuario.id_usuario_tipo == 1) //Paciente
                {
                    foreach (var mensaje in query)
                    {
                        if (mensaje.id_usuario_remitente != usuario.Usuario.id_usuario)
                        {
                            mensaje.leido = true;
                            c.Entry(mensaje);
                            c.SaveChanges();
                        }
                    }
                }

                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public consulta_conversacion GetConversacion(int id_consulta_conversacion)
        {
            try
            {
                return (from cc in c.consulta_conversacion
                        where cc.id_consulta_conversacion == id_consulta_conversacion
                        select cc).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CerrarConversacion(int id_consulta_conversacion)
        {
            try
            {
                consulta_conversacion cc = (from co in c.consulta_conversacion
                                            where co.id_consulta_conversacion == id_consulta_conversacion
                                            select co).FirstOrDefault();
                cc.cerrada = true;

                c.Entry(cc);
                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int MensajesNoLeidos(UsuarioCompleto usuario)
        {
            try
            {
                if (usuario.Usuario.id_usuario_tipo == 1) //Paciente
                {
                    return (from cc in c.consulta_conversacion
                            join cm in c.consulta_mensaje on cc.id_consulta_conversacion equals cm.id_consulta_conversacion
                            where (cc.id_usuario_destinatario == usuario.Usuario.id_usuario ||
                            cc.id_usuario_remitente == usuario.Usuario.id_usuario)
                            && cm.leido == false
                            && cm.id_usuario_remitente != usuario.Usuario.id_usuario
                            select cm).Count();
                }
                if (usuario.Usuario.id_usuario_tipo == 2) //Profesional
                {
                    return (from cc in c.consulta_conversacion
                            join cm in c.consulta_mensaje on cc.id_consulta_conversacion equals cm.id_consulta_conversacion
                            where (cc.id_usuario_destinatario == usuario.Usuario.id_usuario || cc.id_usuario_destinatario == null)
                            && cm.leido == false
                            && cm.id_usuario_remitente != usuario.Usuario.id_usuario
                            select cm).Count();
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ConversacionSinLeer(int id_consulta_conversacion, UsuarioCompleto usuario)
        {
            try
            {
                if (usuario.Usuario.id_usuario_tipo == 1) //Paciente
                {
                    return (from cc in c.consulta_conversacion
                            join cm in c.consulta_mensaje on cc.id_consulta_conversacion equals cm.id_consulta_conversacion
                            where cc.id_usuario_remitente == usuario.Usuario.id_usuario
                            && cc.id_consulta_conversacion == id_consulta_conversacion
                            && cm.leido == false
                            && cm.id_usuario_remitente != usuario.Usuario.id_usuario
                            select cm).Count();
                }
                if (usuario.Usuario.id_usuario_tipo == 2) //Profesional
                {
                    return (from cc in c.consulta_conversacion
                            join cm in c.consulta_mensaje on cc.id_consulta_conversacion equals cm.id_consulta_conversacion
                            where (cc.id_usuario_destinatario == usuario.Usuario.id_usuario || cc.id_usuario_destinatario == null)
                            && cc.id_consulta_conversacion == id_consulta_conversacion
                            && cm.leido == false
                            && cm.id_usuario_remitente != usuario.Usuario.id_usuario
                            select cm).Count();
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
