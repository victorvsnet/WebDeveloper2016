using Birth.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birth.DataAccess
{
    public class DAOrganizacion
    {
        public List<BEOrganizacion> ObtenerOrganizadores(int anio, int idUsuario)
        {
            List<BEOrganizacion> Lista = new List<BEOrganizacion>();
            BEOrganizacion item = new BEOrganizacion();
            using (SqlConnection ocn = new SqlConnection(Util.getConnection()))
            {
                using (SqlCommand ocmd = new SqlCommand("Muro.SP_Cumpleanios_Select", ocn))
                {
                    ocmd.CommandType = CommandType.StoredProcedure;
                    ocmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                    ocmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

                    ocn.Open();

                    using (SqlDataReader oReader = ocmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            //Instanciamos la variable
                            item = new BEOrganizacion();

                            //cargamos la informacion de la BD
                            if (!Convert.IsDBNull(oReader["id"]))
                                item.id = Convert.ToInt32(oReader["id"]);

                            if (!Convert.IsDBNull(oReader["idusuario"]))
                                item.idusuario = Convert.ToInt32(oReader["idusuario"]);

                            if (!Convert.IsDBNull(oReader["Cumpleaniero"]))
                                item.gls_Cumpleaniero = oReader["Cumpleaniero"].ToString();

                            if (!Convert.IsDBNull(oReader["idusuariorganiza"]))
                                item.idusuariorganiza = Convert.ToInt32(oReader["idusuariorganiza"]);

                            if (!Convert.IsDBNull(oReader["organizador"]))
                                item.gls_organizador = oReader["organizador"].ToString();

                            if (!Convert.IsDBNull(oReader["anio"]))
                                item.anio = Convert.ToInt32(oReader["anio"]);
                            
                            if (!Convert.IsDBNull(oReader["estado"]))
                                item.estado = oReader["estado"].ToString();

                            if (!Convert.IsDBNull(oReader["gls_Cargo"]))
                                item.gls_Cargo = oReader["gls_Cargo"].ToString();

                            Lista.Add(item);
                        }
                    }
                }

                ocn.Close();
            }
            return Lista;
        }
    }
}
