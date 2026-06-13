using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_SistemaCursosAcad.Inventario
{
    public class RecursoDidacticoCD
    {
        public static List<CP_ListarRecursoProveedorFiltroResult> listarTransporteFiltro(string val)
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.CP_ListarRecursoProveedorFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Transporte filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<RecursoDidactico> listarTransporte()
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.RecursoDidactico.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar la tabla Transporte", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void insertarTransportes(Entidades.Inventario.RecursoDidactico obj)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPInsertarRecursoDidactico(obj.IdRecurso, obj.IdProveedor, obj.Tipo, obj.CostoUnitario);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Transporte", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void modificarTransporte(Entidades.Inventario.RecursoDidactico obj)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPAactualizarRecursoDidactico(obj.IdRecurso, obj.IdProveedor, obj.Tipo, obj.CostoUnitario);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar tabla Transporte", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void eliminarTransporte(Entidades.Inventario.RecursoDidactico opr)
        {

            DBCursoDataContext DB = null;

            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPEliminarRecursoDidactico(opr.IdRecurso);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla transporte", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
