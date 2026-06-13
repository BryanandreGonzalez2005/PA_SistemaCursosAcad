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
    public partial class editModuloCurso : Form
    {
        public editModuloCurso()
        {
            InitializeComponent();
        }

        public ModuloPaisPersonalizado auxiliar;
        PaisLN olnp = new PaisLN();
        ModuloCursoLN alnp = new ModuloCursoLN();


        private void editModuloCurso_Load(object sender, EventArgs e)
        {
            CargarPais();
            if (auxiliar != null)

            {
                setDatos();
            }
        }

        public ModuloCurso CrearObjeto()
        {
            ModuloCurso oa;
            int IdAc = int.Parse(textBox1.Text);
            string nombre = textBox2.Text;
            string tipo = comboBox1.Text;
            string desc = textBox3.Text;
            string dur = textBox4.Text;
            decimal costo = decimal.Parse(textBox5.Text);
            int paisSelec = (int)comboBox2.SelectedValue;
            oa = new ModuloCurso(IdAc, nombre, tipo, desc, dur, costo, paisSelec);
            return oa;
        }
        public void CargarPais()
        {
            var paises = olnp.ViewPaises();
            if (paises != null && paises.Count > 0)
            {
                comboBox2.DataSource = paises;
                comboBox2.DisplayMember = "Nombre";
                comboBox2.ValueMember = "idPais";
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
                textBox1.Text = auxiliar.IdModulo.ToString();
                textBox2.Text = auxiliar.NombreModulo;
                comboBox1.Text = auxiliar.TipoModulo;
                textBox3.Text = auxiliar.Descripcion;
                textBox4.Text = auxiliar.Duracion;
                textBox5.Text = auxiliar.CostoModulo.ToString();
                comboBox2.SelectedIndex = buscarIndice(comboBox2, auxiliar.Paises);
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
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verificar que textBox5 (costo) solo contenga números (decimal)
            decimal costo;
            if (!decimal.TryParse(textBox5.Text, out costo) || costo < 0)
            {
                MessageBox.Show("El costo debe ser un número válido y positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verificar que comboBox1 tenga un valor seleccionado
            if (comboBox1.SelectedIndex == -1 || string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Debe seleccionar un tipo de actividad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verificar que comboBox2 tenga un país seleccionado
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un país.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true; // Si todo está bien, retorna verdadero
        }
        public void guardar()
        {
            bool claveRepetida = false;

            if (validar())
            {
                if (label1.Text == "Ingresar Actividad")
                {
                    if (alnp.VerificarActividad(int.Parse(textBox1.Text)))
                    {
                        MessageBox.Show("El código de la actividad ya existe. Por favor, ingrese un código diferente.",
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Close();
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
