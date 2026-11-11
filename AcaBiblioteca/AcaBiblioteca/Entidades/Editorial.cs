namespace AcaBiblioteca.Entidades
{
    public class Editorial
    {
        public int IdEditorial { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public Editorial() { }

        public Editorial(int idEditorial, string nombre)
        {
            IdEditorial = idEditorial;
            Nombre = nombre;
        }
    }
}
