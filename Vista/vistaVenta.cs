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
    public partial class vistaVenta : Form
    {
        VentaBLL BLL_Venta;
        ClienteBLL BLL_Cliente;
        PrendaBLL BLL_Prenda;
        List<DetalleVenta> detalleActual;
        List<Venta> todasLasVentas;

        public vistaVenta()
        {
            InitializeComponent();
            BLL_Venta = new VentaBLL();
            BLL_Cliente = new ClienteBLL();
            BLL_Prenda = new PrendaBLL();
            detalleActual = new List<DetalleVenta>();
            todasLasVentas = new List<Venta>();
        }

        private void vistaVenta_Load(object sender, EventArgs e)
        {
            try
            {
                cmbTipoVenta.DataSource = Enum.GetValues(typeof(TipoVenta));
                cmbMedioPago.DataSource = Enum.GetValues(typeof(MedioPago));
                cmbEstado.DataSource = Enum.GetValues(typeof(EstadoVenta));

                //cargarCombosExternos();
                //refrescarDetalle();
                //actualizarDGV();
                //nuevaVenta();

                this.Activated += vistaVenta_Activated;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vistaVenta_Activated(object sender, EventArgs e)
        {
            try
            {
                cargarCombosExternos();
                actualizarDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarCombosExternos()
        {
            cmbCliente.DataSource = BLL_Cliente.consultarClientes();
            cmbCliente.DisplayMember = "DescripcionCombo";
            cmbCliente.ValueMember = "Documento";

            cmbPrenda.DataSource = BLL_Prenda.consultarPrendas();
            cmbPrenda.DisplayMember = "DescripcionCombo";
            cmbPrenda.ValueMember = "Codigo";
        }

        private void actualizarDGV()
        {
            todasLasVentas = BLL_Venta.consultarVentas();
            aplicarFiltro();
        }

        private void aplicarFiltro()
        {

            try
            {
                string termino = txtBuscar.Text.Trim().ToLower();
                List<Venta> filtradas = new List<Venta>();

                if (string.IsNullOrEmpty(termino))
                {
                    filtradas = todasLasVentas;
                }
                else
                {
                    foreach (Venta v in todasLasVentas)
                    {
                        bool coincide = false;
                        if (v.NumeroVenta.ToString().Contains(termino))
                        {
                            coincide = true;
                        }
                        if (v.ClienteNombre.ToLower().Contains(termino))
                        {
                            coincide = true;
                        }
                        if (v.Cliente.Documento.ToLower().Contains(termino))
                        {
                            coincide = true;
                        }
                        if (coincide)
                        {
                            filtradas.Add(v);
                        }
                    }
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = filtradas;
                ocultarColumnasVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            aplicarFiltro();
        }

        private void ocultarColumnasVenta()
        {
            try
            {
                if (dataGridView1.Columns.Contains("Cliente"))
                {
                    dataGridView1.Columns["Cliente"].Visible = false;
                }
                if (dataGridView1.Columns.Contains("Factura"))
                {
                    dataGridView1.Columns["Factura"].Visible = false;
                }
                if (dataGridView1.Columns.Contains("Detalle"))
                {
                    dataGridView1.Columns["Detalle"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refrescarDetalle()
        {
            try
            {
                dgvDetalle.DataSource = null;
                dgvDetalle.DataSource = detalleActual;
                if (dgvDetalle.Columns.Contains("Prenda"))
                {
                    dgvDetalle.Columns["Prenda"].Visible = false;
                }
                lblTotal.Text = "Total: $" + calcularTotalDetalle().ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private decimal calcularTotalDetalle()
        {
            try
            {
                decimal total = 0;
                foreach (DetalleVenta d in detalleActual)
                {
                    total = total + d.Subtotal;
                }
                return total;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void btnAgregarRenglon_Click(object sender, EventArgs e)
        {
            try
            {
                Prenda? prenda = cmbPrenda.SelectedItem as Prenda;
                if (prenda == null)
                {
                    throw new Exception("Debe seleccionar una prenda");
                }

                int cantidad;
                if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
                {
                    throw new Exception("La cantidad debe ser un entero mayor a 0");
                }
                if (!prenda.tieneStock(cantidad))
                {
                    throw new Exception($"Stock insuficiente: quedan {prenda.stockDisponible} unidades de {prenda.Descripcion}");
                }

                bool yaEsta = false;
                foreach (DetalleVenta d in detalleActual)
                {
                    if (d.Prenda.Codigo == prenda.Codigo)
                    {
                        yaEsta = true;
                    }
                }
                if (yaEsta)
                {
                    throw new Exception("La prenda ya está cargada en el detalle");
                }

                detalleActual.Add(new DetalleVenta(prenda, cantidad, prenda.Valor));
                refrescarDetalle();
                txtCantidad.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarRenglon_Click(object sender, EventArgs e)
        {
            try
            {
                DetalleVenta? seleccionado = null;
                if (dgvDetalle.CurrentRow != null)
                {
                    seleccionado = dgvDetalle.CurrentRow.DataBoundItem as DetalleVenta;
                }

                if (seleccionado != null)
                {
                    detalleActual.Remove(seleccionado);
                    refrescarDetalle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente? cliente = cmbCliente.SelectedItem as Cliente;
                if (cliente == null)
                {
                    throw new Exception("Debe seleccionar un cliente");
                }
                if (detalleActual.Count == 0)
                {
                    throw new Exception("La venta debe tener al menos un renglón de detalle");
                }

                TipoVenta tipo = (TipoVenta)cmbTipoVenta.SelectedItem;
                MedioPago medio = (MedioPago)cmbMedioPago.SelectedItem;
                EstadoVenta estado = (EstadoVenta)cmbEstado.SelectedItem;
                DateTime fecha = dtpFecha.Value.Date;

                Venta nVenta = new Venta(0, cliente, tipo, medio, estado, fecha);
                foreach (DetalleVenta d in detalleActual)
                {
                    nVenta.agregarDetalle(d.Prenda, d.Cantidad, d.ValorUnitario);
                }

                BLL_Venta.AgregarVenta(nVenta);   // descuenta el stock de cada prenda
                cargarCombosExternos();            // refresca las prendas con el stock actualizado
                actualizarDGV();
                nuevaVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Venta seleccionada = obtenerVentaSeleccionada();

                string valorActual = ((int)seleccionada.Estado).ToString();
                string texto = Interaction.InputBox(
                    "Nuevo estado:\n1 = Pendiente\n2 = Confirmada\n3 = Despachada\n4 = Entregada\n5 = Cancelada",
                    "Modificar estado", valorActual);

                if (string.IsNullOrWhiteSpace(texto))
                {
                    throw new Exception("El estado no puede estar vacío");
                }

                int estadoInt;
                if (!int.TryParse(texto, out estadoInt) || !Enum.IsDefined(typeof(EstadoVenta), estadoInt))
                {
                    throw new Exception("El estado debe ser un valor entre 1 y 5");
                }

                EstadoVenta estado = (EstadoVenta)estadoInt;
                BLL_Venta.ModificarEstadoVenta(seleccionada.NumeroVenta, estado, seleccionada.MedioPago);
                actualizarDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Venta seleccionada = obtenerVentaSeleccionada();

                DialogResult r = MessageBox.Show(
                    $"¿Eliminar la venta N° {seleccionada.NumeroVenta}?",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    BLL_Venta.EliminarVenta(seleccionada.NumeroVenta);
                    actualizarDGV();
                    nuevaVenta();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevaVenta();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            /* Venta? seleccionada = null;
             if (dataGridView1.CurrentRow != null)
             {
                 seleccionada = dataGridView1.CurrentRow.DataBoundItem as Venta;
             }

             if (seleccionada != null)
             {
                 seleccionarClienteEnCombo(seleccionada.Cliente.Documento);
                 cmbTipoVenta.SelectedItem = seleccionada.TipoVenta;
                 cmbMedioPago.SelectedItem = seleccionada.MedioPago;
                 cmbEstado.SelectedItem = seleccionada.Estado;
                 dtpFecha.Value = seleccionada.FechaVenta;

                 detalleActual = new List<DetalleVenta>(seleccionada.Detalle);
                 refrescarDetalle();
             }*/
        }

        private void seleccionarClienteEnCombo(string pDocumento)
        {
            foreach (object item in cmbCliente.Items)
            {
                Cliente? c = item as Cliente;
                if (c != null && c.Documento == pDocumento)
                {
                    cmbCliente.SelectedItem = item;
                }
            }
        }

        private Venta obtenerVentaSeleccionada()
        {
            Venta? seleccionada = null;
            if (dataGridView1.CurrentRow != null)
            {
                seleccionada = dataGridView1.CurrentRow.DataBoundItem as Venta;
            }

            if (seleccionada == null)
            {
                throw new Exception("Debe seleccionar una venta de la lista");
            }

            return seleccionada;
        }

        private void nuevaVenta()
        {
            detalleActual = new List<DetalleVenta>();
            refrescarDetalle();
            txtCantidad.Clear();

            if (cmbCliente.Items.Count > 0)
            {
                cmbCliente.SelectedIndex = 0;
            }
            if (cmbTipoVenta.Items.Count > 0)
            {
                cmbTipoVenta.SelectedIndex = 0;
            }
            if (cmbMedioPago.Items.Count > 0)
            {
                cmbMedioPago.SelectedIndex = 0;
            }
            if (cmbEstado.Items.Count > 0)
            {
                cmbEstado.SelectedIndex = 0;
            }
            if (cmbPrenda.Items.Count > 0)
            {
                cmbPrenda.SelectedIndex = 0;
            }
            dtpFecha.Value = DateTime.Now;
        }
    }
}
