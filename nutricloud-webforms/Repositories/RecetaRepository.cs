using System;
using System.Collections.Generic;
using System.Linq;
using nutricloud_webforms.DataBase;

namespace nutricloud_webforms.Repositories
{
    public class RecetaRepository
    {
        private nutricloudEntities c = new nutricloudEntities();

        public List<usuario_receta> Listar()
        {
            try
            {
                return (from ur in c.usuario_receta select ur).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public usuario_receta getReceta(int id)
        {
            try
            {
                return c.usuario_receta.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void addReceta(usuario_receta receta)
        {
            try
            {
                c.usuario_receta.Add(receta);
                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void updateReceta(usuario_receta receta)
        {
            try
            {
                c.Entry(receta);
                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void deleteReceta(usuario_receta receta)
        {
            try
            {
                c.usuario_receta.Remove(receta);
                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}