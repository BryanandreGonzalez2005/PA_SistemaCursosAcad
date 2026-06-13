using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Inventario
{
    public class RecursoDidactico
    {
        private int idRecurso;
        private int idProveedor;
        private string tipo;
        private decimal costoUnitario;

        public RecursoDidactico()
        {
        }

        public RecursoDidactico(int idRecurso)
        {
            this.idRecurso = idRecurso;
        }

        public RecursoDidactico(int idRecurso, int idProveedor, string tipo, decimal costoUnitario)
        {
            this.idRecurso = idRecurso;
            this.idProveedor = idProveedor;
            this.tipo = tipo;
            this.costoUnitario = costoUnitario;
        }

        public int IdRecurso { get => idRecurso; set => idRecurso = value; }
        public int IdProveedor { get => idProveedor; set => idProveedor = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public decimal CostoUnitario { get => costoUnitario; set => costoUnitario = value; }
    }
}
