using BLL;
using Entidades;
using Entidades.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    public partial class vistaFactura : Form
    {
        FacturaBLL BLL_Factura;
        VentaBLL BLL_Venta;

        public vistaFactura()
        {
            InitializeComponent();
            BLL_Factura = new FacturaBLL();
            BLL_Venta = new VentaBLL();
        }

        private void vistaFactura_Load(object sender, EventArgs e)
        {
            try
            {
                cmbEstadoFactura.DataSource = Enum.GetValues(typeof(EstadoFactura));
                refrescar();
                this.Activated += vistaFactura_Activated;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vistaFactura_Activated(object sender, EventArgs e)
        {
            try
            {
                refrescar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refrescar()
        {
            actualizarVentasSinFacturar();
            actualizarFacturas();
        }

        private void actualizarVentasSinFacturar()
        {
            dgvVentasSinFacturar.DataSource = null;
            dgvVentasSinFacturar.DataSource = BLL_Venta.consultarVentasSinFacturar();
            ocultarColumnasVenta();
        }

        private void ocultarColumnasVenta()
        {
            if (dgvVentasSinFacturar.Columns.Contains("Cliente"))
            {
                dgvVentasSinFacturar.Columns["Cliente"].Visible = false;
            }
            if (dgvVentasSinFacturar.Columns.Contains("Factura"))
            {
                dgvVentasSinFacturar.Columns["Factura"].Visible = false;
            }
            if (dgvVentasSinFacturar.Columns.Contains("Detalle"))
            {
                dgvVentasSinFacturar.Columns["Detalle"].Visible = false;
            }
            if (dgvVentasSinFacturar.Columns.Contains("NumeroFactura"))
            {
                dgvVentasSinFacturar.Columns["NumeroFactura"].Visible = false;
            }
        }

        private void actualizarFacturas()
        {
            dgvFacturas.DataSource = null;
            dgvFacturas.DataSource = BLL_Factura.consultarFacturas();
        }

        private void dgvVentasSinFacturar_SelectionChanged(object sender, EventArgs e)
        {
            Venta? seleccionada = null;
            if (dgvVentasSinFacturar.CurrentRow != null)
            {
                seleccionada = dgvVentasSinFacturar.CurrentRow.DataBoundItem as Venta;
            }

            if (seleccionada == null)
            {
                lblImporte.Text = "$0.00";
            }
            else
            {
                lblImporte.Text = "$" + seleccionada.Total.ToString("0.00");
            }
        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            try
            {
                Venta venta = obtenerVentaSeleccionada();

                if (!esEstadoFacturable(venta.Estado))
                {
                    throw new Exception("Solo se pueden facturar ventas en estado Confirmada, Despachada o Entregada");
                }

                string numero = txtNumeroFactura.Text.Trim();
                if (string.IsNullOrWhiteSpace(numero))
                {
                    throw new Exception("El número de factura no puede estar vacío");
                }

                DateTime fecha = dtpFechaFactura.Value.Date;
                EstadoFactura estado = (EstadoFactura)cmbEstadoFactura.SelectedItem;
                decimal importe = venta.Total;

                Factura nFactura = new Factura(numero, fecha, importe, estado);
                BLL_Factura.AgregarFactura(nFactura);
                BLL_Venta.AsignarFactura(venta.NumeroVenta, numero);

                refrescar();
                limpiarEmision();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                Factura factura = obtenerFacturaSeleccionada();

                string valorActual = ((int)factura.Estado).ToString();
                string texto = Interaction.InputBox(
                    "Nuevo estado:\n1 = Emitida\n2 = Pagada\n3 = Anulada",
                    "Modificar estado", valorActual);

                if (string.IsNullOrWhiteSpace(texto))
                {
                    throw new Exception("El estado no puede estar vacío");
                }

                int estadoInt;
                if (!int.TryParse(texto, out estadoInt) || !Enum.IsDefined(typeof(EstadoFactura), estadoInt))
                {
                    throw new Exception("El estado debe ser un valor entre 1 y 3");
                }

                EstadoFactura estado = (EstadoFactura)estadoInt;
                BLL_Factura.ModificarEstadoFactura(factura.NumeroFactura, estado);
                actualizarFacturas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                Factura factura = obtenerFacturaSeleccionada();

                if (factura.Estado == EstadoFactura.Anulada)
                {
                    throw new Exception("La factura ya está anulada");
                }

                DialogResult r = MessageBox.Show(
                    $"¿Anular la factura {factura.NumeroFactura}?",
                    "Confirmar anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    BLL_Factura.ModificarEstadoFactura(factura.NumeroFactura, EstadoFactura.Anulada);
                    actualizarFacturas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool esEstadoFacturable(EstadoVenta pEstado)
        {
            bool facturable = false;
            if (pEstado == EstadoVenta.Confirmada || pEstado == EstadoVenta.Despachada || pEstado == EstadoVenta.Entregada)
            {
                facturable = true;
            }
            return facturable;
        }

        private Venta obtenerVentaSeleccionada()
        {
            Venta? seleccionada = null;
            if (dgvVentasSinFacturar.CurrentRow != null)
            {
                seleccionada = dgvVentasSinFacturar.CurrentRow.DataBoundItem as Venta;
            }

            if (seleccionada == null)
            {
                throw new Exception("Debe seleccionar una venta sin facturar");
            }

            return seleccionada;
        }

        private Factura obtenerFacturaSeleccionada()
        {
            Factura? seleccionada = null;
            if (dgvFacturas.CurrentRow != null)
            {
                seleccionada = dgvFacturas.CurrentRow.DataBoundItem as Factura;
            }

            if (seleccionada == null)
            {
                throw new Exception("Debe seleccionar una factura de la lista");
            }

            return seleccionada;
        }

        private void limpiarEmision()
        {
            txtNumeroFactura.Clear();
            dtpFechaFactura.Value = DateTime.Now;
            if (cmbEstadoFactura.Items.Count > 0)
            {
                cmbEstadoFactura.SelectedIndex = 0;
            }
            lblImporte.Text = "$0.00";
        }
    }
}
