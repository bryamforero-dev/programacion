using AcaBiblioteca.Datos;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AcaBiblioteca;

public partial class FrmReportes : Form
{
    private readonly Conexion conexion = new();
    private readonly DataGridView dgv = new();
    private readonly ComboBox cmbReporte = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 260 };
    public FrmReportes()
    {
        InitializeComponent(); ConstruirInterfaz();
        Load += (_, _) => { cmbReporte.SelectedIndex = 0; CargarReporte(); };
    }
    private void ConstruirInterfaz()
    {
        BackColor = Color.White; Padding = new Padding(16);
        var titulo = new Label { Text = "REPORTES DE BIBLIOTECA", Dock = DockStyle.Top, Height = 42, Font = new Font("Segoe UI",16,FontStyle.Bold), ForeColor=Color.FromArgb(35,57,85) };
        var barra = new FlowLayoutPanel { Dock=DockStyle.Top, Height=55, Padding=new Padding(0,8,0,8) };
        cmbReporte.Items.AddRange(new object[] { "Listado de libros", "Listado de usuarios", "Listado de autores y editoriales", "Préstamos activos", "Préstamos devueltos", "Historial completo", "Resumen de existencias" });
        var btn = UiHelper.Boton("Generar reporte"); btn.Click += (_,_) => CargarReporte(); barra.Controls.Add(UiHelper.Etiqueta("Tipo de reporte:")); barra.Controls.Add(cmbReporte); barra.Controls.Add(btn);
        UiHelper.EstilizarGrid(dgv); Controls.Add(dgv); Controls.Add(barra); Controls.Add(titulo);
    }
    private void CargarReporte()
    {
        if (cmbReporte.SelectedIndex < 0) return;
        string sql = cmbReporte.SelectedIndex switch
        {
            0 => "SELECT l.ISBN,l.Titulo,a.Nombre+' '+a.Apellido AS Autor,e.Nombre AS Editorial,l.Categoria,l.Anio,l.Existencias FROM Libros l INNER JOIN Autores a ON a.IdAutor=l.IdAutor INNER JOIN Editoriales e ON e.IdEditorial=l.IdEditorial ORDER BY l.Titulo",
            1 => "SELECT IdUsuario,Nombre,Apellido,Documento,Telefono,Correo FROM Usuarios ORDER BY Apellido,Nombre",
            2 => "SELECT a.IdAutor,a.Nombre,a.Apellido,e.IdEditorial,e.Nombre AS Editorial FROM Autores a CROSS JOIN Editoriales e ORDER BY a.Apellido,e.Nombre",
            3 => "SELECT p.IdPrestamo,u.Documento,CONCAT(u.Nombre,' ',u.Apellido) AS Usuario,l.ISBN,l.Titulo,p.FechaPrestamo,p.Estado FROM Prestamos p JOIN Usuarios u ON u.IdUsuario=p.IdUsuario JOIN Libros l ON l.ISBN=p.ISBN WHERE p.Estado='Prestado' ORDER BY p.FechaPrestamo",
            4 => "SELECT p.IdPrestamo,u.Documento,CONCAT(u.Nombre,' ',u.Apellido) AS Usuario,l.ISBN,l.Titulo,p.FechaPrestamo,p.FechaDevolucion,p.Estado FROM Prestamos p JOIN Usuarios u ON u.IdUsuario=p.IdUsuario JOIN Libros l ON l.ISBN=p.ISBN WHERE p.Estado='Devuelto' ORDER BY p.FechaDevolucion DESC",
            5 => "SELECT p.IdPrestamo,CONCAT(u.Nombre,' ',u.Apellido) AS Usuario,l.Titulo,p.FechaPrestamo,p.FechaDevolucion,p.Estado FROM Prestamos p JOIN Usuarios u ON u.IdUsuario=p.IdUsuario JOIN Libros l ON l.ISBN=p.ISBN ORDER BY p.FechaPrestamo DESC",
            _ => "SELECT ISBN,Titulo,Existencias,CASE WHEN Existencias>0 THEN 'Disponible' ELSE 'Agotado' END AS Disponibilidad FROM Libros ORDER BY Titulo"
        };
        try { using var cn=conexion.ObtenerConexion(); using var da=new SqlDataAdapter(sql,cn); var dt=new DataTable(); da.Fill(dt); dgv.DataSource=dt; }
        catch(Exception ex) { MessageBox.Show("No fue posible generar el reporte.\n"+ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error); }
    }
}
