using Entidades;
using Entidades.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAO
{
    public class FacturaDAO : SQLKit
    {
        public FacturaDAO() : base() { }

        public DataTable consultarFacturas()
        {
            try
            {
                conectar();
                com.CommandText = "SELECT NUM_FACT_LEGAL, FECHA_FACTURA, IMPORTE_FACTURA, ID_ESTADO_FC FROM Factura ORDER BY NUM_FACT_LEGAL;";
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

        public void agregarFactura(Factura pFactura)
        {
            try
            {
                conectar();
                com.CommandText = @"INSERT INTO Factura
                                        (NUM_FACT_LEGAL, FECHA_FACTURA, IMPORTE_FACTURA, ID_ESTADO_FC)
                                    VALUES
                                        (@Num, @Fecha, @Importe, @Estado);";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Num", pFactura.NumeroFactura);
                com.Parameters.AddWithValue("@Fecha", pFactura.FechaEmision);
                com.Parameters.AddWithValue("@Importe", pFactura.Importe);
                com.Parameters.AddWithValue("@Estado", (int)pFactura.Estado);
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

        public void modificarEstadoFactura(string pNumFactura, EstadoFactura pEstado)
        {
            try
            {
                conectar();
                com.CommandText = "UPDATE Factura SET ID_ESTADO_FC = @Estado WHERE NUM_FACT_LEGAL = @Num;";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Num", pNumFactura);
                com.Parameters.AddWithValue("@Estado", (int)pEstado);
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
