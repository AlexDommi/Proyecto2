namespace CapaDatos
{
    public class Configuracion
    {

        private static readonly string _CadenaDeConexion = @"Data Source=DESKTOP-IHO4E8H; Initial Catalog=TiendaOnline; Integrated Security=True";

        public static string ObtenerConexion
        {
            get
            {
                return _CadenaDeConexion;
            }
        }

    }
}
