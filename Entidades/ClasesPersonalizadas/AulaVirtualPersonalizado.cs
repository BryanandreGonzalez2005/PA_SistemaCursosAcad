using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesPersonalizadas
{
    public class AulaVirtualPersonalizado
    {

        private int idAulaVirtual;
        private string nombre;
        private string tipo;
        private string categoria;
        private string direccion;
        private decimal precioUso;
        private int duracionDisponibilidad;
        private string descripcion;
        private decimal subtotal;
        private string paises;

        public AulaVirtualPersonalizado()
        {
        }

        public AulaVirtualPersonalizado(int idAulaVirtual, string nombre, string tipo, string categoria, string direccion, decimal precioUso,
            int duracionDisponibilidad, string descripcion, decimal subtotal, string paises)
        {
            this.idAulaVirtual = idAulaVirtual;
            this.nombre = nombre;
            this.tipo = tipo;
            this.categoria = categoria;
            this.direccion = direccion;
            this.precioUso = precioUso;
            this.duracionDisponibilidad = duracionDisponibilidad;
            this.descripcion = descripcion;
            this.subtotal = subtotal;
            this.paises = paises;
        }

        public int IdAulaVirtual { get => idAulaVirtual; set => idAulaVirtual = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public decimal PrecioUso { get => precioUso; set => precioUso = value; }
        public int DuracionDisponibilidad { get => duracionDisponibilidad; set => duracionDisponibilidad = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Subtotal { get => subtotal; set => subtotal = value; }
        public string Paises { get => paises; set => paises = value; }
    }
}
