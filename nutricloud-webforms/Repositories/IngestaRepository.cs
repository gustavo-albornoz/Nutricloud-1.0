using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nutricloud_webforms.DataBase;

namespace nutricloud_webforms.Repositories
{
    public class IngestaRepository
    {
        private nutricloudEntities c = new nutricloudEntities();

        public usuario_idr GetIDR(int id)
        {
            try
            {
                return (from i in c.usuario_idr where id == i.id_usuario select i).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertarIngesta(usuario_idr ingesta)
        {
            try
            {
                c.usuario_idr.Add(ingesta);
                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ActualizarIngesta(usuario_idr ingesta)
        {
            try
            {
                c.Entry(ingesta);
                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void BorrarIngesta(usuario_idr ingesta)
        {
            try
            {
                c.usuario_idr.Remove(ingesta);
                c.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}