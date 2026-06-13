using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_SistemaCursosAcad.Inventario
{
    public class InscripcionCD
    {
        public static List<CP_ListarInscripcionAlumnoFiltroResult> listarReservaFiltro(string val)
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.CP_ListarInscripcionAlumnoFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Reserva filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<Inscripcion> listarReserva()
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.Inscripcion.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar la tabla Reserva", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void insertarReserva(Entidades.Inventario.Inscripcion obj)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPInsertarInscripcion(obj.IdInscripcion, obj.FechaInscripcion, obj.FechaInicio, obj.FechaFin, obj.CantHorasTeoricas, obj.CantHorasPracticas, obj.IdAlumno);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Reserva", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void modificarReserva(Entidades.Inventario.Inscripcion obj)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPAactualizarInscripcion(obj.IdInscripcion, obj.FechaInscripcion, obj.FechaInicio, obj.FechaFin, obj.CantHorasTeoricas, obj.CantHorasPracticas, obj.IdAlumno);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar tabla Reserva", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void eliminarReserva(Entidades.Inventario.Inscripcion opr)
        {

            DBCursoDataContext DB = null;

            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPEliminarInscripcion(opr.IdInscripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla Reserva", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
