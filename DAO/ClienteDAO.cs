using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAO
{
    public class ClienteDAO : SQLKit
    {
        public ClienteDAO() : base() { }
        public DataTable consultarClientes()
        {
            try
            {
                conectar();
                com.CommandText = "SELECT * FROM Cliente; ";
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

        public void agregarCliente(Cliente pCliente)
        {
            try
            {
                conectar();
                com.CommandText = "INSERT INTO CLIENTE VALUES (@NroDoc, @TipoDoc, @Apellido, @Nombre, @Email, @Domicilio);";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@NroDoc", pCliente.Documento);
                com.Parameters.AddWithValue("@TipoDoc", (int)pCliente.TipoDocumento);
                com.Parameters.AddWithValue("@Apellido", pCliente.Apellido);
                com.Parameters.AddWithValue("@Nombre", pCliente.Nombre);
                com.Parameters.AddWithValue("@Email", pCliente.Email);
                com.Parameters.AddWithValue("@Domicilio", pCliente.DomicilioFacturacion);
                com.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { desconectar(); }
        }

        public void modificarCliente(Cliente pCliente)
        {
            try
            {
                conectar();
                com.CommandText = @"UPDATE Cliente SET
                                        ID_TIPO_DOC      = @TipoDoc,
                                        APELLIDO_CLIENTE = @Apellido,
                                        NOM_CLIENTE      = @Nombre,
                                        EMAIL_CLIENTE    = @Email,
                                        DOM_FACT_CLIENTE = @Domicilio
                                    WHERE NRO_DOC_CLIENTE = @NroDoc;";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@NroDoc", pCliente.Documento);
                com.Parameters.AddWithValue("@TipoDoc", (int)pCliente.TipoDocumento);
                com.Parameters.AddWithValue("@Apellido", pCliente.Apellido);
                com.Parameters.AddWithValue("@Nombre", pCliente.Nombre);
                com.Parameters.AddWithValue("@Email", pCliente.Email);
                com.Parameters.AddWithValue("@Domicilio", pCliente.DomicilioFacturacion);
                com.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { desconectar(); }
        }

        public void eliminarCliente(string pDocumento)
        {
            try
            {
                conectar();

                // No se permite la baja si el cliente tiene ventas asociadas (sin cascada)
                com.CommandText = "SELECT COUNT(*) FROM Venta WHERE NRO_DOC_CLIENTE = @Doc;";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Doc", pDocumento);
                if ((int)com.ExecuteScalar() > 0)
                    throw new Exception("No se puede eliminar: el cliente tiene ventas asociadas.");

                // Desvincular los teléfonos del cliente
                com.CommandText = "DELETE FROM Cliente_Telefono WHERE NRO_DOC_CLIENTE = @Doc;";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Doc", pDocumento);
                com.ExecuteNonQuery();

                // Borrar los teléfonos que hayan quedado sin ningún cliente
                com.CommandText = @"DELETE t FROM Telefono t
                                    WHERE NOT EXISTS (SELECT 1 FROM Cliente_Telefono ct
                                                      WHERE ct.TELEFONO = t.TELEFONO);";
                com.Parameters.Clear();
                com.ExecuteNonQuery();

                // Borrar el cliente
                com.CommandText = "DELETE FROM Cliente WHERE NRO_DOC_CLIENTE = @Doc;";
                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Doc", pDocumento);
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
