namespace AcaBiblioteca.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? Correo { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellido}";

        public Usuario() { }

        public Usuario(int idUsuario, string nombre, string apellido, string documento)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Apellido = apellido;
            Documento = documento;
        }
    }
}
