using Entidades.ClasesPersonalizadas;
using PA_SistemaCursosAcad.Inventario;
using PA_SistemaCursosAcad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Inventario
{
    public class CiudadLN
    {
        public List<Entidades.Inventario.Ciudad> ViewCiudad()
        {
            List<Entidades.Inventario.Ciudad> lista = new List<Entidades.Inventario.Ciudad>();
            Entidades.Inventario.Ciudad oc;
            try
            {
                List<Ciudad> auxLista = CiudadCD.listarCiudad();
                foreach (Ciudad obj in auxLista)
                {
                    oc = new Entidades.Inventario.Ciudad(obj.idCiudad, obj.idPais, obj.Nombre, obj.Descripcion);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Ciudades de la tabla de BD", ex);
            }
            finally
            {

            }
            return lista;
        }
        public List<CiudadPersonalizado> ViewCiudadFiltro(string valor)
        {
            List<CiudadPersonalizado> lista = new List<CiudadPersonalizado>();
            CiudadPersonalizado oc;

            try
            {
                List<CP_ListarCiudadPaisFiltroResult> auxLista = CiudadCD.listarCiudadFiltro(valor);
                foreach (CP_ListarCiudadPaisFiltroResult obj in auxLista)
                {
                    oc = new CiudadPersonalizado(obj.idCiudad, obj.Pais, obj.Ciudad, obj.Descripcion);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Ciudad Filtro con procedimiento almacenado", ex);
            }
            finally
            {

            }
            return lista;
        }

        public bool CreateCiudad(Entidades.Inventario.Ciudad op)
        {
            try
            {
                CiudadCD.insertarCiudad(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar la Ciudad en la BD");
            }
        }
        public bool UpDateCiudad(Entidades.Inventario.Ciudad op)
        {

            try
            {
                CiudadCD.modificarCiudad(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Modificar la Ciudad en la BD");
            }
        }
        public bool DeleteCiudad(Entidades.Inventario.Ciudad op)
        {

            try
            {
                CiudadCD.eliminarCiudad(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Eliminar la ciudad en la BD");
            }
        }
        public bool VerificarCiudad(int idc)
        {
            List<Entidades.Inventario.Ciudad> ciudad = ViewCiudad();

            return ciudad.Any(c => c.IdCiudad == idc);
        }

    }
}
