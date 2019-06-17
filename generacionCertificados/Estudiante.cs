using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generacionCertificados
{
    class Estudiante {
        private string numMatricula;
        private Carrera carreraEstudiante;
        private Boolean isEstudiantePosgrado;

        public string NumMatricula { get; set; }
        public Carrera CarreraEstudiante { get; set; }
        public Boolean IsEstudiantePosgrado { get; set; }
    }
}
