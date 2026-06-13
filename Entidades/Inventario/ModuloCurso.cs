using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Inventario
{
    public class ModuloCurso
    {
        private int idModuloCurso;
        private string nombreModulo;
        private string tipoModulo;
        private string descripcion;
        private string duracion;
        private decimal costoModulo;
        private int idPais;

        public ModuloCurso()
        {
        }

        public ModuloCurso(int idModuloCurso)
        {
            IdModuloCurso = idModuloCurso;
        }

        public ModuloCurso(int idModuloCurso, string nombreModulo, string tipoModulo, string descripcion, string duracion, decimal costoModulo, int idPais)
        {
            this.idModuloCurso = idModuloCurso;
            this.nombreModulo = nombreModulo;
            this.tipoModulo = tipoModulo;
            this.descripcion = descripcion;
            this.duracion = duracion;
            this.costoModulo = costoModulo;
            this.idPais = idPais;
        }

        public int IdModuloCurso { get => idModuloCurso; set => idModuloCurso = value; }
        public string NombreModulo { get => nombreModulo; set => nombreModulo = value; }
        public string TipoModulo { get => tipoModulo; set => tipoModulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Duracion { get => duracion; set => duracion = value; }
        public decimal CostoModulo { get => costoModulo; set => costoModulo = value; }
        public int IdPais { get => idPais; set => idPais = value; }
    }
}
