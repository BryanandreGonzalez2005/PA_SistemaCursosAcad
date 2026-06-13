using Logica.Inventario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios.Facturacion
{
    public partial class adminEspecialidad : Form
    {
        public adminEspecialidad()
        {
            InitializeComponent();
        }

        EspecialidadLN aln= new EspecialidadLN();
        public void listarDestino(string avl)
        {
            dataGridView1.DataSource = aln.ViewDestinoFiltro(avl);
        }
        private void adminEspecialidad_Load(object sender, EventArgs e)
        {
            listarDestino("");
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 95, 115); // Azul Marino
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Texto blanco
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Bordes del encabezado
            dataGridView1.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            // Alternar colores de filas para mejor legibilidad
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 247, 255); // Celeste muy suave
            // Quitar bordes innecesarios del DataGridView
            dataGridView1.BorderStyle = BorderStyle.None;


            label1.Font = new Font("Arial", 18, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 95, 115); // Azul Marino
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label2.Font = new Font("Arial", 10, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(44, 62, 80); // Gris Oscuro

            textBox1.BackColor = Color.FromArgb(250, 243, 223); // Mismo color que el panel superior (arena)
            textBox1.Font = new Font("Arial", 10, FontStyle.Regular);
            textBox1.ForeColor = Color.Black;

            // Refrescar para aplicar cambios
            dataGridView1.Refresh();
        }
    }
}
