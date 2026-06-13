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

namespace Presentaciones.Recursos
{
    public partial class adminDocente : Form
    {
        public adminDocente()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
        }

        DocenteLN cln = new DocenteLN();
        public void listarCompañia(string val)
        {
            dataGridView1.DataSource = cln.ViewCompañiaFiltro(val);
        }

        public void Nuevo()
        {
            editDocente frm = new editDocente();
            frm.label1.Text = "INGRESAR DOCENTE";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Docente op = frm.CrearObjeto();
                cln.CreateCompañia(op);
                frm.Hide();
                listarCompañia("");
            }
        }
        public void Modificar()
        {
            try
            {
                Docente op = dataGridView1.CurrentRow.DataBoundItem as Docente;
                editDocente frm = new editDocente();
                frm.label1.Text = "Modificar Docente";
                frm.auxiliar = op;
                frm.setDatos();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    cln.UpdateCompañia(frm.CrearObjeto());
                    frm.Hide();
                    listarCompañia("");
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
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("Desea eliminar Docente", "Eliminar Docente", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        Docente oc = dataGridView1.CurrentRow.DataBoundItem as Docente;
                        cln.DeleteCompañia(oc);
                        listarCompañia("");
                    }
                    else
                        MessageBox.Show("Seleccione la fila");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" error al eliminar datos" + ex.Message);
            }
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
            Eliminar();
        }

        private void adminDocente_Load(object sender, EventArgs e)
        {
            listarCompañia("");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
