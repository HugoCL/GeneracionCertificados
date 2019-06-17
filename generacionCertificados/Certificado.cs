using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generacionCertificados
{
    class Certificado {

        private PersonaUniversitaria datosSolicitante;
        private DateTime fechaCreacion;
        private DateTime vigencia;
        private int vigenciaEstablecida;

        public PersonaUniversitaria DatosSolicitante { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime Vigencia { get; set; }
        public int VigenciaEstablecida { get; set; }
    }
}
