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
    public class EspecialidadLN
    {
        public List<Entidades.Inventario.Especialidad> ViewDestino()
        {
            List<Entidades.Inventario.Especialidad> lista = new List<Entidades.Inventario.Especialidad>();
            Entidades.Inventario.Especialidad oc;
            try
            {
                List<PA_SistemaCursosAcad.Especialidad> auxLista = EspecialidadCD.listarDestino();
                foreach (PA_SistemaCursosAcad.Especialidad obj in auxLista)
                {
                    oc = new Entidades.Inventario.Especialidad(obj.idEspecialidad, obj.NombreEspecialidad, obj.Descripcion
                        , obj.idPais, obj.TipoEspecialidad, obj.Costo);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Destinos de la tabla de BD", ex);
            }
            finally
            {

            }
            return lista;
        }
        public List<EspecialidadPersonalizado> ViewDestinoFiltro(string valor)
        {
            List<EspecialidadPersonalizado> lista = new List<EspecialidadPersonalizado>();
            EspecialidadPersonalizado oc;

            try
            {
                List<CP_ListarEspecialidadFiltroResult> auxLista = EspecialidadCD.listarDestinoFiltro(valor);
                foreach (CP_ListarEspecialidadFiltroResult obj in auxLista)
                {
                    oc = new EspecialidadPersonalizado(obj.idEspecialidad, obj.NombreEspecialidad, obj.Descripcion
                         , obj.Nombre, obj.TipoEspecialidad, obj.Costo);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Destino Filtro con procedimiento almacenado", ex);
            }
            finally
            {

            }
            return lista;
        }

        public bool CreateDestino(Entidades.Inventario.Especialidad op)
        {
            try
            {
                EspecialidadCD.insertarDestino(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar el Destino en la BD");
            }
        }
        public bool UpDateDestino(Entidades.Inventario.Especialidad op)
        {

            try
            {
                EspecialidadCD.modificarDestino(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Modificar el Destino en la BD");
            }
        }
        public bool DeleteDestino(Entidades.Inventario.Especialidad op)
        {

            try
            {
                EspecialidadCD.eliminarDestino(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Eliminar el Destino en la BD");
            }
        }
        public bool VerificarDestino(int idDestino)
        {
            List<Entidades.Inventario.Especialidad> destino = ViewDestino();

            return destino.Any(c => c.IdEspecialidad == idDestino);
        }
        public int ObtenerIdPais(int idDestino)
        {
            var destino = ViewDestino().FirstOrDefault(d => d.IdEspecialidad == idDestino);
            return destino != null ? destino.IdPais : 0;
        }
    }
}
