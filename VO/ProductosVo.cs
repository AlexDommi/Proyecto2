        using System.Data;

namespace VO
{
    public class ProductosVo
    {
        #region Productos
        //Atributos        
        private int _PRODUC_CODIGO_K;
        private string _PRODUC_DESCRIPCION;
        private string _PRODUC_DESCCORTA;
        private decimal _PRODUC_PESO;
        private string _PRODUC_OBSERVACIONES;
        private string _PRODUC_CODIGO_BARRAS;
        private int _CFGEDO_CODIGO_K;

        //Propiedades
        public int PRODUC_CODIGO_K
        {
            get => _PRODUC_CODIGO_K;
            set => _PRODUC_CODIGO_K = value;
        }

        public string PRODUC_DESCRIPCION
        {
            get => _PRODUC_DESCRIPCION;
            set => _PRODUC_DESCRIPCION = value;
        }
        public string PRODUC_DESCCORTA
        {
            get => _PRODUC_DESCCORTA;
            set => _PRODUC_DESCCORTA = value;
        }
        public decimal PRODUC_PESO
        {
            get => _PRODUC_PESO;
            set => _PRODUC_PESO = value;
        }
        public string PRODUC_OBSERVACIONES
        {
            get => _PRODUC_OBSERVACIONES;
            set => _PRODUC_OBSERVACIONES = value;
        }
        public string PRODUC_CODIGO_BARRAS
        {
            get => _PRODUC_CODIGO_BARRAS;
            set => _PRODUC_CODIGO_BARRAS = value;
        }
        public int CFGEDO_CODIGO_K
        {
            get => _CFGEDO_CODIGO_K;
            set => _CFGEDO_CODIGO_K = value;
        }

        //Constructor
        public ProductosVo(DataRow dr)
        {
            PRODUC_CODIGO_K = int.Parse(dr["PRODUC_CODIGO_K"].ToString());
            PRODUC_DESCRIPCION = dr["PRODUC_DESCRIPCION"].ToString();
            PRODUC_DESCCORTA = dr["PRODUC_DESCCORTA"].ToString();
            PRODUC_PESO = decimal.Parse(dr["PRODUC_PESO"].ToString());
            PRODUC_OBSERVACIONES = dr["PRODUC_OBSERVACIONES"].ToString();
            PRODUC_CODIGO_BARRAS = dr["PRODUC_CODIGO_BARRAS"].ToString();
            CFGEDO_CODIGO_K = int.Parse(dr["CFGEDO_CODIGO_K"].ToString());

        }

        public ProductosVo()
        {
            PRODUC_CODIGO_K = 0;
            PRODUC_DESCRIPCION = string.Empty;
            PRODUC_DESCCORTA = string.Empty;
            PRODUC_PESO = 0;
            PRODUC_OBSERVACIONES = string.Empty;
            PRODUC_CODIGO_BARRAS = string.Empty;
            CFGEDO_CODIGO_K = 0;
        }
        #endregion
    }
}
