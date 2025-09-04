using System;
using System.Collections.Generic;
using System.Data;
using VO;
namespace CapaDatos
{
    public class DalTienda
    {
        // Implementación de métodos para acceder a la base de datos de la tienda
        // Ejemplo: Obtener lista de productos, agregar producto, eliminar producto, etc.

        /*
         CTECLI_CODIGO_K INT IDENTITY(1,1) PRIMARY KEY,
        CTECLI_NOMBRE VARCHAR(100) NOT NULL,
	    CTECLI_RAZONSOCIAL VARCHAR(200) NOT NULL,
        CTECLI_CORREO VARCHAR(100) NOT NULL,
        CTECLI_TELEFONO VARCHAR(20),
        CTECLI_DIRECCION VARCHAR(200)
         */

        //Es vacio porque no retorna nada solamente es para mandar los datos a la base de datos 
        public static int InserarCliente(string CTECLI_NOMBRE, string CTECLI_RAZONSOCIAL, string CTECLI_CORREO, string CTECLI_TELEFONO, string CTECLI_DIRECCION)
        {

            try
            {
                return MetodoDatos.iExecuteNonQuery(
                                            "SP_INSERTAR_CLIENTE"
                                            , "@CTECLI_NOMBRE",CTECLI_NOMBRE
                                            , "@CTECLI_RAZONSOCIAL", CTECLI_RAZONSOCIAL
                                            , "@CTECLI_CORREO", CTECLI_CORREO
                                            , "@CTECLI_TELEFONO", CTECLI_TELEFONO
                                            , "@CTECLI_DIRECCION", CTECLI_DIRECCION);
            }
            catch (Exception)
            {
                //No se puedo insertar por x cosa, no creo que pase alv
                return 0;
            }
        }

        public static int ActualizarCliente(int CTECLI_CODIGO_K, string CTECLI_NOMBRE, string CTECLI_RAZONSOCIAL, string CTECLI_CORREO, string CTECLI_TELEFONO, string CTECLI_DIRECCION)
        {
            try
            {
                return MetodoDatos.iExecuteNonQuery(
                                            "SP_ACTUALIZAR_CLIENTE"
                                            , "@CTECLI_CODIGO_K", CTECLI_CODIGO_K
                                            , "@CTECLI_NOMBRE", CTECLI_NOMBRE
                                            , "@CTECLI_RAZONSOCIAL", CTECLI_RAZONSOCIAL
                                            , "@CTECLI_CORREO", CTECLI_CORREO
                                            , "@CTECLI_TELEFONO", CTECLI_TELEFONO
                                            , "@CTECLI_DIRECCION", CTECLI_DIRECCION);
            }
            catch (Exception)
            {
                return 0;
            }
        }


        public static int deleteCliente(int CTECLI_CODIGO_K)
        {
            try
            {
                return MetodoDatos.iExecuteNonQuery("SP_ELIMINAR_CLIENTES_BY_ID", "@CTECLI_CODIGO_K", CTECLI_CODIGO_K);
            }
            catch (Exception ex)
            {
                
                return 0;
            }
        }

        public static List<ClientesVo> GetListClientes(int? CTECLI_CODIGO_K)
        {
            try
            {

                // Código para obtener la lista de clientes desde la base de datos
                DataSet dsClientes;

                if (CTECLI_CODIGO_K != null)
                {
                    dsClientes = MetodoDatos.dtExecuteDataSet("SP_LISTAR_CLIENTES", "@CTECLI_CODIGO_K", CTECLI_CODIGO_K);
                }
                else
                {
                    dsClientes = MetodoDatos.dtExecuteDataSet("SP_LISTAR_CLIENTES");

                }

                List<ClientesVo> listaClientes = new List<ClientesVo>();

                foreach (DataRow dr in dsClientes.Tables[0].Rows)
                {
                    listaClientes.Add(new ClientesVo(dr));
                }

                return listaClientes;
            }
            catch (Exception ex)
            {
                // Manejo de errores bloquea el error
                Console.WriteLine($"Error al obtener la lista de clientes: {ex.Message}");
                //Remplaza la excepcion
                throw;
            }
        }

        public static ClientesVo GetClientesById(int? paramIdCliente)
        {
            try
            {
                DataSet dsCliente = MetodoDatos.dtExecuteDataSet("SP_LISTAR_CLIENTES_BY_ID", "@CTECLI_CODIGO_K", paramIdCliente);

                if (dsCliente.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsCliente.Tables[0].Rows[0];
                    ClientesVo Cliente = new ClientesVo(dr);
                    return Cliente;
                }
                else
                {
                    ClientesVo Clientes = new ClientesVo();
                    return Clientes;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
