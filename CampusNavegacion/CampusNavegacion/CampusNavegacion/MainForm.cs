using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace CampusNavegacion
{
    public partial class MainForm : Form
    {
        private Grafo grafo;
        private TablaHash tablaVisitas;
        private MinHeap heapRutas;

        // Variables de estado para el dibujo interactivo
        private Dictionary<string, Point> coordenadasNodos;
        private List<(string origen, string destino, int distancia)> aristasGrafo;
        private string nodoOrigenActual = "";
        private string nodoDestinoActual = "";
        private List<string> nodosVisitados = new List<string>();
        private List<string> caminoFinal = new List<string>();

        public MainForm()
        {
            InitializeComponent();
            InicializarDatos();
            var writer = new TextBoxStreamWriter(rtbResultados);
            Console.SetOut(writer);

            // Vinculamos el evento de dibujo al PictureBox
            picMapa.Paint += PicMapa_Paint;
        }

        private void InicializarDatos()
        {
            grafo = new Grafo();
            tablaVisitas = new TablaHash();
            heapRutas = new MinHeap();

            string[] edificios = {
                "Biblioteca Central (A)", "Cafeteria (B)", "Laboratorio de Cómputo (C)",
                "Rectoria (D)", "Gimnasio (E)", "Aulas Generales (F)", "Estacionamiento (G)"
            };
            foreach (var ed in edificios) grafo.AgregarEdificio(ed);

            // Coordenadas fijas para dibujar el mapa exactamente como el PDF
            coordenadasNodos = new Dictionary<string, Point>
            {
                { "Laboratorio de Cómputo (C)", new Point(80, 80) },
                { "Aulas Generales (F)", new Point(320, 80) },
                { "Biblioteca Central (A)", new Point(80, 240) },
                { "Cafeteria (B)", new Point(200, 240) },
                { "Rectoria (D)", new Point(320, 240) },
                { "Gimnasio (E)", new Point(200, 380) },
                { "Estacionamiento (G)", new Point(420, 200) }
            };

            // Definición de caminos para pintarlos
            aristasGrafo = new List<(string, string, int)>
{
    ("Biblioteca Central (A)", "Cafeteria (B)", 120),
    ("Cafeteria (B)", "Gimnasio (E)", 300),
    ("Gimnasio (E)", "Estacionamiento (G)", 250),
    ("Biblioteca Central (A)", "Laboratorio de Cómputo (C)", 200),
    ("Laboratorio de Cómputo (C)", "Aulas Generales (F)", 100),
    ("Rectoria (D)", "Aulas Generales (F)", 80),
    ("Cafeteria (B)", "Rectoria (D)", 150),
    ("Aulas Generales (F)", "Estacionamiento (G)", 180)
};

            foreach (var arista in aristasGrafo)
            {
                grafo.AgregarCamino(arista.origen, arista.destino, arista.distancia);
            }

            cmbOrigen.Items.Clear(); cmbDestino.Items.Clear();
            cmbOrigen.Items.AddRange(edificios); cmbDestino.Items.AddRange(edificios);
            if (cmbOrigen.Items.Count > 0) cmbOrigen.SelectedIndex = 0;
            if (cmbDestino.Items.Count > 6) cmbDestino.SelectedIndex = 6;
        }

        // === MOTOR DE DIBUJO GDI+ ===
        private void PicMapa_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // Bordes suaves

            // 1. Dibujar las líneas (aristas)
            foreach (var arista in aristasGrafo)
            {
                Point p1 = coordenadasNodos[arista.origen];
                Point p2 = coordenadasNodos[arista.destino];

                bool esParteDelCamino = false;
                for (int i = 0; i < caminoFinal.Count - 1; i++)
                {
                    if ((caminoFinal[i] == arista.origen && caminoFinal[i + 1] == arista.destino) ||
                        (caminoFinal[i] == arista.destino && caminoFinal[i + 1] == arista.origen))
                    {
                        esParteDelCamino = true;
                        break;
                    }
                }

                // Si es el camino final, se pinta verde grueso; si no, gris claro
                Pen lapiz = esParteDelCamino ? new Pen(Color.FromArgb(46, 204, 113), 4) : new Pen(Color.LightGray, 2);
                g.DrawLine(lapiz, p1, p2);

                // Dibujar la distancia (texto) en el medio de la línea
                Point medio = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
                g.DrawString($"{arista.distancia}m", new Font("Segoe UI", 8), Brushes.Gray, medio);
            }

            // 2. Dibujar los Nodos (Círculos)
            foreach (var nodo in coordenadasNodos)
            {
                Point p = nodo.Value;
                int radio = 25;

                // Determinar el color del nodo según su estado interactivo
                Color colorNodo = Color.FromArgb(41, 128, 185); // Azul normal por defecto

                if (nodo.Key == nodoOrigenActual)
                    colorNodo = Color.FromArgb(142, 68, 173); // Morado (Origen)
                else if (nodo.Key == nodoDestinoActual && caminoFinal.Count > 0)
                    colorNodo = Color.FromArgb(231, 76, 60); // Rojo (Destino)
                else if (caminoFinal.Contains(nodo.Key))
                    colorNodo = Color.FromArgb(46, 204, 113); // Verde (Camino)
                else if (nodosVisitados.Contains(nodo.Key))
                    colorNodo = Color.FromArgb(243, 156, 18); // Naranja (Visitado)

                // Pintar el círculo
                g.FillEllipse(new SolidBrush(colorNodo), p.X - radio, p.Y - radio, radio * 2, radio * 2);
                g.DrawEllipse(new Pen(Color.White, 2), p.X - radio, p.Y - radio, radio * 2, radio * 2);

                // Extraer solo la letra entre paréntesis (ej. "A")
                string letra = nodo.Key.Substring(nodo.Key.IndexOf('(') + 1, 1);
                string nombreEdificio = nodo.Key.Substring(0, nodo.Key.IndexOf('(')).Trim();

                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString(letra, new Font("Segoe UI", 12, FontStyle.Bold), Brushes.White, p, sf);
                g.DrawString(nombreEdificio, new Font("Segoe UI", 8), Brushes.Black, p.X, p.Y + radio + 10, sf);
            }
        }

        // === EVENTOS DE LOS BOTONES ===
        private void btnMostrarGrafo_Click(object sender, EventArgs e)
        {
            rtbResultados.Clear();
            grafo.MostrarGrafo();
            RestablecerColores();
        }

        private void btnRecorridoBFS_Click(object sender, EventArgs e)
        {
            rtbResultados.Clear();
            if (cmbOrigen.SelectedItem != null)
            {
                RestablecerColores();
                nodoOrigenActual = cmbOrigen.SelectedItem.ToString();

                // Obtener los nodos visitados y mandarlos a dibujar
                nodosVisitados = grafo.RecorridoBFS(nodoOrigenActual, tablaVisitas);
                picMapa.Invalidate(); // Refresca el panel para dibujar los colores
            }
        }

        private void btnRecorridoDFS_Click(object sender, EventArgs e)
        {
            rtbResultados.Clear();
            if (cmbOrigen.SelectedItem != null && cmbDestino.SelectedItem != null)
            {
                RestablecerColores();
                nodoOrigenActual = cmbOrigen.SelectedItem.ToString();
                nodoDestinoActual = cmbDestino.SelectedItem.ToString();

                // Ejecutar DFS y obtener las listas de dibujado
                var resultado = grafo.RecorridoDFS(nodoOrigenActual, nodoDestinoActual, tablaVisitas);
                nodosVisitados = resultado.visitados;
                caminoFinal = resultado.camino;

                picMapa.Invalidate();
            }
        }

        private void btnTablaHash_Click(object sender, EventArgs e)
        {
            rtbResultados.Clear();
            tablaVisitas.MostrarEstadisticas();
            Console.WriteLine($"\nEdificio más visitado: {tablaVisitas.EdificioMasVisitado()}");
        }

        private void btnMinHeap_Click(object sender, EventArgs e)
        {
            rtbResultados.Clear();
            if (cmbOrigen.SelectedItem == null) return;

            MinHeap heapLocal = new MinHeap();
            string origen = cmbOrigen.SelectedItem.ToString();
            foreach (var ruta in grafo.ObtenerVecinos(origen))
                heapLocal.Insertar(ruta.destino, ruta.distancia);

            heapLocal.MostrarRutasOrdenadas(origen);
        }
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            rtbResultados.Clear();
            InicializarDatos();
            RestablecerColores();
            Console.WriteLine("Sistema reiniciado. Visitas y rutas borradas.");
        }

        private void RestablecerColores()
        {
            nodoOrigenActual = "";
            nodoDestinoActual = "";
            nodosVisitados.Clear();
            caminoFinal.Clear();
            picMapa.Invalidate(); // Fuerza al mapa a dibujarse azul nuevamente
        }
    }

    // Clase auxiliar para la consola
    public class TextBoxStreamWriter : TextWriter
    {
        private RichTextBox _output;
        public TextBoxStreamWriter(RichTextBox output) { _output = output; }
        public override void Write(char value)
        {
            if (_output.InvokeRequired) _output.Invoke(new Action(() => _output.AppendText(value.ToString())));
            else _output.AppendText(value.ToString());
            _output.ScrollToCaret();
        }
        public override System.Text.Encoding Encoding => System.Text.Encoding.UTF8;
    }
}