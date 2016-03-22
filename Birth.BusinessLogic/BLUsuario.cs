using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth.BusinessEntity;
using Birth.DataAccess;

namespace Birth.BusinessLogic
{
    public class BLUsuario
    {
        /// <summary>
        /// Obtiene usuarios de la tabla Perfil.Usuario
        /// </summary>
        /// <param name="guid_user">llave clave GUID</param>
        /// <returns>usuario correspondiente</returns>
        public BEUsuario ObtenerUsuario(string guid_user)
        {
            return new DAUsuario().ObtenerUsuario(guid_user);
        }

        /// <summary>
        /// Insertar Datos de Usuario
        /// </summary>
        /// <param name="parametro">Datos del Usuario (Objeto BEUsuario)</param>
        /// <returns>Estado de la Grabacion</returns>
        public bool InsertUsuario(BEUsuario parametro)
        {
            return new DAUsuario().InsertUsuario(parametro);
        }

        /// <summary>
        /// Actualiza informacion del usuario
        /// </summary>
        /// <param name="parametro">propiedades del usuario</param>
        /// <returns></returns>
        public bool ActualizarUsuario(BEUsuario parametro)
        {
            return new DAUsuario().ActualizarUsuario(parametro);
        }
    }
}
