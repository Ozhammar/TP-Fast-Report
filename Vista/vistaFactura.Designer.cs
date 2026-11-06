namespace Vista
{
    partial class vistaFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxVentas = new GroupBox();
            dgvVentasSinFacturar = new DataGridView();
            groupBoxEmitir = new GroupBox();
            lblNumero = new Label();
            txtNumeroFactura = new TextBox();
            lblFecha = new Label();
            dtpFechaFactura = new DateTimePicker();
            lblEstado = new Label();
            cmbEstadoFactura = new ComboBox();
            lblImporteCaption = new Label();
            lblImporte = new Label();
            btnEmitir = new Button();
            groupBoxFacturas = new GroupBox();
            dgvFacturas = new DataGridView();
            btnModificarEstado = new Button();
            btnAnular = new Button();
            groupBoxVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentasSinFacturar).BeginInit();
            groupBoxEmitir.SuspendLayout();
            groupBoxFacturas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            SuspendLayout();
            // 
            // groupBoxVentas
            // 
            groupBoxVentas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxVentas.Controls.Add(dgvVentasSinFacturar);
            groupBoxVentas.Location = new Point(12, 12);
            groupBoxVentas.Name = "groupBoxVentas";
            groupBoxVentas.Size = new Size(660, 250);
            groupBoxVentas.TabIndex = 0;
            groupBoxVentas.TabStop = false;
            groupBoxVentas.Text = "Ventas sin facturar";
            // 
            // dgvVentasSinFacturar
            // 
            dgvVentasSinFacturar.AllowUserToAddRows = false;
            dgvVentasSinFacturar.AllowUserToDeleteRows = false;
            dgvVentasSinFacturar.AllowUserToResizeColumns = false;
            dgvVentasSinFacturar.AllowUserToResizeRows = false;
            dgvVentasSinFacturar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvVentasSinFacturar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentasSinFacturar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentasSinFacturar.Location = new Point(10, 22);
            dgvVentasSinFacturar.MultiSelect = false;
            dgvVentasSinFacturar.Name = "dgvVentasSinFacturar";
            dgvVentasSinFacturar.ReadOnly = true;
            dgvVentasSinFacturar.RowHeadersVisible = false;
            dgvVentasSinFacturar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentasSinFacturar.Size = new Size(640, 215);
            dgvVentasSinFacturar.TabIndex = 0;
            dgvVentasSinFacturar.SelectionChanged += dgvVentasSinFacturar_SelectionChanged;
            // 
            // groupBoxEmitir
            // 
            groupBoxEmitir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxEmitir.Controls.Add(lblNumero);
            groupBoxEmitir.Controls.Add(txtNumeroFactura);
            groupBoxEmitir.Controls.Add(lblFecha);
            groupBoxEmitir.Controls.Add(dtpFechaFactura);
            groupBoxEmitir.Controls.Add(lblEstado);
            groupBoxEmitir.Controls.Add(cmbEstadoFactura);
            groupBoxEmitir.Controls.Add(lblImporteCaption);
            groupBoxEmitir.Controls.Add(lblImporte);
            groupBoxEmitir.Controls.Add(btnEmitir);
            groupBoxEmitir.Location = new Point(684, 12);
            groupBoxEmitir.Name = "groupBoxEmitir";
            groupBoxEmitir.Size = new Size(300, 250);
            groupBoxEmitir.TabIndex = 1;
            groupBoxEmitir.TabStop = false;
            groupBoxEmitir.Text = "Emitir factura";
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(15, 28);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(89, 15);
            lblNumero.TabIndex = 0;
            lblNumero.Text = "N° factura legal";
            // 
            // txtNumeroFactura
            // 
            txtNumeroFactura.Location = new Point(15, 46);
            txtNumeroFactura.Name = "txtNumeroFactura";
            txtNumeroFactura.Size = new Size(265, 23);
            txtNumeroFactura.TabIndex = 1;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(15, 78);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(38, 15);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha";
            // 
            // dtpFechaFactura
            // 
            dtpFechaFactura.Format = DateTimePickerFormat.Short;
            dtpFechaFactura.Location = new Point(15, 96);
            dtpFechaFactura.Name = "dtpFechaFactura";
            dtpFechaFactura.Size = new Size(265, 23);
            dtpFechaFactura.TabIndex = 3;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(15, 128);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(42, 15);
            lblEstado.TabIndex = 4;
            lblEstado.Text = "Estado";
            // 
            // cmbEstadoFactura
            // 
            cmbEstadoFactura.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoFactura.Location = new Point(15, 146);
            cmbEstadoFactura.Name = "cmbEstadoFactura";
            cmbEstadoFactura.Size = new Size(265, 23);
            cmbEstadoFactura.TabIndex = 5;
            // 
            // lblImporteCaption
            // 
            lblImporteCaption.AutoSize = true;
            lblImporteCaption.Location = new Point(15, 180);
            lblImporteCaption.Name = "lblImporteCaption";
            lblImporteCaption.Size = new Size(52, 15);
            lblImporteCaption.TabIndex = 6;
            lblImporteCaption.Text = "Importe:";
            // 
            // lblImporte
            // 
            lblImporte.AutoSize = true;
            lblImporte.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblImporte.Location = new Point(73, 180);
            lblImporte.Name = "lblImporte";
            lblImporte.Size = new Size(38, 15);
            lblImporte.TabIndex = 7;
            lblImporte.Text = "$0.00";
            // 
            // btnEmitir
            // 
            btnEmitir.Location = new Point(15, 205);
            btnEmitir.Name = "btnEmitir";
            btnEmitir.Size = new Size(265, 32);
            btnEmitir.TabIndex = 8;
            btnEmitir.Text = "Emitir factura";
            btnEmitir.UseVisualStyleBackColor = true;
            btnEmitir.Click += btnEmitir_Click;
            // 
            // groupBoxFacturas
            // 
            groupBoxFacturas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxFacturas.Controls.Add(dgvFacturas);
            groupBoxFacturas.Controls.Add(btnModificarEstado);
            groupBoxFacturas.Controls.Add(btnAnular);
            groupBoxFacturas.Location = new Point(12, 274);
            groupBoxFacturas.Name = "groupBoxFacturas";
            groupBoxFacturas.Size = new Size(972, 211);
            groupBoxFacturas.TabIndex = 2;
            groupBoxFacturas.TabStop = false;
            groupBoxFacturas.Text = "Facturas";
            // 
            // dgvFacturas
            // 
            dgvFacturas.AllowUserToAddRows = false;
            dgvFacturas.AllowUserToDeleteRows = false;
            dgvFacturas.AllowUserToResizeColumns = false;
            dgvFacturas.AllowUserToResizeRows = false;
            dgvFacturas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Location = new Point(10, 22);
            dgvFacturas.MultiSelect = false;
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.ReadOnly = true;
            dgvFacturas.RowHeadersVisible = false;
            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturas.Size = new Size(780, 183);
            dgvFacturas.TabIndex = 0;
            // 
            // btnModificarEstado
            // 
            btnModificarEstado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnModificarEstado.Location = new Point(800, 30);
            btnModificarEstado.Name = "btnModificarEstado";
            btnModificarEstado.Size = new Size(160, 30);
            btnModificarEstado.TabIndex = 1;
            btnModificarEstado.Text = "Modificar estado";
            btnModificarEstado.UseVisualStyleBackColor = true;
            btnModificarEstado.Click += btnModificarEstado_Click;
            // 
            // btnAnular
            // 
            btnAnular.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAnular.Location = new Point(800, 70);
            btnAnular.Name = "btnAnular";
            btnAnular.Size = new Size(160, 30);
            btnAnular.TabIndex = 2;
            btnAnular.Text = "Anular factura";
            btnAnular.UseVisualStyleBackColor = true;
            btnAnular.Click += btnAnular_Click;
            // 
            // vistaFactura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(996, 496);
            ControlBox = false;
            Controls.Add(groupBoxFacturas);
            Controls.Add(groupBoxEmitir);
            Controls.Add(groupBoxVentas);
            FormBorderStyle = FormBorderStyle.None;
            Name = "vistaFactura";
            ShowIcon = false;
            Text = "vistaFactura";
            Load += vistaFactura_Load;
            groupBoxVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVentasSinFacturar).EndInit();
            groupBoxEmitir.ResumeLayout(false);
            groupBoxEmitir.PerformLayout();
            groupBoxFacturas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxVentas;
        private DataGridView dgvVentasSinFacturar;
        private GroupBox groupBoxEmitir;
        private Label lblNumero;
        private TextBox txtNumeroFactura;
        private Label lblFecha;
        private DateTimePicker dtpFechaFactura;
        private Label lblEstado;
        private ComboBox cmbEstadoFactura;
        private Label lblImporteCaption;
        private Label lblImporte;
        private Button btnEmitir;
        private GroupBox groupBoxFacturas;
        private DataGridView dgvFacturas;
        private Button btnModificarEstado;
        private Button btnAnular;
    }
}
