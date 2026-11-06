using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    public partial class vistaReportes : Form
    {
        ReporteBLL BLL_Reporte;
        Reporte? reporteActual;
        bool cargandoCombo;

        public vistaReportes()
        {
            InitializeComponent();
            BLL_Reporte = new ReporteBLL();
        }

        private void vistaReportes_Load(object sender, EventArgs e)
        {
            try
            {
                // Reporte es abstracta: en lugar de un "reporte vacío" se usa el placeholder del combo
                cargandoCombo = true;
                cmbReporte.DisplayMember = "Titulo";
                cmbReporte.DataSource = BLL_Reporte.ConsultarReportes();
                cmbReporte.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargandoCombo = false;
            }
        }

        private void cmbReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoCombo)
            {
                return;   // evita consultar la base mientras se arma el combo
            }
            try
            {
                cargarReporte();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarReporte();
                if (reporteActual == null)
                {
                    throw new Exception("Debe seleccionar un reporte");
                }

                SaveFileDialog dialogo = new SaveFileDialog();
                dialogo.Filter = "Documento PDF (*.pdf)|*.pdf";
                dialogo.FileName = reporteActual.Archivo + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".pdf";

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    reporteActual.exportarPDF(dialogo.FileName);
                    DialogResult resultado = MessageBox.Show("El reporte se generó correctamente. ¿Desea abrir el archivo?", "Reporte generado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (resultado == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(dialogo.FileName) { UseShellExecute = true });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarReporte()
        {
            try
            {
                Reporte? seleccionado = cmbReporte.SelectedItem as Reporte;
                if (seleccionado == null || cmbReporte.SelectedIndex < 0)
                {
                    reporteActual = null;
                    dgvVistaPrevia.DataSource = null;

                }
                else
                {
                    reporteActual = BLL_Reporte.GenerarReporte(seleccionado);
                    dgvVistaPrevia.DataSource = null;
                    dgvVistaPrevia.DataSource = reporteActual.Datos;
                    foreach (DataGridViewColumn columna in dgvVistaPrevia.Columns)
                    {
                        columna.HeaderText = reporteActual.obtenerEncabezado(columna.Name);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
