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

namespace Presentaciones
{
    public partial class frmMenu : Form
    {
        private string usuario;
        public frmMenu(string usuario)
        {
            InitializeComponent();
           
            this.usuario = usuario;
            // Configuración del formulario
            this.IsMdiContainer = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Size = new Size(1400, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        private void CerrarFormularios()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }
       

        private void frmMenu_Load(object sender, EventArgs e)
        {
         
            toolStripStatusLabel2.Text = $"Usuario: {usuario}";
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void pAISESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormularios();
            adminPais frm = new adminPais
            {
                MdiParent = this,
                StartPosition = FormStartPosition.Manual,
                Location = new Point(0, 0),
                WindowState = FormWindowState.Maximized

            };
            frm.Show();
        }

        private void cIUDADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormularios();
            adminCiudades frm = new adminCiudades
            {
                MdiParent = this,
                StartPosition = FormStartPosition.Manual,
                Location = new Point(0, 0),
                WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void aulaVirtualInstalacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormularios();
            adminAulaVirtual frm = new adminAulaVirtual
            {
                MdiParent = this,
                StartPosition = FormStartPosition.Manual,
                Location = new Point(0, 0),
                WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void docenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormularios();
            adminDocente frm = new adminDocente
            {
                MdiParent = this,
                StartPosition = FormStartPosition.Manual,
                Location = new Point(0, 0),
                WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void rECURSOSDIDACTICOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormularios();
            adminRecursoDidactico frm = new adminRecursoDidactico
            {
                MdiParent = this,
                StartPosition = FormStartPosition.Manual,
                Location = new Point(0, 0),
                WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void aLUMNOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormularios();
            adminModuloCurso frm = new adminModuloCurso
            {
                MdiParent = this,
                StartPosition = FormStartPosition.Manual,
                Location = new Point(0, 0),
                WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void eSPECIALIDADESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormularios();
            adminEspecialidades frm = new adminEspecialidades
            {
                MdiParent = this,
                StartPosition = FormStartPosition.Manual,
                Location = new Point(0, 0),
                WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void aLUMNOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CerrarFormularios();
            adminAlumno frm = new adminAlumno
            {
                MdiParent = this,
                StartPosition = FormStartPosition.Manual,
                Location = new Point(0, 0),
                WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void cURSOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormularios();
            adminCurso frm = new adminCurso
            {
                MdiParent = this,
                StartPosition = FormStartPosition.Manual,
                Location = new Point(0, 0),
                WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void iNSCRIPCIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormularios();
            adminInscripcion frm = new adminInscripcion
            {
                MdiParent = this,
                StartPosition = FormStartPosition.Manual,
                Location = new Point(0, 0),
                WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
