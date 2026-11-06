using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using DAO;
using System.Data;
using Entidades.Enums;

namespace ORM
{
    public class ClienteMapper
    {
        ClienteDAO ClienteDAO;
        TelefonoDAO TelefonoDAO;
        public ClienteMapper()
        {
            ClienteDAO = new ClienteDAO();
            TelefonoDAO = new TelefonoDAO();
        }
        public List<Cliente> consultarClientes()
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                DataTable DT = ClienteDAO.consultarClientes();

                foreach (DataRow row in DT.Rows)
                {
                    Cliente nCliente = new Cliente(
                            row.Field<string>(0),
                            (TipoDocumento)row.Field<int>(1), // da error por el enum
                            row.Field<string>(3),
                            row.Field<string>(2),
                            row.Field<string>(4),
                            row.Field<string>(5)
                        );

                    DataTable DTtel = TelefonoDAO.consultarTelefono(nCliente.Documento);
                    foreach (DataRow rowTel in DTtel.Rows)
                        nCliente.agregarTelefono(rowTel.Field<string>(0));

                    clientes.Add(nCliente);
                }
                return clientes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void agregarCliente(Cliente pCliente) { ClienteDAO.agregarCliente(pCliente); }
        public void modificarCliente(Cliente pCliente) { ClienteDAO.modificarCliente(pCliente); }
        public void eliminarCliente(string pDocumento) { ClienteDAO.eliminarCliente(pDocumento); }
        public void agregarTelefono(string pDocumento, string pTelefono) { TelefonoDAO.agregarTelefono(pDocumento, pTelefono); }
        public void eliminarTelefono(string pDocumento, string pTelefono) { TelefonoDAO.eliminarTelefono(pDocumento, pTelefono); }
    }
}
