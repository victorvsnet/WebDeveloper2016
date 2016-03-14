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
        /// Selecciona usuarios de la tabla Perfil.Usuario
        /// </summary>
        /// <returns></returns>
        public List<BEUsuario> ListarUsuario()
        {
            return new DAUsuario().ListarUsuario();
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
    }
}
