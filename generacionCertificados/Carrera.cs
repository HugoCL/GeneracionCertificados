using System;

namespace generacionCertificados
{
    class Carrera
    {

        public string NombreCarrera { get; set; }
        public string CodigoCarrera { get; set; }

        public void CrearCarrera()
        {
            Console.WriteLine("\nSe ingresará una carrera");
            Console.WriteLine("Ingrese el nombre de la carrera");
            string nCarrera = Console.ReadLine();
            Console.WriteLine("Ingrese el codigo asociado a la carrera");
            string cCarrera = Console.ReadLine();
            NombreCarrera = nCarrera;
            CodigoCarrera = cCarrera;
        }
    }
}
