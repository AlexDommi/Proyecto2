using CapaDatos;
using System;
using System.Collections.Generic;
using VO;

namespace CapaNegocios
{
    public class BillTiendaOnline
    {
        public static List<ClientesVo> GetListClientes(int? CTECLI_CODIGO_K)
        {
            //RETORNA LA LISTA DE CLIENTES
            return DalTienda.GetListClientes(CTECLI_CODIGO_K);
        }

        public static List<EstadosVo> GetListEstados(int? CFGEDO_CODIGO_K)
        {
            //RETORNA LA LISTA DE CLIENTES
            return DalTienda.GetListEstados(CFGEDO_CODIGO_K);
        }

        public static ClientesVo GetClientesById(int CTECLI_CODIGO_K)
        {
            return DalTienda.GetClientesById(CTECLI_CODIGO_K);
        }

        public static int EliminarCliente(int CTECLI_CODIGO_K) 
        {
            int iExitoso = DalTienda.deleteCliente(CTECLI_CODIGO_K);

            if(iExitoso == 1)
            {
                //Eliminado
                return 1;
            }
            else
            {
                //No se puede Eliminar por la integridad referencial
                return 0;
            }
        }

        public static string ActualizarCliente( int CTECLI_CODIGO_K, string CTECLI_NOMBRE, string CTECLI_RAZONSOCIAL, string CTECLI_CORREO, string CTECLI_TELEFONO, string CTECLI_DIRECCION, string CTECLI_FOTOURL)
        {
            int iExitoso = DalTienda.ActualizarCliente(CTECLI_CODIGO_K, CTECLI_NOMBRE, CTECLI_RAZONSOCIAL, CTECLI_CORREO, CTECLI_TELEFONO, CTECLI_DIRECCION, CTECLI_FOTOURL);
            if (iExitoso == 1)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public static int InsertarCliente(string CTECLI_NOMBRE, string CTECLI_RAZONSOCIAL, string CTECLI_CORREO, string CTECLI_TELEFONO, string CTECLI_DIRECCION, string CTECLI_FOTOURL)
        {
            int iExitoso = DalTienda.InserarCliente(CTECLI_NOMBRE, CTECLI_RAZONSOCIAL, CTECLI_CORREO, CTECLI_TELEFONO, CTECLI_DIRECCION, CTECLI_FOTOURL);
            if (iExitoso == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static List<ProductosVo> GetListProductos(int? PRODUC_CODIGO_K)
        {
            return DalTienda.GetListProductos(PRODUC_CODIGO_K);
        }

        public static ProductosVo GetProductoById(int PRODUC_CODIGO_K)
        {
            return DalTienda.GetProductosById(PRODUC_CODIGO_K);
        }

        public static int InsertarProducto(string PRODUC_DESCRIPCION, string PRODUC_DESCCORTA, decimal PRODUC_PESO, string PRODUC_OBSERVACIONES, string PRODUC_CODIGO_BARRAS, int CFGEDO_CODIGO_K, int PRODUC_PZAXUND)
        {
            int iExitoso = DalTienda.InserarProducto(PRODUC_DESCRIPCION, PRODUC_DESCCORTA, PRODUC_PESO, PRODUC_OBSERVACIONES, PRODUC_CODIGO_BARRAS,CFGEDO_CODIGO_K, PRODUC_PZAXUND);

            if (iExitoso == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static int ActualizarProducto(int PRODUC_CODIGO_K, string PRODUC_DESCRIPCION, string PRODUC_DESCCORTA, decimal PRODUC_PESO, string PRODUC_OBSERVACIONES, string PRODUC_CODIGO_BARRAS, int CFGEDO_CODIGO_K, int PRODUC_PZAXUND)
        {
            int iExitoso = DalTienda.ActualizarProducto(PRODUC_CODIGO_K, PRODUC_DESCRIPCION, PRODUC_DESCCORTA, PRODUC_PESO, PRODUC_OBSERVACIONES, PRODUC_CODIGO_BARRAS, CFGEDO_CODIGO_K, PRODUC_PZAXUND);
            if (iExitoso == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static int EliminarProducto(int PRODUC_CODIGO_K)
        {
            int iExitoso = DalTienda.deleteProducto(PRODUC_CODIGO_K);
            if (iExitoso == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public static int InsertarPedidoEnc(int CTECLI_CODIGO_K,string PEDCTE_FECHA, string PEDCTE_OBSERVACIONES, out int PEDCTE_CODIGO_K)
        {
            int iExitosoEnc = DalTienda.InsertarPedidoEnc(CTECLI_CODIGO_K, PEDCTE_FECHA, PEDCTE_OBSERVACIONES, out PEDCTE_CODIGO_K);

            return iExitosoEnc;
        }

        public static int InsertarPedidoDet(int PEDCTE_CODIGO_K, int PRODUC_CODIGO_K, int PEDCTED_CANTIDAD, int PEDCTED_CANTPZA, decimal PEDCTED_PRECIO)
        {
            int iExitoso = DalTienda.InsertarPedidoDet(PEDCTE_CODIGO_K, PRODUC_CODIGO_K, PEDCTED_CANTIDAD, PEDCTED_CANTPZA, PEDCTED_PRECIO);

            return iExitoso;
        }
    }
}
