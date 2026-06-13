using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Inventario
{
    public class Usuario
    {

        private string nombreUsuario;
        private string contraseña;

        public Usuario()
        {
        }

        public Usuario(string nombreUsuario, string contraseña)
        {
            this.NombreUsuario = nombreUsuario;
            this.Contraseña = contraseña;
        }

        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
    }
}
