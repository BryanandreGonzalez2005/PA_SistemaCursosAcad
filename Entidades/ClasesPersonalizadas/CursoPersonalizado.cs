using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesPersonalizadas
{
    public class CursoPersonalizado
    {
        private int idCurso;
        private string nombreCurso;
        private decimal subtotal;
        private decimal descuento;
        private string requisitos;
        private string tipoRecurso;
        private string nombreEspecilidad;
        private string nombreAulaVirtual;
        private string nombreModuloCurso;
        private string descripcion;

        public CursoPersonalizado()
        {
        }

        public CursoPersonalizado(int idCurso, string nombreCurso, decimal subtotal, decimal descuento, string requisitos, string tipoRecurso,
            string nombreEspecilidad, string nombreAulaVirtual, string nombreModuloCurso, string descripcion)
        {
            this.idCurso = idCurso;
            this.nombreCurso = nombreCurso;
            this.subtotal = subtotal;
            this.descuento = descuento;
            this.requisitos = requisitos;
            this.tipoRecurso = tipoRecurso;
            this.nombreEspecilidad = nombreEspecilidad;
            this.nombreAulaVirtual = nombreAulaVirtual;
            this.nombreModuloCurso = nombreModuloCurso;
            this.descripcion = descripcion;
        }

        public int IdCurso { get => idCurso; set => idCurso = value; }
        public string NombreCurso { get => nombreCurso; set => nombreCurso = value; }
        public decimal Subtotal { get => subtotal; set => subtotal = value; }
        public decimal Descuento { get => descuento; set => descuento = value; }
        public string Requisitos { get => requisitos; set => requisitos = value; }
        public string TipoRecurso { get => tipoRecurso; set => tipoRecurso = value; }
        public string NombreEspecilidad { get => nombreEspecilidad; set => nombreEspecilidad = value; }
        public string NombreAulaVirtual { get => nombreAulaVirtual; set => nombreAulaVirtual = value; }
        public string NombreModuloCurso { get => nombreModuloCurso; set => nombreModuloCurso = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
