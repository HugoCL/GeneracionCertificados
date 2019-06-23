using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace generacionCertificados
{
    class Funcionario : PersonaUniversitaria {

        public string RutFuncionario { get; set; }
        public string Departamento { get; set; }

        public bool TipoContrato { get; set; } // TRUE PARA HONORARIO, FALSE PARA FIJO
        public string Perfil { get; set; }
        public int Sueldo { get; set; }
        public List<Certificado> CertificadosFuncionario { get; set; }

        public Funcionario()
        {
            CertificadosFuncionario = new List<Certificado>();
        }


        public override void ListarInfo(string cantidadInfo, int idFunc)
        {
            Console.Out.WriteLine("******************************************************");
            Console.Out.WriteLine("\nFUNCIONARIO NUMERO " + idFunc);
            if (cantidadInfo == "1")
            {
                Console.WriteLine("Nombre completo: " + NombrePersona + " " + ApellidoPersona);
                Console.WriteLine("Departamento: " + Departamento);
                Console.WriteLine("RUT: " + RutFuncionario);
            }

            else
            {
                Console.WriteLine("\nNombre completo: " + NombrePersona + " " + ApellidoPersona);
                Console.WriteLine("Departamento: " + Departamento);
                Console.WriteLine("RUT: " + RutFuncionario);
                Console.WriteLine(TipoContrato ? "Es un funcionario a honorarios" : "Es funcionario con contrato fijo");
                Console.WriteLine("Direccion: " + DireccionPersona);
                Console.WriteLine("Numero de telefono: " + NumeroTelefono);
                Console.WriteLine("Perfil: " + Perfil);
            }
            Console.Out.WriteLine("******************************************************");
        }

        public override void CrearPersonaUniversitaria(Universidad universidad)
        {
            Console.WriteLine("\nSe ingresará un funcionario al sistema");
            Console.WriteLine("Ingrese los nombres del funcionario:");
            NombrePersona = Console.ReadLine();
            Console.WriteLine("Ingrese los apellido del funcionario");
            ApellidoPersona = Console.ReadLine();
            Console.Out.WriteLine("Ingrese el rut del funcionario sin puntos y con guion");
            Console.Out.WriteLine("Ejemplo: 20308423-5");
            string rutProfesorPrelim = Console.ReadLine();
            const string patron = @"[0-9]+-[0-9]{1}";
            if (Regex.IsMatch(rutProfesorPrelim ?? throw new InvalidOperationException(), patron) == false)
            {
                int exitoRut = 0;
                do
                {
                    Console.Out.WriteLine("Rut ingresado no cumple con el formato, intentelo nuevamente:");
                    Console.Out.WriteLine("Ingrese el rut del funcionario sin puntos y con guion");
                    Console.Out.WriteLine("Ejemplo: 20308423-5");
                    rutProfesorPrelim = Console.ReadLine();
                    if (Regex.IsMatch(rutProfesorPrelim ?? throw new InvalidOperationException(), patron))
                    {
                        exitoRut = 1;
                    }
                } while (exitoRut != 1);
            }
            RutFuncionario = rutProfesorPrelim;
            Console.WriteLine("Ingrese direccion del funcionario");
            DireccionPersona = Console.ReadLine();
            Console.WriteLine("Ingrese el numero de telefono del funcionario");
            NumeroTelefono = Console.ReadLine();
            Console.Out.WriteLine("Ingrese su departamento");
            Departamento = Console.ReadLine();
            Console.Out.WriteLine("Elija el tipo de contrato que posee actualmente:");
            Console.Out.WriteLine("[1] Fijo");
            Console.Out.WriteLine("[2] Honorario");
            var tipoSueldo = Console.ReadLine();
            if (tipoSueldo == "1")
            {
                TipoContrato = false;
            }
            else if (tipoSueldo == "2")
            {
                TipoContrato = true;
            }
            else
            {
                var exitoCon = 0;
                do
                {
                    Console.Out.WriteLine("Tipo de contrato no valido");
                    Console.Out.WriteLine("Ingrese la opcion nuevamente: ");
                    Console.Out.WriteLine("[1] Fijo");
                    Console.Out.WriteLine("[2] Honorario");
                    tipoSueldo = Console.ReadLine();
                    if (tipoSueldo == "1")
                    {
                        TipoContrato = false;
                        exitoCon = 1;
                    }
                    else if (tipoSueldo == "2")
                    {
                        TipoContrato = true;
                        exitoCon = 1;
                    }
                } while (exitoCon != 1);
            }
            Console.Out.WriteLine("Ingrese el tipo de perfil: ");
            Perfil = Console.ReadLine();
            try
            {
                Console.Out.WriteLine("Ingrese el sueldo: ");
                Console.Out.WriteLine("Usar caracteres no numericos lanzará una excepcion");
                int sueldo = Convert.ToInt32(Console.ReadLine());
                Sueldo = sueldo;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Se recibió un caracter no numerico. Reinicie el programa e intente nuevamente.");
                Console.WriteLine(e);
                throw;
            }
            
            Console.Out.WriteLine("Perfil creado exitosamente");
        }

        public override void ListarCertificados()
        {
            if(CertificadosFuncionario.Count == 0)
            {
                Console.Out.WriteLine("No hay certificados asociados a este funcionario");
            }
            else
            {
                int numCert = 1;
                foreach (CertificadoFuncionario certificado in CertificadosFuncionario)
                {
                    Console.Out.WriteLine("CERTIFICADO NUMERO " + numCert);
                    Console.Out.WriteLine("***********************************************************************");
                    Console.Out.WriteLine("                       Universidad de Talca");
                    Console.Out.Write("                    Certificado de ");
                    if (certificado.TipoCertificado == 8)
                    {
                        Console.Out.Write("Antiguedad\n");
                        Console.Out.WriteLine("\nEste certificado esta destinado exclusivamente a: " +
                                              certificado.Destinatario);
                    }
                    else if (certificado.TipoCertificado == 9)
                    {
                        Console.Out.Write("Honorarios\n");
                        Console.Out.WriteLine("Pago bruto: " + Sueldo);
                        Console.Out.WriteLine("Pago retenido (10%): " + (Sueldo * 0.10));
                    }

                    Console.Out.WriteLine("Nombre completo: " + NombrePersona + " " + ApellidoPersona);
                    Console.Out.WriteLine("Departamento: " + Departamento);
                    Console.Out.WriteLine("RUT: " + RutFuncionario);
                    Console.Out.WriteLine("Numero de telefono: " + NumeroTelefono);
                    Console.Out.WriteLine("Direccion: " + DireccionPersona);
                    Console.Out.WriteLine("Impuesto: " + certificado.ImpuestoCertificado);
                    Console.Out.WriteLine("Fecha de emision: " + certificado.FechaCreacion);
                    Console.Out.WriteLine("Fecha de vencimiento " + certificado.Vigencia);
                    Console.Out.WriteLine("Codigo de validacion: " + certificado.CodigoVerificacion);
                    Console.Out.WriteLine("\n         Certificado solo para fines indicados anteriormente.");
                    Console.Out.WriteLine("                       Universidad de Talca");
                    Console.Out.WriteLine("***********************************************************************");
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
                Console.Out.WriteLine("[5] Departamento");
                Console.Out.WriteLine("[6] RUT");
                Console.Out.WriteLine("[7] Tipo de contrato");
                Console.Out.WriteLine("[8] Perfil");
                Console.Out.WriteLine("[9] Sueldo");
                Console.Out.WriteLine("[10] Salir");
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
                        Console.Out.WriteLine("Ingrese el nuevo departamento del usuario");
                        Departamento = Console.ReadLine();
                        Console.Out.WriteLine("Cambio realizado correctamente");
                        break;
                    case "6":
                        Console.Out.WriteLine("Ingrese el nuyevo rut del funcionario sin puntos y con guion");
                        Console.Out.WriteLine("Ejemplo: 20308423-5");
                        string rutProfesorPrelim = Console.ReadLine();
                        const string patron = @"[0-9]+-[0-9]{1}";
                        if (Regex.IsMatch(rutProfesorPrelim ?? throw new InvalidOperationException(), patron) == false)
                        {
                            int exitoRut = 0;
                            do
                            {
                                Console.Out.WriteLine("Rut ingresado no cumple con el formato, intentelo nuevamente:");
                                Console.Out.WriteLine("Ingrese el rut del funcionario sin puntos y con guion");
                                Console.Out.WriteLine("Ejemplo: 20308423-5");
                                rutProfesorPrelim = Console.ReadLine();
                                if (Regex.IsMatch(rutProfesorPrelim ?? throw new InvalidOperationException(), patron))
                                {
                                    exitoRut = 1;
                                }
                            } while (exitoRut != 1);
                        }
                        RutFuncionario = rutProfesorPrelim;
                        Console.Out.WriteLine("Cambio realizado correctamente");
                        break;
                    case "7":
                        Console.Out.WriteLine("Elija el nuevo tipo de contrato que posee actualmente:");
                        Console.Out.WriteLine("[1] Fijo");
                        Console.Out.WriteLine("[2] Honorario");
                        var tipoSueldo = Console.ReadLine();
                        switch (tipoSueldo)
                        {
                            case "1":
                                TipoContrato = false;
                                break;
                            case "2":
                                TipoContrato = true;
                                break;
                            default:
                            {
                                var exitoCon = 0;
                                do
                                {
                                    Console.Out.WriteLine("Tipo de contrato no valido");
                                    Console.Out.WriteLine("Ingrese la opcion nuevamente: ");
                                    Console.Out.WriteLine("[1] Fijo");
                                    Console.Out.WriteLine("[2] Honorario");
                                    tipoSueldo = Console.ReadLine();
                                    if (tipoSueldo == "1")
                                    {
                                        TipoContrato = false;
                                        exitoCon = 1;
                                    }
                                    else if (tipoSueldo == "2")
                                    {
                                        TipoContrato = true;
                                        exitoCon = 1;
                                    }
                                } while (exitoCon != 1);

                                break;
                            }
                        }
                        Console.Out.WriteLine("Cambio realizado correctamente");
                        break;
                    case "8":
                        Console.Out.WriteLine("Ingrese el nuevo perfil del funcionario");
                        Perfil = Console.ReadLine();
                        Console.Out.WriteLine("Cambio realizado correctamente");
                        break;
                    case "9":
                        try
                        {
                            Console.Out.WriteLine("Ingrese el nuevo sueldo: ");
                            Console.Out.WriteLine("Usar caracteres no numericos lanzará una excepcion");
                            int sueldo = Convert.ToInt32(Console.ReadLine());
                            Sueldo = sueldo;
                        }
                        catch (Exception e)
                        {
                            Console.Out.WriteLine("Se recibió un caracter no numerico. Reinicie el programa e intente nuevamente.");
                            Console.WriteLine(e);
                            throw;
                        }
                        break;
                    case "10":
                        Console.Out.WriteLine("Saliendo del menu...");
                        break;
                    default:
                        Console.Out.WriteLine("Opcion no valida :(");
                        break;
                }
            } while (opEdicion != "10");
        }

        public void MenuCertificados(Funcionario datos)
        {
            string opCert;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Out.WriteLine("\n¡Bienvenido " + NombrePersona + "!");
                Console.Out.WriteLine("*********************************************");
                Console.Out.WriteLine("Certificados disponibles");
                Console.Out.WriteLine("[1] Antiguedad");
                Console.Out.WriteLine("[2] Honorarios");
                Console.Out.WriteLine("[3] Salir");
                Console.Out.WriteLine("Elige el certificado a emitir:");
                opCert = Console.ReadLine();
                switch (opCert)
                {
                    case "1":
                        Console.Out.WriteLine("Ingrese el destinatario del certificado");
                        string dest = Console.ReadLine();
                        CertificadoFuncionario certificado1 = new CertificadoFuncionario();
                        certificado1.CrearCertificado(datos, 8, dest);
                        CertificadosFuncionario.Add(certificado1);
                        break;
                    case "2":
                        if (TipoContrato == false) {
                            Console.Out.WriteLine("No eres un trabajador a honorarios, por lo que no puedes generar este certificado");
                        }
                        else
                        {
                            CertificadoFuncionario certificado2 = new CertificadoFuncionario();
                            certificado2.CrearCertificado(datos, 9, "No aplica");
                            CertificadosFuncionario.Add(certificado2);
                        }
                        break;
                    case "3":
                        Console.Out.WriteLine("Saliendo del menu...");
                        break;
                    default:
                        Console.Out.WriteLine("Opcion no valida :(");
                        break;
                }
            } while (opCert != "3");
        }
    }
}
