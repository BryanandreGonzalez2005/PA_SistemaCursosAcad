using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesPersonalizadas
{
    public class InscripcionPersonalizada
    {
        private int idInscripcion;
        private DateTime fechaInscripcion;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private int cantHorasTeoricas;
        private int cantHorasPrecticas;
        private string cedulaAlumno;

        public InscripcionPersonalizada()
        {
        }

        public InscripcionPersonalizada(int idInscripcion, DateTime fechaInscripcion, DateTime fechaInicio, 
            DateTime fechaFin, int cantHorasTeoricas, int cantHorasPrecticas, string cedulaAlumno)
        {
            this.idInscripcion = idInscripcion;
            this.fechaInscripcion = fechaInscripcion;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.cantHorasTeoricas = cantHorasTeoricas;
            this.cantHorasPrecticas = cantHorasPrecticas;
            this.cedulaAlumno = cedulaAlumno;
        }

        public int IdInscripcion { get => idInscripcion; set => idInscripcion = value; }
        public DateTime FechaInscripcion { get => fechaInscripcion; set => fechaInscripcion = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public int CantHorasTeoricas { get => cantHorasTeoricas; set => cantHorasTeoricas = value; }
        public int CantHorasPrecticas { get => cantHorasPrecticas; set => cantHorasPrecticas = value; }
        public string CedulaAlumno { get => cedulaAlumno; set => cedulaAlumno = value; }
    }
}
