using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class ReporteRankingClientes : Reporte
    {
        public override TipoReporte Tipo => TipoReporte.RankingClientes;
        public override string Titulo => "Ranking de clientes";
        public override string Archivo => "RankingClientes";
        public override string Fuente => "Clientes";

        protected override void definirEncabezados()
        {
            agregarEncabezado("POSICION", "Posición");
            agregarEncabezado("NRO_DOC_CLIENTE", "Documento");
            agregarEncabezado("APELLIDO_CLIENTE", "Apellido");
            agregarEncabezado("NOM_CLIENTE", "Nombre");
            agregarEncabezado("CANT_VENTAS", "Cant. ventas");
            agregarEncabezado("MONTO_COMPRADO", "Monto comprado");
        }
    }
}
