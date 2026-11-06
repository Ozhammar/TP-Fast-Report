using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAO;
using Entidades;
using Entidades.Enums;

namespace ORM
{
    public class ReporteMapper
    {
        ReporteDAO ReporteDAO;
        public ReporteMapper()
        {
            ReporteDAO = new ReporteDAO();
        }

        public void cargarDatos(Reporte pReporte)
        {
            try
            {
                DataTable DT;
                switch (pReporte.Tipo)
                {
                    case TipoReporte.VentasPorPeriodo:
                        DT = ReporteDAO.consultarVentasPorPeriodo();
                        break;
                    case TipoReporte.PrendasMasVendidas:
                        DT = ReporteDAO.consultarPrendasMasVendidas();
                        break;
                    case TipoReporte.RankingClientes:
                        DT = ReporteDAO.consultarRankingClientes();
                        break;
                    case TipoReporte.FacturacionPorPeriodo:
                        DT = ReporteDAO.consultarFacturacionPorPeriodo();
                        break;
                    case TipoReporte.StockDisponible:
                        DT = ReporteDAO.consultarStockDisponible();
                        break;
                    default:
                        throw new Exception("El tipo de reporte no es válido");
                }
                pReporte.cargarDatos(DT);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
