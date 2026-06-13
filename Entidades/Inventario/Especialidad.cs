using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Inventario
{
    public class Especialidad
    {
        private int idEspecialidad;
        private string nombreEspecialidad;
        private string descripcion;
        private int idPais;
        private string tipoEspecialidad;
        private decimal costo;

        public Especialidad()
        {
        }

        public Especialidad(int o)
        {
            this.idEspecialidad = o;
        }

        public Especialidad(int idEspecialidad, string nombreEspecialidad, string descripcion, int idPais, string tipoEspecialidad, decimal costo)
        {
            this.idEspecialidad = idEspecialidad;
            this.nombreEspecialidad = nombreEspecialidad;
            this.descripcion = descripcion;
            this.idPais = idPais;
            this.tipoEspecialidad = tipoEspecialidad;
            this.costo = costo;
        }

        public int IdEspecialidad { get => idEspecialidad; set => idEspecialidad = value; }
        public string NombreEspecialidad { get => nombreEspecialidad; set => nombreEspecialidad = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IdPais { get => idPais; set => idPais = value; }
        public string TipoEspecialidad { get => tipoEspecialidad; set => tipoEspecialidad = value; }
        public decimal Costo { get => costo; set => costo = value; }
    }
}
