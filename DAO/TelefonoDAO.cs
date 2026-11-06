using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DAO
{
    public class TelefonoDAO:SQLKit
    {
        public TelefonoDAO(): base()
        {
        }

        public DataTable consultarTelefono(string Documento)
        {
            try
            {
                conectar();
                com.CommandText = "SELECT TELEFONO from Cliente_Telefono as ct where ct.NRO_DOC_CLIENTE = @Doc";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Doc", Documento);

                SqlDataReader reader = com.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(reader);

                return DT;
            }
            catch (Exception)
            {
                throw;
            }
            finally { desconectar(); }
        }

        public void agregarTelefono(string pDocumento, string pTelefono)
        {
            try
            {
                conectar();

                // Alta del número en el catálogo si todavía no existe
                com.CommandText = @"IF NOT EXISTS (SELECT 1 FROM Telefono WHERE TELEFONO = @Tel)
                                        INSERT INTO Telefono (TELEFONO) VALUES (@Tel);";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Tel", pTelefono);
                com.ExecuteNonQuery();

                // Vínculo cliente-teléfono si todavía no existe
                com.CommandText = @"IF NOT EXISTS (SELECT 1 FROM Cliente_Telefono
                                                   WHERE NRO_DOC_CLIENTE = @Doc AND TELEFONO = @Tel)
                                        INSERT INTO Cliente_Telefono (NRO_DOC_CLIENTE, TELEFONO)
                                        VALUES (@Doc, @Tel);";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Doc", pDocumento);
                com.Parameters.AddWithValue("@Tel", pTelefono);
                com.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { desconectar(); }
        }

        public void eliminarTelefono(string pDocumento, string pTelefono)
        {
            try
            {
                conectar();

                // Quitar el vínculo del cliente con ese número
                com.CommandText = "DELETE FROM Cliente_Telefono WHERE NRO_DOC_CLIENTE = @Doc AND TELEFONO = @Tel;";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Doc", pDocumento);
                com.Parameters.AddWithValue("@Tel", pTelefono);
                com.ExecuteNonQuery();

                // Borrar el número del catálogo si quedó sin ningún cliente
                com.CommandText = @"DELETE FROM Telefono
                                    WHERE TELEFONO = @Tel
                                      AND NOT EXISTS (SELECT 1 FROM Cliente_Telefono WHERE TELEFONO = @Tel);";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Tel", pTelefono);
                com.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { desconectar(); }
        }
    }
}
