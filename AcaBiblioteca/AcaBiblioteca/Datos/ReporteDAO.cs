using System.Data;
using Microsoft.Data.SqlClient;

namespace AcaBiblioteca.Datos
{
    /// <summary>
    /// Capa de acceso a datos para reportes consolidados.
    /// </summary>
    public class ReporteDAO
    {
        private readonly Conexion _conexion = new Conexion();

        public DataTable PrestamosActivos()
        {
            return Ejecutar(@"
                SELECT
                    p.IdPrestamo,
                    u.Nombre + ' ' + u.Apellido AS Usuario,
                    l.ISBN,
                    l.Titulo AS Libro,
                    p.FechaPrestamo,
                    p.Estado
                FROM Prestamos p
                INNER JOIN Usuarios u ON p.IdUsuario = u.IdUsuario
                INNER JOIN Libros l ON p.ISBN = l.ISBN
                WHERE p.Estado = 'Prestado'
                ORDER BY p.FechaPrestamo DESC");
        }

        public DataTable PrestamosDevueltos()
        {
            return Ejecutar(@"
                SELECT
                    p.IdPrestamo,
                    u.Nombre + ' ' + u.Apellido AS Usuario,
                    l.ISBN,
                    l.Titulo AS Libro,
                    p.FechaPrestamo,
                    p.FechaDevolucion,
                    p.Estado
                FROM Prestamos p
                INNER JOIN Usuarios u ON p.IdUsuario = u.IdUsuario
                INNER JOIN Libros l ON p.ISBN = l.ISBN
                WHERE p.Estado = 'Devuelto'
                ORDER BY p.FechaDevolucion DESC");
        }

        public DataTable InventarioLibros()
        {
            return Ejecutar(@"
                SELECT
                    l.ISBN,
                    l.Titulo,
                    a.Nombre + ' ' + a.Apellido AS Autor,
                    e.Nombre AS Editorial,
                    l.Categoria,
                    l.Anio,
                    l.Existencias
                FROM Libros l
                INNER JOIN Autores a ON l.IdAutor = a.IdAutor
                INNER JOIN Editoriales e ON l.IdEditorial = e.IdEditorial
                ORDER BY l.Titulo");
        }

        public DataTable HistorialPrestamos()
        {
            return Ejecutar(@"
                SELECT
                    p.IdPrestamo,
                    u.Nombre + ' ' + u.Apellido AS Usuario,
                    l.ISBN,
                    l.Titulo AS Libro,
                    p.FechaPrestamo,
                    p.FechaDevolucion,
                    p.Estado
                FROM Prestamos p
                INNER JOIN Usuarios u ON p.IdUsuario = u.IdUsuario
                INNER JOIN Libros l ON p.ISBN = l.ISBN
                ORDER BY p.FechaPrestamo DESC");
        }

        public DataTable UsuariosRegistrados()
        {
            return Ejecutar(@"
                SELECT IdUsuario, Nombre, Apellido, Documento, Telefono, Correo
                FROM Usuarios
                ORDER BY Apellido, Nombre");
        }

        private DataTable Ejecutar(string sql)
        {
            using var cn = _conexion.ObtenerConexion();
            cn.Open();
            using var da = new SqlDataAdapter(sql, cn);
            var tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }
    }
}
