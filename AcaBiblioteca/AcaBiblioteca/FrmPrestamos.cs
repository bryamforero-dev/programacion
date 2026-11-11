using AcaBiblioteca.Datos;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AcaBiblioteca;

public partial class FrmPrestamos : Form
{
    private readonly ComboBox cmbUsuario = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 260 };
    private readonly ComboBox cmbLibro = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 360 };
    private readonly DateTimePicker dtpFecha = new() { Format = DateTimePickerFormat.Short, Width = 130, Value = DateTime.Today };
    private readonly DataGridView dgv = new();
    private readonly Conexion conexion = new();

    public FrmPrestamos()
    {
        InitializeComponent();
        ConstruirInterfaz();
        Load += (_, _) => { CargarCombos(); CargarPrestamos(); };
    }

    private void ConstruirInterfaz()
    {
        Text = "Gestión de préstamos"; BackColor = Color.White; Padding = new Padding(16);
        var titulo = new Label { Text = "PRÉSTAMOS Y DEVOLUCIONES", Dock = DockStyle.Top, Height = 42,
            Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = Color.FromArgb(35,57,85) };
        var filtros = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 92, WrapContents = true, Padding = new Padding(0,8,0,8) };
        filtros.Controls.Add(UiHelper.Etiqueta("Usuario:")); filtros.Controls.Add(cmbUsuario);
        filtros.Controls.Add(UiHelper.Etiqueta("Libro disponible:")); filtros.Controls.Add(cmbLibro);
        filtros.Controls.Add(UiHelper.Etiqueta("Fecha:")); filtros.Controls.Add(dtpFecha);
        var acciones = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 48 };
        var btnPrestar = UiHelper.Boton("Registrar préstamo"); btnPrestar.Click += (_, _) => RegistrarPrestamo();
        var btnDevolver = UiHelper.Boton("Registrar devolución"); btnDevolver.Click += (_, _) => RegistrarDevolucion();
        var btnActualizar = UiHelper.Boton("Actualizar lista"); btnActualizar.Click += (_, _) => { CargarCombos(); CargarPrestamos(); };
        acciones.Controls.AddRange(new Control[] { btnPrestar, btnDevolver, btnActualizar });
        UiHelper.EstilizarGrid(dgv);
        Controls.Add(dgv); Controls.Add(acciones); Controls.Add(filtros); Controls.Add(titulo);
    }

    private void CargarCombos()
    {
        try
        {
            using var cn = conexion.ObtenerConexion(); cn.Open();
            using (var da = new SqlDataAdapter("SELECT IdUsuario, CONCAT(Nombre,' ',Apellido,' - ',Documento) AS NombreCompleto FROM Usuarios ORDER BY Nombre,Apellido", cn))
            { var dt = new DataTable(); da.Fill(dt); cmbUsuario.DataSource = dt; cmbUsuario.DisplayMember = "NombreCompleto"; cmbUsuario.ValueMember = "IdUsuario"; }
            using (var da = new SqlDataAdapter("SELECT ISBN, CONCAT(Titulo,' (',ISBN,') - disponibles: ',Existencias) AS Descripcion FROM Libros WHERE Existencias > 0 ORDER BY Titulo", cn))
            { var dt = new DataTable(); da.Fill(dt); cmbLibro.DataSource = dt; cmbLibro.DisplayMember = "Descripcion"; cmbLibro.ValueMember = "ISBN"; }
        }
        catch (Exception ex) { Error("No fue posible cargar usuarios y libros.", ex); }
    }

    private void CargarPrestamos()
    {
        try
        {
            using var cn = conexion.ObtenerConexion();
            const string sql = @"SELECT p.IdPrestamo, CONCAT(u.Nombre,' ',u.Apellido) AS Usuario, p.ISBN, l.Titulo AS Libro,
                p.FechaPrestamo, p.FechaDevolucion, p.Estado FROM Prestamos p
                INNER JOIN Usuarios u ON u.IdUsuario=p.IdUsuario INNER JOIN Libros l ON l.ISBN=p.ISBN
                ORDER BY CASE WHEN p.Estado='Prestado' THEN 0 ELSE 1 END, p.FechaPrestamo DESC";
            using var da = new SqlDataAdapter(sql, cn); var dt = new DataTable(); da.Fill(dt); dgv.DataSource = dt;
            if (dgv.Columns.Contains("IdPrestamo")) dgv.Columns["IdPrestamo"].HeaderText = "N.º préstamo";
            if (dgv.Columns.Contains("FechaPrestamo")) dgv.Columns["FechaPrestamo"].HeaderText = "Fecha préstamo";
            if (dgv.Columns.Contains("FechaDevolucion")) dgv.Columns["FechaDevolucion"].HeaderText = "Fecha devolución";
        }
        catch (Exception ex) { Error("No fue posible consultar los préstamos.", ex); }
    }

    private void RegistrarPrestamo()
    {
        if (cmbUsuario.SelectedValue == null || cmbLibro.SelectedValue == null)
        { MessageBox.Show("Debe seleccionar un usuario y un libro con existencias.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        using var cn = conexion.ObtenerConexion(); cn.Open(); using var tx = cn.BeginTransaction();
        try
        {
            using var descontar = new SqlCommand("UPDATE Libros SET Existencias=Existencias-1 WHERE ISBN=@ISBN AND Existencias>0", cn, tx);
            descontar.Parameters.Add("@ISBN", SqlDbType.VarChar, 20).Value = cmbLibro.SelectedValue.ToString();
            if (descontar.ExecuteNonQuery() != 1) throw new InvalidOperationException("El libro ya no tiene existencias disponibles.");
            using var insertar = new SqlCommand("INSERT INTO Prestamos(IdUsuario,ISBN,FechaPrestamo,Estado) VALUES(@Usuario,@ISBN,@Fecha,'Prestado')", cn, tx);
            insertar.Parameters.Add("@Usuario", SqlDbType.Int).Value = Convert.ToInt32(cmbUsuario.SelectedValue);
            insertar.Parameters.Add("@ISBN", SqlDbType.VarChar, 20).Value = cmbLibro.SelectedValue.ToString();
            insertar.Parameters.Add("@Fecha", SqlDbType.Date).Value = dtpFecha.Value.Date;
            insertar.ExecuteNonQuery(); tx.Commit();
            MessageBox.Show("Préstamo registrado. Las existencias se actualizaron correctamente.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarCombos(); CargarPrestamos();
        }
        catch (Exception ex) { tx.Rollback(); Error("No se pudo registrar el préstamo.", ex); }
    }

    private void RegistrarDevolucion()
    {
        if (dgv.CurrentRow == null || dgv.CurrentRow.Cells["IdPrestamo"].Value == DBNull.Value)
        { MessageBox.Show("Seleccione un préstamo activo en la tabla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        if (!string.Equals(Convert.ToString(dgv.CurrentRow.Cells["Estado"].Value), "Prestado", StringComparison.OrdinalIgnoreCase))
        { MessageBox.Show("El préstamo seleccionado ya fue devuelto.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        int id = Convert.ToInt32(dgv.CurrentRow.Cells["IdPrestamo"].Value);
        string isbn = Convert.ToString(dgv.CurrentRow.Cells["ISBN"].Value)!;
        using var cn = conexion.ObtenerConexion(); cn.Open(); using var tx = cn.BeginTransaction();
        try
        {
            using var actualizar = new SqlCommand("UPDATE Prestamos SET FechaDevolucion=@Fecha,Estado='Devuelto' WHERE IdPrestamo=@Id AND Estado='Prestado'", cn, tx);
            actualizar.Parameters.Add("@Fecha", SqlDbType.Date).Value = DateTime.Today; actualizar.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            if (actualizar.ExecuteNonQuery() != 1) throw new InvalidOperationException("El préstamo cambió o ya fue devuelto.");
            using var reponer = new SqlCommand("UPDATE Libros SET Existencias=Existencias+1 WHERE ISBN=@ISBN", cn, tx);
            reponer.Parameters.Add("@ISBN", SqlDbType.VarChar, 20).Value = isbn; reponer.ExecuteNonQuery();
            tx.Commit(); MessageBox.Show("Devolución registrada y existencias repuestas.", "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarCombos(); CargarPrestamos();
        }
        catch (Exception ex) { tx.Rollback(); Error("No se pudo registrar la devolución.", ex); }
    }

    private static void Error(string mensaje, Exception ex) => MessageBox.Show(mensaje + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
