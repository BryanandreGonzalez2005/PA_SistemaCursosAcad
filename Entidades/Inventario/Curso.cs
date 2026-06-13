using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Inventario
{
    public class Curso
    {
        private int idCurso;
        private string nombreCurso;
        private decimal subtotal;
        private decimal descuento;
        private string requisitos;
        private int idRecurso;
        private int idEspecialidad;
        private int idAulasVirtual;
        private int idModuloCurso;
        private string descripcion;

        public Curso()
        {
        }

        public Curso(int idCurso, string nombreCurso, decimal subtotal, decimal descuento, string requisitos, int idRecurso, int idEspecialidad, int idAulasVirtual, int idModuloCurso, string descripcion)
        {
            this.idCurso = idCurso;
            this.nombreCurso = nombreCurso;
            this.subtotal = subtotal;
            this.descuento = descuento;
            this.requisitos = requisitos;
            this.idRecurso = idRecurso;
            this.idEspecialidad = idEspecialidad;
            this.idAulasVirtual = idAulasVirtual;
            this.idModuloCurso = idModuloCurso;
            this.descripcion = descripcion;
        }

        public int IdCurso { get => idCurso; set => idCurso = value; }
        public string NombreCurso { get => nombreCurso; set => nombreCurso = value; }
        public decimal Subtotal { get => subtotal; set => subtotal = value; }
        public decimal Descuento { get => descuento; set => descuento = value; }
        public string Requisitos { get => requisitos; set => requisitos = value; }
        public int IdRecurso { get => idRecurso; set => idRecurso = value; }
        public int IdEspecialidad { get => idEspecialidad; set => idEspecialidad = value; }
        public int IdAulasVirtual { get => idAulasVirtual; set => idAulasVirtual = value; }
        public int IdModuloCurso { get => idModuloCurso; set => idModuloCurso = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
