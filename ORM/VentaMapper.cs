using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAO;
using Entidades;
using Entidades.Enums;

namespace ORM
{
    public class VentaMapper
    {
        VentaDAO VentaDAO;
        public VentaMapper()
        {
            VentaDAO = new VentaDAO();
        }

        public List<Venta> consultarVentas()
        {
            try
            {
                DataTable DT = VentaDAO.consultarVentas();
                DataTable DTdet = VentaDAO.consultarDetalles();
                return mapearVentas(DT, DTdet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Venta> consultarVentasSinFacturar()
        {
            try
            {
                DataTable DT = VentaDAO.consultarVentasSinFacturar();
                DataTable DTdet = VentaDAO.consultarDetallesSinFacturar();
                return mapearVentas(DT, DTdet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Se reciben cabeceras y detalles ya consultados (2 consultas en total en lugar de 1 + N)
        private List<Venta> mapearVentas(DataTable DT, DataTable DTdet)
        {
            List<Venta> ventas = new List<Venta>();
            Dictionary<int, Venta> ventasPorNumero = new Dictionary<int, Venta>();

            foreach (DataRow row in DT.Rows)
            {
                Cliente cli = new Cliente(
                        row.Field<string>(1),
                        (TipoDocumento)row.Field<int>(2),
                        row.Field<string>(4),
                        row.Field<string>(3),
                        row.Field<string>(5),
                        row.Field<string>(6)
                    );

                Venta nVenta = new Venta(
                        row.Field<int>(0),
                        cli,
                        (TipoVenta)row.Field<int>(7),
                        (MedioPago)row.Field<int>(8),
                        (EstadoVenta)row.Field<int>(9),
                        row.Field<DateTime>(10)
                    );

                // Factura asociada (LEFT JOIN: viene en NULL si la venta no está facturada)
                if (!row.IsNull(11))
                {
                    Factura factura = new Factura(
                            row.Field<string>(11),
                            row.Field<DateTime>(12),
                            row.Field<decimal>(13),
                            (EstadoFactura)row.Field<int>(14)
                        );
                    nVenta.asignarFactura(factura);
                }

                ventas.Add(nVenta);
                ventasPorNumero[nVenta.NumeroVenta] = nVenta;
            }

            foreach (DataRow rowDet in DTdet.Rows)
            {
                Venta? venta;
                if (!ventasPorNumero.TryGetValue(rowDet.Field<int>(9), out venta))
                {
                    continue;
                }

                Prenda prenda = new Prenda(
                        rowDet.Field<string>(0),
                        rowDet.Field<string>(1),
                        (Categoria)rowDet.Field<int>(2),
                        (ColorPrenda)rowDet.Field<int>(3),
                        (Talle)rowDet.Field<int>(4),
                        rowDet.Field<decimal>(5),
                        rowDet.Field<int>(6)
                    );
                venta.agregarDetalle(prenda, rowDet.Field<int>(7), rowDet.Field<decimal>(8));
            }

            return ventas;
        }

        public void agregarVenta(Venta pVenta)
        {
            VentaDAO.agregarVenta(pVenta);
        }

        public void modificarEstadoVenta(int pNumVenta, EstadoVenta pEstado, MedioPago pMedioPago)
        {
            VentaDAO.modificarEstadoVenta(pNumVenta, pEstado, pMedioPago);
        }

        public void eliminarVenta(int pNumVenta)
        {
            VentaDAO.eliminarVenta(pNumVenta);
        }

        public void asignarFactura(int pNumVenta, string pNumFactura)
        {
            VentaDAO.asignarFactura(pNumVenta, pNumFactura);
        }
    }
}
