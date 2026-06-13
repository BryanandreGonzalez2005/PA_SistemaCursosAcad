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
    public partial class editRecursoDidactico : Form
    {
        public editRecursoDidactico()
        {
            InitializeComponent();
        }

        public RecursoDidacticoPersonalizado auxiliar;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void editRecursoDidactico_Load(object sender, EventArgs e)
        {
            CargarCompañia();
            if (auxiliar != null)
            {
                setDatos();
            }
        }

        DocenteLN olnc = new DocenteLN();
        RecursoDidacticoLN oln = new RecursoDidacticoLN();

        public RecursoDidactico crearObjeto()
        {
            RecursoDidactico oa;
            int id = int.Parse(textBox1.Text);
            int compslec = (int)comboBox1.SelectedValue;
            string tipo = comboBox2.Text;
            decimal costo = decimal.Parse(textBox2.Text);
            oa = new RecursoDidactico(id, compslec, tipo, costo);
            return oa;
        }
        public void CargarCompañia()
        {
            var companias = olnc.ViewCompañia();
            if (companias != null && companias.Count > 0)
            {
                comboBox1.DataSource = companias;
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "idProveedor";
            }
            else
            {
                MessageBox.Show("No hay compañias disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public int buscarIndice(System.Windows.Forms.ComboBox comboBox, string value)
        {
            foreach (object item in comboBox.Items)
            {
                if (item.GetType() == typeof(Docente))
                {
                    if ((item as Docente).Nombre.Equals(value))
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
                textBox1.Text = auxiliar.IdRecurso.ToString();
                comboBox1.SelectedIndex = buscarIndice(comboBox1, auxiliar.Proveedor);
                comboBox2.Text = auxiliar.Tipo;
                textBox2.Text = auxiliar.CostoUnitario.ToString();
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
                string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verificar que textBox5 (costo) solo contenga números (decimal)
            decimal costo;
            if (!decimal.TryParse(textBox2.Text, out costo) || costo < 0)
            {
                MessageBox.Show("El costo debe ser un número válido y positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int id;
            if (!int.TryParse(textBox1.Text, out id) || costo < 0)
            {
                MessageBox.Show("El identificador ser un número válido y positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Verificar que comboBox1 tenga un valor seleccionado
            if (comboBox1.SelectedIndex == -1 || string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Debe seleccionar una compañia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verificar que comboBox2 tenga un país seleccionado
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de transporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true; // Si todo está bien, retorna verdadero
        }
        public void guardar()
        {
            bool claveRepetida = false;

            if (validar())
            {
                if (label1.Text == "Ingresar Transporte")
                {
                    if (oln.VerificarTransporte(int.Parse(textBox1.Text)))
                    {
                        MessageBox.Show("El código del tramsporte ya existe. Por favor, ingrese un código diferente.",
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
