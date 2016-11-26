using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace nutricloud_webforms.Repositories
{
    class ValidRepository
    {
        public bool ValidaVacio(string text)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ValidaMail(string email)
        {
            // VER ESTO, TODO FUE ENCONTRADO EN INTERNET
            String expresion = @"^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$";

            try
            {
                if (Regex.IsMatch(email, expresion))
                {
                    if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

        public bool ValidaRangoLen(string text, int min, int max)
        {
            try
            {
                if (text.Length < min || text.Length > max)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Se usaria por ejemplo para validar que las dos password sean iguales
        public bool ValidaIguales(string text1, string text2)
        {
            try
            {
                if (text1.Equals(text2))
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
    }
}
