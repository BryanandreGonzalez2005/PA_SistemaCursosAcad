using Entidades.Inventario;
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

namespace Presentaciones.Ubicaciones
{
    public partial class adminPais : Form
    {
        public adminPais()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

        }
        PaisLN pln = new PaisLN();

        public void listarPais(string avl)
        {
            dataGridView1.DataSource = pln.ViewPaisesFiltro(avl);
        }

        public void Nuevo()
        {
            edirPais frm = new edirPais();
            frm.label1.Text = "Ingresar Pais";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Paises op = frm.CrearObjeto();
                pln.CreatePaises(op);
                frm.Hide();
                listarPais("");
            }
        }
        public void Modificar()
        {
            try
            {
                Entidades.Inventario.Paises op = dataGridView1.CurrentRow.DataBoundItem as Entidades.Inventario.Paises;
                edirPais frm = new edirPais();
                frm.label1.Text = "Modificar Pais";
                frm.auxiliar = op;
                frm.setDatos();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    pln.UpdatePaises(frm.CrearObjeto());
                    frm.Hide();
                    listarPais("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione una fila a modificar");
            }
        }
        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una fila antes de eliminar.");
                    return;
                }

                var res = MessageBox.Show("¿Desea eliminar el país?", "Eliminar País", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (res == DialogResult.Yes)
                {
                    Paises oc = dataGridView1.CurrentRow.DataBoundItem as Paises;
                    pln.DeletePaises(oc);
                    listarPais("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar datos: " + ex.Message);
            }
        }


        private void adminPais_Load(object sender, EventArgs e)
        {
            listarPais("");
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Modificar();

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Eliminar();       }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Color semiTransparentColor = Color.FromArgb(204, 15, 15, 15); // mismo color y opacidad
            using (SolidBrush brush = new SolidBrush(semiTransparentColor))
            {
                e.Graphics.FillRectangle(brush, panel2.ClientRectangle);
            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
