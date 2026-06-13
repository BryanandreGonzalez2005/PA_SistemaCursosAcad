using Entidades.ClasesPersonalizadas;
using Logica.Inventario;
using Entidades.Inventario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Logica.Inventario.AulaVirtualLN;

namespace Presentaciones.Inscripciones
{
    public partial class editCurso : Form
    {
        public editCurso()
        {
            InitializeComponent();
        }


        EspecialidadLN destinoLN = new EspecialidadLN();
        AulaVirtualLN alojamientoLN = new AulaVirtualLN();
        ModuloCursoLN actividadLN = new ModuloCursoLN();
        RecursoDidacticoLN transporteLN = new RecursoDidacticoLN();
        CursoLN paqueteLN = new CursoLN();

        public CursoPersonalizado auxiliar;
        private bool comboBoxCargado = false;

       
        private void CargarDestinos()
        {
            var destinos = destinoLN.ViewDestino();
            comboBox2.DataSource = destinos;
            comboBox2.DisplayMember = "NombreEspecialidad";
            comboBox2.ValueMember = "IdEspecialidad";
            comboBox2.SelectedIndex = -1;
        }

        private void CargarTransportes()
        {
            var transportes = transporteLN.ViewTransporte();
            comboBox1.DataSource = transportes;
            comboBox1.DisplayMember = "Tipo";
            comboBox1.ValueMember = "IdRecurso";
            comboBox1.SelectedIndex = -1;
        }



        private void CargarAlojamientosPorPais(int idPais)
        {
            var alojamientos = alojamientoLN.ViewAlojamiento().Where(a => a.IdPais == idPais).ToList();
            comboBox3.DataSource = alojamientos;
            comboBox3.DisplayMember = "Nombre";
            comboBox3.ValueMember = "IdAulaVirtual";
            comboBox3.SelectedIndex = -1;
        }

        private void CargarActividadesPorPais(int idPais)
        {
            var actividades = actividadLN.ViewActividad().Where(a => a.IdPais == idPais).ToList();
            comboBox4.DataSource = actividades;
            comboBox4.DisplayMember = "NombreModulo";
            comboBox4.ValueMember = "IdModuloCurso";
            comboBox4.SelectedIndex = -1;
        }

        public void setDatos()
        {
            try
            {
                textBox1.ReadOnly = true;
                textBox1.Text = auxiliar.IdCurso.ToString();
                textBox2.Text = auxiliar.NombreCurso;
                textBox3.Text = auxiliar.Requisitos;
                textBox4.Text = auxiliar.Descripcion;

                // 🔹 Cargar Transportes y Destinos antes de asignar valores
                CargarTransportes();
                CargarDestinos();

                // 🔹 Buscar y seleccionar valores en los ComboBox correctamente
                int indexTransporte = comboBox1.FindStringExact(auxiliar.TipoRecurso);
                if (indexTransporte >= 0) comboBox1.SelectedIndex = indexTransporte;

                int indexDestino = comboBox2.FindStringExact(auxiliar.NombreEspecilidad);
                if (indexDestino >= 0) comboBox2.SelectedIndex = indexDestino;

                // 🔹 Obtener ID del país para filtrar alojamientos y actividades
                if (comboBox2.SelectedValue != null && int.TryParse(comboBox2.SelectedValue.ToString(), out int idDestino))
                {
                    int idPais = destinoLN.ObtenerIdPais(idDestino);

                    // 🔹 Cargar alojamientos y actividades según el país del destino
                    CargarAlojamientosPorPais(idPais);
                    CargarActividadesPorPais(idPais);

                    // 🔹 Buscar y seleccionar Alojamiento y Actividad
                    int indexAlojamiento = comboBox3.FindStringExact(auxiliar.NombreAulaVirtual);
                    if (indexAlojamiento >= 0) comboBox3.SelectedIndex = indexAlojamiento;

                    int indexActividad = comboBox4.FindStringExact(auxiliar.NombreModuloCurso);
                    if (indexActividad >= 0) comboBox4.SelectedIndex = indexActividad;
                }
                else
                {
                    MessageBox.Show("Error al obtener el ID del destino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // 🔹 Asignar subtotal y descuento
                textBox5.Text = auxiliar.Subtotal.ToString("0.00");
                textBox6.Text = auxiliar.Descuento.ToString("0.00");

                // 🔹 Actualizar los totales
                ActualizarTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Curso CrearObjeto()
        {
            int idPaquete = int.Parse(textBox1.Text);
            string nombre = textBox2.Text;
            string requisitos = textBox3.Text;
            int idTransporte = (int)comboBox1.SelectedValue;
            int idDestino = (int)comboBox2.SelectedValue;
            int idAlojamiento = (int)comboBox3.SelectedValue;
            int idActividad = comboBox4.SelectedValue != null ? (int)comboBox4.SelectedValue : 0;
            string descripcion = textBox4.Text;

            decimal subtotal = paqueteLN.CalcularSubtotal(idTransporte, idDestino, idAlojamiento, idActividad);
            decimal totalConDescuento = paqueteLN.CalcularDescuento(subtotal, idActividad);

            return new Curso(idPaquete, nombre, subtotal, totalConDescuento, requisitos, idTransporte, idDestino, idAlojamiento, idActividad, descripcion);
        }

        public bool validar()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(textBox1.Text, out int id) || id < 0)
            {
                MessageBox.Show("El ID del paquete debe ser un número válido y positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 ||
                comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar todas las opciones del paquete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public void guardar()
        {
            if (validar())
            {
                if (label1.Text == "Ingresar Paquete")
                {
                    if (paqueteLN.VerificarPaquete(int.Parse(textBox1.Text)))
                    {
                        MessageBox.Show("El ID del paquete ya existe. Ingrese un ID diferente.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ActualizarTotales()
        {
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null &&
                comboBox3.SelectedValue != null)
            {
                int idTransporte = (int)comboBox1.SelectedValue;
                int idDestino = (int)comboBox2.SelectedValue;
                int idAlojamiento = (int)comboBox3.SelectedValue;
                int? idActividad = comboBox4.SelectedValue != null ? (int)comboBox4.SelectedValue : (int?)null;

                decimal subtotal = paqueteLN.CalcularSubtotal(idTransporte, idDestino, idAlojamiento, idActividad);
                decimal descuento = paqueteLN.CalcularDescuento(subtotal, idActividad);
                decimal totalFinal = subtotal - descuento;

                textBox5.Text = totalFinal.ToString("0.00"); // 🔹 Monto final después del descuento
                textBox6.Text = descuento.ToString("0.00");  // 🔹 Monto del descuento aplicado
            }
        }


        private void editCurso_Load(object sender, EventArgs e)
        {
            CargarDestinos();
            CargarTransportes();

            comboBoxCargado = true;

            if (auxiliar != null)
            {
                setDatos();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (!comboBoxCargado || comboBox2.SelectedValue == null)
                return;

            if (comboBox2.SelectedValue is int idDestino)
            {
                int idPais = destinoLN.ObtenerIdPais(idDestino);
                if (idPais > 0)
                {
                    CargarAlojamientosPorPais(idPais);
                    CargarActividadesPorPais(idPais);
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

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
