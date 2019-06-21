using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
                Console.WriteLine(TipoContrato == true ? "Es un funcionario a honorarios" : "Es funcionario con contrato fijo");
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
            string RutProfesorPrelim = Console.ReadLine();
            string patron = @"[0-9]+-[0-9]{1}";
            if (Regex.IsMatch(RutProfesorPrelim, patron) == false)
            {
                int exitoRut = 0;
                do
                {
                    Console.Out.WriteLine("Rut ingresado no cumple con el formato, intentelo nuevamente:");
                    Console.Out.WriteLine("Ingrese el rut del funcionario sin puntos y con guion");
                    Console.Out.WriteLine("Ejemplo: 20308423-5");
                    RutProfesorPrelim = Console.ReadLine();
                    if (Regex.IsMatch(RutProfesorPrelim, patron) == true)
                    {
                        exitoRut = 1;
                    }
                } while (exitoRut != 1);
            }
            RutFuncionario = RutProfesorPrelim;
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
            throw new NotImplementedException();
        }

        public void MenuCertificados(Funcionario datos)
        {
            string opCert = "0";
            do
            {
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
                }
            } while (opCert != "3");
        }
    }
}
