using Entidades.ClasesPersonalizadas;
using PA_SistemaCursosAcad;
using PA_SistemaCursosAcad.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Inventario
{
    public class InscripcionLN
    {
        public List<Entidades.Inventario.Inscripcion> ViewReserva()
        {
            List<Entidades.Inventario.Inscripcion> lista = new List<Entidades.Inventario.Inscripcion>();
            Entidades.Inventario.Inscripcion oc;
            try
            {
                List<PA_SistemaCursosAcad.Inscripcion> auxLista = InscripcionCD.listarReserva();
                foreach (PA_SistemaCursosAcad.Inscripcion obj in auxLista)
                {
                    oc = new Entidades.Inventario.Inscripcion(obj.idInscripcion, obj.FechaInscripcion, obj.FechaInicio, obj.FechaFin, obj.CantHorasTeoricas, (int)obj.CatHorasPracticas, obj.idAlumno);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Reservaes de la tabla de BD", ex);
            }
            finally
            {

            }
            return lista;
        }
        public List<InscripcionPersonalizada> ViewReservaFiltro(string valor)
        {
            List<InscripcionPersonalizada> lista = new List<InscripcionPersonalizada>();
            InscripcionPersonalizada oc;

            try
            {
                List<CP_ListarInscripcionAlumnoFiltroResult> auxLista = InscripcionCD.listarReservaFiltro(valor);
                foreach (CP_ListarInscripcionAlumnoFiltroResult obj in auxLista)
                {
                    oc = new InscripcionPersonalizada(obj.idInscripcion, obj.FechaInscripcion, obj.FechaInicio, obj.FechaFin, obj.CantHorasTeoricas, (int)obj.CatHorasPracticas, obj.CedulaAlumno);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Reserva Filtro con procedimiento almacenado", ex);
            }
            finally
            {

            }
            return lista;
        }

        public bool CreateReserva(Entidades.Inventario.Inscripcion op)
        {
            try
            {
                InscripcionCD.insertarReserva(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar la Reserva en la BD");
            }
        }
        public bool UpDateReserva(Entidades.Inventario.Inscripcion op)
        {

            try
            {
                InscripcionCD.modificarReserva(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Modificar la Reserva en la BD");
            }
        }
        public bool DeleteReserva(Entidades.Inventario.Inscripcion op)
        {

            try
            {
                InscripcionCD.eliminarReserva(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Eliminar la Reserva en la BD");
            }
        }
        public bool VerificarReserva(int idc)
        {
            List<Entidades.Inventario.Inscripcion> Reserva = ViewReserva();

            return Reserva.Any(c => c.IdInscripcion == idc);
        }
    }
}
