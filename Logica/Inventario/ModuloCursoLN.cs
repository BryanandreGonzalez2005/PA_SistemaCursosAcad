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
    public class ModuloCursoLN
    {
        public List<Entidades.Inventario.ModuloCurso> ViewActividad()
        {
            List<Entidades.Inventario.ModuloCurso> lista = new List<Entidades.Inventario.ModuloCurso>();
            Entidades.Inventario.ModuloCurso oc;
            try
            {
                List<PA_SistemaCursosAcad.ModuloCurso> auxLista = ModuloCursoCD.listarActividad();
                foreach (PA_SistemaCursosAcad.ModuloCurso obj in auxLista)
                {
                    oc = new Entidades.Inventario.ModuloCurso(obj.idModuloCurso, obj.NombreModulo, obj.TipoModulo, obj.Descripcion, obj.Duracion, obj.CostoModulo, obj.idPais);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Actividades de la tabla de BD", ex);
            }
            finally
            {

            }
            return lista;
        }
        public List<ModuloPaisPersonalizado> ViewActividadFiltro(string valor)
        {
            List<ModuloPaisPersonalizado> lista = new List<ModuloPaisPersonalizado>();
            ModuloPaisPersonalizado oc;

            try
            {
                List<CP_ListarModuloFiltroResult> auxLista = ModuloCursoCD.listarActividadFiltro(valor);
                foreach (CP_ListarModuloFiltroResult obj in auxLista)
                {
                    oc = new ModuloPaisPersonalizado(obj.idModuloCurso, obj.NombreModulo, obj.TipoModulo, obj.Descripcion, obj.Duracion, obj.CostoModulo, obj.Nombre);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Actividad Filtro con procedimiento almacenado", ex);
            }
            finally
            {

            }
            return lista;
        }

        public bool CreateActividad(Entidades.Inventario.ModuloCurso op)
        {
            try
            {
                ModuloCursoCD.insertarActividades(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar la Actividad en la BD");
            }
        }
        public bool UpDateActividad(Entidades.Inventario.ModuloCurso op)
        {

            try
            {
                ModuloCursoCD.modificarActividad(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Modificar la Actividad en la BD");
            }
        }
        public bool DeleteActividad(Entidades.Inventario.ModuloCurso op)
        {

            try
            {
                ModuloCursoCD.eliminarActividad(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Eliminar la actividad en la BD");
            }
        }
        public bool VerificarActividad(int idActividad)
        {
            List<Entidades.Inventario.ModuloCurso> actividads = ViewActividad();

            return actividads.Any(c => c.IdModuloCurso == idActividad);
        }
    }
}
