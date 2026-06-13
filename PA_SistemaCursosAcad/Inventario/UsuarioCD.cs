using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_SistemaCursosAcad.Inventario
{
    public class UsuarioCD
    {
        public static void insertar(Usuario oc)
        {
            DBCursoDataContext DB = null;
            try
            {
                using (DB = new DBCursoDataContext())
                {
                    DB.CP_InsertarUsuario(oc.NombreUsuario, oc.Contraseña);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar en la tabla usuario", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static bool verificar(string nombre, string contraseña)
        {
            DBCursoDataContext DB = null;
            try
            {
                using (DB = new DBCursoDataContext())
                {
                    var usuario = DB.Usuario.FirstOrDefault(u => u.NombreUsuario == nombre);
                    if (usuario == null)
                    {
                        throw new DatosExcepciones("Usuario incorrecto");
                    }

                    if (usuario.Contraseña != contraseña)
                    {
                        throw new DatosExcepciones("Contraseña incorrecta");
                    }

                    return true; // Usuario y contraseña correctos
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones(ex.Message, ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
