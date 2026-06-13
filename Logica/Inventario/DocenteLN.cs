using PA_SistemaCursosAcad;
using PA_SistemaCursosAcad.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Inventario
{
    public class DocenteLN
    {
        public List<Entidades.Inventario.Docente> ViewCompañia()
        {
            List<Entidades.Inventario.Docente> lista = new List<Entidades.Inventario.Docente>();
            Entidades.Inventario.Docente oc;
            try
            {
                List<PA_SistemaCursosAcad.Proveedor> auxLista = DocenteCD.listarCompañia();
                foreach (PA_SistemaCursosAcad.Proveedor obj in auxLista)
                {
                    oc = new Entidades.Inventario.Docente(obj.idProveedor, obj.Ruc, obj.Nombre, obj.Tipo, obj.Direccion, obj.Email, obj.Telefono);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Compañia de la tabla de BD", ex);
            }
            finally
            {

            }
            return lista;
        }
        public List<Entidades.Inventario.Docente> ViewCompañiaFiltro(string valor)
        {
            List<Entidades.Inventario.Docente> lista = new List<Entidades.Inventario.Docente>();
            Entidades.Inventario.Docente oc;

            try
            {
                List<CP_ListarProveedorFiltroResult> auxLista = DocenteCD.listarCompañiaFiltro(valor);
                foreach (CP_ListarProveedorFiltroResult obj in auxLista)
                {
                    oc = new Entidades.Inventario.Docente(obj.idProveedor, obj.Ruc, obj.Nombre, obj.Tipo, obj.Direccion, obj.Email, obj.Telefono);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Compañia con procedimiento almacenado", ex);
            }
            finally
            {

            }
            return lista;
        }

        public bool VerificarCompañia(int idCompañia)
        {
            List<Entidades.Inventario.Docente> compañias = ViewCompañia();

            return compañias.Any(c => c.IdProveedor == idCompañia);
        }

        public bool CreateCompañia(Entidades.Inventario.Docente oa)
        {
            try
            {
                DocenteCD.InsertarCompañia(oa);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar Compañia en la BD", ex);
            }
        }

        public bool UpdateCompañia(Entidades.Inventario.Docente oa)
        {
            try
            {
                DocenteCD.ModificarCompañia(oa);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar Compañia en la BD");
            }
        }
        public bool DeleteCompañia(Entidades.Inventario.Docente oa)
        {

            try
            {
                DocenteCD.EliminarCompañia(oa);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Compañia en la BD");
            }
        }
    }
}
