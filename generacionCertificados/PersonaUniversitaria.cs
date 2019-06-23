using System.Collections.Generic;

namespace generacionCertificados
{
    abstract class PersonaUniversitaria {
        
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public string NumeroTelefono { get; set; }
        public string DireccionPersona { get; set; }

        public List<Certificado> Certificados { get; set; }

        public abstract void ListarInfo(string cantidadInfo, int idPersona);

        public abstract void CrearPersonaUniversitaria(Universidad universidad);

        public abstract void ListarCertificados();

        public abstract void CambiarDatos(Universidad universidad);
    }
}
