using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_SistemaCursosAcad.Inventario
{
    public class CiudadCD
    {
        public static List<CP_ListarCiudadPaisFiltroResult> listarCiudadFiltro(string val)
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.CP_ListarCiudadPaisFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Ciudad filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<Ciudad> listarCiudad()
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.Ciudad.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar la tabla Ciudad", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void insertarCiudad(Entidades.Inventario.Ciudad obj)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPInsertarCiudad(obj.IdCiudad, obj.IdPais, obj.Nombre, obj.Descripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Ciudad", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void modificarCiudad(Entidades.Inventario.Ciudad obj)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPAactualizarCiudad(obj.IdCiudad, obj.IdPais, obj.Nombre, obj.Descripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar tabla Ciudad", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void eliminarCiudad(Entidades.Inventario.Ciudad opr)
        {

            DBCursoDataContext DB = null;

            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPEliminarCiudad(opr.IdCiudad);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla Ciudad", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
