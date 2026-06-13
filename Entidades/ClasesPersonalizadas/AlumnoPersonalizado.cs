using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesPersonalizadas
{
    public class AlumnoPersonalizado
    {

        private int idAlumno;
        private string cedula;
        private string nombre;
        private string apellido;
        private string ciudad;
        private int telefono;
        private string email;

        public AlumnoPersonalizado()
        {
        }

        public AlumnoPersonalizado(int idAlumno, string cedula, 
            string nombre, string apellido, string ciudad, int telefono, string email)
        {
            this.idAlumno = idAlumno;
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellido = apellido;
            this.ciudad = ciudad;
            this.telefono = telefono;
            this.email = email;
        }

        public int IdAlumno { get => idAlumno; set => idAlumno = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
    }
}
