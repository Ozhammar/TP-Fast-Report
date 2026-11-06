namespace Vista
{
    partial class UI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
            inicioStrip = new MenuStrip();
            StripInicio = new ToolStripMenuItem();
            cerrarToolStripMenuItem = new ToolStripMenuItem();
            StripCliente = new ToolStripMenuItem();
            PrendaStrip = new ToolStripMenuItem();
            VentaStrip = new ToolStripMenuItem();
            FacturaStrip = new ToolStripMenuItem();
            ReporteStrip = new ToolStripMenuItem();
            inicioStrip.SuspendLayout();
            SuspendLayout();
            // 
            // inicioStrip
            // 
            inicioStrip.ImageScalingSize = new Size(24, 24);
            inicioStrip.Items.AddRange(new ToolStripItem[] { StripInicio, StripCliente, PrendaStrip, VentaStrip, FacturaStrip, ReporteStrip });
            inicioStrip.Location = new Point(0, 0);
            inicioStrip.Name = "inicioStrip";
            inicioStrip.Padding = new Padding(4, 1, 0, 1);
            inicioStrip.Size = new Size(1019, 24);
            inicioStrip.TabIndex = 1;
            inicioStrip.Text = "menuStrip1";
            // 
            // StripInicio
            // 
            StripInicio.DropDownItems.AddRange(new ToolStripItem[] { cerrarToolStripMenuItem });
            StripInicio.Name = "StripInicio";
            StripInicio.Size = new Size(48, 22);
            StripInicio.Text = "Inicio";
            StripInicio.Click += StripInicio_Click;
            // 
            // cerrarToolStripMenuItem
            // 
            cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            cerrarToolStripMenuItem.Size = new Size(106, 22);
            cerrarToolStripMenuItem.Text = "Cerrar";
            cerrarToolStripMenuItem.Click += cerrarToolStripMenuItem_Click;
            // 
            // StripCliente
            // 
            StripCliente.Name = "StripCliente";
            StripCliente.Size = new Size(61, 22);
            StripCliente.Text = "Clientes";
            StripCliente.Click += StripCliente_Click;
            // 
            // PrendaStrip
            // 
            PrendaStrip.Name = "PrendaStrip";
            PrendaStrip.Size = new Size(61, 22);
            PrendaStrip.Text = "Prendas";
            PrendaStrip.Click += PrendaStrip_Click;
            // 
            // VentaStrip
            // 
            VentaStrip.Name = "VentaStrip";
            VentaStrip.Size = new Size(53, 22);
            VentaStrip.Text = "Ventas";
            VentaStrip.Click += VentaStrip_Click;
            // 
            // FacturaStrip
            // 
            FacturaStrip.Name = "FacturaStrip";
            FacturaStrip.Size = new Size(63, 22);
            FacturaStrip.Text = "Facturas";
            FacturaStrip.Click += FacturaStrip_Click;
            // 
            // ReporteStrip
            // 
            ReporteStrip.Name = "ReporteStrip";
            ReporteStrip.Size = new Size(65, 22);
            ReporteStrip.Text = "Reportes";
            ReporteStrip.Click += ReporteStrip_Click;
            // 
            // UI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.LOGO_FONDO_TRANSPARENTE;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1019, 515);
            Controls.Add(inicioStrip);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = inicioStrip;
            Margin = new Padding(2);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "UI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trabajo Práctico Reporteria";
            inicioStrip.ResumeLayout(false);
            inicioStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip inicioStrip;
        private ToolStripMenuItem StripInicio;
        private ToolStripMenuItem StripCliente;
        private ToolStripMenuItem PrendaStrip;
        private ToolStripMenuItem VentaStrip;
        private ToolStripMenuItem FacturaStrip;
        private ToolStripMenuItem ReporteStrip;
        private ToolStripMenuItem cerrarToolStripMenuItem;
    }
}
