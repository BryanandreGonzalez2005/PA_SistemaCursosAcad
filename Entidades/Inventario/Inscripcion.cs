using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Inventario
{
    public class Inscripcion
    {
        private int idInscripcion;
        private DateTime fechaInscripcion;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private int cantHorasTeoricas;
        private int cantHorasPracticas;
        private int idAlumno;

        public Inscripcion()
        {
        }

        public Inscripcion(int idInscripcion)
        {
            this.idInscripcion = idInscripcion;
        }

        public Inscripcion(int idInscripcion, DateTime fechaInscripcion, DateTime fechaInicio, DateTime fechaFin, int cantHorasTeoricas, int cantHorasPracticas, int idAlumno)
        {
            this.idInscripcion = idInscripcion;
            this.fechaInscripcion = fechaInscripcion;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.cantHorasTeoricas = cantHorasTeoricas;
            this.cantHorasPracticas = cantHorasPracticas;
            this.idAlumno = idAlumno;
        }

        public int IdInscripcion { get => idInscripcion; set => idInscripcion = value; }
        public DateTime FechaInscripcion { get => fechaInscripcion; set => fechaInscripcion = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public int CantHorasTeoricas { get => cantHorasTeoricas; set => cantHorasTeoricas = value; }
        public int CantHorasPracticas { get => cantHorasPracticas; set => cantHorasPracticas = value; }
        public int IdAlumno { get => idAlumno; set => idAlumno = value; }
    }
}
