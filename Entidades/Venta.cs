using Entidades.Enums;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Venta
    {
        public Venta(int pNumVenta, Cliente pCliente, TipoVenta pTipoVta, MedioPago pMedioPago, EstadoVenta pEstado, DateTime pFechavta)
        {
            NumeroVenta = pNumVenta;
            Cliente = pCliente;
            TipoVenta = pTipoVta;
            MedioPago = pMedioPago;
            Estado = pEstado;
            FechaVenta = pFechavta;
            Detalle = new List<DetalleVenta>();
        }

        [DisplayName("N° venta")]
        public int NumeroVenta { get; set; }
        public Cliente Cliente { get; set; }
        [DisplayName("Tipo de venta")]
        public TipoVenta TipoVenta { get; set; }
        [DisplayName("Medio de pago")]
        public MedioPago MedioPago { get; set; }
        [DisplayName("Estado")]
        public EstadoVenta Estado { get; set; }
        [DisplayName("Fecha")]
        public DateTime FechaVenta { get; set; }
        public Factura? Factura { get; set; }
        public List<DetalleVenta> Detalle { get; set; }

        public void asignarFactura(Factura pFactura)
        {
            Factura = pFactura;
        }

        public void agregarDetalle(Prenda pPrenda, int pCantidad, decimal pValorUnitario)
        {
            Detalle.Add(new DetalleVenta(pPrenda, pCantidad, pValorUnitario));
        }

        // La venta le pide a cada prenda de su detalle que descuente lo vendido.
        // Primero valida todo el detalle para no dejar descuentos a medias.
        public void descontarStockPrendas()
        {
            foreach (DetalleVenta d in Detalle)
            {
                if (!d.Prenda.tieneStock(d.Cantidad))
                {
                    throw new Exception($"Stock insuficiente para la prenda {d.Prenda.Codigo} - {d.Prenda.Descripcion}. Disponible: {d.Prenda.stockDisponible}, solicitado: {d.Cantidad}");
                }
            }
            foreach (DetalleVenta d in Detalle)
            {
                d.Prenda.descontarStock(d.Cantidad);
            }
        }

        // Revierte el descuento en memoria si la venta no se pudo registrar
        public void reponerStockPrendas()
        {
            foreach (DetalleVenta d in Detalle)
            {
                d.Prenda.reponerStock(d.Cantidad);
            }
        }

        [DisplayName("N° factura")]
        public string NumeroFactura
        {
            get { return Factura == null ? "" : Factura.NumeroFactura; }
        }

        [DisplayName("Cliente")]
        public string ClienteNombre
        {
            get { return Cliente.Apellido + ", " + Cliente.Nombre; }
        }

        [DisplayName("Total")]
        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (DetalleVenta d in Detalle)
                {
                    total = total + d.Subtotal;
                }
                return total;
            }
        }
    }
}
