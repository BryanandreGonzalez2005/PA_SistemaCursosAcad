using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Inventario
{
    public class Ciudad
    {
        private int idCiudad;
        private int idPais;
        private string nombre;
        private string descripcion;

        public Ciudad()
        {
        }

        public Ciudad(int idCiudad)
        {
            this.idCiudad = idCiudad;
        }

        public Ciudad(int idCiudad, int idPais, string nombre, string descripcion)
        {
            this.IdCiudad = idCiudad;
            this.IdPais = idPais;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public int IdCiudad { get => idCiudad; set => idCiudad = value; }
        public int IdPais { get => idPais; set => idPais = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
