using Entidades.ClasesPersonalizadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_SistemaCursosAcad.Inventario
{
    public class CursoCD
    {
        public static List<CP_ListarCursoFiltroResult> listarPaqueteFiltro(string val)
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.CP_ListarCursoFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Paquete filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<Curso> listarPaquete()
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.Curso.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar la tabla Paquete", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void insertarPaquete(Entidades.Inventario.Curso obj)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPInsertarCurso(obj.IdCurso, obj.NombreCurso, obj.Subtotal, obj.Descuento, obj.Requisitos, obj.IdRecurso, obj.IdEspecialidad, obj.IdAulasVirtual, obj.IdModuloCurso, obj.Descripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Paquete", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void modificarPaquete(Entidades.Inventario.Curso obj)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPAactualizarCurso(obj.IdCurso, obj.NombreCurso, obj.Subtotal, obj.Descuento, obj.Requisitos, obj.IdRecurso, obj.IdEspecialidad, obj.IdAulasVirtual, obj.IdModuloCurso, obj.Descripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar tabla Paquete", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void eliminarPaquete(Entidades.Inventario.Curso opr)
        {

            DBCursoDataContext DB = null;

            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPEliminarCurso(opr.IdCurso);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla Paquete", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static decimal ObtenerCostoTransporte(int idTransporte)
        {
            using (DBCursoDataContext db = new DBCursoDataContext())
            {
                return db.RecursoDidactico.Where(t => t.idRecurso == idTransporte)
                                    .Select(t => t.CostoUnitario)
                                    .FirstOrDefault();
            }
        }

        public static decimal ObtenerCostoDestino(int idDestino)
        {
            using (DBCursoDataContext db = new DBCursoDataContext())
            {
                return db.Especialidad.Where(d => d.idEspecialidad == idDestino)
                                 .Select(d => d.Costo)
                                 .FirstOrDefault();
            }
        }

        public static decimal ObtenerCostoAlojamiento(int idAlojamiento)
        {
            using (DBCursoDataContext db = new DBCursoDataContext())
            {
                return db.AulasVital.Where(a => a.idAulaVirtual == idAlojamiento)
                                     .Select(a => a.SubTotal)
                                     .FirstOrDefault();
            }
        }

        public static decimal ObtenerCostoActividad(int? idActividad)
        {
            using (DBCursoDataContext db = new DBCursoDataContext())
            {
                return idActividad.HasValue
                    ? db.ModuloCurso.Where(act => act.idModuloCurso == idActividad)
                                  .Select(act => act.CostoModulo)
                                  .FirstOrDefault()
                    : 0;
            }
        }

        public static List<CursoDTO> listarCursosPorAlumno(int idAlumno)
        {
            using (var db = new DBCursoDataContext())
            {
                var cursos = (from v in db.V_InscripcionCursoPLUS
                              where v.idAlumno == idAlumno
                              select new CursoDTO
                              {
                                  IdCurso = v.idCurso,
                                  NombreCurso = v.NombreCurso
                              }).Distinct().ToList();

                return cursos;
            }
        }


        public CertificadoDTO ObtenerCertificadoPorAlumno(int idAlumno)
        {
            using (var db = new DBCursoDataContext())
            {
                var resultado = db.ExecuteQuery<CertificadoDTO>(
                    "EXEC CP_ObtenerCertificadoPorAlumno @idAlumno={0}", idAlumno).FirstOrDefault();

                return resultado;
            }
        }

        public static bool RegistrarNotaYGenerarCertificado(int idAlumno, int idCurso, decimal notaFinal)
        {
            using (var db = new DBCursoDataContext())
            {
                try
                {
                    // Insertar en NotaFinalCurso
                    NotaFinalCurso nuevaNota = new NotaFinalCurso
                    {
                        idAlumno = idAlumno,
                        idCurso = idCurso,
                        NotaFinal = notaFinal
                    };

                    db.NotaFinalCurso.InsertOnSubmit(nuevaNota);
                    db.SubmitChanges();

                    // Si nota >= 7, se genera el certificado
                    if (notaFinal >= 7)
                    {
                        CertificadoCurso nuevoCert = new CertificadoCurso
                        {
                            idNotaCurso = nuevaNota.idNotaFinal,
                            FechaEmisicion = DateTime.Now,
                            CodigoVerificacion = Guid.NewGuid().ToString().Substring(0, 8), // código único
                            URLDocumento = $"https://certificados.micurso.com/certificado/{nuevaNota.idNotaFinal}" // ejemplo
                        };

                        db.CertificadoCurso.InsertOnSubmit(nuevoCert);
                        db.SubmitChanges();
                    }

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static string RegistrarNotaFinal(int idAlumno, int idCurso, decimal notaFinal)
        {
            try
            {
                using (var db = new DBCursoDataContext())
                {
                    db.ExecuteCommand("EXEC CP_RegistrarNotaFinal @p0, @p1, @p2", idAlumno, idCurso, notaFinal);
                }

                return "Nota registrada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al registrar nota: " + ex.Message;
            }
        }


    }
}
