using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth.BusinessEntity;
using Birth.DataAccess;

namespace Birth.BusinessLogic
{
    public class BLEmpresa
    {

        /// <summary>
        /// Lista empresas registradas.
        /// </summary>
        /// <returns></returns>
        public List<BEEmpresa> ListarEmpresa()
        {
            return new DAEmpresa().ListarEmpresa();
        }
    }
}
