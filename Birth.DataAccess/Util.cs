﻿using System.Configuration;

namespace Birth.DataAccess
{
    public static class Util
    {
        /// <summary>
        /// Obtiene la cadena de conexión configurada en el Web.Config
        /// </summary>
        /// <returns>Cadena de conexión</returns>
        public static string getConnection()
        {
            return ConfigurationManager.ConnectionStrings["DBBIRTHDAY"].ConnectionString;
        }
    }
}
