using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class EstadosVo
    {
        private int _CFGEDO_CODIGO_K;
        private string _CFGEDO_DESCRIPCION;

        public int CFGEDO_CODIGO_K
        {
            get => _CFGEDO_CODIGO_K;
            set => _CFGEDO_CODIGO_K = value;
        }

        public string CFGEDO_DESCRIPCION
        {
            get => _CFGEDO_DESCRIPCION;
            set => _CFGEDO_DESCRIPCION = value;
        }

        public EstadosVo(DataRow dr)
        {
            CFGEDO_CODIGO_K = int.Parse(dr["CFGEDO_CODIGO_K"].ToString());
            CFGEDO_DESCRIPCION = dr["CFGEDO_DESCRIPCION"].ToString();
        }

        public EstadosVo()
        {
            CFGEDO_CODIGO_K = 0;
            CFGEDO_DESCRIPCION = string.Empty;
        }
    }
}
