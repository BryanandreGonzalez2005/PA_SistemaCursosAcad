using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Inventario
{
    public class Docente
    {
        private int idProveedor;
        private string ruc;
        private string nombre;
        private string tipo;
        private string direccion;
        private string email;
        private int telefono;

        public Docente()
        {
        }

        public Docente(int idProveedor, string ruc, string nombre, string tipo, string direccion, string email, int telefono)
        {
            this.idProveedor = idProveedor;
            this.ruc = ruc;
            this.nombre = nombre;
            this.tipo = tipo;
            this.direccion = direccion;
            this.email = email;
            this.telefono = telefono;
        }
        public int IdProveedor { get => idProveedor; set => idProveedor = value; }
        public string Ruc { get => ruc; set => ruc = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Email { get => email; set => email = value; }
        public int Telefono { get => telefono; set => telefono = value; }
    }



}
