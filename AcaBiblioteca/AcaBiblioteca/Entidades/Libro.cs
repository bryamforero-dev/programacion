namespace AcaBiblioteca.Entidades
{
    public class Libro
    {
        public string ISBN { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public int IdAutor { get; set; }
        public int IdEditorial { get; set; }
        public string? Categoria { get; set; }
        public int? Anio { get; set; }
        public int Existencias { get; set; }

        // Propiedades de navegación (útiles para reportes y combos)
        public string? NombreAutor { get; set; }
        public string? NombreEditorial { get; set; }

        public Libro() { }

        public Libro(string isbn, string titulo, int idAutor, int idEditorial, int existencias)
        {
            ISBN = isbn;
            Titulo = titulo;
            IdAutor = idAutor;
            IdEditorial = idEditorial;
            Existencias = existencias;
        }
    }
}
