using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generacionCertificados
{
    class Universidad
    {

        public Universidad()
        {
            Carreras = new List<Carrera>();
            Estudiantes = new List<Estudiante>();
            Funcionarios = new List<Funcionario>();
        }

        public string NombreUniversidad { get; set; }
        public List<Estudiante> Estudiantes { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
        public List<Carrera> Carreras { get; set; }


        public void listarCarreras()
        {
            Console.WriteLine("Estas son las carreras disponibles");
            int contCarre = 1;
            foreach (Carrera carreraActual in Carreras)
            {
                Console.WriteLine("[" + contCarre + "] " + carreraActual.NombreCarrera);
                contCarre++;
            }
            if (contCarre == 1) { Console.WriteLine("No hay carreras ingresadas"); }
        }
        
    }
}
