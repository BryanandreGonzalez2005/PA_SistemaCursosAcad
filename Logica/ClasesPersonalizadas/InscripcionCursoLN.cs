using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.ClasesPersonalizadas;
using Entidades.Inventario;
using PA_SistemaCursosAcad;
using PA_SistemaCursosAcad.ClasesPersonalizadas;

namespace Logica.ClasesPersonalizadas
{
    public class InscripcionCursoLN
    {
        public List<InscripcionCursoPersonalizado> ViewReservaPaquete(int id)

        {
            List<InscripcionCursoPersonalizado> lista = new List<InscripcionCursoPersonalizado>();
            InscripcionCursoPersonalizado opp;

            try
            {
                List<CPV_ListarInscripcionCursoResult> auxLista = InscripcionCursoCD.listarInscripcionCurso(id);
                foreach (CPV_ListarInscripcionCursoResult obj in auxLista)
                {
                    opp = new InscripcionCursoPersonalizado(obj.idCurso, obj.NombreCurso, obj.idInscripcion, (DateTime)obj.FechaPago, obj.SubTotal, obj.MetodoPago, obj.Iva, obj.TotalPagar);

                    lista.Add(opp);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostrar reserva paquete personalizado con procedimiento almacenado", ex);
            }
            finally
            {

            }
            return lista;
        }
        public List<Entidades.Inventario.InscripcionCurso> viewReservaP()
        {
            List<Entidades.Inventario.InscripcionCurso> lista = new List<Entidades.Inventario.InscripcionCurso>();
            Entidades.Inventario.InscripcionCurso oc;
            try
            {
                List<Entidades.Inventario.InscripcionCurso> auxLista = InscripcionCursoCD.listarInscripcionCursoP();
                foreach (Entidades.Inventario.InscripcionCurso obj in auxLista)
                {
                    oc = new Entidades.Inventario.InscripcionCurso(obj.IdCurso, obj.IdInscripcion, (DateTime)obj.FechaPago, obj.SubTotal, obj.MetodoPago, obj.Iva, obj.TotalPagar);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Reserva-Paquete de la tabla de BD", ex);
            }
            finally
            {

            }
            return lista;
        }

        public bool CreateProductoProveedor(Entidades.Inventario.InscripcionCurso op)
        {
            try
            {
                InscripcionCursoCD.insertarReservaPaquete(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar Reserva Paquete en la BD");
            }
        }
        public bool UpDateProductoProveedor(int idPaquete, int idReservaActual, int idReservaNueva, DateTime fechaPago, decimal subTotal, string metodoPago, decimal iva, decimal totalPagar)
        {
            try
            {
                InscripcionCursoCD.modificarReservaPaquete(idPaquete, idReservaActual, idReservaNueva, fechaPago, subTotal, metodoPago, iva, totalPagar);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar la reserva en la BD: " + ex.Message, ex);
            }
        }

        public bool DeleteProductoProveedor(Entidades.Inventario.InscripcionCurso op)
        {

            try
            {
                InscripcionCursoCD.eliminarReservaPaquete(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Eliminar reserva paquete en la BD");
            }
        }
        public InscripcionCurso GenerarReserva(int idPaquete, int idReserva, DateTime fechaPago, string metodoPago)
        {
            // 🔹 Obtener la cantidad de adultos y niños de la reserva
            var reserva = InscripcionCursoCD.ObtenerReserva(idReserva);
            if (reserva == null)
            {
                throw new Exception("La reserva seleccionada no existe.");
            }

            int cantidadAdultos = reserva.CantHorasTeoricas;
            int cantidadNiños = (int)reserva.CatHorasPracticas;

            // 🔹 Obtener el subtotal del paquete
            var paquete = InscripcionCursoCD.ObtenerPaquete(idPaquete);
            if (paquete == null)
            {
                throw new Exception("El paquete seleccionado no existe.");
            }

            decimal subtotalPaquete = paquete.SubTotal;

            // 🔹 Calcular el subtotal de la reserva
            decimal subtotalReserva = subtotalPaquete * (cantidadAdultos + (cantidadNiños * 0.5m));

            // 🔹 Calcular recargo (5% si el método de pago NO es efectivo)
            decimal recargo = metodoPago != "Efectivo" ? subtotalReserva * 0.05m : 0;

            // 🔹 Calcular el IVA (18% del subtotal con recargo)
            decimal iva = (subtotalReserva + recargo) * 0.18m;

            // 🔹 Calcular el total a pagar
            decimal totalPagar = subtotalReserva + recargo + iva;

            // 🔹 Retornar la reserva ya calculada
            return new InscripcionCurso(idPaquete, idReserva, fechaPago, subtotalReserva, metodoPago, iva, totalPagar);
        }
    }
}
