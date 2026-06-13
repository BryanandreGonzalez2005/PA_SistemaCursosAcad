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
    public partial class adminInscripcion : Form
    {
        public adminInscripcion()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
        }
        InscripcionLN olnr = new InscripcionLN();

        public void listarReserva(string filtro)
        {
            dataGridView1.DataSource = olnr.ViewReservaFiltro(filtro);
        }

        public void Nuevo()
        {
            editInscripcion frm = new editInscripcion();
            frm.label1.Text = "INGRESAR INSCRIPCION";
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                Inscripcion op = frm.CrearObjeto();
                olnr.CreateReserva(op);
                frm.Hide();
                listarReserva(""); // Refrescar la lista
            }
        }

        // 🔹 Método para modificar una reserva seleccionada
        public void Modificar()
        {
            try
            {
                InscripcionPersonalizada op = dataGridView1.CurrentRow.DataBoundItem as InscripcionPersonalizada;
                editInscripcion frm = new editInscripcion();
                frm.label1.Text = "Modificar Inscripcion";
                frm.auxiliar = op;
                frm.setDatos();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    olnr.UpDateReserva(frm.CrearObjeto());
                    frm.Hide();
                    listarReserva(""); // Refrescar la lista
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione una Inscripcion para modificar.");
            }
        }

   
        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("¿Desea eliminar esta Inscripcion", "Eliminar Inscripcion", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        InscripcionPersonalizada obp = dataGridView1.CurrentRow.DataBoundItem as InscripcionPersonalizada;
                        Inscripcion op = new Inscripcion(obp.IdInscripcion);
                        olnr.DeleteReserva(op);
                        listarReserva(""); // Refrescar la lista
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una Inscripcion para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la Inscripcion: " + ex.Message);
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

        private void adminInscripcion_Load(object sender, EventArgs e)
        {
            listarReserva("");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
