using System;
using System.Data;

namespace VO
{
    internal class PagosVo
    {
        /*
         LIQPAG_CODIGO_K INT IDENTITY(1,1) PRIMARY KEY,
        PEDCTE_CODIGO_K INT NOT NULL,
        LIQPAG_FECHA DATETIME NOT NULL DEFAULT GETDATE(),
        LIQPAG_MONTO DECIMAL(10,2) NOT NULL,
        CFGPAG_CODIGO_K INT,
         */

        #region Pagos
        //Atributos
        private int _LIQPAG_CODIGO_K;
        private int _PEDCTE_CODIGO_K;
        private DateTime _LIQPAG_FECHA;
        private decimal _LIQPAG_MONTO;
        private int _CFGPAG_CODIGO_K;

        //Propiedades
        public int LIQPAG_CODIGO_K
        {
            get => _LIQPAG_CODIGO_K;
            set => _LIQPAG_CODIGO_K = value;
        }

        public int PEDCTE_CODIGO_K
        {
            get => _PEDCTE_CODIGO_K;
            set => _PEDCTE_CODIGO_K = value;
        }

        public DateTime LIQPAG_FECHA
        {
            get => _LIQPAG_FECHA;
            set => _LIQPAG_FECHA = value;
        }

        public decimal LIQPAG_MONTO
        {
            get => _LIQPAG_MONTO;
            set => _LIQPAG_MONTO = value;
        }

        public int CFGPAG_CODIGO_K
        {
            get => _CFGPAG_CODIGO_K;
            set => _CFGPAG_CODIGO_K = value;
        }

        //Constructor

        public PagosVo(DataRow dr)
        {
            LIQPAG_CODIGO_K = int.Parse(dr["LIQPAG_CODIGO_K"].ToString());
            PEDCTE_CODIGO_K = int.Parse(dr["PEDCTE_CODIGO_K"].ToString());
            LIQPAG_FECHA = DateTime.Parse(dr["LIQPAG_FECHA"].ToString());
            LIQPAG_MONTO = decimal.Parse(dr["LIQPAG_MONTO"].ToString());
            CFGPAG_CODIGO_K = int.Parse(dr["CFGPAG_CODIGO_K"].ToString());
        }

        public PagosVo()
        {
            LIQPAG_CODIGO_K = 0;
            PEDCTE_CODIGO_K = 0;
            LIQPAG_FECHA = DateTime.Parse("1900-01-01");
            LIQPAG_MONTO = 0;
            CFGPAG_CODIGO_K = 1;
        }
        #endregion Pagos
    }
}
