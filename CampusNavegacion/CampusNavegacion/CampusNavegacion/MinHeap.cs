using System;
using System.Collections.Generic;

namespace CampusNavegacion
{
    public class MinHeap
    {
        private List<(string edificio, int distancia)> heap = new List<(string, int)>();

        
        public void Insertar(string edificio, int distancia) // [cite: 89]
        {
            heap.Add((edificio, distancia));
            Flotar(heap.Count - 1);
        }

       
        public (string edificio, int distancia) ExtraerMinimo() // [cite: 89]
        {
            if (EstaVacio()) throw new InvalidOperationException("Heap vacío");
            var minimo = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            if (!EstaVacio()) Hundir(0);
            return minimo;
        }

        public bool EstaVacio() => heap.Count == 0; // [cite: 90]


        public void MostrarRutasOrdenadas(string origen = "")
        {
            string titulo = string.IsNullOrEmpty(origen)
                ? "=== RUTAS Ordenadas por distancia ==="
                : $"=== RUTAS DESDE {origen} — Ordenadas por distancia ===";
            Console.WriteLine(titulo);
            int index = 1;
            while (!EstaVacio())
            {
                var ruta = ExtraerMinimo();
                Console.WriteLine($"{index}° {ruta.edificio,-35} {ruta.distancia} metros");
                index++;
            }
            Console.WriteLine("Heap vacío — todas las rutas fueron procesadas.");
        }

        private void Flotar(int indice)
        {
            while (indice > 0)
            {
                int padre = (indice - 1) / 2;
                if (heap[indice].distancia >= heap[padre].distancia) break;
                var temp = heap[indice];
                heap[indice] = heap[padre];
                heap[padre] = temp;
                indice = padre;
            }
        }

        private void Hundir(int indice)
        {
            while (true)
            {
                int hIzq = 2 * indice + 1, hDer = 2 * indice + 2, menor = indice;
                if (hIzq < heap.Count && heap[hIzq].distancia < heap[menor].distancia) menor = hIzq;
                if (hDer < heap.Count && heap[hDer].distancia < heap[menor].distancia) menor = hDer;
                if (menor == indice) break;
                var temp = heap[indice];
                heap[indice] = heap[menor];
                heap[menor] = temp;
                indice = menor;
            }
        }
    }
}