using Presentaciones;
using Presentaciones.Formacion;
using Presentaciones.Inscripciones;
using Presentaciones.Recursos;
using Presentaciones.Ubicaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
    public partial class frmMENU_2 : Form
    {
        private string usuario;
        public frmMENU_2(string usuario)
        {

            InitializeComponent();
            this.usuario = usuario;
            typeof(Panel).InvokeMember("DoubleBuffered",
     System.Reflection.BindingFlags.SetProperty |
     System.Reflection.BindingFlags.Instance |
     System.Reflection.BindingFlags.NonPublic,
     null, PanelContenedor, new object[] { true });


        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hWnd, int msg, bool wParam, int lParam);
        private const int WM_SETREDRAW = 11;

        private void SuspenderRedibujado(Control ctrl)
        {
            SendMessage(ctrl.Handle, WM_SETREDRAW, false, 0);
        }

        private void ReanudarRedibujado(Control ctrl)
        {
            SendMessage(ctrl.Handle, WM_SETREDRAW, true, 0);
            ctrl.Refresh();
        }


        private void AbrirFormularioEnPanel(Form formulario, Panel panelContenedor, Panel panelSuperpuesto = null)
        {
            SuspenderRedibujado(panelContenedor);

            foreach (Control ctrl in panelContenedor.Controls)
            {
                if (ctrl is Form) ctrl.Dispose();
            }

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.StartPosition = FormStartPosition.Manual;

            formulario.Load += (s, e) =>
            {
                // Solo se ejecuta cuando el formulario ya se cargó y tiene tamaño real
                formulario.Location = new Point(
                    (panelContenedor.Width - formulario.Width) / 2,
                    (panelContenedor.Height - formulario.Height) / 2
                );
            };

            // Agregar y mostrar

            panelContenedor.Controls.Add(formulario);
            formulario.BringToFront();
            formulario.Show();

            ReanudarRedibujado(panelContenedor);
            // Si hay un panel superpuesto (como un submenú), traerlo al frente
            panelSuperpuesto?.BringToFront();
        }




        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            subMenuReportes.Visible = !subMenuReportes.Visible;
            subMenuReportes.BringToFront();
            subMenu4.Visible = false;
            subMenu2.Visible = false;
            subMenu3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            subMenu2.Visible = true;
            subMenuReportes.Visible = false;
            subMenu4.Visible = false;
            subMenu3.Visible = false;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            subMenu3.Visible = true;
            subMenuReportes.Visible = false;
            subMenu4.Visible = false;
            subMenu2.Visible = false;
        }

    

        private void button3_Click(object sender, EventArgs e)
        {
            subMenu4.Visible = true;
            subMenuReportes.Visible = false;
            subMenu2.Visible = false;
            subMenu3.Visible = false;
        }
        private void MenuBarra_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmMENU_2_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = $"Usuario: {usuario}";
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.Size = new Size(1550, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            adminPais frm = new adminPais();
           
            AbrirFormularioEnPanel(frm, PanelContenedor, subMenuReportes);
            subMenuReportes.Visible = false;
        }

        private void subMenuReportes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            adminCiudades frm = new adminCiudades();

            AbrirFormularioEnPanel(frm, PanelContenedor, subMenuReportes);
            subMenuReportes.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            adminAulaVirtual frm = new adminAulaVirtual();

            AbrirFormularioEnPanel(frm, PanelContenedor, subMenu2);
            subMenu2.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            adminDocente frm = new adminDocente();

            AbrirFormularioEnPanel(frm, PanelContenedor, subMenu2);
            subMenu2.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            adminRecursoDidactico frm = new adminRecursoDidactico();

            AbrirFormularioEnPanel(frm, PanelContenedor, subMenu2);
            subMenu2.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            adminModuloCurso frm = new adminModuloCurso();

            AbrirFormularioEnPanel(frm, PanelContenedor, subMenu3);
            subMenu3.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            adminEspecialidades frm = new adminEspecialidades();

            AbrirFormularioEnPanel(frm, PanelContenedor, subMenu3);
            subMenu3.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            adminAlumno frm = new adminAlumno();

            AbrirFormularioEnPanel(frm, PanelContenedor, subMenu4);
            subMenu4.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            adminCurso frm = new adminCurso();

            AbrirFormularioEnPanel(frm, PanelContenedor, subMenu4);
            subMenu4.Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            adminInscripcion frm = new adminInscripcion();

            AbrirFormularioEnPanel(frm, PanelContenedor, subMenu4);
            subMenu4.Visible = false;
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
