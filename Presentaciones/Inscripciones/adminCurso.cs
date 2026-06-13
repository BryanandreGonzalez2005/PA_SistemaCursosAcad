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

namespace Presentaciones.Inscripciones
{
    public partial class adminCurso : Form
    {
        public adminCurso()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
        }
        CursoLN paqueteLN = new CursoLN();

        public void listarPaquetes(string filtro)
        {
            dataGridView1.DataSource = paqueteLN.ViewPaqueteFiltro(filtro);
        }

        // 🔹 Método para agregar un nuevo paquete
        public void Nuevo()
        {
            editCurso frm = new editCurso();
            frm.label1.Text = "INGRESAR CURSO";
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                Curso paquete = frm.CrearObjeto();
                paqueteLN.CreatePaquete(paquete);
                frm.Hide();
                listarPaquetes("");
            }
        }

        // 🔹 Método para modificar un paquete seleccionado
        public void Modificar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    CursoPersonalizado paquete = dataGridView1.CurrentRow.DataBoundItem as CursoPersonalizado;
                    editCurso frm = new editCurso();
                    frm.label1.Text = "Modificar Curso";
                    frm.auxiliar = paquete;
                    frm.setDatos();
                    frm.ShowDialog();

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        paqueteLN.UpDatePaquete(frm.CrearObjeto());
                        frm.Hide();
                        listarPaquetes("");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un Curso a modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar Curso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Método para eliminar un paquete seleccionado
        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("¿Desea eliminar este Curso?", "Eliminar Curso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (res == DialogResult.Yes)
                    {
                        CursoPersonalizado paquete = dataGridView1.CurrentRow.DataBoundItem as CursoPersonalizado;
                        Curso paqueteEliminar = new Curso(paquete.IdCurso, "", 0, 0, "", 0, 0, 0, 0, "");

                        paqueteLN.DeletePaquete(paqueteEliminar);
                        listarPaquetes("");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un Curso a eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar Cursp: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

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

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    CursoPersonalizado obj = dataGridView1.CurrentRow.DataBoundItem as CursoPersonalizado;
                    frmInscripcionCurso frm = new frmInscripcionCurso();
                    frm.auxiliar = obj;
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Seleccione un Curso para Inscribirse", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al reservar Curso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adminCurso_Load(object sender, EventArgs e)
        {
            listarPaquetes("");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
