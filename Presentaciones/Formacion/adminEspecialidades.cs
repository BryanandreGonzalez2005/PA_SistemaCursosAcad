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

namespace Presentaciones
{
    public partial class adminEspecialidades : Form
    {
        public adminEspecialidades()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
        }

        EspecialidadLN aln = new EspecialidadLN();
        public void listarDestino(string avl)
        {
            dataGridView1.DataSource = aln.ViewDestinoFiltro(avl);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listarDestino("");
            
        }

        public void Nuevo()
        {
            editEspecialidades frm = new editEspecialidades();
            frm.label1.Text = "INGRESAR ESPECIALIDADES";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Especialidad op = frm.CrearObjeto();
                aln.CreateDestino(op);
                frm.Hide();
                listarDestino("");
            }
        }
        public void Modificar()
        {
            try
            {
                Entidades.ClasesPersonalizadas.EspecialidadPersonalizado op = dataGridView1.CurrentRow.DataBoundItem as Entidades.ClasesPersonalizadas.EspecialidadPersonalizado;
                editEspecialidades frm = new editEspecialidades();
                frm.label1.Text = "Modificar Especialidades";
                frm.auxiliar = op;
                frm.setDatos();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    aln.UpDateDestino(frm.CrearObjeto());
                    frm.Hide();
                    listarDestino("");
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
                    var res = MessageBox.Show("Desea eliminar Especialidades", "Eliminar Especialidades", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        EspecialidadPersonalizado obp = dataGridView1.CurrentRow.DataBoundItem as EspecialidadPersonalizado;
                        Especialidad op = new Especialidad(obp.IdEspecilidad);
                        aln.DeleteDestino(op);
                        listarDestino("");
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
