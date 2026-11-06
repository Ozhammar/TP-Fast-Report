using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAO
{
    public class PrendaDAO : SQLKit
    {
        public PrendaDAO() : base() { }

        public DataTable consultarPrendas()
        {
            try
            {
                conectar();
                com.CommandText = "SELECT * FROM Prenda;";
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

        public void agregarPrenda(Prenda pPrenda)
        {
            try
            {
                conectar();
                com.CommandText = @"INSERT INTO Prenda
                                        (COD_PRENDA, DESC_PRENDA, ID_CATEGORIA, ID_COLOR, ID_TALLE, PRECIO_CATALOGO, STOCK_DISP)
                                    VALUES
                                        (@Cod, @Desc, @Categoria, @Color, @Talle, @Precio, @Stock);";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Cod", pPrenda.Codigo);
                com.Parameters.AddWithValue("@Desc", pPrenda.Descripcion);
                com.Parameters.AddWithValue("@Categoria", (int)pPrenda.Categoria);
                com.Parameters.AddWithValue("@Color", (int)pPrenda.Color);
                com.Parameters.AddWithValue("@Talle", (int)pPrenda.Talle);
                com.Parameters.AddWithValue("@Precio", pPrenda.Valor);
                com.Parameters.AddWithValue("@Stock", pPrenda.stockDisponible);
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

        public void modificarPrenda(Prenda pPrenda)
        {
            try
            {
                conectar();
                com.CommandText = @"UPDATE Prenda SET
                                        DESC_PRENDA     = @Desc,
                                        ID_CATEGORIA    = @Categoria,
                                        ID_COLOR        = @Color,
                                        ID_TALLE        = @Talle,
                                        PRECIO_CATALOGO = @Precio,
                                        STOCK_DISP      = @Stock
                                    WHERE COD_PRENDA = @Cod;";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Cod", pPrenda.Codigo);
                com.Parameters.AddWithValue("@Desc", pPrenda.Descripcion);
                com.Parameters.AddWithValue("@Categoria", (int)pPrenda.Categoria);
                com.Parameters.AddWithValue("@Color", (int)pPrenda.Color);
                com.Parameters.AddWithValue("@Talle", (int)pPrenda.Talle);
                com.Parameters.AddWithValue("@Precio", pPrenda.Valor);
                com.Parameters.AddWithValue("@Stock", pPrenda.stockDisponible);
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

        public void eliminarPrenda(string pCodigo)
        {
            try
            {
                conectar();

                // No se permite la baja si la prenda tiene ventas asociadas (sin cascada)
                com.CommandText = "SELECT COUNT(*) FROM Detalle_Venta WHERE COD_PRENDA = @Cod;";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Cod", pCodigo);
                if ((int)com.ExecuteScalar() > 0)
                {
                    throw new Exception("No se puede eliminar: la prenda tiene ventas asociadas.");
                }

                com.CommandText = "DELETE FROM Prenda WHERE COD_PRENDA = @Cod;";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Cod", pCodigo);
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
