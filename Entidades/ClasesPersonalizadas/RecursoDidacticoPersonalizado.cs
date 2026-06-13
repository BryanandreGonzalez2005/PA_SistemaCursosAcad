using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesPersonalizadas
{
    public class RecursoDidacticoPersonalizado
    {
        private int idRecurso;
        private string proveedor;
        private string tipo;
        private decimal costoUnitario;

        public RecursoDidacticoPersonalizado()
        {
        }

        public RecursoDidacticoPersonalizado(int idRecurso, string proveedor, string tipo, decimal costoUnitario)
        {
            this.idRecurso = idRecurso;
            this.proveedor = proveedor;
            this.tipo = tipo;
            this.costoUnitario = costoUnitario;
        }

        public int IdRecurso { get => idRecurso; set => idRecurso = value; }
        public string Proveedor { get => proveedor; set => proveedor = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public decimal CostoUnitario { get => costoUnitario; set => costoUnitario = value; }
    }

}
