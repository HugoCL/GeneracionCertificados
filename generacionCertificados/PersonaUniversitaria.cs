using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generacionCertificados
{
    abstract class PersonaUniversitaria {
        
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public string NumeroTelefono { get; set; }
        public string DireccionPersona { get; set; }

        public abstract void ListarInfo(int cantidadInfo);
    }
}
