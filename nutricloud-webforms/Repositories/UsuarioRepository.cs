using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nutricloud_webforms.DataBase;
using nutricloud_webforms.Models;

namespace nutricloud_webforms.Repositories
{
    class UsuarioRepository
    {
        nutricloudEntities c = new nutricloudEntities();

        #region Interaccion con la base
        public void Insertar(usuario u)
        {
            try
            {
                c.usuario.Add(PreparaUsuarioNuevo(u));
                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ActualizarUsuario(usuario u)
        {
            /*try
            {*/
                var usuario = c.usuario.Find(u.id_usuario);
                usuario.clave = u.clave;
                usuario.nombre = u.nombre;
                usuario.sexo = u.sexo;
                usuario.f_nacimiento = u.f_nacimiento;

                c.Entry(usuario);
                c.SaveChanges();
            /*}
            catch (Exception)
            {

                throw;
            }*/
        }

        public string getNombreImagenUsuario(int idUsuario)
        {
            var u = (from ui in c.usuario_imagen where ui.id_usuario == idUsuario select ui).FirstOrDefault();

            if (u == null)
            { return "null"; }
            else
            return u.nombre_imagen;
            
        }

        public void ActualizarDatosUsuario(usuario_datos u)
        {
            /*try
            {*/
            var usuariod = c.usuario_datos.Find(u.id_usuario_datos);
                usuariod.altura_cm = u.altura_cm;
                usuariod.peso_kg = u.peso_kg;
                usuariod.id_usuario_objetivo = u.id_usuario_objetivo;
                usuariod.id_usuario_actividad = u.id_usuario_actividad;


                c.Entry(usuariod);
                c.SaveChanges();
            /*}
            catch (Exception)
            {

                throw;
            }*/

        }

        public void actualizarFotoDePerfil(usuario_imagen ui)
        {
            var u = (from a in c.usuario_imagen where a.id_usuario == ui.id_usuario select a).FirstOrDefault();

            if (u == null) {

                c.usuario_imagen.Add(ui);
                c.SaveChanges();
            } else
            {
                u.nombre_imagen = ui.nombre_imagen;
                c.Entry(u);
                c.SaveChanges();
            }
        }

        public void InsertarDatosUsuario(usuario_datos ud)
        {
            /*try
            {*/

            c.usuario_datos.Add(ud);
                c.SaveChanges();
            /*}
            catch (Exception)
            {

                throw;
            }*/
        }

        public usuario BuscarUsuarioLogIn(usuario usuario)
        {
            /*try
            {*/

                string claveEncriptada = SeguridadRepository.Encriptar(usuario.clave);

                usuario u = (from us in c.usuario
                             where us.email == usuario.email && us.clave == claveEncriptada
                             select us).FirstOrDefault();

                if (u != null)
                {
                    c.Entry(PraparaUsuarioUpdate(u));
                    c.SaveChanges();
                }

                return u;
            /*}
            catch (Exception)
            {

                throw;
            }*/
        }

        public List<usuario_tipo> ListarTipoUsuario()
        {
            /*try
            {*/

            return c.usuario_tipo.ToList();
            /*}
            catch (Exception)
            {

                throw;
            }*/

        }

        public List<usuario_actividad> ListarActividades()
        {
            /*try
            {*/
            return (from u in c.usuario_actividad select u).ToList();
            /*}
            catch (Exception)
            {

                throw;
            }*/
        }

        public usuario_datos Buscar(int idUsuario)
        {

            /*try
            {*/
            return (from ud in c.usuario_datos
                        where ud.id_usuario == idUsuario
                        orderby ud.f_ingreso descending
                        select ud).FirstOrDefault();
            /*}
            catch (Exception)
            {

                throw;
            }*/
        }

        public usuario BuscarUsuario(int id_usuario)
        {
            /*try
            {*/
            return (from u in c.usuario
                        where u.id_usuario == id_usuario
                        select u).FirstOrDefault();
                /*}
                catch (Exception)
                {

                    throw;
                }*/
            }

        public usuario_datos BuscarUsuarioDatos(int id_usuario)
        {
            /*try
            {*/
            return (from ud in c.usuario_datos
                        where ud.id_usuario == id_usuario
                        orderby ud.f_ingreso descending
                        select ud).FirstOrDefault();
                /*}
                catch (Exception)
                {

                    throw;
                }*/
            }

        public List<usuario_objetivo> ListarObjetivos()
        {
            /*try
            {*/
            return (from ob in c.usuario_objetivo select ob).ToList();
                /*}
                catch (Exception)
                {

                    throw;
                }*/
            }

        public List<usuario> ListarUsuarios(string nombre)
        {
            /*try
            {*/
            return (from us in c.usuario
                        where us.nombre.Contains(nombre) ||
                        us.email.Contains(nombre)
                        select us).ToList();
                /*}
                catch (Exception)
                {

                    throw;
                }*/
            }

        #endregion

            #region Metodos
        private usuario PreparaUsuarioNuevo(usuario u)
        {
            /*try
            {*/
            string claveEncriptada = SeguridadRepository.Encriptar(u.clave);
                u.clave = claveEncriptada;
                u.f_registro = DateTime.Now;

                return u;
                /*}
                catch (Exception)
                {

                    throw;
                }*/
            }

        private usuario PraparaUsuarioUpdate(usuario u)
        {
            /*try
            {*/
            u.f_ultimo_ingreso = DateTime.Now;
                return u;
                /*}
                catch (Exception)
                {

                    throw;
                }*/
            }

        public int CalcularEdad(usuario u)
        {
            /*try
            {*/
            DateTime Hoy = DateTime.Today;
                DateTime Bday = Convert.ToDateTime(u.f_nacimiento);
                int edad = Hoy.Year - Bday.Year;

                if (Bday > Hoy.AddYears(-edad))
                    edad--;

                return edad;
                /*}
                catch (Exception)
                {

                    throw;
                }*/
            }

        public double CalcularIngesta(UsuarioCompleto u)
        {
            /*try
            {*/
            int edad = CalcularEdad(u.Usuario);
                double tmb;
                double tmb2;
                double tmb3;
                double tmbtot;
                char sexo = Convert.ToChar(u.Usuario.sexo);
                double ingesta;
                int actividad;
            if (u.UsuarioDatos.id_usuario_actividad != null)
            {
                actividad = Convert.ToInt32(u.UsuarioDatos.id_usuario_actividad);
            }
            else
            {
                actividad = 0;
            }
            
                if (sexo == 'm')
                {
                    tmb = (10 * Convert.ToDouble(u.UsuarioDatos.peso_kg));
                    tmb2 = (6.25 * u.UsuarioDatos.altura_cm);
                    tmb3 = (5 * edad);

                    tmbtot = tmb + tmb2 - tmb3 + 5;

                    switch (actividad)
                    {
                        case 1:
                            ingesta = tmbtot * 1.2;
                            break;
                        case 2:
                            ingesta = tmbtot * 1.375;
                            break;
                        case 3:
                            ingesta = tmbtot * 1.55;
                            break;
                        case 4:
                            ingesta = tmbtot * 1.725;
                            break;
                        case 5:
                            ingesta = tmbtot * 1.9;
                            break;
                        default:
                            ingesta = 0;
                            break;
                    }

                    return ingesta;
                }

                else
                {
                    if (sexo == 'f')
                    {
                        tmb = (10 * Convert.ToDouble(u.UsuarioDatos.peso_kg));
                        tmb2 = (6.25 * u.UsuarioDatos.altura_cm);
                        tmb3 = (5 * edad);

                        tmbtot = tmb + tmb2 - tmb3 - 161;

                        switch (actividad)
                        {
                            case 1:
                                ingesta = tmbtot * 1.2;
                                break;
                            case 2:
                                ingesta = tmbtot * 1.375;
                                break;
                            case 3:
                                ingesta = tmbtot * 1.55;
                                break;
                            case 4:
                                ingesta = tmbtot * 1.725;
                                break;
                            case 5:
                                ingesta = tmbtot * 1.9;
                                break;
                            default:
                                ingesta = 0;
                                break;
                        }
                        return ingesta;
                    }
                    else return 0;
                }
                /*}
                catch (Exception)
                {

                    throw;
                }*/
            }
    }
    #endregion
}
