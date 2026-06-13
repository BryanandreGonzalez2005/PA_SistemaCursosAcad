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
    public partial class adminAulaVirtual : Form
    {
        public adminAulaVirtual()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
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

        private void adminAulaVirtual_Load(object sender, EventArgs e)
        {
            listarAlojamiento("");
        }

        AulaVirtualLN aln = new AulaVirtualLN();
        public void listarAlojamiento(string avl)
        {
            dataGridView1.DataSource = aln.ViewAlojamientoFiltro(avl);
        }
        public void Nuevo()
        {
            editAulaVirtual frm = new editAulaVirtual();
            frm.label1.Text = "INGRESAR INSTITUCION";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                AulasVirtual op = frm.crearObjeto();
                aln.CreateAlojamiento(op);
                frm.Hide();
                listarAlojamiento("");
            }
        }
        public void Modificar()
        {
            try
            {
                Entidades.ClasesPersonalizadas.AulaVirtualPersonalizado op = dataGridView1.CurrentRow.DataBoundItem as Entidades.ClasesPersonalizadas.AulaVirtualPersonalizado;
                editAulaVirtual frm = new editAulaVirtual();
                frm.label1.Text = "Modificar Institucion";
                frm.auxiliar = op;
                frm.setDatos();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    aln.UpDateAlojamiento(frm.crearObjeto());
                    frm.Hide();
                    listarAlojamiento("");
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
                    var res = MessageBox.Show("Desea eliminar Institucion", "Eliminar Institucion", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        AulaVirtualPersonalizado obp = dataGridView1.CurrentRow.DataBoundItem as AulaVirtualPersonalizado;
                        AulasVirtual op = new AulasVirtual(obp.IdAulaVirtual);
                        aln.DeleteAlojamiento(op);
                        listarAlojamiento("");
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
