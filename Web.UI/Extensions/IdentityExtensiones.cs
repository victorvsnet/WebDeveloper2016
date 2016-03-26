using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Web.UI.Extensions
{
    public static class IdentityExtensiones
    {
        public static string NombreUsuario(this IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated) return string.Empty;

            var claims = user.Identity as ClaimsIdentity;

            if (claims.EsNulo()) return string.Empty;

            var nombre = claims
                .Claims
                .SingleOrDefault(x => x.Type.Equals("Nombre"));
            return !nombre.EsNulo() ? nombre.Value : string.Empty;
        }

        public static string FechaRegistro(this IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated) return string.Empty;

            var claims = user.Identity as ClaimsIdentity;

            if (claims.EsNulo()) return string.Empty;

            var fecha = claims
                .Claims
                .SingleOrDefault(x => x.Type.Equals("Registro"));
            return !fecha.EsNulo() ? fecha.Value : string.Empty;
        }

        public static bool EsNulo(this object objeto)
        {
            return (objeto == null);
        }

    }
}