namespace AcaBiblioteca
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PnlMenu = new Panel();
            PnlLogo = new Panel();
            piclogo = new PictureBox();
            LblsubTitulo = new Label();
            label1 = new Label();
            PnlSuperior = new Panel();
            PnlEstado = new Panel();
            PnlContenido = new Panel();
            btninicio = new FontAwesome.Sharp.IconButton();
            btnlibros = new FontAwesome.Sharp.IconButton();
            btnusuarios = new FontAwesome.Sharp.IconButton();
            PnlMenu.SuspendLayout();
            PnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)piclogo).BeginInit();
            SuspendLayout();
            // 
            // PnlMenu
            // 
            PnlMenu.BackColor = SystemColors.Highlight;
            PnlMenu.Controls.Add(btnusuarios);
            PnlMenu.Controls.Add(btnlibros);
            PnlMenu.Controls.Add(btninicio);
            PnlMenu.Controls.Add(PnlLogo);
            PnlMenu.Dock = DockStyle.Left;
            PnlMenu.Enabled = false;
            PnlMenu.ForeColor = SystemColors.ControlDarkDark;
            PnlMenu.Location = new Point(0, 0);
            PnlMenu.Name = "PnlMenu";
            PnlMenu.Size = new Size(220, 450);
            PnlMenu.TabIndex = 0;
            // 
            // PnlLogo
            // 
            PnlLogo.BackColor = SystemColors.ActiveCaption;
            PnlLogo.Controls.Add(piclogo);
            PnlLogo.Controls.Add(LblsubTitulo);
            PnlLogo.Controls.Add(label1);
            PnlLogo.Dock = DockStyle.Top;
            PnlLogo.Location = new Point(0, 0);
            PnlLogo.Name = "PnlLogo";
            PnlLogo.Size = new Size(220, 80);
            PnlLogo.TabIndex = 0;
            // 
            // piclogo
            // 
            piclogo.BackColor = Color.Transparent;
            piclogo.Image = Properties.Resources.images;
            piclogo.Location = new Point(0, 3);
            piclogo.Name = "piclogo";
            piclogo.Size = new Size(83, 65);
            piclogo.SizeMode = PictureBoxSizeMode.Zoom;
            piclogo.TabIndex = 2;
            piclogo.TabStop = false;
            // 
            // LblsubTitulo
            // 
            LblsubTitulo.AccessibleName = "LblsubTitulo";
            LblsubTitulo.AutoSize = true;
            LblsubTitulo.BackColor = Color.Transparent;
            LblsubTitulo.Font = new Font("Corbel", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblsubTitulo.ForeColor = SystemColors.ControlLightLight;
            LblsubTitulo.Location = new Point(87, 44);
            LblsubTitulo.Name = "LblsubTitulo";
            LblsubTitulo.Size = new Size(107, 14);
            LblsubTitulo.TabIndex = 1;
            LblsubTitulo.Text = "Sistema de Gestion";
            // 
            // label1
            // 
            label1.AccessibleName = "LblTitulo";
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Corbel", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(87, 9);
            label1.Name = "label1";
            label1.Size = new Size(125, 26);
            label1.TabIndex = 0;
            label1.Text = "BIBLIOTECA";
            // 
            // PnlSuperior
            // 
            PnlSuperior.BackColor = SystemColors.ControlDark;
            PnlSuperior.Dock = DockStyle.Top;
            PnlSuperior.Location = new Point(220, 0);
            PnlSuperior.Name = "PnlSuperior";
            PnlSuperior.Size = new Size(580, 80);
            PnlSuperior.TabIndex = 1;
            PnlSuperior.Paint += PnlSuperior_Paint;
            // 
            // PnlEstado
            // 
            PnlEstado.BackColor = SystemColors.ScrollBar;
            PnlEstado.Dock = DockStyle.Bottom;
            PnlEstado.Location = new Point(220, 410);
            PnlEstado.Name = "PnlEstado";
            PnlEstado.Size = new Size(580, 40);
            PnlEstado.TabIndex = 2;
            // 
            // PnlContenido
            // 
            PnlContenido.Dock = DockStyle.Fill;
            PnlContenido.Font = new Font("Corbel", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PnlContenido.Location = new Point(220, 80);
            PnlContenido.Name = "PnlContenido";
            PnlContenido.Size = new Size(580, 330);
            PnlContenido.TabIndex = 3;
            // 
            // btninicio
            // 
            btninicio.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            btninicio.IconColor = Color.Black;
            btninicio.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btninicio.Location = new Point(0, 80);
            btninicio.Name = "btninicio";
            btninicio.Size = new Size(220, 42);
            btninicio.TabIndex = 1;
            btninicio.Text = "INICIO";
            btninicio.TextAlign = ContentAlignment.MiddleRight;
            btninicio.TextImageRelation = TextImageRelation.ImageBeforeText;
            btninicio.UseVisualStyleBackColor = true;
            // 
            // btnlibros
            // 
            btnlibros.IconChar = FontAwesome.Sharp.IconChar.Book;
            btnlibros.IconColor = Color.Black;
            btnlibros.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnlibros.Location = new Point(0, 128);
            btnlibros.Name = "btnlibros";
            btnlibros.Size = new Size(220, 42);
            btnlibros.TabIndex = 2;
            btnlibros.Text = "LIBROS";
            btnlibros.TextAlign = ContentAlignment.MiddleRight;
            btnlibros.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnlibros.UseVisualStyleBackColor = true;
            // 
            // btnusuarios
            // 
            btnusuarios.IconChar = FontAwesome.Sharp.IconChar.PersonShelter;
            btnusuarios.IconColor = Color.Black;
            btnusuarios.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnusuarios.Location = new Point(0, 176);
            btnusuarios.Name = "btnusuarios";
            btnusuarios.Size = new Size(220, 48);
            btnusuarios.TabIndex = 3;
            btnusuarios.Text = "USUARIOS";
            btnusuarios.TextAlign = ContentAlignment.MiddleRight;
            btnusuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnusuarios.UseVisualStyleBackColor = true;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PnlContenido);
            Controls.Add(PnlEstado);
            Controls.Add(PnlSuperior);
            Controls.Add(PnlMenu);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Gestión de Biblioteca";
            WindowState = FormWindowState.Maximized;
            Load += FrmPrincipal_Load;
            PnlMenu.ResumeLayout(false);
            PnlLogo.ResumeLayout(false);
            PnlLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)piclogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PnlMenu;
        private Panel PnlSuperior;
        private Panel PnlEstado;
        private Panel PnlContenido;
        private Panel PnlLogo;
        private Label label1;
        private Label LblsubTitulo;
        private PictureBox piclogo;
        private FontAwesome.Sharp.IconButton btninicio;
        private FontAwesome.Sharp.IconButton btnlibros;
        private FontAwesome.Sharp.IconButton btnusuarios;
        private Button button1;
    }
}
