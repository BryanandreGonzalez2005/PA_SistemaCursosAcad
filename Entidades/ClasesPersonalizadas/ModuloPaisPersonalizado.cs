using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesPersonalizadas
{
    public class ModuloPaisPersonalizado
    {
        private int idModulo;
        private string nombreModulo;
        private string tipoModulo;
        private string descripcion;
        private string duracion;
        private decimal costoModulo;
        private string paises;

        public ModuloPaisPersonalizado()
        {
        }

        public ModuloPaisPersonalizado(int idModulo, string nombreModulo, string tipoModulo, string descripcion, 
            string duracion, decimal costoModulo, string paises)
        {
            this.idModulo = idModulo;
            this.nombreModulo = nombreModulo;
            this.tipoModulo = tipoModulo;
            this.descripcion = descripcion;
            this.duracion = duracion;
            this.costoModulo = costoModulo;
            this.paises = paises;
        }

        public int IdModulo { get => idModulo; set => idModulo = value; }
        public string NombreModulo { get => nombreModulo; set => nombreModulo = value; }
        public string TipoModulo { get => tipoModulo; set => tipoModulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Duracion { get => duracion; set => duracion = value; }
        public decimal CostoModulo { get => costoModulo; set => costoModulo = value; }
        public string Paises { get => paises; set => paises = value; }
    }
}
