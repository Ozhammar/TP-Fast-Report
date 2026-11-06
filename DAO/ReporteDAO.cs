using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;

namespace DAO
{
    public class ReporteDAO : SQLKit
    {
        public ReporteDAO() : base() { }

        public DataTable consultarVentasPorPeriodo()
        {
            return ejecutarConsulta(@"SELECT ANIO, MES, TIPO_VENTA, MEDIO_PAGO, CANT_VENTAS, MONTO_TOTAL
                                      FROM dbo.vw_ventas_por_periodo
                                      ORDER BY ANIO, MES, TIPO_VENTA, MEDIO_PAGO;");
        }

        public DataTable consultarPrendasMasVendidas()
        {
            return ejecutarConsulta(@"SELECT COD_PRENDA, DESC_PRENDA, CATEGORIA, COLOR, TALLE, UNIDADES_VENDIDAS, MONTO_VENDIDO
                                      FROM dbo.vw_prendas_mas_vendidas
                                      ORDER BY UNIDADES_VENDIDAS DESC, MONTO_VENDIDO DESC;");
        }

        public DataTable consultarRankingClientes()
        {
            return ejecutarConsulta(@"SELECT POSICION, NRO_DOC_CLIENTE, APELLIDO_CLIENTE, NOM_CLIENTE, CANT_VENTAS, MONTO_COMPRADO
                                      FROM dbo.vw_ranking_clientes
                                      ORDER BY POSICION, APELLIDO_CLIENTE;");
        }

        public DataTable consultarFacturacionPorPeriodo()
        {
            return ejecutarConsulta(@"SELECT [AÑO] AS ANIO, MES, ESTADO_FACTURA, CANT_FACTURAS, IMPORTE_TOTAL
                                      FROM dbo.vw_facturacion_por_periodo
                                      ORDER BY [AÑO], MES, ESTADO_FACTURA;");
        }

        public DataTable consultarStockDisponible()
        {
            return ejecutarConsulta(@"SELECT COD_PRENDA, DESC_PRENDA, CATEGORIA, COLOR, TALLE, PRECIO_CATALOGO, STOCK_DISP
                                      FROM dbo.vw_stock_disponible
                                      ORDER BY CATEGORIA, COD_PRENDA;");
        }

        private DataTable ejecutarConsulta(string pConsulta)
        {
            try
            {
                conectar();
                com.CommandText = pConsulta;
                com.Parameters.Clear();
                SqlDataReader reader = com.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(reader);
                return DT;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                desconectar();
            }
        }
    }
}
