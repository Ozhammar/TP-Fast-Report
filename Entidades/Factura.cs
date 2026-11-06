using Entidades.Enums;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Factura
    {
        public Factura(string pNumFC, DateTime pFEmision, decimal pImporte, EstadoFactura pEstado = 0)
        {
            NumeroFactura = pNumFC;
            FechaEmision = pFEmision;
            Importe = pImporte;
            Estado = pEstado;
        }
        [DisplayName("N° factura")]
        public string NumeroFactura { get; set; }
        [DisplayName("Fecha de emisión")]
        public DateTime FechaEmision { get; set; }
        [DisplayName("Importe")]
        public decimal Importe { get; set; }
        [DisplayName("Estado")]
        public EstadoFactura Estado { get; set; }
    }

}
