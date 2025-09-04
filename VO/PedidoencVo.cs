using System;
using System.Collections.Generic;
using System.Data;

namespace VO
{
    public class PedidoencVo
    {
        #region Pedidoenc
        //Atributos
        private int _PEDCTE_CODIGO_K;
        private int _CTECLI_CODIGO_K;
        private DateTime _PEDCTE_FECHA;
        private string _PEDCTE_OBSERVACIONES;
        private int _CFGEDO_CODIGO_K;
        private List<PedidoDetVo> listDetallePedido;
        //Propiedades
        public int PEDCTE_CODIGO_K
        {
            get => _PEDCTE_CODIGO_K;
            set => _PEDCTE_CODIGO_K = value;
        }
        public int CTECLI_CODIGO_K
        {
            get => _CTECLI_CODIGO_K;
            set => _CTECLI_CODIGO_K = value;
        }
        public DateTime PEDCTE_FECHA
        {
            get => _PEDCTE_FECHA;
            set => _PEDCTE_FECHA = value;
        }
        public string PEDCTE_OBSERVACIONES
        {
            get => _PEDCTE_OBSERVACIONES;
            set => _PEDCTE_OBSERVACIONES = value;
        }
        public int CFGEDO_CODIGO_K
        {
            get => _CFGEDO_CODIGO_K;
            set => _CFGEDO_CODIGO_K = value;
        }

        //Constructor
        public PedidoencVo(DataRow dr)
        {
            PEDCTE_CODIGO_K = int.Parse(dr["PEDCTE_CODIGO_K"].ToString());
            CTECLI_CODIGO_K = int.Parse(dr["CTECLI_CODIGO_K"].ToString());
            PEDCTE_FECHA = DateTime.Parse(dr["PEDCTE_FECHA"].ToString());
            PEDCTE_OBSERVACIONES = dr["PEDCTE_OBSERVACIONES"].ToString();
            CFGEDO_CODIGO_K = int.Parse(dr["CFGEDO_CODIGO_K"].ToString());
        }

        public PedidoencVo()
        {
            PEDCTE_CODIGO_K = 0;
            CTECLI_CODIGO_K = 0;
            PEDCTE_FECHA = DateTime.Parse("1900-01-01"); ;
            PEDCTE_OBSERVACIONES = string.Empty;
            CFGEDO_CODIGO_K = 1;
        }

        #endregion Pedidoenc
    }
}
