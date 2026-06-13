using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_SistemaCursosAcad.Inventario
{
    public class AulaVirtualCD
    {
        public static List<CP_ListarAulaInstalacionesFiltroResult> listarAlojamientoFiltro(string val)
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.CP_ListarAulaInstalacionesFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Alojamiento filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<AulasVital> listarAlojamiento()
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.AulasVital.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar la tabla Alojamiento", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void insertarAlojamiento(Entidades.Inventario.AulasVirtual obj)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPInsertarAulaVirtual(obj.IdAulaVirtual, obj.Nombre, obj.Tipo, obj.Categoria, obj.Direccion, obj.PrecioUso, obj.DuracionDisponibilidad, obj.Descripcion, obj.SubTotal, obj.IdPais);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Alojamiento", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void modificarAlojamiento(Entidades.Inventario.AulasVirtual obj)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPAactualizarAulaVirtual(obj.IdAulaVirtual, obj.Nombre, obj.Tipo, obj.Categoria, obj.Direccion, obj.PrecioUso, obj.DuracionDisponibilidad, obj.Descripcion, obj.SubTotal, obj.IdPais);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar tabla Alojamiento", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void eliminarAlojamiento(Entidades.Inventario.AulasVirtual opr)
        {

            DBCursoDataContext DB = null;

            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPEliminarAulaVirtual(opr.IdAulaVirtual);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla Alojamiento", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
