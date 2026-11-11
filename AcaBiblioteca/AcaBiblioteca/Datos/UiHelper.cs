using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AcaBiblioteca.Datos;

internal static class UiHelper
{
    public static void EstilizarGrid(DataGridView grid)
    {
        grid.Dock = DockStyle.Fill;
        grid.ReadOnly = true;
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.MultiSelect = false;
        grid.BackgroundColor = Color.White;
        grid.BorderStyle = BorderStyle.None;
        grid.RowHeadersVisible = false;
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 57, 85);
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(243, 246, 250);
    }

    public static Button Boton(string texto)
    {
        return new Button { Text = texto, AutoSize = true, Height = 34, Padding = new Padding(12, 4, 12, 4),
            BackColor = Color.FromArgb(35, 85, 130), ForeColor = Color.White, FlatStyle = FlatStyle.Flat,
            Margin = new Padding(4) };
    }

    public static Label Etiqueta(string texto) => new() { Text = texto, AutoSize = true, Anchor = AnchorStyles.Left, Padding = new Padding(3, 8, 3, 3) };
}
