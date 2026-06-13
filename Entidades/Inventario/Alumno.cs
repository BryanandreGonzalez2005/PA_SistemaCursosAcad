using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Inventario
{
    public class Alumno
    {
        private int idAlumno;
        private string cedula;
        private string nombre;
        private string apellido;
        private int idCiudad;
        private int telefono;
        private string email;

        public Alumno()
        {
        }

        public Alumno(int idAlumno)
        {
            this.idAlumno = idAlumno;
        }

        public Alumno(int idAlumno, string cedula, string nombre, string apellido, int idCiudad, int telefono, string email)
        {
            this.idAlumno = idAlumno;
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellido = apellido;
            this.idCiudad = idCiudad;
            this.telefono = telefono;
            this.email = email;
        }

        public int IdAlumno { get => idAlumno; set => idAlumno = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int IdCiudad { get => idCiudad; set => idCiudad = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
    }
}
