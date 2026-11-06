using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class ReporteVentasPorPeriodo : Reporte
    {
        public override TipoReporte Tipo => TipoReporte.VentasPorPeriodo;
        public override string Titulo => "Ventas por período";
        public override string Archivo => "VentasPorPeriodo";
        public override string Fuente => "Ventas";

        protected override void definirEncabezados()
        {
            agregarEncabezado("ANIO", "Año");
            agregarEncabezado("MES", "Mes");
            agregarEncabezado("TIPO_VENTA", "Tipo de venta");
            agregarEncabezado("MEDIO_PAGO", "Medio de pago");
            agregarEncabezado("CANT_VENTAS", "Cant. ventas");
            agregarEncabezado("MONTO_TOTAL", "Monto total");
        }
    }
}
