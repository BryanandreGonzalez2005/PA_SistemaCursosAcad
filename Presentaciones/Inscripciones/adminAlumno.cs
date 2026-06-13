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
    public partial class adminAlumno : Form
    {
        public adminAlumno()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
        }

        AlumnoLN cln = new AlumnoLN();

        public void listarCliente(string filtro)
        {
            dataGridView1.DataSource = cln.ViewClienteFiltro(filtro);
        }

        public void Nuevo()
        {
            editAlumno frm = new editAlumno();
            frm.label1.Text = "INGRESAR ALUMNO";
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                Alumno op = frm.CrearObjeto();
                cln.CreateCliente(op);
                frm.Hide();
                listarCliente(""); // Refrescar la lista
            }
        }

        // 🔹 Método para modificar un cliente seleccionado
        public void Modificar()
        {
            try
            {
                AlumnoPersonalizado op = dataGridView1.CurrentRow.DataBoundItem as AlumnoPersonalizado;
                editAlumno frm = new editAlumno();
                frm.label1.Text = "Modificar ALUMNO";
                frm.auxiliar = op;
                frm.setDatos();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    cln.UpDateCliente(frm.CrearObjeto());
                    frm.Hide();
                    listarCliente(""); // Refrescar la lista
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione un cliente para modificar.");
            }
        }

        // 🔹 Método para eliminar un cliente seleccionado
        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("¿Desea eliminar este Alumno?", "Eliminar Alumno", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        AlumnoPersonalizado obp = dataGridView1.CurrentRow.DataBoundItem as AlumnoPersonalizado;
                        Alumno op = new Alumno(obp.IdAlumno);
                        cln.DeleteCliente(op);
                        listarCliente(""); // Refrescar la lista
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un Alumno para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el Alumno: " + ex.Message);
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

        private void adminAlumno_Load(object sender, EventArgs e)
        {
            listarCliente("");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
