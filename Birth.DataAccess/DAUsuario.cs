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
    public class DAUsuario
    {
        /// <summary>
        /// Selecciona usuarios de la tabla Perfil.Usuario
        /// </summary>
        /// <returns></returns>
        public List<BEUsuario> ListarUsuario()
        {
            List<BEUsuario> Lista = new List<BEUsuario>();
            BEUsuario item;

            using (SqlConnection ocn = new SqlConnection(Util.getConnection()))
            {
                using (SqlCommand ocmd = new SqlCommand("Perfil.SP_Usuario_Obtener", ocn))
                {
                    ocmd.CommandType = CommandType.StoredProcedure;
                    ocn.Open();

                    using (SqlDataReader oReader = ocmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            //Instanciamos la variable
                            item = new BEUsuario();

                            //cargamos la informacion de la BD
                            if (!Convert.IsDBNull(oReader["id"]))
                                item.id = Convert.ToInt32(oReader["id"]);

                            if (!Convert.IsDBNull(oReader["gls_nombre"]))
                                item.gls_nombre = oReader["gls_nombre"].ToString();

                            if (!Convert.IsDBNull(oReader["gls_ape_paterno"]))
                                item.gls_ape_paterno = oReader["gls_ape_paterno"].ToString();

                            if (!Convert.IsDBNull(oReader["gls_ape_materno"]))
                                item.gls_ape_materno = oReader["gls_ape_materno"].ToString();

                            if (!Convert.IsDBNull(oReader["correo"]))
                                item.correo = oReader["correo"].ToString();

                            if (!Convert.IsDBNull(oReader["anexo"]))
                                item.anexo = Convert.ToInt32(oReader["anexo"]);

                            if (!Convert.IsDBNull(oReader["gls_usuario"]))
                                item.gls_usuario = oReader["gls_usuario"].ToString();

                            if (!Convert.IsDBNull(oReader["idcargo"]))
                                item.idcargo = Convert.ToInt32(oReader["idcargo"]);

                            if (!Convert.IsDBNull(oReader["idarea"]))
                                item.idarea = Convert.ToInt32(oReader["idarea"]);

                            if (!Convert.IsDBNull(oReader["idempresa"]))
                                item.idempresa = Convert.ToInt32(oReader["idempresa"]);

                            if (!Convert.IsDBNull(oReader["idcategoria"]))
                                item.idcategoria = Convert.ToInt32(oReader["idcategoria"]);

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
        /// Insertar Datos de Usuario
        /// </summary>
        /// <param name="parametro">Datos del Usuario (Objeto BEUsuario)</param>
        /// <returns>Estado de la Grabacion</returns>
        public bool InsertUsuario(BEUsuario parametro)
        {
            try
            {
                bool estado = false;
                using (SqlConnection con = new SqlConnection(Util.getConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand("Perfil.SP_Insert_Usuario", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@gls_nombre", SqlDbType.VarChar).Value = parametro.gls_nombre;
                        cmd.Parameters.Add("@gls_ape_paterno", SqlDbType.VarChar).Value = parametro.gls_ape_paterno;
                        cmd.Parameters.Add("@gls_ape_materno", SqlDbType.VarChar).Value = parametro.gls_ape_materno;

                        if (parametro.anexo != null)
                            cmd.Parameters.Add("@anexo", SqlDbType.Int).Value = parametro.anexo.Value;

                        cmd.Parameters.Add("@gls_usuario", SqlDbType.VarChar).Value = parametro.gls_usuario;
                        cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = parametro.correo;

                        if (parametro.idcargo != null)
                            cmd.Parameters.Add("@idcargo", SqlDbType.Int).Value = parametro.idcargo.Value;

                        if (parametro.idarea != null)
                            cmd.Parameters.Add("@idarea", SqlDbType.Int).Value = parametro.idarea.Value;

                        if (parametro.idempresa != null)
                            cmd.Parameters.Add("@idempresa", SqlDbType.Int).Value = parametro.idempresa.Value;

                        if (parametro.idcategoria != null)
                            cmd.Parameters.Add("@idcategoria", SqlDbType.Int).Value = parametro.idcategoria.Value;

                        cmd.Parameters.Add("@guid_user", SqlDbType.VarChar).Value = parametro.guid_user;
                        cmd.Parameters.Add("@estado", SqlDbType.Char).Value = parametro.estado;
                        cmd.Parameters.Add("@aud_usr_ingreso", SqlDbType.VarChar).Value = parametro.aud_usr_ingreso;

                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        cmd.ExecuteNonQuery();
                        estado = true;
                    }
                    con.Close();
                }
                return estado;
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error: ", ex);
            }

        }

    }
}
