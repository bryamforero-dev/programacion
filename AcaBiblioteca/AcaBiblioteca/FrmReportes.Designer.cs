namespace AcaBiblioteca
{
    partial class FrmReportes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlSuperior = new Panel();
            this.lblTitulo = new Label();
            this.pnlControles = new Panel();
            this.lblTipo = new Label();
            this.cmbTipoReporte = new ComboBox();
            this.btnGenerar = new Button();
            this.btnLimpiar = new Button();
            this.lblTotal = new Label();
            this.dgvReportes = new DataGridView();
            this.pnlSuperior.SuspendLayout();
            this.pnlControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.SuspendLayout();

            // pnlSuperior
            this.pnlSuperior.BackColor = Color.FromArgb(142, 68, 173);
            this.pnlSuperior.Controls.Add(this.lblTitulo);
            this.pnlSuperior.Dock = DockStyle.Top;
            this.pnlSuperior.Location = new Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new Size(1000, 55);
            this.pnlSuperior.TabIndex = 0;

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Location = new Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(220, 30);
            this.lblTitulo.Text = "Reportes de Biblioteca";

            // pnlControles
            this.pnlControles.Controls.Add(this.lblTipo);
            this.pnlControles.Controls.Add(this.cmbTipoReporte);
            this.pnlControles.Controls.Add(this.btnGenerar);
            this.pnlControles.Controls.Add(this.btnLimpiar);
            this.pnlControles.Controls.Add(this.lblTotal);
            this.pnlControles.Dock = DockStyle.Top;
            this.pnlControles.Location = new Point(0, 55);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new Size(1000, 70);
            this.pnlControles.TabIndex = 1;

            // lblTipo
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new Font("Segoe UI", 10F);
            this.lblTipo.Location = new Point(25, 25);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new Size(100, 19);
            this.lblTipo.Text = "Tipo de reporte:";

            // cmbTipoReporte
            this.cmbTipoReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTipoReporte.Font = new Font("Segoe UI", 10F);
            this.cmbTipoReporte.FormattingEnabled = true;
            this.cmbTipoReporte.Location = new Point(140, 22);
            this.cmbTipoReporte.Name = "cmbTipoReporte";
            this.cmbTipoReporte.Size = new Size(250, 25);
            this.cmbTipoReporte.TabIndex = 0;

            // btnGenerar
            this.btnGenerar.BackColor = Color.FromArgb(142, 68, 173);
            this.btnGenerar.FlatAppearance.BorderSize = 0;
            this.btnGenerar.FlatStyle = FlatStyle.Flat;
            this.btnGenerar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnGenerar.ForeColor = Color.White;
            this.btnGenerar.Location = new Point(420, 18);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new Size(130, 35);
            this.btnGenerar.TabIndex = 1;
            this.btnGenerar.Text = "Generar Reporte";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new EventHandler(this.btnGenerar_Click);

            // btnLimpiar
            this.btnLimpiar.BackColor = Color.FromArgb(149, 165, 166);
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = FlatStyle.Flat;
            this.btnLimpiar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnLimpiar.ForeColor = Color.White;
            this.btnLimpiar.Location = new Point(570, 18);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new Size(110, 35);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new EventHandler(this.btnLimpiar_Click);

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTotal.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblTotal.Location = new Point(720, 25);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new Size(140, 19);
            this.lblTotal.Text = "Total de registros: 0";

            // dgvReportes
            this.dgvReportes.AllowUserToAddRows = false;
            this.dgvReportes.AllowUserToDeleteRows = false;
            this.dgvReportes.BackgroundColor = Color.White;
            this.dgvReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Dock = DockStyle.Fill;
            this.dgvReportes.Location = new Point(0, 125);
            this.dgvReportes.MultiSelect = false;
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.ReadOnly = true;
            this.dgvReportes.RowHeadersWidth = 25;
            this.dgvReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvReportes.Size = new Size(1000, 475);
            this.dgvReportes.TabIndex = 2;

            // FrmReportes
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(this.dgvReportes);
            this.Controls.Add(this.pnlControles);
            this.Controls.Add(this.pnlSuperior);
            this.Name = "FrmReportes";
            this.Text = "Reportes";
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlSuperior;
        private Label lblTitulo;
        private Panel pnlControles;
        private Label lblTipo;
        private ComboBox cmbTipoReporte;
        private Button btnGenerar;
        private Button btnLimpiar;
        private Label lblTotal;
        private DataGridView dgvReportes;
    }
}
