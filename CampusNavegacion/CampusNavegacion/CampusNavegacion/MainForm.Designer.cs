namespace CampusNavegacion
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.picMapa = new System.Windows.Forms.PictureBox();
            this.cmbOrigen = new System.Windows.Forms.ComboBox();
            this.cmbDestino = new System.Windows.Forms.ComboBox();
            this.btnMostrarGrafo = new System.Windows.Forms.Button();
            this.btnRecorridoBFS = new System.Windows.Forms.Button();
            this.btnRecorridoDFS = new System.Windows.Forms.Button();
            this.btnTablaHash = new System.Windows.Forms.Button();
            this.btnMinHeap = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.rtbResultados = new System.Windows.Forms.RichTextBox();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picMapa)).BeginInit();
            this.SuspendLayout();

            this.picMapa.BackColor = System.Drawing.Color.White; this.picMapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.picMapa.Location = new System.Drawing.Point(12, 50); this.picMapa.Name = "picMapa"; this.picMapa.Size = new System.Drawing.Size(480, 480); this.picMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lblTitulo.AutoSize = true; this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold); this.lblTitulo.Location = new System.Drawing.Point(12, 10); this.lblTitulo.Name = "lblTitulo"; this.lblTitulo.Size = new System.Drawing.Size(400, 25); this.lblTitulo.Text = "SISTEMA DE NAVEGACIÓN DEL CAMPUS";
            this.lblOrigen.Location = new System.Drawing.Point(510, 50); this.lblOrigen.Name = "lblOrigen"; this.lblOrigen.Size = new System.Drawing.Size(81, 13); this.lblOrigen.Text = "Edificio Origen:";
            this.cmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbOrigen.Location = new System.Drawing.Point(513, 68); this.cmbOrigen.Name = "cmbOrigen"; this.cmbOrigen.Size = new System.Drawing.Size(180, 21);
            this.lblDestino.Location = new System.Drawing.Point(710, 50); this.lblDestino.Name = "lblDestino"; this.lblDestino.Size = new System.Drawing.Size(117, 13); this.lblDestino.Text = "Edificio Destino (DFS):";
            this.cmbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbDestino.Location = new System.Drawing.Point(713, 68); this.cmbDestino.Name = "cmbDestino"; this.cmbDestino.Size = new System.Drawing.Size(180, 21);
            this.btnMostrarGrafo.BackColor = System.Drawing.Color.FromArgb(45, 64, 89); this.btnMostrarGrafo.ForeColor = System.Drawing.Color.White; this.btnMostrarGrafo.Location = new System.Drawing.Point(513, 110); this.btnMostrarGrafo.Name = "btnMostrarGrafo"; this.btnMostrarGrafo.Size = new System.Drawing.Size(180, 40); this.btnMostrarGrafo.Text = "Mostrar Grafo"; this.btnMostrarGrafo.UseVisualStyleBackColor = false; this.btnMostrarGrafo.Click += new System.EventHandler(this.btnMostrarGrafo_Click);
            this.btnRecorridoBFS.BackColor = System.Drawing.Color.FromArgb(50, 130, 184); this.btnRecorridoBFS.ForeColor = System.Drawing.Color.White; this.btnRecorridoBFS.Location = new System.Drawing.Point(713, 110); this.btnRecorridoBFS.Name = "btnRecorridoBFS"; this.btnRecorridoBFS.Size = new System.Drawing.Size(180, 40); this.btnRecorridoBFS.Text = "Recorrido BFS"; this.btnRecorridoBFS.UseVisualStyleBackColor = false; this.btnRecorridoBFS.Click += new System.EventHandler(this.btnRecorridoBFS_Click);
            this.btnRecorridoDFS.BackColor = System.Drawing.Color.FromArgb(40, 167, 69); this.btnRecorridoDFS.ForeColor = System.Drawing.Color.White; this.btnRecorridoDFS.Location = new System.Drawing.Point(513, 160); this.btnRecorridoDFS.Name = "btnRecorridoDFS"; this.btnRecorridoDFS.Size = new System.Drawing.Size(180, 40); this.btnRecorridoDFS.Text = "Recorrido DFS"; this.btnRecorridoDFS.UseVisualStyleBackColor = false; this.btnRecorridoDFS.Click += new System.EventHandler(this.btnRecorridoDFS_Click);
            this.btnTablaHash.BackColor = System.Drawing.Color.FromArgb(111, 66, 193); this.btnTablaHash.ForeColor = System.Drawing.Color.White; this.btnTablaHash.Location = new System.Drawing.Point(713, 160); this.btnTablaHash.Name = "btnTablaHash"; this.btnTablaHash.Size = new System.Drawing.Size(180, 40); this.btnTablaHash.Text = "Tabla Hash"; this.btnTablaHash.UseVisualStyleBackColor = false; this.btnTablaHash.Click += new System.EventHandler(this.btnTablaHash_Click);
            this.btnMinHeap.BackColor = System.Drawing.Color.FromArgb(253, 126, 20); this.btnMinHeap.ForeColor = System.Drawing.Color.White; this.btnMinHeap.Location = new System.Drawing.Point(513, 210); this.btnMinHeap.Name = "btnMinHeap"; this.btnMinHeap.Size = new System.Drawing.Size(180, 40); this.btnMinHeap.Text = "Min-Heap Rutas"; this.btnMinHeap.UseVisualStyleBackColor = false; this.btnMinHeap.Click += new System.EventHandler(this.btnMinHeap_Click);
            this.btnReiniciar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125); this.btnReiniciar.ForeColor = System.Drawing.Color.White; this.btnReiniciar.Location = new System.Drawing.Point(713, 210); this.btnReiniciar.Name = "btnReiniciar"; this.btnReiniciar.Size = new System.Drawing.Size(180, 40); this.btnReiniciar.Text = "Reiniciar Todo"; this.btnReiniciar.UseVisualStyleBackColor = false; this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            this.rtbResultados.BackColor = System.Drawing.Color.FromArgb(30, 30, 40); this.rtbResultados.Font = new System.Drawing.Font("Consolas", 10F); this.rtbResultados.ForeColor = System.Drawing.Color.WhiteSmoke; this.rtbResultados.Location = new System.Drawing.Point(513, 270); this.rtbResultados.Name = "rtbResultados"; this.rtbResultados.ReadOnly = true; this.rtbResultados.Size = new System.Drawing.Size(380, 260); this.rtbResultados.Text = "";
            this.ClientSize = new System.Drawing.Size(910, 550); this.Controls.Add(this.rtbResultados); this.Controls.Add(this.btnReiniciar); this.Controls.Add(this.btnMinHeap); this.Controls.Add(this.btnTablaHash); this.Controls.Add(this.btnRecorridoDFS); this.Controls.Add(this.btnRecorridoBFS); this.Controls.Add(this.btnMostrarGrafo); this.Controls.Add(this.cmbDestino); this.Controls.Add(this.lblDestino); this.Controls.Add(this.cmbOrigen); this.Controls.Add(this.lblOrigen); this.Controls.Add(this.lblTitulo); this.Controls.Add(this.picMapa); this.Name = "MainForm"; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; this.Text = "SNCU"; ((System.ComponentModel.ISupportInitialize)(this.picMapa)).EndInit(); this.ResumeLayout(false); this.PerformLayout();
        }
        private System.Windows.Forms.PictureBox picMapa; private System.Windows.Forms.ComboBox cmbOrigen; private System.Windows.Forms.ComboBox cmbDestino; private System.Windows.Forms.Button btnMostrarGrafo; private System.Windows.Forms.Button btnRecorridoBFS; private System.Windows.Forms.Button btnRecorridoDFS; private System.Windows.Forms.Button btnTablaHash; private System.Windows.Forms.Button btnMinHeap; private System.Windows.Forms.Button btnReiniciar; private System.Windows.Forms.RichTextBox rtbResultados; private System.Windows.Forms.Label lblOrigen; private System.Windows.Forms.Label lblDestino; private System.Windows.Forms.Label lblTitulo;
    }
}
