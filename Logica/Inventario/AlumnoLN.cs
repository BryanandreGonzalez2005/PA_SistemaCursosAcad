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
    public class AlumnoLN
    {
        public List<Entidades.Inventario.Alumno> ViewCliente()
        {
            List<Entidades.Inventario.Alumno > lista = new List<Entidades.Inventario.Alumno>();
            Entidades.Inventario.Alumno oc;
            try
            {
                List<PA_SistemaCursosAcad.Alumno> auxLista = AlumnoCD.listarCliente();
                foreach (PA_SistemaCursosAcad.Alumno obj in auxLista)
                {
                    oc = new Entidades.Inventario.Alumno(obj.idAlumno, obj.Cedula, obj.Nombre, obj.Apellido, obj.idCiudad, obj.Telefono, obj.Email);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Clientees de la tabla de BD", ex);
            }
            finally
            {

            }
            return lista;
        }
        public List<AlumnoPersonalizado> ViewClienteFiltro(string valor)
        {
            List<AlumnoPersonalizado> lista = new List<AlumnoPersonalizado>();
            AlumnoPersonalizado oc;

            try
            {
                List<CP_ListarAlumnoFiltroResult> auxLista = AlumnoCD.listarClienteFiltro(valor);
                foreach (CP_ListarAlumnoFiltroResult obj in auxLista)
                {
                    oc = new AlumnoPersonalizado(obj.idAlumno, obj.Cedula, obj.Nombre, obj.Apellido, obj.Ciudad, obj.Telefono, obj.Email);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar Cliente Filtro con procedimiento almacenado", ex);
            }
            finally
            {

            }
            return lista;
        }

        public bool CreateCliente(Entidades.Inventario.Alumno op)
        {
            try
            {
                AlumnoCD.insertarCliente(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar la Cliente en la BD");
            }
        }
        public bool UpDateCliente(Entidades.Inventario.Alumno op)
        {

            try
            {
                AlumnoCD.modificarCliente(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Modificar la Cliente en la BD");
            }
        }
        public bool DeleteCliente(Entidades.Inventario.Alumno op)
        {

            try
            {
                AlumnoCD.eliminarCliente(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Eliminar la Cliente en la BD");
            }
        }
        public bool VerificarCliente(int idc)
        {
            List<Entidades.Inventario.Alumno> Cliente = ViewCliente();

            return Cliente.Any(c => c.IdAlumno == idc);
        }

        public List<AlumnoDTO> ViewClienteConInscripcion()
        {
            return AlumnoCD.listarAlumnosConInscripcion();
        }


    }
}
