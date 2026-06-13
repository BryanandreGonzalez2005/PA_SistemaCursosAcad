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
    public partial class editAulaVirtual : Form
    {
        public editAulaVirtual()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void editAulaVirtual_Load(object sender, EventArgs e)
        {
            CargarPais();
            if (auxiliar != null)

            {
                setDatos();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        PaisLN olnp = new PaisLN();
        AulaVirtualLN alnp = new AulaVirtualLN();
        public AulaVirtualPersonalizado auxiliar;
        public AulasVirtual crearObjeto()
        {
            AulasVirtual oa;
            int IdAc = int.Parse(textBox1.Text);
            string nombre = textBox2.Text;
            string tipo = comboBox1.Text;
            string cat = comboBox2.Text;
            string dir = textBox3.Text;
            decimal precio = decimal.Parse(textBox4.Text);
            int dur = int.Parse(comboBox4.SelectedItem.ToString()); // 🔹 Tomamos el valor seleccionado
            string desc = textBox6.Text;
            int paisSelec = (int)comboBox3.SelectedValue;
            oa = new AulasVirtual(IdAc, nombre, tipo, cat, dir, precio, dur, desc, 0, paisSelec);
            return oa;
        }

        public void CargarPais()
        {
            var paises = olnp.ViewPaises();
            if (paises != null && paises.Count > 0)
            {
                comboBox3.DataSource = paises;
                comboBox3.DisplayMember = "Nombre";
                comboBox3.ValueMember = "idPais";
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
                textBox1.Text = auxiliar.IdAulaVirtual.ToString();
                textBox2.Text = auxiliar.Nombre;
                comboBox1.Text = auxiliar.Tipo;
                comboBox2.Text = auxiliar.Categoria;
                textBox3.Text = auxiliar.Direccion;
                textBox4.Text = auxiliar.PrecioUso.ToString();
                comboBox4.SelectedItem = auxiliar.DuracionDisponibilidad.ToString(); // 🔹 Seleccionamos la duración correcta
                textBox6.Text = auxiliar.Descripcion;
                comboBox3.SelectedIndex = buscarIndice(comboBox3, auxiliar.Paises);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool validar()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
               string.IsNullOrWhiteSpace(textBox2.Text) ||
               string.IsNullOrWhiteSpace(textBox3.Text) ||
               string.IsNullOrWhiteSpace(textBox4.Text) ||
               string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            decimal costo;
            if (!decimal.TryParse(textBox4.Text, out costo) || costo < 0)
            {
                MessageBox.Show("El precio por noche debe ser un número decimal válido y positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una duración válida (5, 7, 10 o 20 días).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBox1.SelectedIndex == -1 || string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Debe seleccionar un tipo de alojamiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un país.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una Categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public void guardar()
        {
            bool claveRepetida = false;

            if (validar())
            {
                if (label1.Text == "Ingresar Alojamiento")
                {
                    if (alnp.VerificarAlojamiento(int.Parse(textBox1.Text)))
                    {
                        MessageBox.Show("El código del alojamiento ya existe. Por favor, ingrese un código diferente.",
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
