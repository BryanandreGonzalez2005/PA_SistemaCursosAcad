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
    public partial class editAlumno : Form
    {
        public editAlumno()
        {
            InitializeComponent();
        }

        public AlumnoPersonalizado auxiliar;
        CiudadLN olnd = new CiudadLN();
        AlumnoLN olc = new AlumnoLN();

        private void editAlumno_Load(object sender, EventArgs e)
        {
            CargarCiudades();
            if (auxiliar != null)
            {
                setDatos();
            }
        }

        public void CargarCiudades()
        {
            var ciudades = olnd.ViewCiudad();
            if (ciudades != null && ciudades.Count > 0)
            {
                comboBox1.DataSource = ciudades;
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "idCiudad";
            }
            else
            {
                MessageBox.Show("No hay ciudades disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 🔹 Buscar el índice de la ciudad en el ComboBox
        public int buscarIndice(System.Windows.Forms.ComboBox comboBox, string value)
        {
            foreach (object item in comboBox.Items)
            {
                if (item.GetType() == typeof(Ciudad))
                {
                    if ((item as Ciudad).Nombre.Equals(value))
                    {
                        return comboBox.Items.IndexOf(item);
                    }
                }
            }
            return -1;
        }

        // 🔹 Llenar el formulario si se está editando un cliente
        public void setDatos()
        {
            try
            {
                textBox1.ReadOnly = true;
                textBox1.Text = auxiliar.IdAlumno.ToString();
                textBox2.Text = auxiliar.Cedula;
                textBox3.Text = auxiliar.Nombre;
                textBox4.Text = auxiliar.Apellido;
                comboBox1.SelectedIndex = buscarIndice(comboBox1, auxiliar.Ciudad);
                textBox5.Text = auxiliar.Telefono.ToString();
                textBox6.Text = auxiliar.Email;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Crear un objeto Cliente con los datos ingresados
        public Alumno CrearObjeto()
        {
            Alumno cliente;
            int idCliente = int.Parse(textBox1.Text);
            string cedula = textBox2.Text;
            string nombre = textBox3.Text;
            string apellido = textBox4.Text;
            int idCiudad = (int)comboBox1.SelectedValue;
            int telefono = int.Parse(textBox5.Text);
            string email = textBox6.Text;

            cliente = new Alumno(idCliente, cedula, nombre, apellido, idCiudad, telefono, email);
            return cliente;
        }

        // 🔹 Validaciones antes de guardar
        public bool validar()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int id;
            if (!int.TryParse(textBox1.Text, out id) || id < 0)
            {
                MessageBox.Show("El ID Cliente debe ser un número válido y positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBox1.SelectedIndex == -1 || string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Debe seleccionar una ciudad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(textBox5.Text, out _))
            {
                MessageBox.Show("El teléfono debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // 🔹 Guardar el cliente después de validar
        public void guardar()
        {
            bool claveRepetida = false;

            if (validar())
            {
                if (label1.Text == "Ingresar Cliente")
                {
                    if (olc.VerificarCliente(int.Parse(textBox1.Text)))
                    {
                        MessageBox.Show("El ID del cliente ya existe. Ingrese un ID diferente.",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        claveRepetida = true;
                    }
                }
                if (!claveRepetida)
                {
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
