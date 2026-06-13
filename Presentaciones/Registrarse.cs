using Logica.Inventario;
using PA_SistemaCursosAcad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Presentaciones
{
    public partial class Registrarse : Form
    {
        public Registrarse()
        {
            InitializeComponent();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        public void Registrar()
        {
            string nombreUsuario = txtUser.Text.Trim();
            string contraseña = txtCont.Text.Trim();
            string confirmarContraseña = txtConfC.Text.Trim();

            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(confirmarContraseña))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (contraseña != confirmarContraseña)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Usuario  nuevoUsuario = new Usuario(nombreUsuario, contraseña);
                UsuarioLN usuarioLN = new UsuarioLN();

                if (usuarioLN.InsertarUsuario(nuevoUsuario))
                {
                    MessageBox.Show("Usuario registrado con éxito.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar el usuario. Intente nuevamente.", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error durante el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Registrarse_Load(object sender, EventArgs e)
        {

        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCont_Enter(object sender, EventArgs e)
        {
            if (txtCont.Text == "CONTRASEÑA")
            {
                txtCont.Text = "";
                txtCont.ForeColor = Color.Black;
                txtCont.UseSystemPasswordChar = true;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.Black;
            }
        }

        private void txtCont_Leave(object sender, EventArgs e)
        {
            if (txtCont.Text == "")
            {
                txtCont.Text = "CONTRASEÑA";
                txtCont.ForeColor = Color.Black;
                txtCont.UseSystemPasswordChar = false;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (txtConfC.Text == "CONFIRMAR_CONTRASEÑA")
            {
                txtConfC.Text = "";
                txtConfC.ForeColor = Color.Black;
                txtConfC.UseSystemPasswordChar = true;
            }
        }

        private void txtConfC_Leave(object sender, EventArgs e)
        {
            if (txtConfC.Text == "")
            {
                txtConfC.Text = "CONFIRMAR_CONTRASEÑA";
                txtConfC.ForeColor = Color.Black;
                txtConfC.UseSystemPasswordChar = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
