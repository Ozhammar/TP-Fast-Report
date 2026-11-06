using BLL;
using Entidades;
using Entidades.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    public partial class vistaCliente : Form
    {
        ClienteBLL BLL_Cliente;
        public vistaCliente()
        {
            InitializeComponent();
            BLL_Cliente = new ClienteBLL();
        }

        private void vistaCliente_Load(object sender, EventArgs e)
        {
            try
            {
                actualizarDGV();
                this.Activated += vistaCliente_Activated;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vistaCliente_Activated(object sender, EventArgs e)
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
            dataGridView1.DataSource = BLL_Cliente.consultarClientes();
            if (dataGridView1.Columns.Contains("Telefono"))
            {
                dataGridView1.Columns["Telefono"].Visible = false;
            }
            if (dataGridView1.Columns.Contains("DescripcionCombo"))
            {
                dataGridView1.Columns["DescripcionCombo"].Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)   // Alta
        {
            try
            {
                Cliente nCliente = pedirDatosCliente();
                BLL_Cliente.AgregarCliente(nCliente);
                gestionarTelefonos(nCliente);
                actualizarDGV();
            }
            catch (OperationCanceledException)
            {
                // El usuario canceló la carga: se sale sin mostrar error
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)   // Modificar
        {
            try
            {
                Cliente seleccionado = obtenerClienteSeleccionado();
                Cliente modificado = pedirDatosCliente(seleccionado);
                BLL_Cliente.ModificarCliente(modificado);
                gestionarTelefonos(seleccionado);
                actualizarDGV();
            }
            catch (OperationCanceledException)
            {
                // El usuario canceló la modificación: se sale sin mostrar error
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)   // Eliminar
        {
            try
            {
                Cliente seleccionado = obtenerClienteSeleccionado();

                DialogResult r = MessageBox.Show(
                    $"¿Eliminar al cliente {seleccionado.Nombre} {seleccionado.Apellido} (Doc: {seleccionado.Documento})?",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r != DialogResult.Yes)
                    return;

                BLL_Cliente.EliminarCliente(seleccionado.Documento);
                actualizarDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Cliente obtenerClienteSeleccionado()
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is not Cliente cliente)
                throw new Exception("Debe seleccionar un cliente de la lista");
            return cliente;
        }

        private string pedirTexto(string pMensaje, string pTitulo, string pValorPorDefecto = "")
        {
            string texto = Interaction.InputBox(pMensaje, pTitulo, pValorPorDefecto);
            if (string.IsNullOrWhiteSpace(texto))
            {
                throw new OperationCanceledException();
            }
            return texto.Trim();
        }

        private Cliente pedirDatosCliente(Cliente? existente = null)
        {
            string titulo = existente == null ? "Nuevo cliente" : "Modificar cliente";

            string tipoTexto = pedirTexto("Tipo de documento (1 = DNI, 2 = CUIT, 3 = CUIL):", titulo,
                existente == null ? "1" : ((int)existente.TipoDocumento).ToString());
            if (!int.TryParse(tipoTexto, out int tipoInt) || !Enum.IsDefined(typeof(TipoDocumento), tipoInt))
            {
                throw new Exception("El tipo de documento debe ser 1, 2 o 3");
            }
            TipoDocumento tipo = (TipoDocumento)tipoInt;

            string documento;
            if (existente == null)
            {
                documento = pedirTexto($"Ingrese el número de {tipo} (solo números, máx. {ClienteBLL.LARGO_MAX_DOCUMENTO} dígitos):", titulo);
                documento = BLL_Cliente.NormalizarDocumento(documento, tipo);
            }
            else
            {
                documento = existente.Documento;   // el documento es la clave: no se modifica
                BLL_Cliente.NormalizarDocumento(documento, tipo);   // valida que siga siendo coherente con el tipo
            }

            string nombre = pedirTexto("Ingrese el nombre:", titulo, existente?.Nombre ?? "");
            string apellido = pedirTexto("Ingrese el apellido:", titulo, existente?.Apellido ?? "");

            string email = pedirTexto("Ingrese el email:", titulo, existente?.Email ?? "");
            BLL_Cliente.ValidarEmail(email);

            string domicilio = pedirTexto("Ingrese el domicilio de facturación:", titulo, existente?.DomicilioFacturacion ?? "");

            return new Cliente(documento, tipo, nombre, apellido, email, domicilio);
        }

        private void gestionarTelefonos(Cliente pCliente)
        {
            while (true)
            {
                string actuales = pCliente.Telefono.Count == 0
                    ? "(sin teléfonos)"
                    : string.Join(Environment.NewLine, pCliente.Telefono.Select(t => t.NumeroTelefonico));

                string opcion = Interaction.InputBox(
                    $"Teléfonos de {pCliente.Nombre} {pCliente.Apellido}:\n{actuales}\n\n" +
                    "1 = Agregar   |   2 = Quitar   |   0 = Terminar",
                    "Teléfonos", "0");

                if (string.IsNullOrWhiteSpace(opcion) || opcion == "0")
                {
                    break;
                }

                try
                {
                    if (opcion == "1")
                    {
                        string tel = Interaction.InputBox($"Ingrese el teléfono a agregar (máx. {ClienteBLL.LARGO_MAX_TELEFONO} caracteres sin espacios ni guiones):", "Agregar teléfono");
                        if (string.IsNullOrWhiteSpace(tel))
                        {
                            continue;
                        }
                        BLL_Cliente.AgregarTelefono(pCliente, tel);
                    }
                    else if (opcion == "2")
                    {
                        string tel = Interaction.InputBox("Ingrese el teléfono a quitar:", "Quitar teléfono");
                        if (string.IsNullOrWhiteSpace(tel))
                        {
                            continue;
                        }
                        BLL_Cliente.EliminarTelefono(pCliente, tel);
                    }
                    else
                    {
                        MessageBox.Show("Opción inválida", "Teléfonos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    // Un teléfono inválido o repetido no corta la gestión: se informa y se sigue
                    MessageBox.Show(ex.Message, "Teléfonos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
