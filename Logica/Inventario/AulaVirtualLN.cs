using Entidades.ClasesPersonalizadas;
using PA_SistemaCursosAcad;
using PA_SistemaCursosAcad.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logica.Inventario.AulaVirtualLN;

namespace Logica.Inventario
{
    public class AulaVirtualLN
    {
        
            public List<Entidades.Inventario.AulasVirtual> ViewAlojamiento()
            {
                List<Entidades.Inventario.AulasVirtual> lista = new List<Entidades.Inventario.AulasVirtual>();
                Entidades.Inventario.AulasVirtual oc;
                try
                {
                    List<PA_SistemaCursosAcad.AulasVital> auxLista = AulaVirtualCD.listarAlojamiento();
                    foreach (PA_SistemaCursosAcad.AulasVital obj in auxLista)
                    {
                        oc = new Entidades.Inventario.AulasVirtual(obj.idAulaVirtual, obj.Nombre, obj.Tipo, obj.Categoria, obj.Direccion, obj.PrecioUso, obj.DuracionDisponibilidad, obj.Descripcion, obj.SubTotal, obj.idPais);
                        lista.Add(oc);
                    }
                }
                catch (Exception ex)
                {
                    throw new LogicaExcepciones("Error al mostar Alojamientoes de la tabla de BD", ex);
                }
                finally
                {

                }
                return lista;
            }
            public List<AulaVirtualPersonalizado> ViewAlojamientoFiltro(string valor)
            {
                List<AulaVirtualPersonalizado> lista = new List<AulaVirtualPersonalizado>();
                AulaVirtualPersonalizado oc;

                try
                {
                    List<CP_ListarAulaInstalacionesFiltroResult> auxLista = AulaVirtualCD.listarAlojamientoFiltro(valor);
                    foreach (CP_ListarAulaInstalacionesFiltroResult obj in auxLista)
                    {
                        oc = new AulaVirtualPersonalizado(obj.idAulaVirtual, obj.Nombre, obj.Tipo, obj.Categoria, obj.Direccion, obj.PrecioUso, obj.DuracionDisponibilidad, obj.Descripcion, obj.SubTotal, obj.Expr1);
                        lista.Add(oc);
                    }
                }
                catch (Exception ex)
                {
                    throw new LogicaExcepciones("Error al mostar Alojamiento Filtro con procedimiento almacenado", ex);
                }
                finally
                {

                }
                return lista;
            }

            public bool CreateAlojamiento(Entidades.Inventario.AulasVirtual op)
            {
                try
                {
                    op.SubTotal = op.PrecioUso * op.DuracionDisponibilidad;
                    AulaVirtualCD.insertarAlojamiento(op);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new LogicaExcepciones("Error al insertar la Alojamiento en la BD");
                }
            }
            public bool UpDateAlojamiento(Entidades.Inventario.AulasVirtual op)
            {

                try
                {
                    op.SubTotal = op.PrecioUso * op.DuracionDisponibilidad;
                    AulaVirtualCD.modificarAlojamiento(op);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new LogicaExcepciones("Error al Modificar la Alojamiento en la BD");
                }
            }
            public bool DeleteAlojamiento(Entidades.Inventario.AulasVirtual op)
            {

                try
                {
                    AulaVirtualCD.eliminarAlojamiento(op);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new LogicaExcepciones("Error al Eliminar la Alojamiento en la BD");
                }
            }
            public bool VerificarAlojamiento(int idAlojamiento)
            {
                List<Entidades.Inventario.AulasVirtual> Alojamientos = ViewAlojamiento();

                return Alojamientos.Any(c => c.IdAulaVirtual == idAlojamiento);
            }
        }
    
}

