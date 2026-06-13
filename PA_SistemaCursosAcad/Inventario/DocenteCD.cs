using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_SistemaCursosAcad.Inventario
{
    public class DocenteCD
    {
        public static List<Proveedor> listarCompañia()
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.Proveedor.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar la tabla de compañias", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static List<CP_ListarProveedorFiltroResult> listarCompañiaFiltro(string val)
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.CP_ListarProveedorFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Compañia filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void InsertarCompañia(Entidades.Inventario.Docente oc)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPInsertarProveedor(oc.IdProveedor, oc.Ruc, oc.Nombre, oc.Tipo, oc.Direccion, oc.Email, oc.Telefono);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla compañia", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarCompañia(Entidades.Inventario.Docente oc)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPAactualizarProveedor(oc.IdProveedor, oc.Ruc, oc.Nombre, oc.Tipo, oc.Direccion, oc.Email, oc.Telefono);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar tabla compañia", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarCompañia(Entidades.Inventario.Docente oc)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPEliminarProveedor(oc.IdProveedor);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla compañia", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
