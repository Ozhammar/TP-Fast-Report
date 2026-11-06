using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class DetalleVenta
    {
        public DetalleVenta(Prenda pPrenda, int pCantidad, decimal pValorUnitario)
        {
            Prenda = pPrenda;
            Cantidad = pCantidad;
            ValorUnitario = pValorUnitario;
        }

        public Prenda Prenda { get; set; }
        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }
        [DisplayName("Precio unitario")]
        public decimal ValorUnitario { get; set; }

        [DisplayName("Código")]
        public string CodigoPrenda
        {
            get { return Prenda.Codigo; }
        }

        [DisplayName("Descripción")]
        public string DescripcionPrenda
        {
            get { return Prenda.Descripcion; }
        }

        [DisplayName("Subtotal")]
        public decimal Subtotal
        {
            get { return Cantidad * ValorUnitario; }
        }
    }
}
