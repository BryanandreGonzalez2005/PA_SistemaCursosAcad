using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Inventario
{
    public class AulasVirtual
    {

        private int idAulaVirtual;
        private string nombre;
        private string tipo;
        private string categoria;
        private string direccion;
        private decimal precioUso;
        private int duracionDisponibilidad;
        private string descripcion;
        private decimal subTotal;
        private int idPais;

        public AulasVirtual(int idAulaVirtual)
        {
            this.idAulaVirtual = idAulaVirtual;
        }



        public AulasVirtual(int idAulaVirtual, string nombre, string tipo, string categoria, string direccion, decimal precioUso, int duracionDisponibilidad, string descripcion, decimal subTotal, int idPais)
        {
            this.idAulaVirtual = idAulaVirtual;
            this.nombre = nombre;
            this.tipo = tipo;
            this.categoria = categoria;
            this.direccion = direccion;
            this.precioUso = precioUso;
            this.duracionDisponibilidad = duracionDisponibilidad;
            this.descripcion = descripcion;
            this.subTotal = subTotal;
            this.idPais = idPais;
        }

        public int IdAulaVirtual { get => idAulaVirtual; set => idAulaVirtual = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public decimal PrecioUso { get => precioUso; set => precioUso = value; }
        public int DuracionDisponibilidad { get => duracionDisponibilidad; set => duracionDisponibilidad = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal SubTotal { get => subTotal; set => subTotal = value; }
        public int IdPais { get => idPais; set => idPais = value; }
    }
}
