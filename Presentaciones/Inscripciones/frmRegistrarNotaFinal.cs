using Logica.Inventario;
using PA_SistemaCursosAcad.Inventario;
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
    public partial class frmRegistrarNotaFinal : Form
    {
        public frmRegistrarNotaFinal()
        {
            InitializeComponent();
        }

        AlumnoLN olc = new AlumnoLN();
        CursoLN cln = new CursoLN();
        CursoCD cm = new CursoCD();

        public void CargarAlumnos()
        {
            var alumnos = olc.ViewClienteConInscripcion(); // usa el método que creamos antes

            if (alumnos != null && alumnos.Count > 0)
            {
                comboBox1.DataSource = alumnos;
                comboBox1.DisplayMember = "Nombre"; // puedes cambiar a NombreCompleto si lo tienes
                comboBox1.ValueMember = "idAlumno";
            }
            else
            {
                MessageBox.Show("No hay alumnos inscritos en cursos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void CargarCursosPorAlumno(int idAlumno)
        {
            var cursos = cln.GetCursosPorAlumno(idAlumno); // usa el método que consulta desde la vista

            if (cursos != null && cursos.Count > 0)
            {
                comboBox2.DataSource = cursos; // Asegúrate que tengas comboBox2 en tu formulario
                comboBox2.DisplayMember = "NombreCurso";
                comboBox2.ValueMember = "idCurso";
            }
            else
            {
                comboBox2.DataSource = null;
                MessageBox.Show("Este alumno no tiene cursos inscritos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }





        private void frmRegistrarNotaFinal_Load(object sender, EventArgs e)
        {
            CargarAlumnos();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out int idAlumno))
            {
                CargarCursosPorAlumno(idAlumno);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un alumno y un curso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idAlumno = Convert.ToInt32(comboBox1.SelectedValue);
                int idCurso = Convert.ToInt32(comboBox2.SelectedValue);

                if (!decimal.TryParse(textBox1.Text, out decimal notaFinal))
                {
                    MessageBox.Show("Por favor ingresa una nota válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string resultado = CursoCD.RegistrarNotaFinal(idAlumno, idCurso, notaFinal);

                MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar el campo de nota si quieres
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
