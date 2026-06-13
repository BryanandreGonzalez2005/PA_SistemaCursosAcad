using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_SistemaCursosAcad.Inventario
{
    public class ModuloCursoCD
    {
        public static List<CP_ListarModuloFiltroResult> listarActividadFiltro(string val)
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.CP_ListarModuloFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Actviidad filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<ModuloCurso> listarActividad()
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.ModuloCurso.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar la tabla Actividad", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void insertarActividades(Entidades.Inventario.ModuloCurso obj)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPInsertarModuloCurso(obj.IdModuloCurso, obj.NombreModulo, obj.TipoModulo, obj.Descripcion, obj.Duracion, obj.CostoModulo, obj.IdPais);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Actividad", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void modificarActividad(Entidades.Inventario.ModuloCurso obj)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPAactualizarModulo(obj.IdModuloCurso, obj.NombreModulo, obj.TipoModulo, obj.Descripcion, obj.Duracion, obj.CostoModulo, obj.IdPais);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar tabla Actividad", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void eliminarActividad(Entidades.Inventario.ModuloCurso opr)
        {

            DBCursoDataContext DB = null;

            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPEliminarModuloCurso(opr.IdModuloCurso);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla actividades", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
