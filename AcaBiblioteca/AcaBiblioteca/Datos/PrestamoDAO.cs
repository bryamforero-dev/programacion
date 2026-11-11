using System.Data;
using Microsoft.Data.SqlClient;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Datos
{
    /// <summary>
    /// Capa de acceso a datos para la entidad Prestamo.
    /// </summary>
    public class PrestamoDAO
    {
        private readonly Conexion _conexion = new Conexion();

        public DataTable ListarTodos()
        {
            using var cn = _conexion.ObtenerConexion();
            cn.Open();

            string sql = @"
                SELECT 
                    p.IdPrestamo,
                    p.IdUsuario,
                    u.Nombre + ' ' + u.Apellido AS Usuario,
                    p.ISBN,
                    l.Titulo AS Libro,
                    p.FechaPrestamo,
                    p.FechaDevolucion,
                    p.Estado
                FROM Prestamos p
                INNER JOIN Usuarios u ON p.IdUsuario = u.IdUsuario
                INNER JOIN Libros l ON p.ISBN = l.ISBN
                ORDER BY p.IdPrestamo DESC";

            using var da = new SqlDataAdapter(sql, cn);
            var tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public void Insertar(Prestamo prestamo)
        {
            using var cn = _conexion.ObtenerConexion();
            cn.Open();

            using var transaction = cn.BeginTransaction();
            try
            {
                // 1. Insertar préstamo
                string sqlInsert = @"
                    INSERT INTO Prestamos (IdUsuario, ISBN, FechaPrestamo, FechaDevolucion, Estado)
                    VALUES (@IdUsuario, @ISBN, @FechaPrestamo, NULL, 'Prestado')";

                using (var cmd = new SqlCommand(sqlInsert, cn, transaction))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", prestamo.IdUsuario);
                    cmd.Parameters.AddWithValue("@ISBN", prestamo.ISBN);
                    cmd.Parameters.AddWithValue("@FechaPrestamo", prestamo.FechaPrestamo);
                    cmd.ExecuteNonQuery();
                }

                // 2. Disminuir existencias
                string sqlUpdate = "UPDATE Libros SET Existencias = Existencias - 1 WHERE ISBN = @ISBN AND Existencias > 0";
                using (var cmd = new SqlCommand(sqlUpdate, cn, transaction))
                {
                    cmd.Parameters.AddWithValue("@ISBN", prestamo.ISBN);
                    int filas = cmd.ExecuteNonQuery();
                    if (filas == 0)
                        throw new InvalidOperationException("No hay existencias disponibles para este libro.");
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void RegistrarDevolucion(int idPrestamo, string isbn, DateTime fechaDevolucion)
        {
            using var cn = _conexion.ObtenerConexion();
            cn.Open();

            using var transaction = cn.BeginTransaction();
            try
            {
                // 1. Actualizar préstamo
                string sqlUpdatePrestamo = @"
                    UPDATE Prestamos
                    SET FechaDevolucion = @FechaDevolucion,
                        Estado = 'Devuelto'
                    WHERE IdPrestamo = @IdPrestamo AND Estado = 'Prestado'";

                using (var cmd = new SqlCommand(sqlUpdatePrestamo, cn, transaction))
                {
                    cmd.Parameters.AddWithValue("@FechaDevolucion", fechaDevolucion);
                    cmd.Parameters.AddWithValue("@IdPrestamo", idPrestamo);
                    int filas = cmd.ExecuteNonQuery();
                    if (filas == 0)
                        throw new InvalidOperationException("El préstamo no existe o ya fue devuelto.");
                }

                // 2. Aumentar existencias
                string sqlUpdateLibro = "UPDATE Libros SET Existencias = Existencias + 1 WHERE ISBN = @ISBN";
                using (var cmd = new SqlCommand(sqlUpdateLibro, cn, transaction))
                {
                    cmd.Parameters.AddWithValue("@ISBN", isbn);
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Eliminar(int idPrestamo)
        {
            using var cn = _conexion.ObtenerConexion();
            cn.Open();

            // Solo se permite eliminar si está Devuelto (regla de integridad)
            string sql = "DELETE FROM Prestamos WHERE IdPrestamo = @IdPrestamo AND Estado = 'Devuelto'";
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@IdPrestamo", idPrestamo);
            int filas = cmd.ExecuteNonQuery();

            if (filas == 0)
                throw new InvalidOperationException("Solo se pueden eliminar préstamos que ya estén devueltos.");
        }

        public int ObtenerExistencias(string isbn)
        {
            using var cn = _conexion.ObtenerConexion();
            cn.Open();

            string sql = "SELECT Existencias FROM Libros WHERE ISBN = @ISBN";
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@ISBN", isbn);
            object? resultado = cmd.ExecuteScalar();
            return resultado != null ? Convert.ToInt32(resultado) : 0;
        }
    }
}
