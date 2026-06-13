using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Inventario
{
    public class Paises
    {
        private int idPais;
        private string nombre;
        private string descripcion;

        public Paises()
        {
        }

        public Paises(int idPais, string nombre, string descripcion)
        {
            this.IdPais = idPais;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public int IdPais { get => idPais; set => idPais = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
