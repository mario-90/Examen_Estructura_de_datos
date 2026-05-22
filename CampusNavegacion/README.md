# Sistema de Navegación del Campus Universitario (SNCU)

**Curso:** Programación con Estructura de Datos  
**Catedrático:** Ing. Rafael Torres  
**Ciclo:** 2026 — Ciclo I  
**Carrera:** Ingeniería en Ciencias de la Computación — Facultad de Ingeniería, Universidad Don Bosco

---

## Descripción

Aplicación de escritorio en C# (.NET Framework 4.7.2 / Windows Forms) que simula el sistema de navegación de un campus universitario con 7 edificios interconectados. Implementa las siguientes estructuras de datos desde cero:

- **Grafo** con lista de adyacencia
- **BFS** (Breadth-First Search) con Queue
- **DFS** (Depth-First Search) con Stack
- **Tabla Hash** con Dictionary
- **Min-Heap** manual (sin PriorityQueue de .NET)

---

## Edificios del Campus

| Clave | Edificio |
|-------|----------|
| A | Biblioteca Central |
| B | Cafetería |
| C | Laboratorio de Cómputo |
| D | Rectoría |
| E | Gimnasio |
| F | Aulas Generales |
| G | Estacionamiento |

### Caminos peatonales (bidireccionales)

| Camino | Distancia |
|--------|-----------|
| A — B | 120 m |
| A — C | 200 m |
| B — D | 150 m |
| B — E | 300 m |
| C — F | 100 m |
| D — F | 80 m |
| E — G | 250 m |
| F — G | 180 m |

---

## Estructura del Proyecto

```
CampusNavegacion/
├── Grafo.cs          # Tarea 1, 2 y 3 — Grafo, BFS, DFS
├── TablaHash.cs      # Tarea 4 — Registro de visitas con Dictionary
├── MinHeap.cs        # Tarea 5 — Min-Heap manual
├── MainForm.cs       # Interfaz gráfica con visualización GDI+
├── MainForm.Designer.cs
├── Program.cs        # Punto de entrada
└── README.md
```

---

## Funcionalidades

### Tarea 1 — Mostrar Grafo
Imprime la lista de adyacencia completa de cada edificio con sus conexiones y distancias.

### Tarea 2 — Recorrido BFS
Recorre el grafo por amplitud desde un edificio origen usando `Queue<string>`. Muestra el nivel de saltos desde el origen y el total de edificios visitados.

### Tarea 3 — Recorrido DFS
Recorre el grafo en profundidad usando `Stack<string>` para encontrar un camino entre dos edificios. Imprime cada nodo visitado y el camino final encontrado con su distancia total.

### Tarea 4 — Tabla Hash de Visitas
Registra cuántas veces fue visitado cada edificio durante los recorridos BFS y DFS, usando `Dictionary<string, int>`. Muestra estadísticas ordenadas de mayor a menor y el edificio más visitado.

### Tarea 5 — Min-Heap de Rutas
Heap mínimo implementado manualmente con operaciones `Flotar` y `Hundir`. Inserta las rutas directas desde el edificio origen y las extrae ordenadas de menor a mayor distancia.

---

## Interfaz Gráfica

La aplicación incluye un mapa visual del campus dibujado con GDI+ que muestra:

- **Azul** — nodos sin visitar
- **Morado** — nodo origen seleccionado
- **Rojo** — nodo destino (DFS)
- **Naranja** — nodos visitados durante el recorrido
- **Verde** — camino final encontrado

---

## Cómo ejecutar

1. Abrir `CampusNavegacion.slnx` en Visual Studio 2022.
2. Compilar con **Ctrl+Shift+B**.
3. Ejecutar con **F5** o desde `bin/Debug/CampusNavegacion.exe`.

**Requisitos:** Windows, .NET Framework 4.7.2, Visual Studio 2019 o superior.

---

## Notas de implementación

- El Min-Heap es completamente manual; no usa `PriorityQueue` ni `SortedList`.
- El DFS arrastra el camino completo dentro del Stack para poder reconstruirlo al llegar al destino.
- El BFS registra automáticamente las visitas en la Tabla Hash al recorrer.
- La UI redirige `Console.SetOut` hacia un `RichTextBox` para mostrar la salida de consola en pantalla.
