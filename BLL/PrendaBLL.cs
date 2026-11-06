using System;
using System.Collections.Generic;
using System.Text;
using ORM;
using Entidades;

namespace BLL
{
    public class PrendaBLL
    {
        PrendaMapper Mapper;
        public PrendaBLL()
        {
            Mapper = new PrendaMapper();
        }

        public List<Prenda> consultarPrendas()
        {
            return Mapper.consultarPrendas();
        }

        public void AgregarPrenda(Prenda pPrenda)
        {
            Mapper.agregarPrenda(pPrenda);
        }

        public void ModificarPrenda(Prenda pPrenda)
        {
            Mapper.modificarPrenda(pPrenda);
        }

        public void EliminarPrenda(string pCodigo)
        {
            Mapper.eliminarPrenda(pCodigo);
        }
    }
}
