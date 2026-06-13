using Entidades.ClasesPersonalizadas;
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
    public partial class AsignarInscripcion : Form
    {
        public AsignarInscripcion()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
        }

        public InscripcionPersonalizada op;
        InscripcionLN oln = new InscripcionLN();
        public void listar(string val)
        {
            dataGridView1.DataSource = oln.ViewReservaFiltro(val);
        }

        private void AsignarInscripcion_Load(object sender, EventArgs e)
        {
            listar("");
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            InscripcionPersonalizada oc = dataGridView1.CurrentRow.DataBoundItem as InscripcionPersonalizada;
            op = oc;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
