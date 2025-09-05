using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class PedidoDetVo
    {
        private int _PEDCTE_CODIGO_K;
        private int _PRODUC_CODIGO_K;
        private int _PEDCTED_CANTIDAD;
        private int _PEDCTED_CANTPZA;
        private decimal _PEDCTED_PRECIO;

        public int PEDCTE_CODIGO_K
        {
            get => _PEDCTE_CODIGO_K;
            set => _PEDCTE_CODIGO_K = value;
        }

        public int PRODUC_CODIGO_K
        {
            get => _PRODUC_CODIGO_K;
            set => _PRODUC_CODIGO_K = value;
        }

        public int PEDCTED_CANTIDAD
        {
            get => _PEDCTED_CANTIDAD;
            set => _PEDCTED_CANTIDAD = value;
        }

        public int PEDCTED_CANTPZA
        {
            get => _PEDCTED_CANTPZA;
            set => _PEDCTED_CANTPZA = value;
        }

        public decimal PEDCTED_PRECIO
        {
            get => _PEDCTED_PRECIO;
            set => _PEDCTED_PRECIO = value;
        }

        public PedidoDetVo(DataRow dr)
        {
            PEDCTE_CODIGO_K = int.Parse(dr["PEDCTE_CODIGO_K"].ToString());
            PRODUC_CODIGO_K = int.Parse(dr["PRODUC_CODIGO_K"].ToString());
            PEDCTED_CANTIDAD = int.Parse(dr["PEDCTED_CANTIDAD"].ToString());
            PEDCTED_CANTPZA = int.Parse(dr["PEDCTED_CANTPZA"].ToString());
            PEDCTED_PRECIO = decimal.Parse(dr["PEDCTED_PRECIO"].ToString());
        }

        public PedidoDetVo()
        {
            PEDCTE_CODIGO_K = 0;
            PRODUC_CODIGO_K = 0;
            PEDCTED_CANTIDAD = 0;
            PEDCTED_CANTPZA = 0;
            PEDCTED_PRECIO = 0;
        }


    }
}
