namespace Vista
{
    partial class vistaPrenda
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
            groupBoxDatos = new GroupBox();
            lblCodigo = new Label();
            txtCodigo = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            lblColor = new Label();
            cmbColor = new ComboBox();
            lblTalle = new Label();
            cmbTalle = new ComboBox();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            lblStock = new Label();
            txtStock = new TextBox();
            groupBoxABM = new GroupBox();
            btnAlta = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            groupBoxDatos.SuspendLayout();
            groupBoxABM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBoxDatos
            // 
            groupBoxDatos.Controls.Add(lblCodigo);
            groupBoxDatos.Controls.Add(txtCodigo);
            groupBoxDatos.Controls.Add(lblDescripcion);
            groupBoxDatos.Controls.Add(txtDescripcion);
            groupBoxDatos.Controls.Add(lblCategoria);
            groupBoxDatos.Controls.Add(cmbCategoria);
            groupBoxDatos.Controls.Add(lblColor);
            groupBoxDatos.Controls.Add(cmbColor);
            groupBoxDatos.Controls.Add(lblTalle);
            groupBoxDatos.Controls.Add(cmbTalle);
            groupBoxDatos.Controls.Add(lblPrecio);
            groupBoxDatos.Controls.Add(txtPrecio);
            groupBoxDatos.Controls.Add(lblStock);
            groupBoxDatos.Controls.Add(txtStock);
            groupBoxDatos.Location = new Point(12, 12);
            groupBoxDatos.Name = "groupBoxDatos";
            groupBoxDatos.Size = new Size(336, 270);
            groupBoxDatos.TabIndex = 0;
            groupBoxDatos.TabStop = false;
            groupBoxDatos.Text = "Datos de la prenda";
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(12, 28);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(46, 15);
            lblCodigo.TabIndex = 0;
            lblCodigo.Text = "Código";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(100, 25);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(227, 23);
            txtCodigo.TabIndex = 1;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(12, 59);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(69, 15);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(100, 56);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(227, 23);
            txtDescripcion.TabIndex = 3;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(12, 90);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(58, 15);
            lblCategoria.TabIndex = 4;
            lblCategoria.Text = "Categoría";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.Location = new Point(100, 87);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(227, 23);
            cmbCategoria.TabIndex = 5;
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Location = new Point(12, 121);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(36, 15);
            lblColor.TabIndex = 6;
            lblColor.Text = "Color";
            // 
            // cmbColor
            // 
            cmbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbColor.Location = new Point(100, 118);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(227, 23);
            cmbColor.TabIndex = 7;
            // 
            // lblTalle
            // 
            lblTalle.AutoSize = true;
            lblTalle.Location = new Point(12, 152);
            lblTalle.Name = "lblTalle";
            lblTalle.Size = new Size(31, 15);
            lblTalle.TabIndex = 8;
            lblTalle.Text = "Talle";
            // 
            // cmbTalle
            // 
            cmbTalle.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTalle.Location = new Point(100, 149);
            cmbTalle.Name = "cmbTalle";
            cmbTalle.Size = new Size(227, 23);
            cmbTalle.TabIndex = 9;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(12, 183);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(40, 15);
            lblPrecio.TabIndex = 10;
            lblPrecio.Text = "Precio";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(100, 180);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(227, 23);
            txtPrecio.TabIndex = 11;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(12, 214);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(36, 15);
            lblStock.TabIndex = 12;
            lblStock.Text = "Stock";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(100, 211);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(227, 23);
            txtStock.TabIndex = 13;
            // 
            // groupBoxABM
            // 
            groupBoxABM.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxABM.Controls.Add(btnAlta);
            groupBoxABM.Controls.Add(btnModificar);
            groupBoxABM.Controls.Add(btnEliminar);
            groupBoxABM.Controls.Add(btnLimpiar);
            groupBoxABM.Location = new Point(596, 12);
            groupBoxABM.Name = "groupBoxABM";
            groupBoxABM.Size = new Size(110, 270);
            groupBoxABM.TabIndex = 1;
            groupBoxABM.TabStop = false;
            groupBoxABM.Text = "ABM";
            // 
            // btnAlta
            // 
            btnAlta.Location = new Point(14, 30);
            btnAlta.Name = "btnAlta";
            btnAlta.Size = new Size(82, 28);
            btnAlta.TabIndex = 0;
            btnAlta.Text = "Alta";
            btnAlta.UseVisualStyleBackColor = true;
            btnAlta.Click += btnAlta_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(14, 70);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(82, 28);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(14, 110);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(82, 28);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(14, 150);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(82, 28);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 295);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 2;
            label1.Text = "Prendas";
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
            dataGridView1.Location = new Point(12, 313);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(694, 160);
            dataGridView1.TabIndex = 3;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // vistaPrenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(718, 490);
            ControlBox = false;
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(groupBoxABM);
            Controls.Add(groupBoxDatos);
            FormBorderStyle = FormBorderStyle.None;
            Name = "vistaPrenda";
            ShowIcon = false;
            Text = "vistaPrenda";
            Load += vistaPrenda_Load;
            groupBoxDatos.ResumeLayout(false);
            groupBoxDatos.PerformLayout();
            groupBoxABM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxDatos;
        private Label lblCodigo;
        private TextBox txtCodigo;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private Label lblColor;
        private ComboBox cmbColor;
        private Label lblTalle;
        private ComboBox cmbTalle;
        private Label lblPrecio;
        private TextBox txtPrecio;
        private Label lblStock;
        private TextBox txtStock;
        private GroupBox groupBoxABM;
        private Button btnAlta;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Label label1;
        private DataGridView dataGridView1;
    }
}
