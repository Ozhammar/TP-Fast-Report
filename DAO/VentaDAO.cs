using Entidades;
using Entidades.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAO
{
    public class VentaDAO : SQLKit
    {
        public VentaDAO() : base() { }

        // Columnas comunes de la cabecera (incluye la factura, si la venta ya fue facturada)
        private const string SELECT_VENTAS = @"SELECT v.NUM_VENTA, c.NRO_DOC_CLIENTE, c.ID_TIPO_DOC,
                                           c.APELLIDO_CLIENTE, c.NOM_CLIENTE, c.EMAIL_CLIENTE, c.DOM_FACT_CLIENTE,
                                           v.ID_TIPO_VTA, v.ID_MEDIO_PAGO, v.ID_ESTADO_VTA, v.FECHA_VENTA,
                                           f.NUM_FACT_LEGAL, f.FECHA_FACTURA, f.IMPORTE_FACTURA, f.ID_ESTADO_FC
                                    FROM Venta v
                                    JOIN Cliente c ON c.NRO_DOC_CLIENTE = v.NRO_DOC_CLIENTE
                                    LEFT JOIN Factura f ON f.NUM_FACT_LEGAL = v.NUM_FACT_LEGAL ";

        // Detalle de todas las ventas en una sola consulta (evita una consulta por venta)
        private const string SELECT_DETALLES = @"SELECT d.COD_PRENDA, p.DESC_PRENDA, p.ID_CATEGORIA, p.ID_COLOR, p.ID_TALLE,
                                           p.PRECIO_CATALOGO, p.STOCK_DISP, d.CANT_PRENDA, d.VAL_UNIT, d.NUM_VENTA
                                    FROM Detalle_Venta d
                                    JOIN Prenda p ON p.COD_PRENDA = d.COD_PRENDA
                                    JOIN Venta v ON v.NUM_VENTA = d.NUM_VENTA ";

        public DataTable consultarVentas()
        {
            return ejecutarConsulta(SELECT_VENTAS + "ORDER BY v.NUM_VENTA;");
        }

        public DataTable consultarVentasSinFacturar()
        {
            return ejecutarConsulta(SELECT_VENTAS + "WHERE v.NUM_FACT_LEGAL IS NULL ORDER BY v.NUM_VENTA;");
        }

        public DataTable consultarDetalles()
        {
            return ejecutarConsulta(SELECT_DETALLES + "ORDER BY d.NUM_VENTA;");
        }

        public DataTable consultarDetallesSinFacturar()
        {
            return ejecutarConsulta(SELECT_DETALLES + "WHERE v.NUM_FACT_LEGAL IS NULL ORDER BY d.NUM_VENTA;");
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

        public void asignarFactura(int pNumVenta, string pNumFactura)
        {
            try
            {
                conectar();
                com.CommandText = "UPDATE Venta SET NUM_FACT_LEGAL = @Fact WHERE NUM_VENTA = @Num;";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Num", pNumVenta);
                com.Parameters.AddWithValue("@Fact", pNumFactura);
                com.ExecuteNonQuery();
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

        public void agregarVenta(Venta pVenta)
        {
            SqlTransaction? tx = null;
            try
            {
                conectar();
                // Cabecera, detalle y stock se graban juntos: si algo falla no queda nada a medias
                tx = con.BeginTransaction();
                com.Transaction = tx;

                // Cabecera: la factura queda en NULL (se asigna al emitir la factura)
                com.CommandText = @"INSERT INTO Venta
                                        (NRO_DOC_CLIENTE, ID_TIPO_VTA, ID_MEDIO_PAGO, ID_ESTADO_VTA, FECHA_VENTA)
                                    VALUES
                                        (@Doc, @Tipo, @Medio, @Estado, @Fecha);
                                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Doc", pVenta.Cliente.Documento);
                com.Parameters.AddWithValue("@Tipo", (int)pVenta.TipoVenta);
                com.Parameters.AddWithValue("@Medio", (int)pVenta.MedioPago);
                com.Parameters.AddWithValue("@Estado", (int)pVenta.Estado);
                com.Parameters.AddWithValue("@Fecha", pVenta.FechaVenta);
                int numVenta = (int)com.ExecuteScalar();

                foreach (DetalleVenta d in pVenta.Detalle)
                {
                    // Renglón de detalle
                    com.CommandText = @"INSERT INTO Detalle_Venta
                                            (NUM_VENTA, COD_PRENDA, CANT_PRENDA, VAL_UNIT)
                                        VALUES
                                            (@Num, @Cod, @Cant, @Val);";
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("@Num", numVenta);
                    com.Parameters.AddWithValue("@Cod", d.Prenda.Codigo);
                    com.Parameters.AddWithValue("@Cant", d.Cantidad);
                    com.Parameters.AddWithValue("@Val", d.ValorUnitario);
                    com.ExecuteNonQuery();

                    // Descuento del stock. La condición STOCK_DISP >= @Cant controla contra el valor
                    // real de la base, por si otro usuario vendió la prenda mientras tanto.
                    com.CommandText = @"UPDATE Prenda
                                        SET STOCK_DISP = STOCK_DISP - @Cant
                                        WHERE COD_PRENDA = @Cod AND STOCK_DISP >= @Cant;";
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("@Cod", d.Prenda.Codigo);
                    com.Parameters.AddWithValue("@Cant", d.Cantidad);
                    if (com.ExecuteNonQuery() == 0)
                    {
                        throw new Exception($"Stock insuficiente para la prenda {d.Prenda.Codigo}. Actualice la pantalla y vuelva a intentar.");
                    }
                }

                tx.Commit();
                pVenta.NumeroVenta = numVenta;
            }
            catch (Exception)
            {
                try { tx?.Rollback(); } catch (Exception) { /* la transacción ya no es válida */ }
                throw;
            }
            finally
            {
                com.Transaction = null;
                desconectar();
            }
        }

        public void modificarEstadoVenta(int pNumVenta, EstadoVenta pEstado, MedioPago pMedioPago)
        {
            try
            {
                conectar();
                com.CommandText = @"UPDATE Venta SET
                                        ID_ESTADO_VTA = @Estado,
                                        ID_MEDIO_PAGO = @Medio
                                    WHERE NUM_VENTA = @Num;";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Num", pNumVenta);
                com.Parameters.AddWithValue("@Estado", (int)pEstado);
                com.Parameters.AddWithValue("@Medio", (int)pMedioPago);
                com.ExecuteNonQuery();
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

        public void eliminarVenta(int pNumVenta)
        {
            try
            {
                conectar();

                com.CommandText = "DELETE FROM Detalle_Venta WHERE NUM_VENTA = @Num;";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Num", pNumVenta);
                com.ExecuteNonQuery();

                com.CommandText = "DELETE FROM Venta WHERE NUM_VENTA = @Num;";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Num", pNumVenta);
                com.ExecuteNonQuery();
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