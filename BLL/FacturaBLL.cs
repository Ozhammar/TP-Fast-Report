using System;
using System.Collections.Generic;
using System.Text;
using ORM;
using Entidades;
using Entidades.Enums;

namespace BLL
{
    public class FacturaBLL
    {
        FacturaMapper Mapper;
        public FacturaBLL()
        {
            Mapper = new FacturaMapper();
        }

        public List<Factura> consultarFacturas()
        {
            return Mapper.consultarFacturas();
        }

        public void AgregarFactura(Factura pFactura)
        {
            Mapper.agregarFactura(pFactura);
        }

        public void ModificarEstadoFactura(string pNumFactura, EstadoFactura pEstado)
        {
            Mapper.modificarEstadoFactura(pNumFactura, pEstado);
        }
    }
}
