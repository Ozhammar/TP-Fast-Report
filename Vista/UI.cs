using BLL;

namespace Vista
{
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();
        }
        private void AbrirFormularioUnico<T>() where T : Form, new()
        {
            var existente = MdiChildren.OfType<T>().FirstOrDefault();

            if (existente != null)
            {
                if (existente.WindowState == FormWindowState.Minimized)
                    existente.WindowState = FormWindowState.Maximized;

                existente.Activate();
                existente.Show();
                return;
            }

            var nuevo = new T
            {
                MdiParent = this,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            nuevo.Show();
        }

        private void StripCliente_Click(object sender, EventArgs e)
        {
            AbrirFormularioUnico<vistaCliente>();
        }

        private void PrendaStrip_Click(object sender, EventArgs e)
        {
            AbrirFormularioUnico<vistaPrenda>();
        }

        private void VentaStrip_Click(object sender, EventArgs e)
        {
            AbrirFormularioUnico<vistaVenta>();
        }

        private void FacturaStrip_Click(object sender, EventArgs e)
        {
            AbrirFormularioUnico<vistaFactura>();
        }

        private void ReporteStrip_Click(object sender, EventArgs e)
        {
            AbrirFormularioUnico<vistaReportes>();
        }

        private void StripInicio_Click(object sender, EventArgs e)
        {
            foreach (var child in this.MdiChildren)
            {
                child.Hide();
            }
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
