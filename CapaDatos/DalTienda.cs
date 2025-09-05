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
        //Es vacio porque no retorna nada solamente es para mandar los datos a la base de datos 
        /* CLIENTES*/
        public static int InserarCliente(string CTECLI_NOMBRE, string CTECLI_RAZONSOCIAL, string CTECLI_CORREO, string CTECLI_TELEFONO, string CTECLI_DIRECCION)
        {

            try
            {
                return MetodoDatos.iExecuteNonQuery(
                                            "SP_INSERTAR_CLIENTE"
                                            , "@CTECLI_NOMBRE", CTECLI_NOMBRE
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
            catch (Exception)
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

       
        /* PRODUCTOS */
        public static int InserarProducto(string PRODUC_DESCRIPCION, string PRODUC_DESCCORTA, decimal PRODUC_PESO, string PRODUC_OBSERVACIONES, string PRODUC_CODIGO_BARRAS, int CFGEDO_CODIGO_K)
        {
            try
            {
                return MetodoDatos.iExecuteNonQuery(
                                                "SP_INSERTAR_PRODUCTO"
                                                , "@PRODUC_DESCRIPCION", PRODUC_DESCRIPCION
                                                , "@PRODUC_DESCCORTA", PRODUC_DESCCORTA
                                                , "@PRODUC_PESO", PRODUC_PESO
                                                , "@CFGEDO_CODIGO_K", CFGEDO_CODIGO_K
                                                , "@PRODUC_OBSERVACIONES", PRODUC_OBSERVACIONES
                                                , "@PRODUC_CODIGO_BARRAS", PRODUC_CODIGO_BARRAS
                                                );
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public static int deleteProducto(int PRODUC_CODIGO_K)
        {
            try
            {
                return MetodoDatos.iExecuteNonQuery("SP_ELIMINAR_PRODUCTOS_BY_ID", "@PRODUC_CODIGO_K", PRODUC_CODIGO_K);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int ActualizarProducto(int PRODUC_CODIGO_K, string PRODUC_DESCRIPCION, string PRODUC_DESCCORTA, decimal PRODUC_PESO, string PRODUC_OBSERVACIONES, string PRODUC_CODIGO_BARRAS, int CFGEDO_CODIGO_K)
        {
            try
            {
                return MetodoDatos.iExecuteNonQuery(
                                                "SP_ACTUALIZAR_PRODUCTO"
                                                , "@PRODUC_CODIGO_K", PRODUC_CODIGO_K
                                                , "@PRODUC_DESCRIPCION", PRODUC_DESCRIPCION
                                                , "@PRODUC_DESCCORTA", PRODUC_DESCCORTA
                                                , "@PRODUC_PESO", PRODUC_PESO
                                                , "@PRODUC_OBSERVACIONES", PRODUC_OBSERVACIONES
                                                , "@PRODUC_CODIGO_BARRAS", PRODUC_CODIGO_BARRAS
                                                , "@CFGEDO_CODIGO_K", CFGEDO_CODIGO_K);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static List<EstadosVo> GetListEstados(int? CFGEDO_CODIGO_K)
        {
            DataSet dsEstados;

            if (CFGEDO_CODIGO_K != null)
            {
                dsEstados = MetodoDatos.dtExecuteDataSet("SP_LISTAR_ESTADOS", "@CFGEDO_CODIGO_K", CFGEDO_CODIGO_K);
            }
            else
            {
                dsEstados = MetodoDatos.dtExecuteDataSet("SP_LISTAR_ESTADOS");
            }
            List<EstadosVo> listaEstados = new List<EstadosVo>();
            foreach (DataRow dr in dsEstados.Tables[0].Rows)
            {
                listaEstados.Add(new EstadosVo(dr));
            }
            return listaEstados;
        }

        public static List<ProductosVo> GetListProductos(int? PRODUC_CODIGO_K)
        {
            try
            {

                // Código para obtener la lista de clientes desde la base de datos
                DataSet dsProductos;

                if (PRODUC_CODIGO_K != null)
                {
                    dsProductos = MetodoDatos.dtExecuteDataSet("SP_LISTAR_PRODUCTOS", "@PRODUC_CODIGO_K", PRODUC_CODIGO_K);
                }
                else
                {
                    dsProductos = MetodoDatos.dtExecuteDataSet("SP_LISTAR_PRODUCTOS");

                }

                List<ProductosVo> listaProductos = new List<ProductosVo>();

                foreach (DataRow dr in dsProductos.Tables[0].Rows)
                {
                    listaProductos.Add(new ProductosVo(dr));
                }

                return listaProductos;
            }
            catch (Exception ex)
            {
                // Manejo de errores bloquea el error
                Console.WriteLine($"Error al obtener la lista de clientes: {ex.Message}");
                //Remplaza la excepcion
                throw;
            }
        }

        public static ProductosVo GetProductosById(int? PRODUC_CODIGO_K)
        {
            try
            {
                DataSet dsProductos = MetodoDatos.dtExecuteDataSet("SP_LISTAR_PRODUCTOS_BY_ID", "@PRODUC_CODIGO_K", PRODUC_CODIGO_K);

                if (dsProductos.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsProductos.Tables[0].Rows[0];
                    ProductosVo Producto = new ProductosVo(dr);
                    return Producto;
                }
                else
                {
                    ProductosVo Producto = new ProductosVo();
                    return Producto;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int InsertarPedidoEnc(int CTECLI_CODIGO_K, string PEDCTE_FECHA, string PEDCTE_OBSERVACIONES, out int PEDCTE_CODIGO_K)
        {
            try
            {
                return MetodoDatos.iExecuteNonQueryWithOutput(
                                                "SP_INSERTARPEDIDOENC",
                                                "@PEDCTE_CODIGO_K",
                                                out PEDCTE_CODIGO_K,
                                                "@CTECLI_CODIGO_K", CTECLI_CODIGO_K,
                                                "@PEDCTE_FECHA", PEDCTE_FECHA,
                                                "@PEDCTE_OBSERVACIONES", PEDCTE_OBSERVACIONES
                                            );
                
            }
            catch (Exception)
            {
                PEDCTE_CODIGO_K = 0;
                return 0;
            }
        }
        public static int InsertarPedidoDet(int PEDCTE_CODIGO_K, int PRODUC_CODIGO_K, int PEDCTED_CANTIDAD, int PEDCTED_CANTPZA, decimal PEDCTED_PRECIO)
        {

            try
            {
                return MetodoDatos.iExecuteNonQuery(
                    "SP_INSERTARPEDIDODET",
                    "@PEDCTE_CODIGO_K", PEDCTE_CODIGO_K,
                    "@PRODUC_CODIGO_K", PRODUC_CODIGO_K,
                    "@PEDCTED_CANTIDAD", PEDCTED_CANTIDAD,
                    "@PEDCTED_CANTPZA", PEDCTED_CANTPZA,
                    "@PEDCTED_PRECIO", PEDCTED_PRECIO
                );
            }
            catch (Exception ex)
            {
                throw new Exception($"Error insertando detalle del producto {PRODUC_CODIGO_K}: {ex.Message}");
            }

        }
    }
}
