using PA_SistemaCursosAcad.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.ClasesPersonalizadas;
using PA_SistemaCursosAcad;

namespace Logica.Inventario
{
    public class CursoLN
    {
        public List<Entidades.Inventario.Curso> ViewPaquete()
        {
            List<Entidades.Inventario.Curso> lista = new List<Entidades.Inventario.Curso>();
            Entidades.Inventario.Curso oc;
            try
            {
                List < Curso > auxLista = CursoCD.listarPaquete();
                foreach (PA_SistemaCursosAcad.Curso obj in auxLista)
                {
                    oc = new Entidades.Inventario.Curso(obj.idCurso, obj.NombreCurso, obj.SubTotal, obj.Descuento, obj.Requisitos, obj.idRecurso, obj.idEspecialidad, obj.idAulaVirtual, (int)obj.idModuloCurso, obj.Descripcion);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Paquetees de la tabla de BD", ex);
            }
            finally
            {

            }
            return lista;
        }
        public List<CursoPersonalizado> ViewPaqueteFiltro(string valor)
        {
            List<CursoPersonalizado> lista = new List<CursoPersonalizado>();
            CursoPersonalizado oc;

            try
            {
                List<CP_ListarCursoFiltroResult> auxLista = CursoCD.listarPaqueteFiltro(valor);
                foreach (CP_ListarCursoFiltroResult obj in auxLista)
                {
                    oc = new CursoPersonalizado(obj.idCurso, obj.NombreCurso, obj.SubTotal, obj.Descuento, obj.Requisitos, obj.Tipo, obj.NombreEspecialidad, obj.Nombre, obj.NombreModulo, obj.Descripcion);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Paquete Filtro con procedimiento almacenado", ex);
            }
            finally
            {

            }
            return lista;
        }

        public bool CreatePaquete(Entidades.Inventario.Curso op)
        {
            try
            {
                decimal subtotal = CalcularSubtotal(op.IdRecurso, op.IdEspecialidad, op.IdAulasVirtual, op.IdModuloCurso);
                decimal descuento = CalcularDescuento(subtotal, op.IdModuloCurso);
                decimal totalFinal = subtotal - descuento;

                op.Subtotal = totalFinal;
                op.Descuento = descuento;
                CursoCD.insertarPaquete(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar la Paquete en la BD");
            }
        }
        public bool UpDatePaquete(Entidades.Inventario.Curso op)
        {

            try
            {
                decimal subtotal = CalcularSubtotal(op.IdRecurso, op.IdEspecialidad, op.IdAulasVirtual, op.IdModuloCurso);
                decimal descuento = CalcularDescuento(subtotal, op.IdModuloCurso);
                decimal totalFinal = subtotal - descuento;

                // 🔹 Actualizar los valores en el objeto
                op.Subtotal = totalFinal;
                op.Descuento = descuento;
                CursoCD.modificarPaquete(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Modificar la Paquete en la BD");
            }
        }
        public bool DeletePaquete(Entidades.Inventario.Curso op)
        {

            try
            {
                CursoCD.eliminarPaquete(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Eliminar la Paquete en la BD");
            }
        }
        public bool VerificarPaquete(int idc)
        {
            List<Entidades.Inventario.Curso> Paquete = ViewPaquete();

            return Paquete.Any(c => c.IdCurso == idc);
        }
        public decimal CalcularSubtotal(int idTransporte, int idDestino, int idAlojamiento, int? idActividad)
        {
            decimal subtotal = 0;

            subtotal += CursoCD.ObtenerCostoTransporte(idTransporte);
            subtotal += CursoCD.ObtenerCostoDestino(idDestino);
            subtotal += CursoCD.ObtenerCostoAlojamiento(idAlojamiento);
            subtotal += idActividad.HasValue ? CursoCD.ObtenerCostoActividad(idActividad.Value) : 0;

            return subtotal;
        }

        public decimal CalcularDescuento(decimal subtotal, int? idActividad)
        {
            return idActividad.HasValue ? subtotal * 0.10m : 0;
        }

        public List<CursoDTO> GetCursosPorAlumno(int idAlumno)
        {
            return CursoCD.listarCursosPorAlumno(idAlumno);
        }

        private CursoCD cd = new CursoCD();

        public CertificadoDTO ObtenerCertificado(int idAlumno)
        {
            return cd.ObtenerCertificadoPorAlumno(idAlumno);
        }

        public bool RegistrarNotaYCertificado(int idAlumno, int idCurso, decimal notaFinal)
        {
            return CursoCD.RegistrarNotaYGenerarCertificado(idAlumno, idCurso, notaFinal);
        }



    }
}
