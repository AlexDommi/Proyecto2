using System.Data;

namespace VO
{
    public class ClientesVo
    {
        #region Clientes
        //Atributos        
        private int _CTECLI_CODIGO_K;
        private string _CTECLI_NOMBRE;
        private string _CTECLI_RAZONSOCIAL;
        private string _CTECLI_CORREO;
        private string _CTECLI_TELEFONO;
        private string _CTECLI_DIRECCION;
        private string _CTECLI_FOTOURL;
        //Propiedades
        public int CTECLI_CODIGO_K
        {
            get => _CTECLI_CODIGO_K;
            set => _CTECLI_CODIGO_K = value;
        }

        public string CTECLI_NOMBRE
        {
            get => _CTECLI_NOMBRE;
            set => _CTECLI_NOMBRE = value;
        }

        public string CTECLI_RAZONSOCIAL
        {
            get => _CTECLI_RAZONSOCIAL;
            set => _CTECLI_RAZONSOCIAL = value;
        }
        public string CTECLI_CORREO
        {
            get => _CTECLI_CORREO;
            set => _CTECLI_CORREO = value;
        }
        public string CTECLI_TELEFONO
        {
            get => _CTECLI_TELEFONO;
            set => _CTECLI_TELEFONO = value;
        }
        public string CTECLI_DIRECCION
        {
            get => _CTECLI_DIRECCION;
            set => _CTECLI_DIRECCION = value;
        }
        public string CTECLI_FOTOURL
        {
            get => _CTECLI_FOTOURL;
            set => _CTECLI_FOTOURL = value;
        }
        //Constructor
        public ClientesVo(DataRow dr)
        {
            CTECLI_CODIGO_K = int.Parse(dr["CTECLI_CODIGO_K"].ToString());
            CTECLI_NOMBRE = dr["CTECLI_NOMBRE"].ToString();
            CTECLI_RAZONSOCIAL = dr["CTECLI_RAZONSOCIAL"].ToString();
            CTECLI_CORREO = dr["CTECLI_CORREO"].ToString();
            CTECLI_TELEFONO = dr["CTECLI_TELEFONO"].ToString();
            CTECLI_DIRECCION = dr["CTECLI_DIRECCION"].ToString();
            CTECLI_FOTOURL = dr["CTECLI_FOTOURL"].ToString();
        }

        public ClientesVo()
        {
            CTECLI_CODIGO_K = 0;
            CTECLI_NOMBRE = string.Empty;
            CTECLI_RAZONSOCIAL = string.Empty;
            CTECLI_CORREO = string.Empty;
            CTECLI_TELEFONO = string.Empty;
            CTECLI_DIRECCION = string.Empty;
            CTECLI_FOTOURL = string.Empty;
        }
        #endregion
    }
}
