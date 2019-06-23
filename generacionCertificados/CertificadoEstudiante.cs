using System;

namespace generacionCertificados
{
    class CertificadoEstudiante : Certificado
    {
        public void CrearCertificado(Estudiante datos, int idCertificado, string infoAuxiliar, string infoAuxiliar2)
        {
            Console.Out.WriteLine("***********************************************************************");
            Console.Out.WriteLine("                       Universidad de Talca");
            Console.Out.Write("                    Certificado de ");
            if (idCertificado == 1)
            {
                Console.Out.Write("Año Curso - Periodo "+infoAuxiliar);
                ImpuestoCertificado = "$4000";
                VigenciaEstablecida = 15;
                TipoCertificado = 1;
                PeriodoCertificado = infoAuxiliar;
            }
            else if (idCertificado == 2)
            {
                Console.Out.Write("Asignacion Familiar");
                Console.Out.Write("\n                         Periodo de " + infoAuxiliar+"\n");
                Console.Out.WriteLine("\nEste certificado esta destinado exclusivamente a: " + infoAuxiliar2);
                ImpuestoCertificado = "$0";
                VigenciaEstablecida = 30;
                TipoCertificado = 2;
                PeriodoCertificado = infoAuxiliar;
            }
            else if (idCertificado == 3)
            {
                Console.Out.Write("Canton Reclutamiento");
                Console.Out.Write("\n                         Periodo de " + infoAuxiliar);
                ImpuestoCertificado = "$0";
                VigenciaEstablecida = 20;
                TipoCertificado = 3;
                PeriodoCertificado = infoAuxiliar;
            }
            else if (idCertificado == 4)
            {
                Console.Out.Write("Rebaja de Transporte");
                Console.Out.Write("\n                         Periodo de " + infoAuxiliar);
                ImpuestoCertificado = "$0";
                VigenciaEstablecida = 20;
                TipoCertificado = 4;
                PeriodoCertificado = infoAuxiliar;
            }
            else if (idCertificado == 5)
            {
                Console.Out.Write("Informe curricular");
                ImpuestoCertificado = "$5000";
                VigenciaEstablecida = 25;
                TipoCertificado = 5;
            }
            else if (idCertificado == 6)
            {
                Console.Out.Write("Informe curricular de postgrado");
                ImpuestoCertificado = "$10000";
                VigenciaEstablecida = 35;
                TipoCertificado = 6;
            }
            else if (idCertificado == 7)
            {
                Console.Out.Write("Alumno regular de posgrado");
                ImpuestoCertificado = "$10000";
                VigenciaEstablecida = 30;
                TipoCertificado = 7;
            }
            else
            {
                Console.Out.WriteLine("Hubo un error al generar el certificado. Verifique su entrada e intente nuevamente");
                return;
            }
            Console.Out.WriteLine("\nNombre completo: "+datos.NombrePersona+" "+datos.ApellidoPersona);
            Console.Out.WriteLine("Carrera: "+datos.CarreraEstudiante.NombreCarrera);
            Console.Out.WriteLine("Numero de matricula: "+datos.NumMatricula);
            Console.Out.WriteLine("Numero de telefono: "+datos.NumeroTelefono);
            Console.Out.WriteLine("Direccion: "+datos.DireccionPersona);
            Console.Out.WriteLine("Impuesto: "+ImpuestoCertificado);
            FechaCreacion = DateTime.Now;
            Console.Out.WriteLine("Fecha de emision: " +FechaCreacion);
            TimeSpan vigenciaCert = TimeSpan.FromDays(VigenciaEstablecida);
            Vigencia = DateTime.Now.Add(vigenciaCert);
            Console.Out.WriteLine("Fecha de vencimiento "+Vigencia);
            string codigoValidacion = FechaCreacion.Year.ToString() + FechaCreacion.Month.ToString() + datos.NumMatricula + FechaCreacion.Second.ToString();
            Console.Out.WriteLine("Codigo de validacion: "+ codigoValidacion);
            CodigoVerificacion = codigoValidacion;
            Console.Out.WriteLine("\n         Certificado solo para fines indicados anteriormente.");
            Console.Out.WriteLine("                       Universidad de Talca");
            Console.Out.WriteLine("***********************************************************************");
        }
    }
}
