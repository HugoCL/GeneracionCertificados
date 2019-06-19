using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
// ReSharper disable All

namespace generacionCertificados
{
    class Program
    {
        static void Main(string[] args) {
            Universidad universidad = new Universidad();
            universidad.NombreUniversidad = "UTALCA";
            int op = 0;
            do
            {
                Console.WriteLine("\n*************************************************");
                Console.WriteLine("Menu del generador de certificados:");
                Console.WriteLine("[1] Ingresar carrera (LISTO)");
                Console.WriteLine("[2] Ingresar alumno (LISTO)");
                Console.WriteLine("[3] Ingresar funcionario (NO IMPLEMENTADO)");
                Console.WriteLine("[4] Emitir certificado");
                Console.WriteLine("[5] Listar carreras (LISTO)");
                Console.WriteLine("[6] Listar alumnos (LISTO)");
                Console.WriteLine("[7] Listar funcionarios");
                Console.WriteLine("[8] Listar certificados");
                Console.WriteLine("[9] Editar información de alumno o funcionario");
                Console.WriteLine("[10] Validar certicado");
                Console.WriteLine("[11] Eliminar alumno o funcionario");
                Console.WriteLine("[12] Salir");
                Console.WriteLine("*************************************************");
                Console.WriteLine("Ingrese su opcion:");
                op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Carrera carrera = new Carrera();
                        carrera.crearCarrera();
                        universidad.Carreras.Add(carrera);
                        Console.WriteLine("Carrera agregada exitosamente");
                        break;
                    case 2:
                        if (universidad.Carreras.Count == 0) { Console.WriteLine("\nNo hay carreras disponibles para inscribir alumnos :(");}
                        else
                        {
                            Estudiante estudiante = new Estudiante();
                            estudiante.crearPersonaUniversitaria(universidad);
                            universidad.Estudiantes.Add(estudiante);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Se ingreso al sistema de creacion de certificados");
                        Console.WriteLine("Eres alumno[1] o funcionario[2]?");
                        int opPers = Convert.ToInt32(Console.ReadLine());
                        if (opPers == 1)
                        {
                            Console.WriteLine("Ingresa tu numero de matricula a continuacion para iniciar sesion");
                            string numMa = Console.ReadLine();
                            foreach (Estudiante estudiante in universidad.Estudiantes)
                            {
                                if (estudiante.NumMatricula.Equals(numMa))
                                {
                                    estudiante.menuCertificados();

                                }
                            }
                        }
                        break;
                    case 5:
                        universidad.listarCarreras();
                        break;
                    case 6:
                        if (universidad.Estudiantes.Count == 0) { Console.WriteLine("\nNo hay alumnos ingresados en el sistema :/"); }
                        else
                        {
                            Console.WriteLine("¿Desea ver la información principal de los alumnos[1] (Nombre completo, " +
                                              "carrera y numero de matricula) o toda la información [2]?");
                            Console.WriteLine("Ingrese el numero de la opcion deseada");
                            int opInfo = Convert.ToInt32(Console.ReadLine());
                            if (opInfo == 1 || opInfo == 2)
                            {
                                int contAlumn = 1;
                                foreach (Estudiante estudianteActual in universidad.Estudiantes)
                                {
                                    estudianteActual.ListarInfo(opInfo);
                                    contAlumn++;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Opción no valida :(");
                            }
                        }
                        break;
                }
            } while (op != 12);
            
        }
    }
}
