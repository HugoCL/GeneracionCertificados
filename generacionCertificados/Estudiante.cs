using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generacionCertificados
{
    class Estudiante : PersonaUniversitaria {

        public string NumMatricula { get; set; }
        public Carrera CarreraEstudiante { get; set; }
        public Boolean IsEstudiantePosgrado { get; set; }

        public override void ListarInfo(int cantidadInfo)
        {
            if (cantidadInfo == 1)
            {
                Console.WriteLine("\n Nombre completo: " + NombrePersona + " " + ApellidoPersona);
                Console.WriteLine("Carrera: " + CarreraEstudiante.NombreCarrera);
                Console.WriteLine("Numero de matricula: " + NumMatricula);
            }
            
            else
            {
                Console.WriteLine("\n Nombre completo: " + NombrePersona + " " + ApellidoPersona);
                Console.WriteLine("Carrera: " + CarreraEstudiante.NombreCarrera);
                Console.WriteLine("Numero de matricula: " + NumMatricula);
                Console.WriteLine(IsEstudiantePosgrado == true ? "Es un alumno de posgrado" : "Es un alumno de pregrado");
                Console.WriteLine("Direccion: " + DireccionPersona);
                Console.WriteLine("Numero de telefono: " + NumeroTelefono);
            }
        }
    }
}
