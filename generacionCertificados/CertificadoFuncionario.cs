using System;

namespace generacionCertificados
{
    class CertificadoFuncionario : Certificado
    {
        public  void CrearCertificado(Funcionario datos, int idCertificado, string infoAuxiliar)
        {
            Console.Out.WriteLine("***********************************************************************");
            Console.Out.WriteLine("                       Universidad de Talca");
            Console.Out.Write("                    Certificado de ");
            if (idCertificado == 8)
            {
                Console.Out.Write("Antiguedad\n");
                Console.Out.WriteLine("\nEste certificado esta destinado exclusivamente a: "+infoAuxiliar);
                ImpuestoCertificado = "$10000";
                VigenciaEstablecida = 30;
                TipoCertificado = 8;
                Destinatario = infoAuxiliar;
            }
            else if (idCertificado == 9)
            {
                Console.Out.Write("Honorarios\n");
                Console.Out.WriteLine("Pago bruto: "+datos.Sueldo);
                Console.Out.WriteLine("Pago retenido (10%): "+(datos.Sueldo*0.10));
                ImpuestoCertificado = "$30000";
                VigenciaEstablecida = 30;
                TipoCertificado = 9;
                Sueldo = infoAuxiliar;
            }
            Console.Out.WriteLine("Nombre completo: " + datos.NombrePersona + " " + datos.ApellidoPersona);
            Console.Out.WriteLine("Departamento: " + datos.Departamento);
            Console.Out.WriteLine("RUT: " + datos.RutFuncionario);
            Console.Out.WriteLine("Numero de telefono: " + datos.NumeroTelefono);
            Console.Out.WriteLine("Direccion: " + datos.DireccionPersona);
            Console.Out.WriteLine("Impuesto: " + ImpuestoCertificado);
            FechaCreacion = DateTime.Now;
            Console.Out.WriteLine("Fecha de emision: " + FechaCreacion);
            TimeSpan vigenciaCert = TimeSpan.FromDays(VigenciaEstablecida);
            Vigencia = DateTime.Now.Add(vigenciaCert);
            Console.Out.WriteLine("Fecha de vencimiento " + Vigencia);
            string[] rut = datos.RutFuncionario.Split('-');
            string codigoValidacion = FechaCreacion.Year.ToString() + FechaCreacion.Month.ToString() + rut[0] + FechaCreacion.Second.ToString();
            Console.Out.WriteLine("Codigo de validacion: " + codigoValidacion);
            CodigoVerificacion = codigoValidacion;
            Console.Out.WriteLine("\n         Certificado solo para fines indicados anteriormente.");
            Console.Out.WriteLine("                       Universidad de Talca");
            Console.Out.WriteLine("***********************************************************************");
        }
    }
}
