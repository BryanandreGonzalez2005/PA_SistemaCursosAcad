using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_SistemaCursosAcad.Inventario
{
    public class EspecialidadCD
    {
        public static List<CP_ListarEspecialidadFiltroResult> listarDestinoFiltro(string val)
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.CP_ListarEspecialidadFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Destino filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<Especialidad> listarDestino()
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.Especialidad.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar la tabla Destino", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void insertarDestino(Entidades.Inventario.Especialidad obj)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPInsertarEspecialidad(obj.IdEspecialidad, obj.NombreEspecialidad, obj.Descripcion, obj.IdPais, obj.TipoEspecialidad, obj.Costo);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Destino", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void modificarDestino(Entidades.Inventario.Especialidad obj)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPActualizarEspecialidad(obj.IdEspecialidad, obj.NombreEspecialidad, obj.Descripcion, obj.IdPais, obj.TipoEspecialidad, obj.Costo);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar tabla Destino", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void eliminarDestino(Entidades.Inventario.Especialidad opr)
        {

            DBCursoDataContext DB = null;

            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPEliminarEspecialidad(opr.IdEspecialidad);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla Destino", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
