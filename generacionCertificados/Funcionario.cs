using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generacionCertificados
{
    class Funcionario : PersonaUniversitaria {

        public string RutProfesor { get; set; }
        public string Departamente { get; set; }
        public Boolean TipoContrato { get; set; }
        public string Perfil { get; set; }
        

        public override void ListarInfo(int cantidadInfo)
        {
            throw new NotImplementedException();
        }
    }
}
