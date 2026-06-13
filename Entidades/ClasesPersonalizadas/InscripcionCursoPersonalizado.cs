using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesPersonalizadas
{
    public class InscripcionCursoPersonalizado
    {
        private int idCurso;
        private string nombreCurso;
        private int idInscripcion;
        private DateTime fechaPago;
        private decimal subTotal;
        private string metodoPago;
        private decimal iva;
        private decimal totalPagar;

        public InscripcionCursoPersonalizado()
        {
        }

        public InscripcionCursoPersonalizado(int idCurso, string nombreCurso, int idInscripcion, 
            DateTime fechaPago, decimal subTotal, string metodoPago, decimal iva, decimal totalPagar)
        {
            this.idCurso = idCurso;
            this.nombreCurso = nombreCurso;
            this.idInscripcion = idInscripcion;
            this.fechaPago = fechaPago;
            this.subTotal = subTotal;
            this.metodoPago = metodoPago;
            this.iva = iva;
            this.totalPagar = totalPagar;
        }

        public int IdCurso { get => idCurso; set => idCurso = value; }
        public string NombreCurso { get => nombreCurso; set => nombreCurso = value; }
        public int IdInscripcion { get => idInscripcion; set => idInscripcion = value; }
        public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }
        public decimal SubTotal { get => subTotal; set => subTotal = value; }
        public string MetodoPago { get => metodoPago; set => metodoPago = value; }
        public decimal Iva { get => iva; set => iva = value; }
        public decimal TotalPagar { get => totalPagar; set => totalPagar = value; }
    }
}
