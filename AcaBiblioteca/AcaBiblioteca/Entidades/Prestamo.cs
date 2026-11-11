namespace AcaBiblioteca.Entidades
{
    public class Prestamo
    {
        public int IdPrestamo { get; set; }
        public int IdUsuario { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string Estado { get; set; } = "Prestado";

        // Propiedades de navegación
        public string? NombreUsuario { get; set; }
        public string? TituloLibro { get; set; }

        public Prestamo() { }

        public Prestamo(int idUsuario, string isbn, DateTime fechaPrestamo)
        {
            IdUsuario = idUsuario;
            ISBN = isbn;
            FechaPrestamo = fechaPrestamo;
            Estado = "Prestado";
        }
    }
}
