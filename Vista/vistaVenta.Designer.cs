namespace Vista
{
    partial class vistaVenta
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
            groupBoxCabecera = new GroupBox();
            lblCliente = new Label();
            cmbCliente = new ComboBox();
            lblTipo = new Label();
            cmbTipoVenta = new ComboBox();
            lblMedio = new Label();
            cmbMedioPago = new ComboBox();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            groupBoxDetalle = new GroupBox();
            lblPrenda = new Label();
            cmbPrenda = new ComboBox();
            lblCantidad = new Label();
            txtCantidad = new TextBox();
            btnAgregarRenglon = new Button();
            btnQuitarRenglon = new Button();
            dgvDetalle = new DataGridView();
            lblTotal = new Label();
            btnRegistrar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnNuevo = new Button();
            lblVentas = new Label();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            dataGridView1 = new DataGridView();
            groupBoxCabecera.SuspendLayout();
            groupBoxDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBoxCabecera
            // 
            groupBoxCabecera.Controls.Add(lblCliente);
            groupBoxCabecera.Controls.Add(cmbCliente);
            groupBoxCabecera.Controls.Add(lblTipo);
            groupBoxCabecera.Controls.Add(cmbTipoVenta);
            groupBoxCabecera.Controls.Add(lblMedio);
            groupBoxCabecera.Controls.Add(cmbMedioPago);
            groupBoxCabecera.Controls.Add(lblEstado);
            groupBoxCabecera.Controls.Add(cmbEstado);
            groupBoxCabecera.Controls.Add(lblFecha);
            groupBoxCabecera.Controls.Add(dtpFecha);
            groupBoxCabecera.Location = new Point(12, 12);
            groupBoxCabecera.Name = "groupBoxCabecera";
            groupBoxCabecera.Size = new Size(320, 210);
            groupBoxCabecera.TabIndex = 0;
            groupBoxCabecera.TabStop = false;
            groupBoxCabecera.Text = "Datos de la venta";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(12, 31);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(44, 15);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente";
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.Location = new Point(100, 28);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(205, 23);
            cmbCliente.TabIndex = 1;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(12, 62);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(63, 15);
            lblTipo.TabIndex = 2;
            lblTipo.Text = "Tipo venta";
            // 
            // cmbTipoVenta
            // 
            cmbTipoVenta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoVenta.Location = new Point(100, 59);
            cmbTipoVenta.Name = "cmbTipoVenta";
            cmbTipoVenta.Size = new Size(205, 23);
            cmbTipoVenta.TabIndex = 3;
            // 
            // lblMedio
            // 
            lblMedio.AutoSize = true;
            lblMedio.Location = new Point(12, 93);
            lblMedio.Name = "lblMedio";
            lblMedio.Size = new Size(71, 15);
            lblMedio.TabIndex = 4;
            lblMedio.Text = "Medio pago";
            // 
            // cmbMedioPago
            // 
            cmbMedioPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedioPago.Location = new Point(100, 90);
            cmbMedioPago.Name = "cmbMedioPago";
            cmbMedioPago.Size = new Size(205, 23);
            cmbMedioPago.TabIndex = 5;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(12, 124);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(42, 15);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "Estado";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Location = new Point(100, 121);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(205, 23);
            cmbEstado.TabIndex = 7;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(12, 155);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(38, 15);
            lblFecha.TabIndex = 8;
            lblFecha.Text = "Fecha";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(100, 152);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(205, 23);
            dtpFecha.TabIndex = 9;
            // 
            // groupBoxDetalle
            // 
            groupBoxDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxDetalle.Controls.Add(lblPrenda);
            groupBoxDetalle.Controls.Add(cmbPrenda);
            groupBoxDetalle.Controls.Add(lblCantidad);
            groupBoxDetalle.Controls.Add(txtCantidad);
            groupBoxDetalle.Controls.Add(btnAgregarRenglon);
            groupBoxDetalle.Controls.Add(btnQuitarRenglon);
            groupBoxDetalle.Controls.Add(dgvDetalle);
            groupBoxDetalle.Controls.Add(lblTotal);
            groupBoxDetalle.Location = new Point(344, 12);
            groupBoxDetalle.Name = "groupBoxDetalle";
            groupBoxDetalle.Size = new Size(640, 210);
            groupBoxDetalle.TabIndex = 1;
            groupBoxDetalle.TabStop = false;
            groupBoxDetalle.Text = "Detalle";
            // 
            // lblPrenda
            // 
            lblPrenda.AutoSize = true;
            lblPrenda.Location = new Point(12, 28);
            lblPrenda.Name = "lblPrenda";
            lblPrenda.Size = new Size(44, 15);
            lblPrenda.TabIndex = 0;
            lblPrenda.Text = "Prenda";
            // 
            // cmbPrenda
            // 
            cmbPrenda.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrenda.Location = new Point(65, 25);
            cmbPrenda.Name = "cmbPrenda";
            cmbPrenda.Size = new Size(250, 23);
            cmbPrenda.TabIndex = 1;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(330, 28);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(55, 15);
            lblCantidad.TabIndex = 2;
            lblCantidad.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(394, 25);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(55, 23);
            txtCantidad.TabIndex = 3;
            // 
            // btnAgregarRenglon
            // 
            btnAgregarRenglon.Location = new Point(460, 24);
            btnAgregarRenglon.Name = "btnAgregarRenglon";
            btnAgregarRenglon.Size = new Size(75, 25);
            btnAgregarRenglon.TabIndex = 4;
            btnAgregarRenglon.Text = "Agregar";
            btnAgregarRenglon.UseVisualStyleBackColor = true;
            btnAgregarRenglon.Click += btnAgregarRenglon_Click;
            // 
            // btnQuitarRenglon
            // 
            btnQuitarRenglon.Location = new Point(541, 24);
            btnQuitarRenglon.Name = "btnQuitarRenglon";
            btnQuitarRenglon.Size = new Size(85, 25);
            btnQuitarRenglon.TabIndex = 5;
            btnQuitarRenglon.Text = "Quitar";
            btnQuitarRenglon.UseVisualStyleBackColor = true;
            btnQuitarRenglon.Click += btnQuitarRenglon_Click;
            // 
            // dgvDetalle
            // 
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.AllowUserToResizeColumns = false;
            dgvDetalle.AllowUserToResizeRows = false;
            dgvDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Location = new Point(12, 60);
            dgvDetalle.MultiSelect = false;
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.Size = new Size(614, 115);
            dgvDetalle.TabIndex = 6;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotal.Location = new Point(12, 185);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(54, 15);
            lblTotal.TabIndex = 7;
            lblTotal.Text = "Total: $0";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(12, 232);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(120, 30);
            btnRegistrar.TabIndex = 2;
            btnRegistrar.Text = "Registrar venta";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(138, 232);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(130, 30);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar estado";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(274, 232);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(90, 30);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(370, 232);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(90, 30);
            btnNuevo.TabIndex = 5;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // lblVentas
            // 
            lblVentas.AutoSize = true;
            lblVentas.Location = new Point(12, 272);
            lblVentas.Name = "lblVentas";
            lblVentas.Size = new Size(41, 15);
            lblVentas.TabIndex = 6;
            lblVentas.Text = "Ventas";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(621, 264);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(118, 15);
            lblBuscar.TabIndex = 8;
            lblBuscar.Text = "Buscar (N° o cliente):";
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(745, 261);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(239, 23);
            txtBuscar.TabIndex = 9;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 290);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(972, 160);
            dataGridView1.TabIndex = 7;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // vistaVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(996, 465);
            ControlBox = false;
            Controls.Add(dataGridView1);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Controls.Add(lblVentas);
            Controls.Add(btnNuevo);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnRegistrar);
            Controls.Add(groupBoxDetalle);
            Controls.Add(groupBoxCabecera);
            FormBorderStyle = FormBorderStyle.None;
            Name = "vistaVenta";
            ShowIcon = false;
            Text = "vistaVenta";
            Load += vistaVenta_Load;
            groupBoxCabecera.ResumeLayout(false);
            groupBoxCabecera.PerformLayout();
            groupBoxDetalle.ResumeLayout(false);
            groupBoxDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxCabecera;
        private Label lblCliente;
        private ComboBox cmbCliente;
        private Label lblTipo;
        private ComboBox cmbTipoVenta;
        private Label lblMedio;
        private ComboBox cmbMedioPago;
        private Label lblEstado;
        private ComboBox cmbEstado;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private GroupBox groupBoxDetalle;
        private Label lblPrenda;
        private ComboBox cmbPrenda;
        private Label lblCantidad;
        private TextBox txtCantidad;
        private Button btnAgregarRenglon;
        private Button btnQuitarRenglon;
        private DataGridView dgvDetalle;
        private Label lblTotal;
        private Button btnRegistrar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnNuevo;
        private Label lblVentas;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private DataGridView dataGridView1;
    }
}
