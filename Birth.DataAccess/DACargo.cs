using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Birth.BusinessEntity;

namespace Birth.DataAccess
{
    public class DACargo
    {
        /// <summary>
        /// Obtiene todos los Cargos registrados.
        /// </summary>
        /// <returns></returns>
        public List<BECargo> ListarCargo()
        {
            List<BECargo> Lista = new List<BECargo>();
            BECargo item;

            using (SqlConnection ocn = new SqlConnection(Util.getConnection()))
            {
                using (SqlCommand ocmd = new SqlCommand("Perfil.SP_Cargo_Select", ocn))
                {
                    ocmd.CommandType = CommandType.StoredProcedure;
                    ocn.Open();

                    using (SqlDataReader oReader = ocmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            //Instanciamos la variable
                            item = new BECargo();

                            //cargamos la informacion de la BD
                            if (!Convert.IsDBNull(oReader["id"]))
                                item.id = Convert.ToInt32(oReader["id"]);

                            if (!Convert.IsDBNull(oReader["gls_Cargo"]))
                                item.gls_Cargo = oReader["gls_Cargo"].ToString();

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

        /// <summary>
        /// Obtenemos el cargo desde un codigo especifico
        /// </summary>
        /// <param name="id">codigo de busqueda</param>
        /// <returns>Datos del Cargo</returns>
        public BECargo ObtenerCargo(int id)
        {
            BECargo item = new BECargo();

            using (SqlConnection ocn = new SqlConnection(Util.getConnection()))
            {
                using (SqlCommand ocmd = new SqlCommand("Perfil.SP_Cargo_Obtener", ocn))
                {
                    ocmd.CommandType = CommandType.StoredProcedure;
                    ocmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                    ocn.Open();

                    using (SqlDataReader oReader = ocmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {

                            //cargamos la informacion de la BD
                            if (!Convert.IsDBNull(oReader["id"]))
                                item.id = Convert.ToInt32(oReader["id"]);

                            if (!Convert.IsDBNull(oReader["gls_Cargo"]))
                                item.gls_Cargo = oReader["gls_Cargo"].ToString();

                            if (!Convert.IsDBNull(oReader["estado"]))
                                item.estado = oReader["estado"].ToString();
                        }
                    }
                }

                ocn.Close();
                return item;
            }
        }

    }
}
