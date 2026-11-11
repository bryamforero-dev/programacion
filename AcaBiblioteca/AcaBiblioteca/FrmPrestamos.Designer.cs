namespace AcaBiblioteca
{
    partial class FrmPrestamos
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
            this.pnlFormulario = new Panel();
            this.lblUsuario = new Label();
            this.cmbUsuario = new ComboBox();
            this.lblLibro = new Label();
            this.cmbLibro = new ComboBox();
            this.lblFechaPrestamo = new Label();
            this.dtpFechaPrestamo = new DateTimePicker();
            this.lblFechaDevolucion = new Label();
            this.dtpFechaDevolucion = new DateTimePicker();
            this.pnlBotones = new Panel();
            this.btnNuevo = new Button();
            this.btnGuardar = new Button();
            this.btnDevolver = new Button();
            this.btnEliminar = new Button();
            this.btnCancelar = new Button();
            this.dgvPrestamos = new DataGridView();
            this.pnlSuperior.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).BeginInit();
            this.SuspendLayout();

            // pnlSuperior
            this.pnlSuperior.BackColor = Color.FromArgb(41, 128, 185);
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
            this.lblTitulo.Size = new Size(280, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Préstamos";

            // pnlFormulario
            this.pnlFormulario.Controls.Add(this.lblUsuario);
            this.pnlFormulario.Controls.Add(this.cmbUsuario);
            this.pnlFormulario.Controls.Add(this.lblLibro);
            this.pnlFormulario.Controls.Add(this.cmbLibro);
            this.pnlFormulario.Controls.Add(this.lblFechaPrestamo);
            this.pnlFormulario.Controls.Add(this.dtpFechaPrestamo);
            this.pnlFormulario.Controls.Add(this.lblFechaDevolucion);
            this.pnlFormulario.Controls.Add(this.dtpFechaDevolucion);
            this.pnlFormulario.Dock = DockStyle.Top;
            this.pnlFormulario.Location = new Point(0, 55);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Padding = new Padding(20);
            this.pnlFormulario.Size = new Size(1000, 120);
            this.pnlFormulario.TabIndex = 1;

            // lblUsuario
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new Font("Segoe UI", 9.5F);
            this.lblUsuario.Location = new Point(25, 20);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new Size(55, 17);
            this.lblUsuario.Text = "Usuario:";

            // cmbUsuario
            this.cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbUsuario.Font = new Font("Segoe UI", 9.5F);
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new Point(100, 17);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new Size(280, 25);
            this.cmbUsuario.TabIndex = 0;

            // lblLibro
            this.lblLibro.AutoSize = true;
            this.lblLibro.Font = new Font("Segoe UI", 9.5F);
            this.lblLibro.Location = new Point(420, 20);
            this.lblLibro.Name = "lblLibro";
            this.lblLibro.Size = new Size(40, 17);
            this.lblLibro.Text = "Libro:";

            // cmbLibro
            this.cmbLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbLibro.Font = new Font("Segoe UI", 9.5F);
            this.cmbLibro.FormattingEnabled = true;
            this.cmbLibro.Location = new Point(480, 17);
            this.cmbLibro.Name = "cmbLibro";
            this.cmbLibro.Size = new Size(350, 25);
            this.cmbLibro.TabIndex = 1;

            // lblFechaPrestamo
            this.lblFechaPrestamo.AutoSize = true;
            this.lblFechaPrestamo.Font = new Font("Segoe UI", 9.5F);
            this.lblFechaPrestamo.Location = new Point(25, 65);
            this.lblFechaPrestamo.Name = "lblFechaPrestamo";
            this.lblFechaPrestamo.Size = new Size(110, 17);
            this.lblFechaPrestamo.Text = "Fecha Préstamo:";

            // dtpFechaPrestamo
            this.dtpFechaPrestamo.Font = new Font("Segoe UI", 9.5F);
            this.dtpFechaPrestamo.Format = DateTimePickerFormat.Short;
            this.dtpFechaPrestamo.Location = new Point(145, 62);
            this.dtpFechaPrestamo.Name = "dtpFechaPrestamo";
            this.dtpFechaPrestamo.Size = new Size(140, 25);
            this.dtpFechaPrestamo.TabIndex = 2;

            // lblFechaDevolucion
            this.lblFechaDevolucion.AutoSize = true;
            this.lblFechaDevolucion.Font = new Font("Segoe UI", 9.5F);
            this.lblFechaDevolucion.Location = new Point(320, 65);
            this.lblFechaDevolucion.Name = "lblFechaDevolucion";
            this.lblFechaDevolucion.Size = new Size(120, 17);
            this.lblFechaDevolucion.Text = "Fecha Devolución:";

            // dtpFechaDevolucion
            this.dtpFechaDevolucion.Font = new Font("Segoe UI", 9.5F);
            this.dtpFechaDevolucion.Format = DateTimePickerFormat.Short;
            this.dtpFechaDevolucion.Location = new Point(450, 62);
            this.dtpFechaDevolucion.Name = "dtpFechaDevolucion";
            this.dtpFechaDevolucion.Size = new Size(140, 25);
            this.dtpFechaDevolucion.TabIndex = 3;
            this.dtpFechaDevolucion.ShowCheckBox = true;

            // pnlBotones
            this.pnlBotones.Controls.Add(this.btnNuevo);
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Controls.Add(this.btnDevolver);
            this.pnlBotones.Controls.Add(this.btnEliminar);
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Dock = DockStyle.Top;
            this.pnlBotones.Location = new Point(0, 175);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new Size(1000, 55);
            this.pnlBotones.TabIndex = 2;

            // btnNuevo
            this.btnNuevo.BackColor = Color.FromArgb(52, 152, 219);
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = FlatStyle.Flat;
            this.btnNuevo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnNuevo.ForeColor = Color.White;
            this.btnNuevo.Location = new Point(25, 10);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new Size(110, 35);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new EventHandler(this.btnNuevo_Click);

            // btnGuardar
            this.btnGuardar.BackColor = Color.FromArgb(39, 174, 96);
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = FlatStyle.Flat;
            this.btnGuardar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnGuardar.ForeColor = Color.White;
            this.btnGuardar.Location = new Point(150, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(130, 35);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Registrar Préstamo";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new EventHandler(this.btnGuardar_Click);

            // btnDevolver
            this.btnDevolver.BackColor = Color.FromArgb(241, 196, 15);
            this.btnDevolver.FlatAppearance.BorderSize = 0;
            this.btnDevolver.FlatStyle = FlatStyle.Flat;
            this.btnDevolver.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnDevolver.ForeColor = Color.White;
            this.btnDevolver.Location = new Point(300, 10);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new Size(130, 35);
            this.btnDevolver.TabIndex = 2;
            this.btnDevolver.Text = "Registrar Devolución";
            this.btnDevolver.UseVisualStyleBackColor = false;
            this.btnDevolver.Click += new EventHandler(this.btnDevolver_Click);

            // btnEliminar
            this.btnEliminar.BackColor = Color.FromArgb(231, 76, 60);
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = FlatStyle.Flat;
            this.btnEliminar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnEliminar.ForeColor = Color.White;
            this.btnEliminar.Location = new Point(450, 10);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(110, 35);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new EventHandler(this.btnEliminar_Click);

            // btnCancelar
            this.btnCancelar.BackColor = Color.FromArgb(149, 165, 166);
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = FlatStyle.Flat;
            this.btnCancelar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnCancelar.ForeColor = Color.White;
            this.btnCancelar.Location = new Point(580, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(110, 35);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);

            // dgvPrestamos
            this.dgvPrestamos.AllowUserToAddRows = false;
            this.dgvPrestamos.AllowUserToDeleteRows = false;
            this.dgvPrestamos.BackgroundColor = Color.White;
            this.dgvPrestamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrestamos.Dock = DockStyle.Fill;
            this.dgvPrestamos.Location = new Point(0, 230);
            this.dgvPrestamos.MultiSelect = false;
            this.dgvPrestamos.Name = "dgvPrestamos";
            this.dgvPrestamos.ReadOnly = true;
            this.dgvPrestamos.RowHeadersWidth = 25;
            this.dgvPrestamos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrestamos.Size = new Size(1000, 370);
            this.dgvPrestamos.TabIndex = 3;
            this.dgvPrestamos.CellClick += new DataGridViewCellEventHandler(this.dgvPrestamos_CellClick);

            // FrmPrestamos
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(this.dgvPrestamos);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.pnlSuperior);
            this.Name = "FrmPrestamos";
            this.Text = "Gestión de Préstamos";
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlSuperior;
        private Label lblTitulo;
        private Panel pnlFormulario;
        private Label lblUsuario;
        private ComboBox cmbUsuario;
        private Label lblLibro;
        private ComboBox cmbLibro;
        private Label lblFechaPrestamo;
        private DateTimePicker dtpFechaPrestamo;
        private Label lblFechaDevolucion;
        private DateTimePicker dtpFechaDevolucion;
        private Panel pnlBotones;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnDevolver;
        private Button btnEliminar;
        private Button btnCancelar;
        private DataGridView dgvPrestamos;
    }
}
