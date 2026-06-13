using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesPersonalizadas
{
    public class EspecialidadPersonalizado
    {
        private int idEspecilidad;
        private string nombreEspecialidad;
        private string descripcion;
        private string pais;
        private string tipoEspecilidad;
        private decimal costo;

        public EspecialidadPersonalizado()
        {
        }

        public EspecialidadPersonalizado(int idEspecilidad,
            string nombreEspecialidad, string descripcion, string pais, string tipoEspecilidad, decimal costo)
        {
            this.idEspecilidad = idEspecilidad;
            this.nombreEspecialidad = nombreEspecialidad;
            this.descripcion = descripcion;
            this.pais = pais;
            this.tipoEspecilidad = tipoEspecilidad;
            this.costo = costo;
        }

        public int IdEspecilidad { get => idEspecilidad; set => idEspecilidad = value; }
        public string NombreEspecialidad { get => nombreEspecialidad; set => nombreEspecialidad = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Pais { get => pais; set => pais = value; }
        public string TipoEspecilidad { get => tipoEspecilidad; set => tipoEspecilidad = value; }
        public decimal Costo { get => costo; set => costo = value; }
    }
}
