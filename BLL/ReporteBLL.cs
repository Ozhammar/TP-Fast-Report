using System;
using System.Collections.Generic;
using System.Text;
using ORM;
using Entidades;
using Entidades.Enums;

namespace BLL
{
    public class ReporteBLL
    {
        ReporteMapper Mapper;
        public ReporteBLL()
        {
            Mapper = new ReporteMapper();
        }

        // Catálogo de reportes disponibles: una instancia de cada subclase especializada
        public List<Reporte> ConsultarReportes()
        {
            List<Reporte> reportes = new List<Reporte>();
            reportes.Add(new ReporteVentasPorPeriodo());
            reportes.Add(new ReportePrendasMasVendidas());
            reportes.Add(new ReporteRankingClientes());
            reportes.Add(new ReporteFacturacionPorPeriodo());
            reportes.Add(new ReporteStockDisponible());
            return reportes;
        }

        // Recibe el reporte elegido y le carga los datos actuales de la base
        public Reporte GenerarReporte(Reporte pReporte)
        {
            if (pReporte == null)
            {
                throw new Exception("Debe seleccionar un reporte");
            }
            Mapper.cargarDatos(pReporte);
            return pReporte;
        }
    }
}
