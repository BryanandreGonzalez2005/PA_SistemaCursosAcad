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

namespace Presentaciones.Formacion
{
    public partial class adminModuloCurso : Form
    {
        public adminModuloCurso()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;


        }

        ModuloCursoLN aln = new ModuloCursoLN();

        public void listarActividad(string avl)
        {
            dataGridView1.DataSource = aln.ViewActividadFiltro(avl);
            
        }

        public void Nuevo()
        {
            editModuloCurso frm = new editModuloCurso();
            frm.label1.Text = "INGRESAR MODULOCURSO";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                ModuloCurso op = frm.CrearObjeto();
                aln.CreateActividad(op);
                frm.Hide();
                listarActividad("");
            }
        }
        public void Modificar()
        {
            try
            {
                Entidades.ClasesPersonalizadas.ModuloPaisPersonalizado op = dataGridView1.CurrentRow.DataBoundItem as Entidades.ClasesPersonalizadas.ModuloPaisPersonalizado;
                editModuloCurso frm = new editModuloCurso();
                frm.label1.Text = "Modificar Modulo";
                frm.auxiliar = op;
                frm.setDatos();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    aln.UpDateActividad(frm.CrearObjeto());
                    frm.Hide();
                    listarActividad("");
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
                    var res = MessageBox.Show("Desea eliminar Modulo", "Eliminar Modulo", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        ModuloPaisPersonalizado obp = dataGridView1.CurrentRow.DataBoundItem as ModuloPaisPersonalizado;
                        ModuloCurso op = new ModuloCurso(obp.IdModulo);
                        aln.DeleteActividad(op);
                        listarActividad("");
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

        private void adminModuloCurso_Load(object sender, EventArgs e)
        {
            listarActividad("");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
