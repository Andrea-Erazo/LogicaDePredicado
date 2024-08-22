using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaExpertoDiagnostico
{
    class Program
    {
        static void Main(string[] args)
        {
            Enfermedad gripe = new Enfermedad("Gripe");
            gripe.AgregarSintoma("Fiebre");
            gripe.AgregarSintoma("Tos");
            gripe.AgregarSintoma("Dolor de garganta");

            Enfermedad resfriado = new Enfermedad("Resfriado");
            resfriado.AgregarSintoma("Estornudos");
            resfriado.AgregarSintoma("Congestión nasal");
            resfriado.AgregarSintoma("Tos");

            Enfermedad covid = new Enfermedad("COVID-19");
            covid.AgregarSintoma("Fiebre");
            covid.AgregarSintoma("Tos");
            covid.AgregarSintoma("Dificultad para respirar");
            covid.AgregarSintoma("Fatiga");

            Diagnostico diagnostico = new Diagnostico();
            diagnostico.AgregarEnfermedad(gripe);
            diagnostico.AgregarEnfermedad(resfriado);
            diagnostico.AgregarEnfermedad(covid);

            List<string> sintomasPaciente = new List<string> { "Fiebre", "Tos", "Fatiga" };
            List<Enfermedad> enfermedadesPosibles = diagnostico.Diagnosticar(sintomasPaciente);

            Console.WriteLine("Enfermedades posibles:");
            foreach (var enfermedad in enfermedadesPosibles)
            {
                Console.WriteLine(enfermedad.Nombre);
            }
        }
    }

    class Enfermedad
    {
        public string Nombre { get; }
        private HashSet<string> sintomas;

        public Enfermedad(string nombre)
        {
            Nombre = nombre;
            sintomas = new HashSet<string>();
        }

        public void AgregarSintoma(string sintoma)
        {
            sintomas.Add(sintoma);
        }

        public bool TieneSintoma(string sintoma)
        {
            return sintomas.Contains(sintoma);
        }

        public IEnumerable<string> ObtenerSintomas()
        {
            return sintomas;
        }
    }

    class Diagnostico
    {
        private List<Enfermedad> enfermedades;

        public Diagnostico()
        {
            enfermedades = new List<Enfermedad>();
        }

        public void AgregarEnfermedad(Enfermedad enfermedad)
        {
            enfermedades.Add(enfermedad);
        }

        public List<Enfermedad> Diagnosticar(List<string> sintomasPaciente)
        {
            List<Enfermedad> resultado = new List<Enfermedad>();

            foreach (var enfermedad in enfermedades)
            {
                bool coincide = sintomasPaciente.All(s => enfermedad.TieneSintoma(s));
                if (coincide)
                {
                    resultado.Add(enfermedad);
                }
            }

            return resultado;
        }
    }
}