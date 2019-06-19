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
        public List<Certificado> certificados { get; set; }

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
                Console.WriteLine("\nNombre completo: " + NombrePersona + " " + ApellidoPersona);
                Console.WriteLine("Carrera: " + CarreraEstudiante.NombreCarrera);
                Console.WriteLine("Numero de matricula: " + NumMatricula);
                Console.WriteLine(IsEstudiantePosgrado == true ? "Es un alumno de posgrado" : "Es un alumno de pregrado");
                Console.WriteLine("Direccion: " + DireccionPersona);
                Console.WriteLine("Numero de telefono: " + NumeroTelefono);
            }
        }

        public override void crearPersonaUniversitaria(Universidad universidad)
        {
            Console.WriteLine("\nSe ingresará un alumno al sistema");
            Console.WriteLine("Ingrese los nombres del alumno:");
            string nombres = Console.ReadLine();
            Console.WriteLine("Ingrese los apellido del alumno");
            string apellidos = Console.ReadLine();
            Console.WriteLine("Es un estudiante de pregrado? [S/N]");
            string prePos = Console.ReadLine();
            Boolean boolPrePos = false;
            if (prePos.Equals("s", StringComparison.InvariantCultureIgnoreCase))
            {
                boolPrePos = true;
            }
            else if (prePos.Equals("n", StringComparison.InvariantCultureIgnoreCase))
            {
                boolPrePos = false;
            }
            else
            {
                Console.WriteLine("Valor ingresado no valido, ingrese el valor nuevamente");
                int exit = 0;
                do
                {
                    Console.WriteLine("Es un estudiante de pregrado? [S/N]");
                    prePos = Console.ReadLine();
                    if (prePos.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                    {
                        boolPrePos = true;
                        exit = 1;
                    }
                    else if (prePos.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                    {
                        boolPrePos = false;
                        exit = 1;
                    }
                } while (exit == 0);
            }
            Console.WriteLine(boolPrePos);
            Console.WriteLine("Ingrese direccion del alumno");
            string direcc = Console.ReadLine();
            Console.WriteLine("Ingrese el numero de telefono del estudiante");
            string telef = Console.ReadLine();
            Console.WriteLine("Ingrese numero de matricula");
            string numMatri = Console.ReadLine();
            Console.WriteLine("Seleccione el numero correspondiente a la carrera del estudiante");
            int contOp = 1;
            foreach (Carrera carreraActual in universidad.Carreras)
            {
                Console.WriteLine("[" + contOp + "] " + carreraActual.NombreCarrera);
                contOp++;
            }

            int opCarrera = Convert.ToInt32(Console.ReadLine());
            Carrera carreraElegida = universidad.Carreras[opCarrera - 1];
            Estudiante estudiante = new Estudiante();
            NombrePersona = nombres;
            ApellidoPersona = apellidos;
            NumMatricula = numMatri;
            CarreraEstudiante = carreraElegida;
            DireccionPersona = direcc;
            NumeroTelefono = telef;
            IsEstudiantePosgrado = boolPrePos;
        }

        public override void menuCertificados()
        {
            Console.Out.WriteLine("\n¡Bienvenido " + NombrePersona + "!");
            Console.Out.WriteLine("Elige el certificado a emitir:");
            Console.Out.WriteLine("[1] Año curso");
        }
    }
}
