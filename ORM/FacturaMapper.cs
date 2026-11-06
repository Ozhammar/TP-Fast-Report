using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAO;
using Entidades;
using Entidades.Enums;

namespace ORM
{
    public class FacturaMapper
    {
        FacturaDAO FacturaDAO;
        public FacturaMapper()
        {
            FacturaDAO = new FacturaDAO();
        }

        public List<Factura> consultarFacturas()
        {
            try
            {
                List<Factura> facturas = new List<Factura>();
                DataTable DT = FacturaDAO.consultarFacturas();

                foreach (DataRow row in DT.Rows)
                {
                    Factura nFactura = new Factura(
                            row.Field<string>(0),
                            row.Field<DateTime>(1),
                            row.Field<decimal>(2),
                            (EstadoFactura)row.Field<int>(3)
                        );

                    facturas.Add(nFactura);
                }
                return facturas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void agregarFactura(Factura pFactura)
        {
            FacturaDAO.agregarFactura(pFactura);
        }

        public void modificarEstadoFactura(string pNumFactura, EstadoFactura pEstado)
        {
            FacturaDAO.modificarEstadoFactura(pNumFactura, pEstado);
        }
    }
}
