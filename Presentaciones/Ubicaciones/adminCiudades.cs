using Entidades.ClasesPersonalizadas;
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
    public partial class adminCiudades : Form
    {
        CiudadLN aln = new CiudadLN();
        public adminCiudades()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
        }

        public void listarCiudad(string avl)
        {
            dataGridView1.DataSource = aln.ViewCiudadFiltro(avl);
        }
        public void Nuevo()
        {
            editCiudad frm = new editCiudad();
            frm.label1.Text = "Ingresar Ciudad";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Ciudad op = frm.CrearObjeto();
                aln.CreateCiudad(op);
                frm.Hide();
                listarCiudad("");
            }
        }
        public void Modificar()
        {
            try
            {
                Entidades.ClasesPersonalizadas.CiudadPersonalizado op = dataGridView1.CurrentRow.DataBoundItem as Entidades.ClasesPersonalizadas.CiudadPersonalizado;
                editCiudad frm = new editCiudad();
                frm.label1.Text = "Modificar Ciudad";
                frm.auxiliar = op;
                frm.setDatos();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    aln.UpDateCiudad(frm.CrearObjeto());
                    frm.Hide();
                    listarCiudad("");
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
                    var res = MessageBox.Show("Desea eliminar Ciudad", "Eliminar Ciudad", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        CiudadPersonalizado obp = dataGridView1.CurrentRow.DataBoundItem as CiudadPersonalizado;
                        Ciudad op = new Ciudad(obp.IdCiudad);
                        aln.DeleteCiudad(op);
                        listarCiudad("");
                    }

                }
                else
                    MessageBox.Show("Seleccione la fila");
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

        private void adminCiudades_Load(object sender, EventArgs e)
        {
            listarCiudad("");
        }
    }
}
