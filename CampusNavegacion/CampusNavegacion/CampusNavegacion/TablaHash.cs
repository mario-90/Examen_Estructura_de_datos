using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusNavegacion
{
    public class TablaHash
    {
        private Dictionary<string, int> visitas = new Dictionary<string, int>();

     
        public void RegistrarVisita(string edificio) // [cite: 73]
        {
            if (visitas.ContainsKey(edificio)) visitas[edificio]++;
            else visitas[edificio] = 1;
        }

        public int ObtenerConteo(string edificio) // [cite: 73]
        {
            return visitas.ContainsKey(edificio) ? visitas[edificio] : 0;
        }

        public void MostrarEstadisticas()
        {
            Console.WriteLine("=== ESTADÍSTICAS DE VISITAS ===");
            var ordenados = visitas.OrderByDescending(v => v.Value).ToList();
            int max = ordenados[0].Value;
            foreach (var item in ordenados)
            {
                string barras = new string('█', item.Value * 2);
                Console.WriteLine($"{item.Key,-35}: {barras} {item.Value} visitas");
            }
            Console.WriteLine($"\nEdificio más visitado: {EdificioMasVisitado()}");
        }

        public string EdificioMasVisitado() // [cite: 75]
        {
            if (visitas.Count == 0) return "Ninguno";
            var max = visitas.OrderByDescending(v => v.Value).First();
            return $"{max.Key} con {max.Value} visitas";
        }
    }
}