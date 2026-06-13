using Entidades.ClasesPersonalizadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_SistemaCursosAcad.Inventario
{
    public class AlumnoCD
    {
        public static List<CP_ListarAlumnoFiltroResult> listarClienteFiltro(string val)
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.CP_ListarAlumnoFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar Cliente filtro", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<Alumno> listarCliente()
        {
            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    return DB.Alumno.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar la tabla Cliente", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void insertarCliente(Entidades.Inventario.Alumno obj)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPInsertarAlumno(obj.IdAlumno, obj.Cedula, obj.Nombre, obj.Apellido, obj.IdCiudad, obj.Telefono, obj.Email);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Cliente", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void modificarCliente(Entidades.Inventario.Alumno obj)
        {

            DBCursoDataContext DB = null;
            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPAactualizarAlumno(obj.IdAlumno, obj.Cedula, obj.Nombre, obj.Apellido, obj.IdCiudad, obj.Telefono, obj.Email);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar tabla Cliente", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void eliminarCliente(Entidades.Inventario.Alumno opr)
        {

            DBCursoDataContext DB = null;

            try
            {

                using (DB = new DBCursoDataContext())
                {
                    DB.CPEliminarAlumno(opr.IdAlumno);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla Cliente", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<AlumnoDTO> listarAlumnosConInscripcion()
        {
            using (var db = new DBCursoDataContext())
            {
                var alumnos = (from v in db.V_InscripcionCursoPLUS
                               join a in db.Alumno on v.idAlumno equals a.idAlumno
                               select new AlumnoDTO
                               {
                                   idAlumno = a.idAlumno,
                                   Nombre = a.Nombre,
                                   Apellido = a.Apellido
                               }).Distinct().ToList();

                return alumnos;
            }
        }




    }
}
