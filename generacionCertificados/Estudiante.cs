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
                Console.WriteLine(IsEstudiantePosgrado == true ? "Es un alumno de postgrado" : "Es un alumno de pregrado");
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
                    if (certificado.tipoCertificado == 1)
                    {
                        Console.Out.Write("Año Curso - Periodo " + certificado.periodoCertificado);
                    }
                    else if (certificado.tipoCertificado == 2)
                    {
                        Console.Out.Write("Asignacion Familiar");
                        Console.Out.Write("\n                         Periodo de " + certificado.periodoCertificado);
                    }
                    else if (certificado.tipoCertificado == 3)
                    {
                        Console.Out.Write("Canton Reclutamiento");
                        Console.Out.Write("\n                         Periodo de " + certificado.periodoCertificado);
                    }
                    else if (certificado.tipoCertificado == 4)
                    {
                        Console.Out.Write("Rebaja de Transporte");
                        Console.Out.Write("\n                         Periodo de " + certificado.periodoCertificado);
                    }
                    else if (certificado.tipoCertificado == 5)
                    {
                        Console.Out.Write("Informe curricular");
                    }
                    else if (certificado.tipoCertificado == 6)
                    {
                        Console.Out.Write("Informe curricular de postgrado");
                    }
                    else if (certificado.tipoCertificado == 7)
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
                    Console.Out.WriteLine("Fecha de vencimiento " + certificado.Vigencia);
                    Console.Out.WriteLine("\n         Certificado solo para fines indicados anteriormente.");
                    Console.Out.WriteLine("                       Universidad de Talca");
                    Console.Out.WriteLine("***********************************************************************");
                    numCertificados++;
                }
            }
        }

        public void MenuCertificados(Estudiante datos)
        {
            string opCert = "0";
            do
            {
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
                        if (periodoCert.Equals("Otoño", StringComparison.OrdinalIgnoreCase) ||
                            periodoCert.Equals("Verano", StringComparison.OrdinalIgnoreCase))
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
                        if (periodoCert3.Equals("Otoño", StringComparison.OrdinalIgnoreCase) ||
                            periodoCert3.Equals("Verano", StringComparison.OrdinalIgnoreCase))
                        {
                            certificado3.CrearCertificado(datos, 2, periodoCert3, "No aplica");
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
                        if (periodoCert4.Equals("Otoño", StringComparison.OrdinalIgnoreCase) ||
                            periodoCert4.Equals("Verano", StringComparison.OrdinalIgnoreCase))
                        {
                            certificado4.CrearCertificado(datos, 2, periodoCert4, "No aplica");
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
                }
            } while (opCert != "8");
        }

    }
}
