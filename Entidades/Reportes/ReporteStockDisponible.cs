using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class ReporteStockDisponible : Reporte
    {
        public override TipoReporte Tipo => TipoReporte.StockDisponible;
        public override string Titulo => "Stock disponible";
        public override string Archivo => "StockDisponible";
        public override string Fuente => "Stock";

        protected override void definirEncabezados()
        {
            agregarEncabezado("COD_PRENDA", "Código");
            agregarEncabezado("DESC_PRENDA", "Descripción");
            agregarEncabezado("CATEGORIA", "Categoría");
            agregarEncabezado("COLOR", "Color");
            agregarEncabezado("TALLE", "Talle");
            agregarEncabezado("PRECIO_CATALOGO", "Precio");
            agregarEncabezado("STOCK_DISP", "Stock");
        }
    }
}
