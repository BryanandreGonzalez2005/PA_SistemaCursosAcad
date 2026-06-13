using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesPersonalizadas
{
    public class CiudadPersonalizado
    {
        private int idCiudad;
        private string paises;
        private string nombre;
        private string descripcion;

        public CiudadPersonalizado()
        {
        }

        public CiudadPersonalizado(int idCiudad, string paises, string nombre, string descripcion)
        {
            this.IdCiudad = idCiudad;
            this.Paises = paises;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public int IdCiudad { get => idCiudad; set => idCiudad = value; }
        public string Paises { get => paises; set => paises = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
