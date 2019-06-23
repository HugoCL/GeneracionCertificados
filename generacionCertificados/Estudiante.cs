using System;
using System.Collections.Generic;

namespace generacionCertificados
{
    class Estudiante : PersonaUniversitaria {

        public string NumMatricula { get; set; }
        public Carrera CarreraEstudiante { get; set; }
        public Boolean IsEstudiantePosgrado { get; set; }
        public List<Certificado> CertificadosAlumno { get; set; }

        public Estudiante()
        {
            CertificadosAlumno = new List<Certificado>();
        }

        public override void ListarInfo(string cantidadInfo, int idEstudiante)
        {
            Console.Out.WriteLine("**********************************************************");
            Console.Out.WriteLine("\nALUMNO NUMERO " + idEstudiante);
            if (cantidadInfo == "1")
            {
                Console.WriteLine("Nombre completo: " + NombrePersona + " " + ApellidoPersona);
                Console.WriteLine("Carrera: " + CarreraEstudiante.NombreCarrera);
                Console.WriteLine("Numero de matricula: " + NumMatricula);
            }
            
            else
            {
                Console.WriteLine("\nNombre completo: " + NombrePersona + " " + ApellidoPersona);
                Console.WriteLine("Carrera: " + CarreraEstudiante.NombreCarrera);
                Console.WriteLine("Numero de matricula: " + NumMatricula);
                Console.WriteLine(IsEstudiantePosgrado ? "Es un alumno de postgrado" : "Es un alumno de pregrado");
                Console.WriteLine("Direccion: " + DireccionPersona);
                Console.WriteLine("Numero de telefono: " + NumeroTelefono);
            }
        }

        public override void CrearPersonaUniversitaria(Universidad universidad)
        {
            Console.WriteLine("\nSe ingresará un alumno al sistema");
            Console.WriteLine("Ingrese los nombres del alumno:");
            string nombres = Console.ReadLine();
            Console.WriteLine("Ingrese los apellido del alumno");
            string apellidos = Console.ReadLine();
            Console.WriteLine("Es un estudiante de pregrado? [S/N]");
            string prePos = Console.ReadLine();
            Boolean boolPrePos = false;
            if (prePos != null && prePos.Equals("s", StringComparison.InvariantCultureIgnoreCase))
            {
                boolPrePos = true;
            }
            else if (prePos != null && prePos.Equals("n", StringComparison.InvariantCultureIgnoreCase))
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
                    if (prePos != null && prePos.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                    {
                        boolPrePos = true;
                        exit = 1;
                    }
                    else if (prePos != null && prePos.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                    {
                        boolPrePos = false;
                        exit = 1;
                    }
                    else
                    {
                        Console.Out.WriteLine("Valor ingresado no valida, ingrese su opcion nuevamente");
                    }
                } while (exit == 0);
            }
            Console.WriteLine("Ingrese direccion del alumno");
            string direcc = Console.ReadLine();
            Console.WriteLine("Ingrese el numero de telefono del estudiante");
            string telef = Console.ReadLine();
            Console.WriteLine("Seleccione el numero correspondiente a la carrera del estudiante");
            Console.Out.WriteLine("Ingresar un caracter no numerico lanzara una excepcion");
            int contOp = 1;
            foreach (Carrera carreraActual in universidad.Carreras)
            {
                Console.WriteLine("[" + contOp + "] " + carreraActual.NombreCarrera);
                contOp++;
            }
            try
            {
                int opCarrera = Convert.ToInt32(Console.ReadLine());
                if (opCarrera-1  >= universidad.Carreras.Count)
                {
                    var exitCarrera = 0;
                    do
                    {
                        Console.Out.WriteLine("El numero supero las opciones disponibles, intenta nuevamente");
                        Console.WriteLine("Seleccione el numero correspondiente a la carrera del estudiante");
                        Console.Out.WriteLine("Ingresar un caracter no numerico lanzara una excepcion");
                        contOp = 1;
                        foreach (Carrera carreraActual in universidad.Carreras)
                        {
                            Console.WriteLine("[" + contOp + "] " + carreraActual.NombreCarrera);
                            contOp++;
                            opCarrera = Convert.ToInt32(Console.ReadLine());
                            if (opCarrera-1 < universidad.Carreras.Count)
                            {
                                exitCarrera = 1;
                            }
                        }
                    } while (exitCarrera == 0);
                }
                Carrera carreraElegida = universidad.Carreras[opCarrera - 1];
                CarreraEstudiante = carreraElegida;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Se ingresó una opción no valida. Revise la entrada y reinicie el programa");
                Console.WriteLine(e);
                throw;
            }

            string numMatri = DateTime.Now.Year.ToString() + CarreraEstudiante.CodigoCarrera +
                              universidad.Estudiantes.Count.ToString();
            Estudiante estudiante = new Estudiante();
            NombrePersona = nombres;
            ApellidoPersona = apellidos;
            NumMatricula = numMatri;
            Console.Out.WriteLine("********************************************");
            Console.Out.WriteLine("¡El perfil fue creado correctamente!");
            Console.Out.WriteLine("Tu numero de matricula es: "+numMatri);
            Console.Out.WriteLine("********************************************");
            DireccionPersona = direcc;
            NumeroTelefono = telef;
            IsEstudiantePosgrado = boolPrePos;
        }

        public override void ListarCertificados()
        {
            if (CertificadosAlumno.Count == 0) {
                Console.Out.WriteLine("Este alumno no posee certificados creados :(");
            }
            else
            {
                int numCertificados = 1;
                foreach (CertificadoEstudiante certificado in CertificadosAlumno)
                {
                    Console.Out.WriteLine("CERTIFICADO NUMERO "+numCertificados);
                    Console.Out.WriteLine("***********************************************************************");
                    Console.Out.WriteLine("                       Universidad de Talca");
                    Console.Out.Write("                    Certificado de ");
                    if (certificado.TipoCertificado == 1)
                    {
                        Console.Out.Write("Año Curso - Periodo " + certificado.PeriodoCertificado);
                    }
                    else if (certificado.TipoCertificado == 2)
                    {
                        Console.Out.Write("Asignacion Familiar");
                        Console.Out.Write("\n                         Periodo de " + certificado.PeriodoCertificado);
                    }
                    else if (certificado.TipoCertificado == 3)
                    {
                        Console.Out.Write("Canton Reclutamiento");
                        Console.Out.Write("\n                         Periodo de " + certificado.PeriodoCertificado);
                    }
                    else if (certificado.TipoCertificado == 4)
                    {
                        Console.Out.Write("Rebaja de Transporte");
                        Console.Out.Write("\n                         Periodo de " + certificado.PeriodoCertificado);
                    }
                    else if (certificado.TipoCertificado == 5)
                    {
                        Console.Out.Write("Informe curricular");
                    }
                    else if (certificado.TipoCertificado == 6)
                    {
                        Console.Out.Write("Informe curricular de postgrado");
                    }
                    else if (certificado.TipoCertificado == 7)
                    {
                        Console.Out.Write("Alumno regular de posgrado");
                    }
                    else
                    {
                        Console.Out.WriteLine("Hubo un error al generar el certificado. Verifique su entrada e intente nuevamente");
                        return;
                    }

                    Console.Out.WriteLine("\nNombre completo: " + NombrePersona + " " + ApellidoPersona);
                    Console.Out.WriteLine("Carrera: " + CarreraEstudiante.NombreCarrera);
                    Console.Out.WriteLine("Numero de matricula: " + NumMatricula);
                    Console.Out.WriteLine("Numero de telefono: " + NumeroTelefono);
                    Console.Out.WriteLine("Direccion: " + DireccionPersona);
                    Console.Out.WriteLine("Impuesto: " + certificado.ImpuestoCertificado);
                    Console.Out.WriteLine("Fecha de emision: " + DateTime.Now);
                    Console.Out.WriteLine("Fecha de vencimiento: " + certificado.Vigencia);
                    Console.Out.WriteLine("Codigo de verificacion: "+certificado.CodigoVerificacion);
                    Console.Out.WriteLine("\n         Certificado solo para fines indicados anteriormente.");
                    Console.Out.WriteLine("                       Universidad de Talca");
                    Console.Out.WriteLine("***********************************************************************");
                    numCertificados++;
                }
            }
        }

        public override void CambiarDatos(Universidad universidad)
        {
            string opEdicion;
            do
            {
                Console.Out.WriteLine("¿Que dato desea modificar?");
                Console.Out.WriteLine("[1] Nombres");
                Console.Out.WriteLine("[2] Apellidos");
                Console.Out.WriteLine("[3] Direccion");
                Console.Out.WriteLine("[4] Numero de telefono");
                Console.Out.WriteLine("[5] Carrera");
                Console.Out.WriteLine("[6] Numero de matricula");
                Console.Out.WriteLine("[7] Pregrado o postgrado");
                Console.Out.WriteLine("[8] Salir");
                Console.Out.WriteLine("Ingrese su opcion");
                opEdicion = Console.ReadLine();
                switch (opEdicion)
                {
                    case "1":
                        Console.Out.WriteLine("Ingrese los nuevos nombres del usuario");
                        NombrePersona = Console.ReadLine();
                        Console.Out.WriteLine("Cambio realizado correctamente");
                        break;
                    case "2":
                        Console.Out.WriteLine("Ingrese los nuevos apellidos del usuario");
                        ApellidoPersona = Console.ReadLine();
                        Console.Out.WriteLine("Cambio realizado correctamente");
                        break;
                    case "3":
                        Console.Out.WriteLine("Ingrese la nueva direccion del usuario");
                        DireccionPersona = Console.ReadLine();
                        Console.Out.WriteLine("Cambio realizado correctamente");
                        break;
                    case "4":
                        Console.Out.WriteLine("Ingrese el nuevo numero de telefono del usuario");
                        NumeroTelefono = Console.ReadLine();
                        Console.Out.WriteLine("Cambio realizado correctamente");
                        break;
                    case "5":
                        Console.WriteLine("Seleccione el numero correspondiente a la nueva carrera del estudiante");
                        Console.Out.WriteLine("Ingresar un caracter no numerico lanzara una excepcion");
                        int contOp = 1;
                        foreach (Carrera carreraActual in universidad.Carreras)
                        {
                            Console.WriteLine("[" + contOp + "] " + carreraActual.NombreCarrera);
                            contOp++;
                        }
                        try
                        {
                            int opCarrera = Convert.ToInt32(Console.ReadLine());
                            if (opCarrera - 1 >= universidad.Carreras.Count)
                            {
                                var exitCarrera = 0;
                                do
                                {
                                    Console.Out.WriteLine("El numero supero las opciones disponibles, intenta nuevamente");
                                    Console.WriteLine("Seleccione el numero correspondiente a la carrera del estudiante");
                                    Console.Out.WriteLine("Ingresar un caracter no numerico lanzara una excepcion");
                                    contOp = 1;
                                    foreach (Carrera carreraActual in universidad.Carreras)
                                    {
                                        Console.WriteLine("[" + contOp + "] " + carreraActual.NombreCarrera);
                                        contOp++;
                                        opCarrera = Convert.ToInt32(Console.ReadLine());
                                        if (opCarrera - 1 < universidad.Carreras.Count)
                                        {
                                            exitCarrera = 1;
                                        }
                                    }
                                } while (exitCarrera == 0);
                            }
                            Carrera carreraElegida = universidad.Carreras[opCarrera - 1];
                            CarreraEstudiante = carreraElegida;
                        }
                        catch (Exception e)
                        {
                            Console.Out.WriteLine("Se ingresó una opción no valida. Revise la entrada y reinicie el programa");
                            Console.WriteLine(e);
                            throw;
                        }
                        break;
                    case "6":
                        Console.Out.WriteLine("Ingrese el nuevo numero de matricula");
                        NumMatricula = Console.ReadLine();
                        break;
                    case "7":
                        Console.WriteLine("¿Es un estudiante de pregrado? [S/N]");
                        string prePos = Console.ReadLine();
                        bool boolPrePos = false;
                        if (prePos != null && prePos.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                        {
                            boolPrePos = true;
                        }
                        else if (prePos != null && prePos.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                        {
                            boolPrePos = false;
                        }
                        else
                        {
                            Console.WriteLine("Valor ingresado no valido, ingrese el valor nuevamente");
                            int exit = 0;
                            do
                            {
                                Console.WriteLine("¿Es un estudiante de pregrado? [S/N]");
                                prePos = Console.ReadLine();
                                if (prePos != null && prePos.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    boolPrePos = true;
                                    exit = 1;
                                }
                                else if (prePos != null && prePos.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    boolPrePos = false;
                                    exit = 1;
                                }
                                else
                                {
                                    Console.Out.WriteLine("Valor ingresado no valida, ingrese su opcion nuevamente");
                                }
                            } while (exit == 0);
                        }
                        IsEstudiantePosgrado = boolPrePos;
                        break;
                    case "8":
                        Console.Out.WriteLine("Saliendo del menu...");
                        break;
                    default:
                        Console.Out.WriteLine("Opcion no valida");
                        break;
                }

            } while (opEdicion != "8");
        }

        public void MenuCertificados(Estudiante datos)
        {
            string opCert;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Out.WriteLine("\n¡Bienvenido " + NombrePersona + "!");
                Console.Out.WriteLine("*********************************************");
                Console.Out.WriteLine("Elige el certificado a emitir:");
                Console.Out.WriteLine("[1] Año curso");
                Console.Out.WriteLine("[2] Asignacion familiar");
                Console.Out.WriteLine("[3] Canton reclutamiento");
                Console.Out.WriteLine("[4] Rebaja transporte");
                Console.Out.WriteLine("[5] Informe curricular");
                Console.Out.WriteLine("[6] Informe curricular postgrado");
                Console.Out.WriteLine("[7] Alumno regular postgrado");
                Console.Out.WriteLine("[8] Salir");
                Console.Out.WriteLine("*********************************************");
                Console.Out.WriteLine("Ingrese la opcion del certificado a emitir");
                opCert = Console.ReadLine();
                switch (opCert)
                {
                    case "1":
                        CertificadoEstudiante certificado1 = new CertificadoEstudiante();
                        Console.Out.WriteLine("Porque periodo desea realizar la emision del certificado");
                        Console.Out.WriteLine("Por ejemplo: 2019-1");
                        string periodo = Console.ReadLine();
                        certificado1.CrearCertificado(datos, 1, periodo, "No aplica");
                        CertificadosAlumno.Add(certificado1);
                        break;
                    case "2":
                        CertificadoEstudiante certificado2 = new CertificadoEstudiante();
                        Console.Out.WriteLine("¿Por que periodo desea realizar la emision del certificado? (Otoño o Verano)");
                        string periodoCert = Console.ReadLine();
                        if (periodoCert != null && (periodoCert.Equals("Otoño", StringComparison.OrdinalIgnoreCase) ||
                                                    periodoCert.Equals("Verano", StringComparison.OrdinalIgnoreCase)))
                        {
                            Console.Out.WriteLine("Ingrese el destinatario del certificado");
                            string dest = Console.ReadLine();
                            certificado2.CrearCertificado(datos, 2, periodoCert, dest);
                            CertificadosAlumno.Add(certificado2);
                        }
                        else
                        {
                            Console.Out.WriteLine("No se ingresó un periodo valido. Revise la entrada e intente nuevamente");
                        }
                        break;
                    case "3":
                        CertificadoEstudiante certificado3 = new CertificadoEstudiante();
                        Console.Out.WriteLine("¿Por que periodo desea realizar la emision del certificado? (Otoño o Verano)");
                        string periodoCert3 = Console.ReadLine();
                        if (periodoCert3 != null && (periodoCert3.Equals("Otoño", StringComparison.OrdinalIgnoreCase) ||
                                                     periodoCert3.Equals("Verano", StringComparison.OrdinalIgnoreCase)))
                        {
                            certificado3.CrearCertificado(datos, 3, periodoCert3, "No aplica");
                            CertificadosAlumno.Add(certificado3);
                        }
                        else
                        {
                            Console.Out.WriteLine("No se ingresó un periodo valido. Revise la entrada e intente nuevamente");
                        }
                        break;
                    case "4":
                        CertificadoEstudiante certificado4 = new CertificadoEstudiante();
                        Console.Out.WriteLine("¿Por que periodo desea realizar la emision del certificado? (Otoño o Verano)");
                        string periodoCert4 = Console.ReadLine();
                        if (periodoCert4 != null && (periodoCert4.Equals("Otoño", StringComparison.OrdinalIgnoreCase) ||
                                                     periodoCert4.Equals("Verano", StringComparison.OrdinalIgnoreCase)))
                        {
                            certificado4.CrearCertificado(datos, 4, periodoCert4, "No aplica");
                            CertificadosAlumno.Add(certificado4);
                        }
                        else
                        {
                            Console.Out.WriteLine("No se ingresó un periodo valido. Revise la entrada e intente nuevamente");
                        }
                        break;
                    case "5":
                        CertificadoEstudiante certificado5 = new CertificadoEstudiante();
                        certificado5.CrearCertificado(datos, 5, "No aplica", "No aplica");
                        CertificadosAlumno.Add(certificado5);
                        break;
                    case "6":
                        if (IsEstudiantePosgrado == true)
                        {
                            CertificadoEstudiante certificado6 = new CertificadoEstudiante();
                            certificado6.CrearCertificado(datos, 6, "No aplica", "No aplica");
                            CertificadosAlumno.Add(certificado6);
                        }
                        else if (IsEstudiantePosgrado == false)
                        {
                            Console.Out.WriteLine("No eres un alumno de postgrado, por lo que no puedes sacar este certificado :/");
                        }
                        break;
                    case "7":
                        if (IsEstudiantePosgrado == true)
                        {
                            CertificadoEstudiante certificado7 = new CertificadoEstudiante();
                            certificado7.CrearCertificado(datos, 7, "No aplica", "No aplica");
                            CertificadosAlumno.Add(certificado7);
                        }
                        else if (IsEstudiantePosgrado == false)
                        {
                            Console.Out.WriteLine("No eres un alumno de postgrado, por lo que no puedes sacar este certificado :/");
                        }
                        break;
                    case "8":
                        Console.Out.WriteLine("Saliendo del menu...");
                        break;
                    default:
                        Console.Out.WriteLine("Opcion no valida :(");
                        break;
                }
            } while (opCert != "8");
        }

    }
}
