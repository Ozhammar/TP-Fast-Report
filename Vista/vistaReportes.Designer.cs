namespace Vista
{
    partial class vistaReportes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            cmbReporte = new ComboBox();
            btnGenerar = new Button();
            lblVistaPrevia = new Label();
            dgvVistaPrevia = new DataGridView();
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvVistaPrevia).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbReporte
            // 
            cmbReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReporte.FormattingEnabled = true;
            cmbReporte.Location = new Point(21, 30);
            cmbReporte.Name = "cmbReporte";
            cmbReporte.Size = new Size(364, 29);
            cmbReporte.TabIndex = 1;
            cmbReporte.SelectedIndexChanged += cmbReporte_SelectedIndexChanged;
            // 
            // btnGenerar
            // 
            btnGenerar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGenerar.AutoSize = true;
            btnGenerar.BackColor = SystemColors.Control;
            btnGenerar.ForeColor = SystemColors.ControlText;
            btnGenerar.Location = new Point(519, 32);
            btnGenerar.MaximumSize = new Size(200, 27);
            btnGenerar.MinimumSize = new Size(150, 27);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(150, 27);
            btnGenerar.TabIndex = 2;
            btnGenerar.Text = "Generar PDF";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // lblVistaPrevia
            // 
            lblVistaPrevia.AutoSize = true;
            lblVistaPrevia.Location = new Point(12, 92);
            lblVistaPrevia.Name = "lblVistaPrevia";
            lblVistaPrevia.Size = new Size(133, 15);
            lblVistaPrevia.TabIndex = 1;
            lblVistaPrevia.Text = "Vista previa de los datos";
            // 
            // dgvVistaPrevia
            // 
            dgvVistaPrevia.AllowUserToAddRows = false;
            dgvVistaPrevia.AllowUserToDeleteRows = false;
            dgvVistaPrevia.AllowUserToResizeColumns = false;
            dgvVistaPrevia.AllowUserToResizeRows = false;
            dgvVistaPrevia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVistaPrevia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVistaPrevia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVistaPrevia.Location = new Point(12, 112);
            dgvVistaPrevia.Name = "dgvVistaPrevia";
            dgvVistaPrevia.ReadOnly = true;
            dgvVistaPrevia.RowHeadersVisible = false;
            dgvVistaPrevia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVistaPrevia.Size = new Size(694, 233);
            dgvVistaPrevia.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Brown;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnGenerar);
            panel1.Controls.Add(cmbReporte);
            panel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(694, 72);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = Properties.Resources.FR_open_source;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.ForeColor = Color.Transparent;
            panel2.Location = new Point(415, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(72, 72);
            panel2.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(15, 1);
            label1.Margin = new Padding(0, 0, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(77, 21);
            label1.TabIndex = 3;
            label1.Text = "Reportes";
            // 
            // vistaReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(718, 357);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(dgvVistaPrevia);
            Controls.Add(lblVistaPrevia);
            FormBorderStyle = FormBorderStyle.None;
            Name = "vistaReportes";
            ShowIcon = false;
            Text = "vistaReportes";
            Load += vistaReportes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVistaPrevia).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbReporte;
        private Button btnGenerar;
        private Label lblVistaPrevia;
        private DataGridView dgvVistaPrevia;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
    }
}
