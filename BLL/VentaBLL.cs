using System;
using System.Collections.Generic;
using System.Text;
using ORM;
using Entidades;
using Entidades.Enums;

namespace BLL
{
    public class VentaBLL
    {
        VentaMapper Mapper;
        public VentaBLL()
        {
            Mapper = new VentaMapper();
        }

        public List<Venta> consultarVentas()
        {
            return Mapper.consultarVentas();
        }

        public List<Venta> consultarVentasSinFacturar()
        {
            return Mapper.consultarVentasSinFacturar();
        }

        public void AsignarFactura(int pNumVenta, string pNumFactura)
        {
            Mapper.asignarFactura(pNumVenta, pNumFactura);
        }

        public void AgregarVenta(Venta pVenta)
        {
            if (pVenta.Detalle.Count == 0)
            {
                throw new Exception("La venta debe tener al menos un renglón de detalle");
            }

            // Regla de negocio: la venta solicita a cada prenda que descuente su stock
            pVenta.descontarStockPrendas();

            try
            {
                // Se registra la venta y se impacta el stock en la base en una sola transacción
                Mapper.agregarVenta(pVenta);
            }
            catch (Exception)
            {
                pVenta.reponerStockPrendas();
                throw;
            }
        }

        public void ModificarEstadoVenta(int pNumVenta, EstadoVenta pEstado, MedioPago pMedioPago)
        {
            Mapper.modificarEstadoVenta(pNumVenta, pEstado, pMedioPago);
        }

        public void EliminarVenta(int pNumVenta)
        {
            Mapper.eliminarVenta(pNumVenta);
        }
    }
}
