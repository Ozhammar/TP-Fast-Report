using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class ReporteFacturacionPorPeriodo : Reporte
    {
        public override TipoReporte Tipo => TipoReporte.FacturacionPorPeriodo;
        public override string Titulo => "Facturación por período";
        public override string Archivo => "FacturacionPorPeriodo";
        public override string Fuente => "Facturas";

        protected override void definirEncabezados()
        {
            agregarEncabezado("ANIO", "Año");
            agregarEncabezado("MES", "Mes");
            agregarEncabezado("ESTADO_FACTURA", "Estado");
            agregarEncabezado("CANT_FACTURAS", "Cant. facturas");
            agregarEncabezado("IMPORTE_TOTAL", "Importe total");
        }
    }
}
