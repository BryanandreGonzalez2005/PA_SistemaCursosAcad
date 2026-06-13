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
    public partial class editInscripcion : Form
    {
        public editInscripcion()
        {
            InitializeComponent();
        }

        public InscripcionPersonalizada auxiliar;
        AlumnoLN olc = new AlumnoLN();
        InscripcionLN olnr = new InscripcionLN();

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void editInscripcion_Load(object sender, EventArgs e)
        {
            CargarClientes();
            if (auxiliar != null)
            {
                setDatos();
            }
        }

        public void CargarClientes()
        {
            var clientes = olc.ViewCliente();
            if (clientes != null && clientes.Count > 0)
            {
                comboBox1.DataSource = clientes;
                comboBox1.DisplayMember = "Cedula"; // Mostramos la cédula en el combo
                comboBox1.ValueMember = "idAlumno"; // Guardamos el ID
            }
            else
            {
                MessageBox.Show("No hay clientes disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 🔹 Buscar índice del cliente en el ComboBox por su cédula
        public int buscarIndice(System.Windows.Forms.ComboBox comboBox, string value)
        {
            foreach (object item in comboBox.Items)
            {
                if (item.GetType() == typeof(AlumnoPersonalizado))
                {
                    if ((item as AlumnoPersonalizado).Cedula.Equals(value))
                    {
                        return comboBox.Items.IndexOf(item);
                    }
                }
            }
            return -1;
        }

        // 🔹 Llenar el formulario si se está editando una reserva
        public void setDatos()
        {
            try
            {
                textBox1.ReadOnly = true;
                textBox1.Text = auxiliar.IdInscripcion.ToString();
                dateTimePicker1.Value = auxiliar.FechaInscripcion;
                dateTimePicker2.Value = auxiliar.FechaInicio;
                dateTimePicker3.Value = auxiliar.FechaFin;
                textBox2.Text = auxiliar.CantHorasTeoricas.ToString();
                textBox3.Text = auxiliar.CantHorasPrecticas.ToString();
                int index = comboBox1.FindStringExact(auxiliar.CedulaAlumno);
                if (index >= 0)
                {
                    comboBox1.SelectedIndex = index;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Crear un objeto Reserva con los datos ingresados
        public Inscripcion CrearObjeto()
        {
            Inscripcion reserva;
            int idReserva = int.Parse(textBox1.Text);
            DateTime fechaReserva = dateTimePicker1.Value;
            DateTime fechaInicio = dateTimePicker2.Value;
            DateTime fechaFin = dateTimePicker3.Value;
            int cantAdultos = int.Parse(textBox2.Text);
            int cantNiños = int.Parse(textBox3.Text);
            int idCliente = (int)comboBox1.SelectedValue;

            reserva = new Inscripcion(idReserva, fechaReserva, fechaInicio, fechaFin, cantAdultos, cantNiños, idCliente);
            return reserva;
        }

        // 🔹 Validaciones antes de guardar
        public bool validar()
        {
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
                MessageBox.Show("El ID Reserva debe ser un número válido y positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dateTimePicker1.Value > dateTimePicker3.Value)
            {
                MessageBox.Show("La fecha de reserva no puede ser mayor que la fecha de fin.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dateTimePicker2.Value >= dateTimePicker3.Value)
            {
                MessageBox.Show("La fecha de inicio debe ser menor que la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(textBox2.Text, out _) || !int.TryParse(textBox3.Text, out _))
            {
                MessageBox.Show("Las cantidades de adultos y niños deben ser números válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBox1.SelectedIndex == -1 || string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // 🔹 Guardar la reserva después de validar
        public void guardar()
        {
            bool claveRepetida = false;

            if (validar())
            {
                if (label1.Text == "Ingresar Reserva")
                {
                    if (olnr.VerificarReserva(int.Parse(textBox1.Text)))
                    {
                        MessageBox.Show("El ID de la reserva ya existe. Ingrese un ID diferente.",
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

        private bool cambioManual = false;

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (!cambioManual) return;

            cambioManual = false; // Reseteamos la variable

            var result = MessageBox.Show(
                "¿Cuántos días quieres que dure tu viaje?\n\n" +
                "Sí → 5 días\nNo → 7 días\n\n" +
                "(Se mostrará otra opción para 10 o 20 días después)",
                "Seleccionar duración", MessageBoxButtons.YesNoCancel);

            int duracion = 7; // Duración por defecto

            if (result == DialogResult.Yes) duracion = 5;
            else if (result == DialogResult.No) duracion = 7;
            else
            {
                var result2 = MessageBox.Show("Elige otra duración:\n\nSí → 10 días\nNo → 20 días",
                                              "Seleccionar duración", MessageBoxButtons.YesNo);

                if (result2 == DialogResult.Yes) duracion = 10;
                else duracion = 20;
            }

            dateTimePicker3.Value = dateTimePicker2.Value.AddDays(duracion);
        }

        private void dateTimePicker2_MouseDown(object sender, MouseEventArgs e)
        {
            cambioManual = true;
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
