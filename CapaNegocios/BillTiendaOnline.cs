using CapaDatos;
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

        public static string ActualizarCliente( int CTECLI_CODIGO_K, string CTECLI_NOMBRE, string CTECLI_RAZONSOCIAL, string CTECLI_CORREO, string CTECLI_TELEFONO, string CTECLI_DIRECCION)
        {
            int iExitoso = DalTienda.ActualizarCliente(CTECLI_CODIGO_K, CTECLI_NOMBRE, CTECLI_RAZONSOCIAL, CTECLI_CORREO, CTECLI_TELEFONO, CTECLI_DIRECCION);
            if (iExitoso == 1)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public static int InsertarCliente(string CTECLI_NOMBRE, string CTECLI_RAZONSOCIAL, string CTECLI_CORREO, string CTECLI_TELEFONO, string CTECLI_DIRECCION)
        {
            int iExitoso = DalTienda.InserarCliente(CTECLI_NOMBRE, CTECLI_RAZONSOCIAL, CTECLI_CORREO, CTECLI_TELEFONO, CTECLI_DIRECCION);
            if (iExitoso == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
