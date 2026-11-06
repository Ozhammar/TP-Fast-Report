using Entidades.Enums;
using FastReport;
using FastReport.Export.PdfSimple;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Entidades
{
    public abstract class Reporte
    {
        protected Reporte()
        {
            Datos = new DataTable();
            Encabezados = new Dictionary<string, string>();
            definirEncabezados();
        }

        public abstract TipoReporte Tipo { get; }
        public abstract string Titulo { get; }
        public abstract string Archivo { get; }
        public abstract string Fuente { get; }

        public DataTable Datos { get; set; }
        public Dictionary<string, string> Encabezados { get; private set; }

        protected abstract void definirEncabezados();

        protected void agregarEncabezado(string pColumna, string pTexto)
        {
            Encabezados.Add(pColumna, pTexto);
        }

        public string Plantilla
        {
            get { return Path.Combine(AppContext.BaseDirectory, "Reportes", Archivo + ".frx"); }
        }

        public void cargarDatos(DataTable pDatos)
        {
            Datos = pDatos ?? new DataTable();
        }

        public string obtenerEncabezado(string pColumna)
        {
            if (Encabezados.ContainsKey(pColumna))
            {
                return Encabezados[pColumna];
            }
            return pColumna;
        }

        public virtual void exportarPDF(string pRutaDestino)
        {
            if (!File.Exists(Plantilla))
            {
                throw new Exception("No se encontró la plantilla del reporte: " + Plantilla);
            }

            using (Report reporte = new Report())
            {
                reporte.Load(Plantilla);
                reporte.RegisterData(Datos, Fuente);
                reporte.Prepare();

                PDFSimpleExport pdf = new PDFSimpleExport();
                reporte.Export(pdf, pRutaDestino);
            }
        }

        public override string ToString()
        {
            return Titulo;
        }
    }
}
