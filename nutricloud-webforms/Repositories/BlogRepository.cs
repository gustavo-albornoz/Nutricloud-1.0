using nutricloud_webforms.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nutricloud_webforms.Repositories
{
    public class BlogRepository
    {
        private nutricloudEntities c = new nutricloudEntities();
        private NotificacionRepository notificacionRepository = new NotificacionRepository();

        public List<blog_nota> Listar()
        {
            try
            {
                return (from bn in c.blog_nota select bn).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public blog_nota get(int id)
        {
            try
            {
                return c.blog_nota.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void add(blog_nota nota)
        {
            try
            {
                c.blog_nota.Add(nota);
                c.SaveChanges();
                // Nota: EF setea id autoincrementado de la nota luego del SaveChanges()
                notificacionRepository.notificarNotaAPacientes(nota.id_blog_nota);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void update(blog_nota nota)
        {
            try
            {
                c.Entry(nota);
                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void delete(blog_nota nota)
        {
            try
            {
                c.blog_nota.Remove(nota);
                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int buscarIdNotaPorFechaYAutor(blog_nota nota)
        {
            try
            {
                return (from bn in c.blog_nota
                    where bn.f_publicacion == nota.f_publicacion && bn.id_usuario == nota.id_usuario
                    select bn.id_blog_nota).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}