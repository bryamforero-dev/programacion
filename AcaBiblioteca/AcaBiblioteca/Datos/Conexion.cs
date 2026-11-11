using Microsoft.Data.SqlClient;

namespace AcaBiblioteca.Datos
{
    /// <summary>
    /// Clase responsable de proporcionar conexiones a SQL Server.
    /// </summary>
    public class Conexion
    {
        // Cadena de conexión unificada (Base de datos: AcaBiblioteca)
        // Ajusta el Server según tu instancia (.\SQLEXPRESS, .\SQL2022, localhost, etc.)
        private readonly string cadenaConexion =
            "Server=.\\SQL2022;Database=AcaBiblioteca;Integrated Security=true;TrustServerCertificate=true;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
