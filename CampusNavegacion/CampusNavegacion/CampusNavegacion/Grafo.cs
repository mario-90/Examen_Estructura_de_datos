using System;
using System.Collections.Generic;

namespace CampusNavegacion
{
    public class Grafo
    {
        private Dictionary<string, List<(string destino, int distancia)>> listaAdyacencia = new Dictionary<string, List<(string, int)>>();

        public void AgregarEdificio(string nombre)
        {
            if (!listaAdyacencia.ContainsKey(nombre)) listaAdyacencia[nombre] = new List<(string, int)>();
        }

        public void AgregarCamino(string origen, string destino, int distancia)
        {
            listaAdyacencia[origen].Add((destino, distancia));
            listaAdyacencia[destino].Add((origen, distancia));
        }

        public void MostrarGrafo()
        {
            Console.WriteLine("=== MAPA DEL CAMPUS ===");
            foreach (var nodo in listaAdyacencia)
            {
                Console.Write($"{nodo.Key}: ");
                foreach (var arista in nodo.Value)
                {
                    Console.Write($"-> {arista.destino} [{arista.distancia}m] ");
                }
                Console.WriteLine();
            }
        }

        // Ahora retorna la lista de visitados para poder pintarlos
        public List<string> RecorridoBFS(string inicio, TablaHash tablaHash)
        {
            Console.WriteLine($"\n=== RECORRIDO BFS desde: {inicio} ===");
            HashSet<string> visitados = new HashSet<string>();
            Queue<string> cola = new Queue<string>();
            List<string> ordenVisita = new List<string>();

            cola.Enqueue(inicio);
            visitados.Add(inicio);
            int nivel = 0;

            while (cola.Count > 0)
            {
                int cantNivel = cola.Count;
                List<string> nivelesActuales = new List<string>();

                for (int i = 0; i < cantNivel; i++)
                {
                    string actual = cola.Dequeue();
                    nivelesActuales.Add(actual);
                    tablaHash.RegistrarVisita(actual);
                    ordenVisita.Add(actual);

                    foreach (var vecino in listaAdyacencia[actual])
                    {
                        if (!visitados.Contains(vecino.destino))
                        {
                            visitados.Add(vecino.destino);
                            cola.Enqueue(vecino.destino);
                        }
                    }
                }
                Console.WriteLine($"Nivel {nivel}: {string.Join(" | ", nivelesActuales)}");
                nivel++;
            }
            Console.WriteLine($"Total de edificios visitados: {ordenVisita.Count}");
            return ordenVisita;
        }

        // Retorna una tupla con los nodos visitados y el camino final encontrado
        public (List<string> visitados, List<string> camino) RecorridoDFS(string inicio, string destino, TablaHash tablaHash)
        {
            Console.WriteLine($"\n=== RECORRIDO DFS: {inicio} --> {destino} ===");
            Stack<(string nodo, List<string> camino)> pila = new Stack<(string, List<string>)>();
            HashSet<string> visitados = new HashSet<string>();
            List<string> ordenVisita = new List<string>();

            pila.Push((inicio, new List<string> { inicio }));

            while (pila.Count > 0)
            {
                var actual = pila.Pop();
                if (!visitados.Contains(actual.nodo))
                {
                    Console.WriteLine($"Visitando: {actual.nodo}");
                    tablaHash.RegistrarVisita(actual.nodo);
                    visitados.Add(actual.nodo);
                    ordenVisita.Add(actual.nodo);

                    if (actual.nodo == destino)
                    {
                        int distanciaTotal = 0;
                        for (int i = 0; i < actual.camino.Count - 1; i++)
                        {
                            string nodoActual = actual.camino[i];
                            string nodoSiguiente = actual.camino[i + 1];
                            foreach (var vecino in listaAdyacencia[nodoActual])
                            {
                                if (vecino.destino == nodoSiguiente)
                                {
                                    distanciaTotal += vecino.distancia;
                                    break;
                                }
                            }
                        }

                        Console.WriteLine($"\n✓ Camino encontrado:");
                        Console.WriteLine($"  {string.Join(" → ", actual.camino)}");
                        Console.WriteLine($"  Distancia total del camino: {distanciaTotal} metros");
                        return (ordenVisita, actual.camino);
                    }

                    var vecinos = new List<(string destino, int distancia)>(listaAdyacencia[actual.nodo]);
                    vecinos.Reverse();
                    foreach (var vecino in vecinos)
                    {
                        if (!visitados.Contains(vecino.destino))
                        {
                            var nuevoCamino = new List<string>(actual.camino) { vecino.destino };
                            pila.Push((vecino.destino, nuevoCamino));
                        }
                    }
                }
            }
            Console.WriteLine("✗ Camino no encontrado.");
            return (ordenVisita, new List<string>());
        }

        public List<(string destino, int distancia)> ObtenerVecinos(string edificio)
        {
            return listaAdyacencia.ContainsKey(edificio) ? listaAdyacencia[edificio] : new List<(string, int)>();
        }
    }
}