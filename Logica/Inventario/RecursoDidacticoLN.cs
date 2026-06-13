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
    public class RecursoDidacticoLN
    {
        public List<Entidades.Inventario.RecursoDidactico> ViewTransporte()
        {
            List<Entidades.Inventario.RecursoDidactico> lista = new List<Entidades.Inventario.RecursoDidactico>();
            Entidades.Inventario.RecursoDidactico oc;
            try
            {
                List<PA_SistemaCursosAcad.RecursoDidactico> auxLista = RecursoDidacticoCD.listarTransporte();
                foreach (PA_SistemaCursosAcad.RecursoDidactico obj in auxLista)
                {
                    oc = new Entidades.Inventario.RecursoDidactico(obj.idRecurso, obj.idProveedor, obj.Tipo, obj.CostoUnitario);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Transportees de la tabla de BD", ex);
            }
            finally
            {

            }
            return lista;
        }
        public List<RecursoDidacticoPersonalizado> ViewTransporteFiltro(string valor)
        {
            List<RecursoDidacticoPersonalizado> lista = new List<RecursoDidacticoPersonalizado>();
            RecursoDidacticoPersonalizado oc;

            try
            {
                List<CP_ListarRecursoProveedorFiltroResult> auxLista = RecursoDidacticoCD.listarTransporteFiltro(valor);
                foreach (CP_ListarRecursoProveedorFiltroResult obj in auxLista)
                {
                    oc = new RecursoDidacticoPersonalizado(obj.idRecurso, obj.Proveedor, obj.Tipo, obj.CostoUnitario);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Transporte Filtro con procedimiento almacenado", ex);
            }
            finally
            {

            }
            return lista;
        }

        public bool CreateTransporte(Entidades.Inventario.RecursoDidactico op)
        {
            try
            {
                RecursoDidacticoCD.insertarTransportes(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar la Transporte en la BD");
            }
        }
        public bool UpDateTransporte(Entidades.Inventario.RecursoDidactico op)
        {

            try
            {
                RecursoDidacticoCD.modificarTransporte(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Modificar la Transporte en la BD");
            }
        }
        public bool DeleteTransporte(Entidades.Inventario.RecursoDidactico op)
        {

            try
            {
                RecursoDidacticoCD.eliminarTransporte(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Eliminar la Transporte en la BD");
            }
        }
        public bool VerificarTransporte(int idTransporte)
        {
            List<Entidades.Inventario.RecursoDidactico> Transportes = ViewTransporte();

            return Transportes.Any(c => c.IdRecurso == idTransporte);
        }
    }
}
