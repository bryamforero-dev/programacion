using System.Data;
using Microsoft.Data.SqlClient;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca
{
    public partial class FrmPrestamos : Form
    {
        private readonly PrestamoDAO _prestamoDAO = new PrestamoDAO();
        private int? _idPrestamoSeleccionado = null;
        private string? _isbnSeleccionado = null;

        public FrmPrestamos()
        {
            InitializeComponent();
            ConfigurarFormulario();
            CargarDatosIniciales();
        }

        private void ConfigurarFormulario()
        {
            // Configuración del DateTimePicker de devolución
            dtpFechaDevolucion.ShowCheckBox = true;
            dtpFechaDevolucion.Checked = false;
            dtpFechaPrestamo.Value = DateTime.Today;

            // Estilo del DataGridView
            dgvPrestamos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrestamos.MultiSelect = false;
            dgvPrestamos.ReadOnly = true;
            dgvPrestamos.AllowUserToAddRows = false;
            dgvPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDatosIniciales()
        {
            CargarPrestamos();
            CargarUsuarios();
            CargarLibros();
            LimpiarCampos();
        }

        #region Carga de datos

        private void CargarPrestamos()
        {
            try
            {
                dgvPrestamos.DataSource = _prestamoDAO.ListarTodos();

                // Ocultar columnas técnicas si existen
                if (dgvPrestamos.Columns.Contains("IdUsuario"))
                    dgvPrestamos.Columns["IdUsuario"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los préstamos:\n" + ex.Message,
                    "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                Conexion conexion = new Conexion();
                using var cn = conexion.ObtenerConexion();
                cn.Open();

                string sql = "SELECT IdUsuario, Nombre, Apellido FROM Usuarios ORDER BY Nombre, Apellido";
                using var da = new SqlDataAdapter(sql, cn);
                var tabla = new DataTable();
                da.Fill(tabla);

                tabla.Columns.Add("NombreCompleto", typeof(string));
                foreach (DataRow fila in tabla.Rows)
                    fila["NombreCompleto"] = $"{fila["Nombre"]} {fila["Apellido"]}";

                cmbUsuario.DataSource = tabla;
                cmbUsuario.DisplayMember = "NombreCompleto";
                cmbUsuario.ValueMember = "IdUsuario";
                cmbUsuario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios:\n" + ex.Message,
                    "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarLibros()
        {
            try
            {
                Conexion conexion = new Conexion();
                using var cn = conexion.ObtenerConexion();
                cn.Open();

                // Solo libros con existencias disponibles
                string sql = "SELECT ISBN, Titulo, Existencias FROM Libros WHERE Existencias > 0 ORDER BY Titulo";
                using var da = new SqlDataAdapter(sql, cn);
                var tabla = new DataTable();
                da.Fill(tabla);

                cmbLibro.DataSource = tabla;
                cmbLibro.DisplayMember = "Titulo";
                cmbLibro.ValueMember = "ISBN";
                cmbLibro.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los libros:\n" + ex.Message,
                    "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos de botones

        private void btnNuevo_Click(object? sender, EventArgs e)
        {
            LimpiarCampos();
            cmbUsuario.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (cmbUsuario.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un usuario.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbUsuario.Focus();
                    return;
                }

                if (cmbLibro.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un libro.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbLibro.Focus();
                    return;
                }

                string isbn = cmbLibro.SelectedValue!.ToString()!;
                int existencias = _prestamoDAO.ObtenerExistencias(isbn);

                if (existencias <= 0)
                {
                    MessageBox.Show("El libro seleccionado no tiene existencias disponibles.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var prestamo = new Prestamo
                {
                    IdUsuario = Convert.ToInt32(cmbUsuario.SelectedValue),
                    ISBN = isbn,
                    FechaPrestamo = dtpFechaPrestamo.Value.Date
                };

                _prestamoDAO.Insertar(prestamo);

                MessageBox.Show("Préstamo registrado correctamente.", "Biblioteca",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarPrestamos();
                CargarLibros(); // Actualizar existencias en el combo
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el préstamo:\n" + ex.Message,
                    "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idPrestamoSeleccionado == null || string.IsNullOrEmpty(_isbnSeleccionado))
                {
                    MessageBox.Show("Seleccione un préstamo de la lista para registrar la devolución.",
                        "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar que el préstamo esté en estado Prestado
                DataGridViewRow? fila = dgvPrestamos.CurrentRow;
                if (fila == null) return;

                string estado = fila.Cells["Estado"].Value?.ToString() ?? "";
                if (estado != "Prestado")
                {
                    MessageBox.Show("Solo se pueden devolver préstamos que estén en estado 'Prestado'.",
                        "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fechaDevolucion = dtpFechaDevolucion.Checked
                    ? dtpFechaDevolucion.Value.Date
                    : DateTime.Today;

                if (fechaDevolucion < dtpFechaPrestamo.Value.Date)
                {
                    MessageBox.Show("La fecha de devolución no puede ser anterior a la fecha de préstamo.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de registrar la devolución de este libro?",
                    "Confirmar devolución",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes) return;

                _prestamoDAO.RegistrarDevolucion(
                    _idPrestamoSeleccionado.Value,
                    _isbnSeleccionado,
                    fechaDevolucion);

                MessageBox.Show("Devolución registrada correctamente.", "Biblioteca",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarPrestamos();
                CargarLibros();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la devolución:\n" + ex.Message,
                    "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idPrestamoSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un préstamo de la lista.",
                        "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de eliminar este registro de préstamo?\n(Solo se pueden eliminar préstamos ya devueltos)",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes) return;

                _prestamoDAO.Eliminar(_idPrestamoSeleccionado.Value);

                MessageBox.Show("Préstamo eliminado correctamente.", "Biblioteca",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarPrestamos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar:\n" + ex.Message,
                    "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        #endregion

        #region Eventos del DataGridView

        private void dgvPrestamos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvPrestamos.Rows[e.RowIndex];

            _idPrestamoSeleccionado = Convert.ToInt32(fila.Cells["IdPrestamo"].Value);
            _isbnSeleccionado = fila.Cells["ISBN"].Value?.ToString();

            // Cargar datos en los controles
            if (fila.Cells["IdUsuario"].Value != null)
                cmbUsuario.SelectedValue = fila.Cells["IdUsuario"].Value;

            if (!string.IsNullOrEmpty(_isbnSeleccionado))
                cmbLibro.SelectedValue = _isbnSeleccionado;

            if (fila.Cells["FechaPrestamo"].Value != DBNull.Value)
                dtpFechaPrestamo.Value = Convert.ToDateTime(fila.Cells["FechaPrestamo"].Value);

            if (fila.Cells["FechaDevolucion"].Value != DBNull.Value &&
                fila.Cells["FechaDevolucion"].Value != null)
            {
                dtpFechaDevolucion.Value = Convert.ToDateTime(fila.Cells["FechaDevolucion"].Value);
                dtpFechaDevolucion.Checked = true;
            }
            else
            {
                dtpFechaDevolucion.Checked = false;
            }
        }

        #endregion

        private void LimpiarCampos()
        {
            _idPrestamoSeleccionado = null;
            _isbnSeleccionado = null;

            cmbUsuario.SelectedIndex = -1;
            cmbLibro.SelectedIndex = -1;
            dtpFechaPrestamo.Value = DateTime.Today;
            dtpFechaDevolucion.Value = DateTime.Today;
            dtpFechaDevolucion.Checked = false;

            dgvPrestamos.ClearSelection();
        }
    }
}
