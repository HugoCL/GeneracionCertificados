using System;

// ReSharper disable All

namespace generacionCertificados
{
    class Program
    {
        static void Main(string[] args) {
            Universidad universidad = new Universidad();
            universidad.NombreUniversidad = "UTALCA";
            string op = "0";
            Console.Out.WriteLine("Bienvenido al portal de la "+universidad.NombreUniversidad);
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n*************************************************");
                Console.WriteLine("Menu del generador de certificados:");
                Console.WriteLine("[1] Ingresar carrera (LISTO)");
                Console.WriteLine("[2] Ingresar alumno (LISTO)");
                Console.WriteLine("[3] Ingresar funcionario (LISTO)");
                Console.WriteLine("[4] Emitir certificado (LISTO)");
                Console.WriteLine("[5] Listar carreras (LISTO)");
                Console.WriteLine("[6] Listar alumnos (LISTO)");
                Console.WriteLine("[7] Listar funcionarios (LISTO)");
                Console.WriteLine("[8] Listar certificados (LISTO)");
                Console.WriteLine("[9] Editar información de alumno o funcionario (LISTO)");
                Console.WriteLine("[10] Validar certicado (LISTO)");
                Console.WriteLine("[11] Eliminar alumno o funcionario (LISTO)");
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
                    case "3":
                        Funcionario funcionario = new Funcionario();
                        funcionario.CrearPersonaUniversitaria(universidad);
                        universidad.Funcionarios.Add(funcionario);
                        break;
                    case "4":
                        Console.WriteLine("Se ingreso al sistema de creacion de certificados");
                        Console.WriteLine("¿Eres alumno[1] o funcionario[2]?");
                        string opPers = Console.ReadLine();
                        int persEncon = 0;
                        if (opPers == "1")
                        {
                            Console.WriteLine("Ingresa tu numero de matricula a continuacion para iniciar sesion");
                            string numMa = Console.ReadLine();
                            foreach (Estudiante estudiante in universidad.Estudiantes)
                            {
                                if (estudiante.NumMatricula.Equals(numMa))
                                {
                                    estudiante.MenuCertificados(estudiante);
                                    persEncon = 1;
                                }
                            }
                        }
                        else if (opPers == "2")
                        {
                            Console.Out.WriteLine("Ingresa tu RUT a continuación para iniciar sesion");
                            string rutFun = Console.ReadLine();
                            foreach (Funcionario funcionarioActual in universidad.Funcionarios)
                            {
                                if (funcionarioActual.RutFuncionario.Equals(rutFun))
                                {
                                    funcionarioActual.MenuCertificados(funcionarioActual);
                                    persEncon = 1;
                                }
                            }
                        }

                        if (persEncon == 0)
                        {
                            Console.Out.WriteLine("No se encontró ese usuario :/");
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
                                    estudianteActual.ListarInfo(opInfo, contAlumn);
                                    contAlumn++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Opción no valida :(");
                            }
                        }
                        break;
                    case "7":
                        if (universidad.Funcionarios.Count == 0) { Console.WriteLine("\nNo hay funcionarios ingresados en el sistema :/"); }
                        else
                        {
                            Console.WriteLine("¿Desea ver la información principal de los funcionarios[1] (Nombre completo, " +
                                              "departamento y RUT) o toda la información [2]?");
                            Console.WriteLine("Ingrese el numero de la opcion deseada");
                            string opInfo = Console.ReadLine();
                            if (opInfo == "1" || opInfo == "2")
                            {
                                int contFunc = 1;
                                foreach (Funcionario funcionarioActual in universidad.Funcionarios)
                                {
                                    funcionarioActual.ListarInfo(opInfo, contFunc);
                                    contFunc++;
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
                        Console.WriteLine("¿Se listaran certificados de un alumno[1] o de funcionario[2]?");
                        string opPersC = Console.ReadLine();
                        bool exitCertificados = false;
                        if (opPersC == "1")
                        {
                            Console.WriteLine("Ingresa tu numero de matricula a continuacion para iniciar sesion");
                            string numMa = Console.ReadLine();
                            foreach (Estudiante estudiante in universidad.Estudiantes)
                            {
                                if (estudiante.NumMatricula.Equals(numMa))
                                {
                                    estudiante.ListarCertificados();
                                    exitCertificados = true;
                                }
                            }
                            if (exitCertificados == false)
                            {
                                Console.Out.WriteLine("No se encontró a ese alumno");
                            }
                        }
                        else if (opPersC == "2")
                        {
                            Console.Out.WriteLine("Ingrese el RUT a continuacion para iniciar sesion");
                            string RUT = Console.ReadLine();
                            foreach (Funcionario funcionarioList in universidad.Funcionarios)
                            {
                                if (funcionarioList.RutFuncionario.Equals(RUT))
                                {
                                    funcionarioList.ListarCertificados();
                                    exitCertificados = true;
                                }
                            }

                            if (exitCertificados == false)
                            {
                                Console.Out.WriteLine("No se encontró ese funcionario");
                            }
                        }
                        else
                        {
                            Console.Out.WriteLine("Opcion no valida :(");
                        }
                        break;
                    case "9":
                        Console.Out.WriteLine("Se ingresó al sistema de editado de datos");
                        Console.Out.WriteLine("¿A que tipo de persona se le editarán sus datos? [1] Alumno o [2] Funcionario");
                        string opEdit = Console.ReadLine();
                        bool exitEdi = false;
                        if (opEdit == "1")
                        {
                            Console.Out.WriteLine("Ingresa tu numero de matricula a continuacion para inicar sesion");
                            string numMatri = Console.ReadLine();
                            foreach (Estudiante estudianteEdi in universidad.Estudiantes)
                            {
                                if (estudianteEdi.NumMatricula.Equals(numMatri))
                                {
                                    estudianteEdi.CambiarDatos(universidad);
                                    exitEdi = true;
                                }
                            }

                            if (exitEdi == false)
                            {
                                Console.Out.WriteLine("No se encontró a ese alumno");
                            }
                        }
                        else if (opEdit == "2")
                        {
                            Console.Out.WriteLine("Ingresa tu RUT a continuacion para iniciar sesion");
                            string RutFun = Console.ReadLine();
                            foreach (Funcionario funicionarioEdi in universidad.Funcionarios)
                            {
                                if (funicionarioEdi.RutFuncionario.Equals(RutFun))
                                {
                                    funicionarioEdi.CambiarDatos(universidad);
                                    exitEdi = true;
                                }
                            }

                            if (exitEdi == false)
                            {
                                Console.Out.WriteLine("No se encontró ese funcionario");
                            }
                        }
                        else
                        {
                            Console.Out.WriteLine("Se ingresó una opcion no valida :(");
                        }
                        break;
                    case "10":
                        Console.Out.WriteLine("Actualmente la fecha es: "+DateTime.Now);
                        Console.Out.WriteLine(
                            "¿Desea comprobar el certificado por una fecha manual[1] o por la hora del sistema[2]?");
                        string fechaValid = Console.ReadLine();
                        if (fechaValid == "1")
                        {
                            try
                            {
                                Console.Out.WriteLine("Ingrese la fecha a continuación");
                                Console.Out.WriteLine("Ejemplo: 01/01/2019 13:00 (SI NO SE SIGUE EL FORMATO, SE LANZARÁ UNA EXCEPCION)");
                                string fechaManual = Console.ReadLine();
                                DateTime fecha = DateTime.ParseExact(fechaManual, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                                Console.Out.WriteLine("Ingrese el codigo de validacion del certificado:");
                                string codigo = Console.ReadLine();
                                int exitoVal = 0;
                                // FALTA COMPROBAR CERTIFICADOS DE FUNCIONARIOS
                                foreach (Estudiante estudiante in universidad.Estudiantes)
                                {
                                    foreach (Certificado certificado in estudiante.CertificadosAlumno)
                                    {
                                        if (certificado.CodigoVerificacion.Equals(codigo))
                                        {
                                            Console.Out.WriteLine("**********************************");
                                            Console.Out.WriteLine("¡Certificado entontrado!");
                                            if (DateTime.Compare(fecha, certificado.Vigencia) >= 0)
                                            {
                                                Console.Out.WriteLine("El certificado esta vencido");
                                                Console.Out.WriteLine("**********************************");
                                                exitoVal = 1;
                                                break;
                                            }
                                            else
                                            {
                                                Console.Out.WriteLine("El certificado es valido");
                                                Console.Out.WriteLine("**********************************");
                                                exitoVal = 1;
                                                break;
                                            }
                                        }
                                    }
                                }
                                foreach (Funcionario funcionarioActual in universidad.Funcionarios)
                                {
                                    foreach (Certificado certificado in funcionarioActual.CertificadosFuncionario)
                                    {
                                        if (certificado.CodigoVerificacion.Equals(codigo))
                                        {
                                            Console.Out.WriteLine("**********************************");
                                            Console.Out.WriteLine("¡Certificado entontrado!");
                                            if (DateTime.Compare(fecha, certificado.Vigencia) >= 0)
                                            {
                                                Console.Out.WriteLine("El certificado esta vencido");
                                                Console.Out.WriteLine("**********************************");
                                                exitoVal = 1;
                                                break;
                                            }
                                            else
                                            {
                                                Console.Out.WriteLine("El certificado es valido");
                                                Console.Out.WriteLine("**********************************");
                                                exitoVal = 1;
                                                break;
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
                            catch (Exception e)
                            {
                                Console.Out.WriteLine("Excepcion lanzada, error al detectar el parseo de la fecha. Revise la entrada e intente nuevamente");
                                Console.WriteLine(e);
                                throw;
                            }
                        }
                        else if (fechaValid == "2")
                        {
                            Console.Out.WriteLine("Se tomará la fecha "+DateTime.Now+" como la fecha actual");
                            Console.Out.WriteLine("Ingrese el codigo de validacion del certificado:");
                            string codigo = Console.ReadLine();
                            int exitoVal = 0;
                            // FALTA COMPROBAR CERTIFICADOS DE FUNCIONARIOS
                            foreach (Estudiante estudiante in universidad.Estudiantes)
                            {
                                foreach (Certificado certificado in estudiante.CertificadosAlumno)
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
                                            break;
                                        }
                                        else
                                        {
                                            Console.Out.WriteLine("El certificado es valido");
                                            Console.Out.WriteLine("**********************************");
                                            exitoVal = 1;
                                            break;
                                        }
                                    }
                                }
                            }
                            foreach (Funcionario funcionarioCert in universidad.Funcionarios)
                            {
                                foreach (Certificado certificado in funcionarioCert.CertificadosFuncionario)
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
                        else
                        {
                            Console.Out.WriteLine("Opción no valida. Revise la entrada e intente nuevamente");
                        }
                        break;
                    case "11":
                        Console.Out.WriteLine("Se procederá a eliminar un alumno o un funcionario");
                        Console.WriteLine("¿La persona a eliminar es un alumno[1] o funcionario[2]?");
                        string opPersElim = Console.ReadLine();
                        bool exitEliminacion = false;
                        if (opPersElim == "1")
                        {
                            Console.WriteLine("Ingresa tu numero de matricula a continuacion para iniciar sesion y eliminar tu perfil");
                            string numMa = Console.ReadLine();
                            for (int j = 0; j < universidad.Estudiantes.Count ; j++)
                            {
                                if (universidad.Estudiantes[j].NumMatricula.Equals(numMa))
                                {
                                    Console.Out.WriteLine("Alumno encontrado. Confirme eliminación [S/N]");
                                    string confirm = Console.ReadLine();
                                    exitEliminacion = true;
                                    if (confirm.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        universidad.Estudiantes.RemoveAt(j);
                                        Console.Out.WriteLine("Alumno removido con exito");
                                    }
                                    else if (confirm.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        Console.Out.WriteLine("Operación cancelada");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Valor ingresado no valido, ingrese el valor nuevamente");
                                        int exit = 0;
                                        do
                                        {
                                            Console.WriteLine("Alumno encontrado. Confirme eliminación [S/N]");
                                            confirm = Console.ReadLine();
                                            if (confirm.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                                            {
                                                universidad.Estudiantes.RemoveAt(j);
                                                Console.Out.WriteLine("Alumno removido con exito");
                                                exit = 1;
                                            }
                                            else if (confirm.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                                            {
                                                Console.Out.WriteLine("Operación cancelada");
                                                exit = 1;
                                            }
                                        } while (exit == 0);
                                    }
                                }
                            }
                        }
                        else if (opPersElim == "2")
                        {
                            Console.WriteLine("Ingresa tu RUT a continuación para eliminar tu perfil");
                            string RutEli = Console.ReadLine();
                            for (int i = 0; i < universidad.Funcionarios.Count; i++)
                            {
                                if (universidad.Funcionarios[i].RutFuncionario.Equals(RutEli))
                                {
                                    Console.Out.WriteLine("Funcionario encontrado. Confirme eliminación [S/N]");
                                    exitEliminacion = true;
                                    string confirm = Console.ReadLine();
                                    if (confirm.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        universidad.Funcionarios.RemoveAt(i);
                                        Console.Out.WriteLine("Funcionario removido con exito");
                                    }
                                    else if (confirm.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        Console.Out.WriteLine("Operación cancelada");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Valor ingresado no valido, ingrese el valor nuevamente");
                                        int exit = 0;
                                        do
                                        {
                                            Console.WriteLine("Funcionario encontrado. Confirme eliminación [S/N]");
                                            confirm = Console.ReadLine();
                                            if (confirm.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                                            {
                                                universidad.Funcionarios.RemoveAt(i);
                                                Console.Out.WriteLine("Funcionario removido con exito");
                                                exit = 1;
                                            }
                                            else if (confirm.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                                            {
                                                Console.Out.WriteLine("Operación cancelada");
                                                exit = 1;
                                            }
                                        } while (exit == 0);
                                    }
                                }
                            }
                        }

                        if (exitEliminacion == false)
                        {
                            Console.Out.WriteLine("No se encontró al usuario o la opcion ingresada no es valida :(");
                        }
                        break;
                    default:
                        Console.Out.WriteLine("La opción ingresada no es valida :(");
                        break;
                }
            } while (op != "12");
        }
    }
}
