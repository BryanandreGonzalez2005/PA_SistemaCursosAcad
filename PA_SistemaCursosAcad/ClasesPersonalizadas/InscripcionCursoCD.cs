using PA_SistemaCursosAcad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_SistemaCursosAcad.ClasesPersonalizadas
{
    public class InscripcionCursoCD
    {
        public static List<CPV_ListarInscripcionCursoResult> listarInscripcionCurso(int id)
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.CPV_ListarInscripcionCurso(id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar InscripcionCurso", ex);
            }
            finally
            {
                DB = null;
            }

        }
        public static List<Entidades.Inventario.InscripcionCurso> listarInscripcionCursoP()
        {
            DBCursoDataContext DB = null;
            try
            {
                using (DB = new DBCursoDataContext())
                {
                    return DB.Inscripcion_Curso.Select(rp => new Entidades.Inventario.InscripcionCurso
                    {
                        IdCurso = rp.idCurso,
                        IdInscripcion = rp.idInscripcion,
                        FechaPago = (DateTime)rp.FechaPago,
                        SubTotal = rp.SubTotal,
                        MetodoPago = rp.MetodoPago,
                        Iva = rp.Iva,
                        TotalPagar = rp.TotalPagar
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar la tabla", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void insertarReservaPaquete(Entidades.Inventario.InscripcionCurso obj)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPInsertarInscripcionCurso(obj.IdCurso, obj.IdInscripcion, obj.FechaPago, obj.SubTotal, obj.MetodoPago, obj.Iva, obj.TotalPagar);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Reserva Paquete", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void modificarReservaPaquete(int idPaquete, int idReservaActual, int idReservaNueva, DateTime fechaPago, decimal subTotal, string metodoPago, decimal iva, decimal totalPagar)
        {
            using (DBCursoDataContext DB = new DBCursoDataContext())
            {
                DB.CPAactualizarInscripcionCurso(idPaquete, idReservaActual, idReservaNueva, fechaPago, subTotal, metodoPago, iva, totalPagar);
                DB.SubmitChanges();
            }
        }

        public static void eliminarReservaPaquete(Entidades.Inventario.InscripcionCurso obj)
        {
            DBCursoDataContext DB = null;
            try
            {
                using (DB = new DBCursoDataContext())
                {
                    DB.CPEliminarInscripcionCurso(obj.IdCurso, obj.IdInscripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla Reserva Paquete", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static Inscripcion ObtenerReserva(int idReserva)
        {
            using (var db = new DBCursoDataContext())
            {
                return db.Inscripcion.FirstOrDefault(r => r.idInscripcion == idReserva);
            }
        }

        // 🔹 Método para obtener un paquete específico
        public static Curso ObtenerPaquete(int idPaquete)
        {
            using (var db = new DBCursoDataContext())
            {
                return db.Curso.FirstOrDefault(p => p.idCurso == idPaquete);
            }
        }
        public static AulasVital ObtenerAlojamientoPorPaquete(int idPaquete)
        {
            using (var db = new DBCursoDataContext())
            {
                return (from curso in db.Curso
                        join aula in db.AulasVital on curso.idAulaVirtual equals aula.idAulaVirtual
                        where curso.idCurso == idPaquete
                        select aula).FirstOrDefault();
            }
        }
    }
}
