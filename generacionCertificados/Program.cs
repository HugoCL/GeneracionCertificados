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
            string op = "0";
            do
            {
                Console.WriteLine("\n*************************************************");
                Console.WriteLine("Menu del generador de certificados:");
                Console.WriteLine("[1] Ingresar carrera (LISTO)");
                Console.WriteLine("[2] Ingresar alumno (LISTO)");
                Console.WriteLine("[3] Ingresar funcionario (NO IMPLEMENTADO)");
                Console.WriteLine("[4] Emitir certificado (LISTO?)");
                Console.WriteLine("[5] Listar carreras (LISTO)");
                Console.WriteLine("[6] Listar alumnos (LISTO)");
                Console.WriteLine("[7] Listar funcionarios (NO IMPLEMENTADO)");
                Console.WriteLine("[8] Listar certificados (NO IMPLEMENTADO)");
                Console.WriteLine("[9] Editar información de alumno o funcionario");
                Console.WriteLine("[10] Validar certicado");
                Console.WriteLine("[11] Eliminar alumno o funcionario");
                Console.WriteLine("[12] Salir");
                Console.WriteLine("*************************************************");
                Console.WriteLine("Ingrese su opcion:");
                op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        Carrera carrera = new Carrera();
                        carrera.CrearCarrera();
                        universidad.Carreras.Add(carrera);
                        Console.WriteLine("Carrera agregada exitosamente");
                        break;
                    case "2":
                        if (universidad.Carreras.Count == 0) { Console.WriteLine("\nNo hay carreras disponibles para inscribir alumnos :(");}
                        else
                        {
                            Estudiante estudiante = new Estudiante();
                            estudiante.CrearPersonaUniversitaria(universidad);
                            universidad.Estudiantes.Add(estudiante);
                        }
                        break;
                    case "4":
                        Console.WriteLine("Se ingreso al sistema de creacion de certificados");
                        Console.WriteLine("Eres alumno[1] o funcionario[2]?");
                        string opPers = Console.ReadLine();
                        if (opPers == "1")
                        {
                            Console.WriteLine("Ingresa tu numero de matricula a continuacion para iniciar sesion");
                            string numMa = Console.ReadLine();
                            foreach (Estudiante estudiante in universidad.Estudiantes)
                            {
                                if (estudiante.NumMatricula.Equals(numMa))
                                {
                                    estudiante.MenuCertificados(estudiante);

                                }
                            }
                        }
                        break;
                    case "5":
                        universidad.ListarCarreras();
                        break;
                    case "6":
                        if (universidad.Estudiantes.Count == 0) { Console.WriteLine("\nNo hay alumnos ingresados en el sistema :/"); }
                        else
                        {
                            Console.WriteLine("¿Desea ver la información principal de los alumnos[1] (Nombre completo, " +
                                              "carrera y numero de matricula) o toda la información [2]?");
                            Console.WriteLine("Ingrese el numero de la opcion deseada");
                            string opInfo = Console.ReadLine();
                            if (opInfo == "1" || opInfo == "2")
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
                    case "8":
                        Console.WriteLine("Se ingreso al sistema de listado de certificado");
                        Console.WriteLine("Eres alumno[1] o funcionario[2]?");
                        string opPersC = Console.ReadLine();
                        if (opPersC == "1")
                        {
                            Console.WriteLine("Ingresa tu numero de matricula a continuacion para iniciar sesion");
                            string numMa = Console.ReadLine();
                            foreach (Estudiante estudiante in universidad.Estudiantes)
                            {
                                if (estudiante.NumMatricula.Equals(numMa))
                                {
                                    estudiante.ListarCertificados();
                                }
                            }
                        }
                        break;
                    case "10":
                        Console.Out.WriteLine("Actualmente la fecha es: "+DateTime.Now);
                        Console.Out.WriteLine("Para poder comprobar la validez de un certificado, debe ingresar " +
                                              "una fecha manualmente[1] o optar por usar la del sistema[2]");
                        string fechaValid = Console.ReadLine();
                        if (fechaValid == "1")
                        {
                            try
                            {
                                Console.Out.WriteLine("Ingrese la fecha a continuación");
                                Console.Out.WriteLine("Ejemplo: 01/01/2019 13:00 (SI NO SE SIGUE EL FORMATO, SE LANZARÁ UNA EXCEPCION)");
                                string fechaManual = Console.ReadLine();
                                DateTime fecha = DateTime.ParseExact(fechaManual, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                                Console.Out.WriteLine(fecha);
                            }
                            catch (Exception e)
                            {
                                Console.Out.WriteLine("Excepcion lanzada, error al detectar el parseo de la fecha. Revise la entrada e intente nuevamente");
                                Console.WriteLine(e);
                                throw;
                            }
                        }
                        else
                        {
                            Console.Out.WriteLine("Se tomará la fecha "+DateTime.Now+" como la fecha actual");
                            Console.Out.WriteLine("Ingrese el codigo de validacion del certificado:");
                            string codigo = Console.ReadLine();
                            int exitoVal = 0;
                            // FALTA COMPROBAR CERTIFICADOS DE FUNCIONARIOS
                            foreach (Estudiante estudiante in universidad.Estudiantes)
                            {
                                foreach (Certificado certificado in estudiante.Certificados)
                                {
                                    if (certificado.CodigoVerificacion.Equals(codigo))
                                    {
                                        Console.Out.WriteLine("**********************************");
                                        Console.Out.WriteLine("¡Certificado entontrado!");
                                        if (DateTime.Compare(DateTime.Now, certificado.Vigencia) >= 0)
                                        {
                                            Console.Out.WriteLine("El certificado esta vencido");
                                            Console.Out.WriteLine("**********************************");
                                            exitoVal = 1;
                                        }
                                        else
                                        {
                                            Console.Out.WriteLine("El certificado es valido");
                                            Console.Out.WriteLine("**********************************");
                                            exitoVal = 1;
                                        }
                                    }
                                }
                            }

                            if (exitoVal != 1)
                            {
                                Console.Out.WriteLine("**********************************");
                                Console.Out.WriteLine("El certificado no se encontro");
                                Console.Out.WriteLine("**********************************");
                            }
                        }
                        break;
                }
            } while (op != "12");
            
        }
    }
}
