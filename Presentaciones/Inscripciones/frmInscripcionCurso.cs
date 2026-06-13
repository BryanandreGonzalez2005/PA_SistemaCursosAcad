using Entidades.ClasesPersonalizadas;
using Entidades.Inventario;
using Logica.ClasesPersonalizadas;
using PA_SistemaCursosAcad.ClasesPersonalizadas;
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
    public partial class frmInscripcionCurso : Form
    {
        public frmInscripcionCurso()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
        }

        public CursoPersonalizado auxiliar;
        InscripcionCursoLN oln = new InscripcionCursoLN();
        private string control = "";

        private void frmInscripcionCurso_Load(object sender, EventArgs e)
        {
            setDatos();
            listar();
            manejarBotones("Inicio");

            txtId.Enabled = false;
            txtReserva.Enabled = false;
            txtNombres.Enabled = false;
            button1.Enabled = true;
            dateTimePicker1.Enabled = false;
        }

        public void listar()
        {
            dataGridView1.DataSource = oln.ViewReservaPaquete(auxiliar.IdCurso);
        }

        public void setDatos()
        {
            txtId.Text = auxiliar.IdCurso.ToString();
            txtNombres.Text = auxiliar.NombreCurso;
        }

        public void manejarBotones(string boton)
        {
            toolStripGuardar.Enabled = false;
            toolStripSalir.Enabled = false;
            toolStripNuevo.Enabled = false;
            toolStrimEliminar.Enabled = false;
            toolStripModificar.Enabled = false;
            button1.Enabled = false;

            switch (boton)
            {
                case "Inicio":
                case "Guardar":
                    toolStripSalir.Enabled = true;
                    toolStripNuevo.Enabled = true;
                    toolStrimEliminar.Enabled = true;
                    toolStripModificar.Enabled = true;
                    break;
                case "Modificar":
                    toolStripGuardar.Enabled = true;
                    txtReserva.Enabled = true; // Habilitar edición del ID reserva
                    button1.Enabled = true;
                    dateTimePicker1.Enabled = true;
                    break;
                case "Eliminar":
                    toolStripSalir.Enabled = true;
                    toolStripNuevo.Enabled = true;
                    toolStrimEliminar.Enabled = true;
                    toolStripModificar.Enabled = true;
                    break;
                case "Nuevo":
                    toolStripGuardar.Enabled = true;
                    toolStrimEliminar.Enabled = true;
                    toolStripModificar.Enabled = true;
                    txtReserva.Text = "";
                    txtReserva.Enabled = true; // 🔹 Permitir ingresar un nuevo ID de reserva
                    button1.Enabled = true;
                    dateTimePicker1.Enabled = true;
                    break;
                case "Salir":
                    Close();
                    break;
            }
        }

        private void toolStripNuevo_Click(object sender, EventArgs e)
        {
            manejarBotones("Nuevo");
            control = "Insertar";
        }

        private void toolStripModificar_Click(object sender, EventArgs e)
        {
            manejarBotones("Modificar");
            control = "Modificar";

            try
            {
                InscripcionCursoPersonalizado op = dataGridView1.CurrentRow.DataBoundItem as InscripcionCursoPersonalizado;
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una fila para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                txtId.Text = op.IdCurso.ToString();
                txtReserva.Text = op.IdInscripcion.ToString();
                dateTimePicker1.Value = op.FechaPago;
                comboBox1.SelectedItem = op.MetodoPago;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtReserva.Text))
                {
                    MessageBox.Show("Debe asignar una Inscripcion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idPaquete = int.Parse(txtId.Text);
                int idReserva = int.Parse(txtReserva.Text);
                DateTime fechaPago = dateTimePicker1.Value;
                string metodoPago = comboBox1.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(metodoPago))
                {
                    MessageBox.Show("Seleccione un método de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Console.WriteLine($"Guardando Inscripcion: IdCurso={idPaquete}, IdInscripcion={idReserva}, FechaPago={fechaPago}, MetodoPago={metodoPago}");

                InscripcionCurso nuevaReserva = oln.GenerarReserva(idPaquete, idReserva, fechaPago, metodoPago);

                if (control == "Modificar")
                {
                    int idReservaActual = int.Parse(dataGridView1.CurrentRow.Cells["IdInscripcion"].Value.ToString());  // Obtener la reserva actual
                    int idReservaNueva = int.Parse(txtReserva.Text);  // Nuevo ID de reserva

                    // 🔹 Obtener los valores directamente desde la tabla
                    decimal subTotal = decimal.Parse(dataGridView1.CurrentRow.Cells["subTotal"].Value.ToString());
                    decimal iva = decimal.Parse(dataGridView1.CurrentRow.Cells["iva"].Value.ToString());
                    decimal totalPagar = decimal.Parse(dataGridView1.CurrentRow.Cells["TotalPagar"].Value.ToString());

                    bool actualizado = oln.UpDateProductoProveedor(
                        idPaquete,
                        idReservaActual,
                        idReservaNueva,
                        fechaPago,
                        subTotal,
                        metodoPago,
                        iva,
                        totalPagar
                    );

                    Console.WriteLine("Modificación ejecutada: " + actualizado);
                }

                else if (control == "Insertar")
                {
                    bool insertado = oln.CreateProductoProveedor(nuevaReserva);
                    Console.WriteLine("Inserción ejecutada: " + insertado);
                }

                listar();
                manejarBotones("Guardar");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la Inscripcion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStrimEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var res = MessageBox.Show("¿Desea eliminar esta Inscripcion?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    InscripcionCursoPersonalizado op = dataGridView1.CurrentRow.DataBoundItem as InscripcionCursoPersonalizado;
                    if (op == null) throw new Exception("Seleccione una fila para eliminar.");

                    InscripcionCurso occ = new InscripcionCurso(op.IdCurso, op.IdInscripcion, op.FechaPago, op.SubTotal, op.MetodoPago, op.Iva, op.TotalPagar);
                    oln.DeleteProductoProveedor(occ);
                    listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripSalir_Click(object sender, EventArgs e)
        {
            manejarBotones("Salir");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsignarInscripcion frm = new AsignarInscripcion();
            frm.ShowDialog();

            if (frm.op != null)  // Si se seleccionó una reserva
            {
                var reservaSeleccionada = frm.op;

                // 🔹 Obtener el alojamiento del paquete
                var alojamiento = InscripcionCursoCD.ObtenerAlojamientoPorPaquete(auxiliar.IdCurso);

                if (alojamiento != null)
                {
                    // 🔹 Calcular la duración de la reserva
                    int diasReserva = (reservaSeleccionada.FechaFin - reservaSeleccionada.FechaInicio).Days;

                    // 🔹 Validar que coincida con la duración del alojamiento
                    if (diasReserva == alojamiento.DuracionDisponibilidad)
                    {
                        txtReserva.Text = reservaSeleccionada.IdInscripcion.ToString();
                    }
                    else
                    {
                        MessageBox.Show($"La duración de la Inscripcion ({diasReserva} días) no coincide con ({alojamiento.DuracionDisponibilidad} días).",
                                        "Error de duración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró un CURSO.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una Inscripcion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
