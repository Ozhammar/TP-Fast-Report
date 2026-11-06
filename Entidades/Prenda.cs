using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entidades
{
    public class Prenda
    {
        public Prenda(string pCodigo, string pDescripcion, Categoria pCategoria, ColorPrenda pColor, Talle pTalle, decimal pValor, int pStock) {
            Codigo = pCodigo;
            Descripcion = pDescripcion;
            Categoria = pCategoria;
            Color = pColor; 
            Talle = pTalle;
            Valor = pValor;
            stockDisponible = pStock;
        }
        [DisplayName("Código")]
        public string Codigo { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }
        [DisplayName("Color")]
        public ColorPrenda Color { get; set; }
        [DisplayName("Talle")]
        public Talle Talle { get; set; }
        [DisplayName("Precio")]
        public decimal Valor { get; set; }
        [DisplayName("Stock")]
        public int stockDisponible { get; set; }
        public string DescripcionCombo
        {
            get { return Descripcion + "-" + Talle + "-" + Color; }
        }
        public bool tieneStock(int pCantidad)
        {
            return pCantidad > 0 && stockDisponible >= pCantidad;
        }

        // Regla de negocio: una prenda no puede quedar con stock negativo
        public void descontarStock(int pCantidad)
        {
            if (pCantidad <= 0)
            {
                throw new Exception("La cantidad a descontar debe ser mayor a 0");
            }
            if (!tieneStock(pCantidad))
            {
                throw new Exception($"Stock insuficiente para la prenda {Codigo} - {Descripcion}. Disponible: {stockDisponible}, solicitado: {pCantidad}");
            }
            stockDisponible = stockDisponible - pCantidad;
        }

        public void reponerStock(int pCantidad)
        {
            if (pCantidad <= 0)
            {
                throw new Exception("La cantidad a reponer debe ser mayor a 0");
            }
            stockDisponible = stockDisponible + pCantidad;
        }




    }
}
