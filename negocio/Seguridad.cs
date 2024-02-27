using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object sesionUser)
        {
            User user = sesionUser != null ? (User)sesionUser : null;
            if (user != null && user.Id != 0)
                return true;
            else
                return false;
        }

        public static bool esAdmin(object sesionUser)
        {
            User user = sesionUser != null ? (User)sesionUser : null;
            return user != null ? user.Admin : false;
        }
    }
}
