using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class ReportePrendasMasVendidas : Reporte
    {
        public override TipoReporte Tipo => TipoReporte.PrendasMasVendidas;
        public override string Titulo => "Prendas más vendidas";
        public override string Archivo => "PrendasMasVendidas";
        public override string Fuente => "Prendas";

        protected override void definirEncabezados()
        {
            agregarEncabezado("COD_PRENDA", "Código");
            agregarEncabezado("DESC_PRENDA", "Descripción");
            agregarEncabezado("CATEGORIA", "Categoría");
            agregarEncabezado("COLOR", "Color");
            agregarEncabezado("TALLE", "Talle");
            agregarEncabezado("UNIDADES_VENDIDAS", "Unidades vendidas");
            agregarEncabezado("MONTO_VENDIDO", "Monto vendido");
        }
    }
}
