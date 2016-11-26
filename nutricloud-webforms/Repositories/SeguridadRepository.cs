using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace nutricloud_webforms.Repositories
{
    public static class SeguridadRepository
    {
        /// Encripta una cadena
        public static string Encriptar(string originalPassword)
        {
            try
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();

                byte[] inputBytes = (new UnicodeEncoding()).GetBytes(originalPassword);
                byte[] hash = sha1.ComputeHash(inputBytes);

                return Convert.ToBase64String(hash);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
