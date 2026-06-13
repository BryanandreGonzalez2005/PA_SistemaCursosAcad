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

namespace Presentaciones.Recursos
{
    public partial class adminRecursoDidactico : Form
    {
        public adminRecursoDidactico()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
        }
        RecursoDidacticoLN tln = new RecursoDidacticoLN();
        public void listarTransporte(string avl)
        {
            dataGridView1.DataSource = tln.ViewTransporteFiltro(avl);
        }

        private void adminRecursoDidactico_Load(object sender, EventArgs e)
        {
            listarTransporte("");
        }

        public void Nuevo()
        {
            editRecursoDidactico frm = new editRecursoDidactico();
            
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                RecursoDidactico op = frm.crearObjeto();
                tln.CreateTransporte(op);
                frm.Hide();
                listarTransporte("");
            }
        }
        public void Modificar()
        {
            try
            {
                RecursoDidacticoPersonalizado op = dataGridView1.CurrentRow.DataBoundItem as RecursoDidacticoPersonalizado;
                editRecursoDidactico frm = new editRecursoDidactico();
                frm.label1.Text = "Modificar RECURSO";
                frm.auxiliar = op;
                frm.setDatos();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    tln.UpDateTransporte(frm.crearObjeto());
                    frm.Hide();
                    listarTransporte("");
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
                    var res = MessageBox.Show("Desea eliminar RecursoDidact", "Eliminar RecursoDidac", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        RecursoDidacticoPersonalizado obp = dataGridView1.CurrentRow.DataBoundItem as RecursoDidacticoPersonalizado;
                        RecursoDidactico op = new RecursoDidactico(obp.IdRecurso);
                        tln.DeleteTransporte(op);
                        listarTransporte("");
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
