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
                Console.WriteLine("Menu del generador de certificados:");
                Console.WriteLine("[1] Ingresar carrera");
                Console.WriteLine("[2] Ingresar alumno");
                Console.WriteLine("[3] Ingresar funcionario");
                Console.WriteLine("[4] Emitir certificado");
                Console.WriteLine("[5] Listar carreras");
                Console.WriteLine("[6] Listar alumnos");
                Console.WriteLine("[7] Listar funcionarios");
                Console.WriteLine("[8] Listar certificados");
                Console.WriteLine("[9] Editar información de alumno o funcionario");
                Console.WriteLine("[10] Validar certicado");
                Console.WriteLine("[11] Eliminar alumno o funcionario");
                Console.WriteLine("[12] Salir");
                Console.WriteLine("Ingrese su opcion:");
                op = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(op);
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Se ingresará una carrera");
                        Console.WriteLine("Ingrese el nombre de la carrera");
                        string nCarrera = Console.ReadLine();
                        Console.WriteLine("Ingrese el codigo asociado a la carrera");
                        string cCarrera = Console.ReadLine();
                        Carrera carrera = new Carrera();
                        carrera.NombreCarrera = nCarrera;
                        carrera.CodigoCarrera = cCarrera;
                        universidad.Carreras.Add(carrera);
                        Console.WriteLine("Carrera agregada exitosamente");
                        break;
                    case 2:
                        Console.WriteLine("Se ingresará un alumno al sistema");
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
                                Console.WriteLine("Es un estudiante de pregrado? [S/N] SENSIBLE A MAYUS Y MINUS");
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
                        estudiante.NombrePersona = nombres;
                        estudiante.ApellidoPersona = apellidos;
                        estudiante.NumMatricula = numMatri;
                        estudiante.CarreraEstudiante = carreraElegida;
                        estudiante.DireccionPersona = direcc;
                        estudiante.NumeroTelefono = telef;
                        estudiante.IsEstudiantePosgrado = boolPrePos;
                        universidad.Estudiantes.Add(estudiante);
                        break;
                    case 5:
                        universidad.listarCarreras();
                        break;
                    case 6:
                        if (universidad.Estudiantes.Count == 0) { Console.WriteLine("No hay alumnos ingresados en el sistema :/"); }
                        else
                        {
                            Console.WriteLine("¿Desea ver la información principal de los alumnos[1] (Nombre completo, " +
                                              "carrera y numero de matricula) o toda la información [2]?");
                            Console.WriteLine("Ingrese el numero de la opcion deseada");
                            int opInfo = Convert.ToInt32(Console.ReadLine());
                            if (opInfo == 1)
                            {
                                int contAlumn = 1;
                                foreach (Estudiante estudianteActual in universidad.Estudiantes)
                                {
                                    estudianteActual.ListarInfo(opInfo);
                                    contAlumn++;
                                }

                            }
                            else if (opInfo == 2)
                            {

                                int contAlumnTotal = 1;
                                foreach (Estudiante estudianteActual in universidad.Estudiantes)
                                {
                                    estudianteActual.ListarInfo(opInfo);
                                    contAlumnTotal++;
                                }
                                if (contAlumnTotal == 1) { Console.WriteLine("No hay alumnos ingresados en el sistema :/"); }
                            }
                        }
                        break;
                }
            } while (op != 12);
            
        }
    }
}
