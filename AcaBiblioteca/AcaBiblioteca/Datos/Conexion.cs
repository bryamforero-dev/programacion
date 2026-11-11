using Microsoft.Data.SqlClient;

namespace AcaBiblioteca.Datos;

/// <summary>Centraliza la configuración de acceso a SQL Server.</summary>
public sealed class Conexion
{
    // Se puede sobrescribir sin recompilar mediante la variable de entorno ACABIBLIOTECA_SQL.
    private readonly string cadenaConexion = Environment.GetEnvironmentVariable("ACABIBLIOTECA_SQL")
        ?? @"Server=.\SQLEXPRESS;Database=AcaBiblioteca;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;";

    public SqlConnection ObtenerConexion() => new(cadenaConexion);

    public void ProbarConexion()
    {
        using var cn = ObtenerConexion();
        cn.Open();
    }
}
