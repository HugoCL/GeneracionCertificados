using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generacionCertificados
{
    class Universidad
    {
        private string nombreUniversidad;
        private ArrayList estudiantes; 
        private ArrayList funcionarios;
        private ArrayList carreras;

        public string NombreUniversidad { get; set; }
        public ArrayList Estudiantes { get; set; }
        public ArrayList Funcionarios { get; set; }
        public ArrayList Carreras { get; set; }
    }
}
