using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth.BusinessEntity;
using Birth.DataAccess;

namespace Birth.BusinessLogic
{
    public class BLArea
    {
        /// <summary>
        /// Lista Areas en el aplicativo registradas
        /// </summary>
        /// <returns></returns>
        public List<BEArea> ListarArea()
        {
            return new DAArea().ListarArea();
        }
    }
}
