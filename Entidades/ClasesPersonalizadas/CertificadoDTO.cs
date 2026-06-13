using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesPersonalizadas
{
    public class CertificadoDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCurso { get; set; }
        public decimal NotaFinal { get; set; }
        public DateTime FechaEmisicion { get; set; }
        public string CodigoVerificacion { get; set; }
        public string URLDocumento { get; set; }
    }

}
