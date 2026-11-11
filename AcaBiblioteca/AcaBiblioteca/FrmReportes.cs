using AcaBiblioteca.Datos;

namespace AcaBiblioteca
{
    public partial class FrmReportes : Form
    {
        private readonly ReporteDAO _reporteDAO = new ReporteDAO();

        public FrmReportes()
        {
            InitializeComponent();
            ConfigurarFormulario();
            CargarTiposReporte();
        }

        private void ConfigurarFormulario()
        {
            dgvReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReportes.MultiSelect = false;
            dgvReportes.ReadOnly = true;
            dgvReportes.AllowUserToAddRows = false;
            dgvReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarTiposReporte()
        {
            cmbTipoReporte.Items.Clear();
            cmbTipoReporte.Items.Add("Préstamos activos");
            cmbTipoReporte.Items.Add("Préstamos devueltos");
            cmbTipoReporte.Items.Add("Historial de préstamos");
            cmbTipoReporte.Items.Add("Inventario de libros");
            cmbTipoReporte.Items.Add("Usuarios registrados");
            cmbTipoReporte.SelectedIndex = -1;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoReporte.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un tipo de reporte.",
                        "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tipo = cmbTipoReporte.Text;

                switch (tipo)
                {
                    case "Préstamos activos":
                        dgvReportes.DataSource = _reporteDAO.PrestamosActivos();
                        break;

                    case "Préstamos devueltos":
                        dgvReportes.DataSource = _reporteDAO.PrestamosDevueltos();
                        break;

                    case "Historial de préstamos":
                        dgvReportes.DataSource = _reporteDAO.HistorialPrestamos();
                        break;

                    case "Inventario de libros":
                        dgvReportes.DataSource = _reporteDAO.InventarioLibros();
                        break;

                    case "Usuarios registrados":
                        dgvReportes.DataSource = _reporteDAO.UsuariosRegistrados();
                        break;
                }

                lblTotal.Text = $"Total de registros: {dgvReportes.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte:\n" + ex.Message,
                    "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbTipoReporte.SelectedIndex = -1;
            dgvReportes.DataSource = null;
            lblTotal.Text = "Total de registros: 0";
        }
    }
}
