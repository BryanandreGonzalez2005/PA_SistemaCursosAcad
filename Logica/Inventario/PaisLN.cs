using PA_SistemaCursosAcad.Inventario;
using PA_SistemaCursosAcad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Inventario
{
    public class PaisLN
    {
        public List<Entidades.Inventario.Paises> ViewPaises()
        {
            List<Entidades.Inventario.Paises> lista = new List<Entidades.Inventario.Paises>();
            Entidades.Inventario.Paises oc;
            try
            {
                List<Paises> auxLista = PaisCD.listarPaises();
                foreach (Paises obj in auxLista)
                {
                    oc = new Entidades.Inventario.Paises(obj.idPais, obj.Nombre, obj.Descripcion);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Paises de la tabla de BD", ex);
            }
            finally
            {

            }
            return lista;
        }
        public List<Entidades.Inventario.Paises> ViewPaisesFiltro(string valor)
        {
            List<Entidades.Inventario.Paises> lista = new List<Entidades.Inventario.Paises>();
            Entidades.Inventario.Paises oc;

            try
            {
                List<CP_ListarPaisFiltroResult> auxLista = PaisCD.listarPaisFiltro(valor);
                foreach (CP_ListarPaisFiltroResult obj in auxLista)
                {
                    oc = new Entidades.Inventario.Paises(obj.idPais, obj.Nombre, obj.Descripcion);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Paises con procedimiento almacenado", ex);
            }
            finally
            {

            }
            return lista;
        }

        public bool VerificarPaises(int idPaises)
        {
            List<Entidades.Inventario.Paises> Paisess = ViewPaises();

            return Paisess.Any(c => c.IdPais == idPaises);
        }

        public bool CreatePaises(Entidades.Inventario.Paises oa)
        {
            try
            {
                PaisCD.InsertarPaises(oa);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar Paises en la BD", ex);
            }
        }

        public bool UpdatePaises(Entidades.Inventario.Paises oa)
        {
            try
            {
                PaisCD.ModificarPaises(oa);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar Paises en la BD");
            }
        }
        public bool DeletePaises(Entidades.Inventario.Paises oa)
        {

            try
            {
                PaisCD.EliminarPaises(oa);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Paises en la BD");
            }
        }
    }
}
