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

namespace Presentaciones.Ubicaciones
{
    public partial class editCiudad : Form
    {
        public editCiudad()
        {
            InitializeComponent();
        }

        public CiudadPersonalizado auxiliar;
        CiudadLN olnd = new CiudadLN();
        PaisLN olnp = new PaisLN();

        public Ciudad CrearObjeto()
        {
            Ciudad od;
            int IdC = int.Parse(textBox1.Text);
            string nombre = textBox2.Text;
            int paisSelec = (int)comboBox1.SelectedValue;
            string desc = textBox3.Text;
            od = new Ciudad(IdC, paisSelec, nombre, desc);
            return od;

        }
        public void CargarPais()
        {
            var paises = olnp.ViewPaises();
            if (paises != null && paises.Count > 0)
            {
                comboBox1.DataSource = paises;
                comboBox1.DisplayMember = "nombre";
                comboBox1.ValueMember = "idPais";
            }
            else
            {
                MessageBox.Show("No hay paises disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public int buscarIndice(System.Windows.Forms.ComboBox comboBox, string value)
        {
            foreach (object item in comboBox.Items)
            {
                if (item.GetType() == typeof(Paises))
                {
                    if ((item as Paises).Nombre.Equals(value))
                    {
                        return comboBox.Items.IndexOf(item);
                    }
                }
            }
            return -1;
        }
        public void setDatos()
        {
            try
            {
                textBox1.ReadOnly = true;
                textBox1.Text = auxiliar.IdCiudad.ToString();
                textBox2.Text = auxiliar.Nombre;
                comboBox1.SelectedIndex = buscarIndice(comboBox1, auxiliar.Paises);
                textBox3.Text = auxiliar.Descripcion;

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
                string.IsNullOrWhiteSpace(textBox3.Text))

            {
                MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int id;
            if (!int.TryParse(textBox1.Text, out id) || id < 0)
            {
                MessageBox.Show("El  id ciudad debe ser un número válido y positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verificar que comboBox1 tenga un valor seleccionado
            if (comboBox1.SelectedIndex == -1 || string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Debe seleccionar un tipo de ciudad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true; // Si todo está bien, retorna verdadero
        }
        public void guardar()
        {
            bool claveRepetida = false;

            if (validar())
            {
                if (label1.Text == "Ingresar Ciudad")
                {
                    if (olnd.VerificarCiudad(int.Parse(textBox1.Text)))
                    {
                        MessageBox.Show("El código de la ciudad  ya existe. Por favor, ingrese un código diferente.",
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

   

        private void editCiudad_Load(object sender, EventArgs e)
        {
            CargarPais();
            if (auxiliar != null)

            {
                setDatos();
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
