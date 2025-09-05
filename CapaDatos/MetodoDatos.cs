using System;
using System.Data;
using System.Data.SqlClient;

/***********************************************************
    Este es el motorcito que nos permite ejecutar los 
    Store Procedures y Mostrar los datos en un DataSet
    ya no se mete nada mas de codigo en esta clase
 ***********************************************************/

namespace CapaDatos
{
    internal class MetodoDatos
    {
        //Metodo que nos regresa informacion en un DataSet (TABLA O lISTA)
        public static DataSet dtExecuteDataSet(string sStoreProcedure, params object[] parametros)
        {
            DataSet ds = new DataSet();

            //Obtener la cadena de conexion
            string sConexion = Configuracion.ObtenerConexion;

            SqlConnection conn = new SqlConnection(sConexion);

            try
            {
                SqlCommand cmd = new SqlCommand(sStoreProcedure, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sStoreProcedure;

                //Se valida que los parametros estan completos
                if (parametros != null && parametros.Length % 2 != 0)
                {
                    throw new ApplicationException("Los parametros deben ser pares");
                }
                else
                {
                    //Se asignan los parametros al command

                    for (int i = 0; i < parametros.Length; i += 2)
                    {
                        cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1] ?? DBNull.Value);
                    }

                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);

                    conn.Close();
                }

                //Retornamos el DataSet
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo conectar MetodoDatosL62" + ex.Message);
            }
            finally
            {
                //Cerramos la conexion si esta abierta
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        //Metodo que nos ejecuta un Store Procedure (INSERT, UPDATE, DELETE)
        public static int iExecuteNonQuery(string sStoreProcedure, params object[] parametros)
        {
            int iExitoso = 0;

            string sConexion = Configuracion.ObtenerConexion;

            SqlConnection conn = new SqlConnection(sConexion);
            try
            {
                SqlCommand cmd = new SqlCommand(sStoreProcedure, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sStoreProcedure;

                if (parametros != null && parametros.Length % 2 != 0)
                {
                    throw new ApplicationException("Los parametros deben venir en pares");
                }
                else
                {
                    for (int i = 0; i < parametros.Length; i += 2)
                    {
                        cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    iExitoso = 1;
                    conn.Close();
                }
                return iExitoso;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo conectar" + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public static int iExecuteNonQueryWithOutput(string sStoreProcedure, string outputParamName, out int outputValue, params object[] parametros)
        {
            outputValue = 0;
            string sConexion = Configuracion.ObtenerConexion;

            using (SqlConnection conn = new SqlConnection(sConexion))
            using (SqlCommand cmd = new SqlCommand(sStoreProcedure, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Agregar parámetros de entrada
                if (parametros != null)
                {
                    if (parametros.Length % 2 != 0)
                        throw new ApplicationException("Los parámetros deben venir en pares");

                    for (int i = 0; i < parametros.Length; i += 2)
                    {
                        cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1] ?? DBNull.Value);
                    }
                }

                // Agregar parámetro de salida
                SqlParameter outputParam = new SqlParameter(outputParamName, SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                conn.Open();
                cmd.ExecuteNonQuery();

                outputValue = Convert.ToInt32(outputParam.Value); // aquí obtienes el folio
            }

            return 1;
        }



        //Metodo que nos ejecuta un Store Procedure y regresa un valor escalar
        public static int iExecuteEscalar(string sStoredProcedure, params object[] parametros)
        {
            int iResultado = 0;
            string sConexion = Configuracion.ObtenerConexion;
            SqlConnection conn = new SqlConnection(sConexion);

            try
            {
                SqlCommand cmd = new SqlCommand(sStoredProcedure, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sStoredProcedure;

                if (parametros != null && parametros.Length % 2 != 0)
                {
                    throw new ApplicationException("Los parametros deben venir en pares");
                }
                else
                {
                    for (int i = 0; i < parametros.Length; i += 2)
                    {
                        cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                    }

                    conn.Open();
                    iResultado = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();

                }

                return iResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo conectar" + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
