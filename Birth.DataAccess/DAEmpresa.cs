﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Birth.BusinessEntity;


namespace Birth.DataAccess
{
    public class DAEmpresa
    {

        /// <summary>
        /// Lista empresas registradas.
        /// </summary>
        /// <returns></returns>
        public List<BEEmpresa> ListarEmpresa()
        {
            List<BEEmpresa> Lista = new List<BEEmpresa>();
            BEEmpresa item;

            using (SqlConnection ocn = new SqlConnection(Util.getConnection()))
            {
                using (SqlCommand ocmd = new SqlCommand("Perfil.SP_Empresa_Select", ocn))
                {
                    ocmd.CommandType = CommandType.StoredProcedure;
                    ocn.Open();

                    using (SqlDataReader oReader = ocmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            //Instanciamos la variable
                            item = new BEEmpresa();

                            //cargamos la informacion de la BD
                            if (!Convert.IsDBNull(oReader["id"]))
                                item.id = Convert.ToInt32(oReader["id"]);

                            if (!Convert.IsDBNull(oReader["gls_empresa"]))
                                item.gls_empresa = oReader["gls_empresa"].ToString();

                            if (!Convert.IsDBNull(oReader["estado"]))
                                item.estado = oReader["estado"].ToString();

                            //Agregamos el elemento al listado
                            Lista.Add(item);

                        }
                    }
                }

                ocn.Close();
                return Lista;
            }
        }

    }
}
