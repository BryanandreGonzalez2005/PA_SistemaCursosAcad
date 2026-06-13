using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_SistemaCursosAcad.Inventario
{
    public class PaisCD
    {
        public static List<Paises> listarPaises()
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.Paises.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar la tabla paises", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static List<CP_ListarPaisFiltroResult> listarPaisFiltro(string val)
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.CP_ListarPaisFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Países filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void InsertarPaises(Entidades.Inventario.Paises oc)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPInsertarPais(oc.IdPais, oc.Nombre, oc.Descripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla pais", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarPaises(Entidades.Inventario.Paises oc)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPAactualizarPais(oc.IdPais, oc.Nombre, oc.Descripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar tabla pais", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarPaises(Entidades.Inventario.Paises oc)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPEliminarPais(oc.IdPais);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla pais", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
