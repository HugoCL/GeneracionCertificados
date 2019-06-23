using System;

namespace generacionCertificados
{
    abstract class Certificado {


        public PersonaUniversitaria DatosSolicitante { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime Vigencia { get; set; }
        public int VigenciaEstablecida { get; set; }

        public string PeriodoCertificado { get; set; }

        public int TipoCertificado { get; set; }

        public string ImpuestoCertificado { get; set; }

        public string CodigoVerificacion { get; set; }
        public string Destinatario { get; set; }

        public string Sueldo { get; set; }

        
    }
}
