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
    public partial class editDocente : Form
    {
        public editDocente()
        {
            InitializeComponent();
        }

        private void editDocente_Load(object sender, EventArgs e)
        {

        }

        public Docente auxiliar;
        DocenteLN olnp = new DocenteLN();
        public Docente CrearObjeto()
        {
            Docente op;
            int IdC = int.Parse(textBox1.Text);
            string ruc = textBox2.Text;
            string nombre = textBox3.Text;
            string tipo = comboBox1.Text;
            string direccion = textBox4.Text;
            string email = textBox5.Text;
            int telefono = int.Parse(textBox6.Text);
            op = new Docente(IdC, ruc, nombre, tipo, direccion, email, telefono);
            return op;
        }
        public void setDatos()
        {
            try
            {
                textBox1.ReadOnly = true;
                textBox1.Text = auxiliar.IdProveedor.ToString();
                textBox2.Text = auxiliar.Ruc;
                textBox3.Text = auxiliar.Nombre;
                comboBox1.Text = auxiliar.Tipo;
                textBox4.Text = auxiliar.Direccion;
                textBox5.Text = auxiliar.Email;
                textBox6.Text = auxiliar.Telefono.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool validar()
        {
            // Verificar que los TextBox no estén vacíos
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text) ||
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
                MessageBox.Show("El id debe ser un número válido y positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(textBox6.Text, out id) || id < 0)
            {
                MessageBox.Show("El TELEFONO debe ser un número válido y positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }
        public void guardar()
        {
            bool claveRepetida = false;

            if (validar())
            {
                if (label1.Text == "Ingresar Compañia")
                {
                    if (olnp.VerificarCompañia(int.Parse(textBox1.Text)))
                    {
                        MessageBox.Show("El código de la compañia ya existe. Por favor, ingrese un código diferente.",
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
