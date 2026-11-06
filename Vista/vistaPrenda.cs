using BLL;
using Entidades;
using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    public partial class vistaPrenda : Form
    {
        PrendaBLL BLL_Prenda;
        public vistaPrenda()
        {
            InitializeComponent();
            BLL_Prenda = new PrendaBLL();
        }

        private void vistaPrenda_Load(object sender, EventArgs e)
        {
            try
            {
                cmbCategoria.DataSource = Enum.GetValues(typeof(Categoria));
                cmbColor.DataSource = Enum.GetValues(typeof(ColorPrenda));
                cmbTalle.DataSource = Enum.GetValues(typeof(Talle));
                actualizarDGV();
                this.Activated += vistaPrenda_Activated;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vistaPrenda_Activated(object sender, EventArgs e)
        {
            try
            {
                actualizarDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarDGV()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BLL_Prenda.consultarPrendas();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Prenda? seleccionada = null;
            if (dataGridView1.CurrentRow != null)
            {
                seleccionada = dataGridView1.CurrentRow.DataBoundItem as Prenda;
            }

            if (seleccionada != null)
            {
                txtCodigo.Text = seleccionada.Codigo;
                txtDescripcion.Text = seleccionada.Descripcion;
                cmbCategoria.SelectedItem = seleccionada.Categoria;
                cmbColor.SelectedItem = seleccionada.Color;
                cmbTalle.SelectedItem = seleccionada.Talle;
                txtPrecio.Text = seleccionada.Valor.ToString();
                txtStock.Text = seleccionada.stockDisponible.ToString();
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                Prenda nPrenda = leerDatosFormulario(txtCodigo.Text);
                BLL_Prenda.AgregarPrenda(nPrenda);
                actualizarDGV();
                limpiarFormulario();
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
                Prenda seleccionada = obtenerPrendaSeleccionada();

                // El código es la clave de la prenda: si se editó el campo se avisa en lugar de ignorarlo
                string codigoIngresado = txtCodigo.Text.Trim();
                if (!string.Equals(codigoIngresado, seleccionada.Codigo, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception($"El código de una prenda no se puede modificar (seleccionada: {seleccionada.Codigo}, ingresado: {codigoIngresado}).\n" +
                                        "Para usar otro código, dé de alta una prenda nueva con \"Alta\".");
                }

                Prenda modificada = leerDatosFormulario(seleccionada.Codigo);
                BLL_Prenda.ModificarPrenda(modificada);
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
                Prenda seleccionada = obtenerPrendaSeleccionada();

                DialogResult r = MessageBox.Show(
                    $"¿Eliminar la prenda {seleccionada.Codigo} - {seleccionada.Descripcion}?",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    BLL_Prenda.EliminarPrenda(seleccionada.Codigo);
                    actualizarDGV();
                    limpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        private Prenda obtenerPrendaSeleccionada()
        {
            Prenda? seleccionada = null;
            if (dataGridView1.CurrentRow != null)
            {
                seleccionada = dataGridView1.CurrentRow.DataBoundItem as Prenda;
            }

            if (seleccionada == null)
            {
                throw new Exception("Debe seleccionar una prenda de la lista");
            }

            return seleccionada;
        }

        private Prenda leerDatosFormulario(string pCodigo)
        {
            if (string.IsNullOrWhiteSpace(pCodigo))
            {
                throw new Exception("El código no puede estar vacío");
            }

            string descripcion = txtDescripcion.Text.Trim();
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new Exception("La descripción no puede estar vacía");
            }

            if (cmbCategoria.SelectedItem == null)
            {
                throw new Exception("Debe seleccionar una categoría");
            }
            if (cmbColor.SelectedItem == null)
            {
                throw new Exception("Debe seleccionar un color");
            }
            if (cmbTalle.SelectedItem == null)
            {
                throw new Exception("Debe seleccionar un talle");
            }

            Categoria categoria = (Categoria)cmbCategoria.SelectedItem;
            ColorPrenda color = (ColorPrenda)cmbColor.SelectedItem;
            Talle talle = (Talle)cmbTalle.SelectedItem;

            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio) || precio < 0)
            {
                throw new Exception("El precio debe ser un número mayor o igual a 0");
            }

            int stock;
            if (!int.TryParse(txtStock.Text, out stock) || stock < 0)
            {
                throw new Exception("El stock debe ser un número entero mayor o igual a 0");
            }

            Prenda prenda = new Prenda(pCodigo.Trim(), descripcion, categoria, color, talle, precio, stock);
            return prenda;
        }

        private void limpiarFormulario()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();

            if (cmbCategoria.Items.Count > 0)
            {
                cmbCategoria.SelectedIndex = 0;
            }
            if (cmbColor.Items.Count > 0)
            {
                cmbColor.SelectedIndex = 0;
            }
            if (cmbTalle.Items.Count > 0)
            {
                cmbTalle.SelectedIndex = 0;
            }
        }
    }
}
