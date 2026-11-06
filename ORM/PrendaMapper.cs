using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAO;
using Entidades;
using Entidades.Enums;

namespace ORM
{
    public class PrendaMapper
    {
        PrendaDAO PrendaDAO;
        public PrendaMapper()
        {
            PrendaDAO = new PrendaDAO();
        }

        public List<Prenda> consultarPrendas()
        {
            try
            {
                List<Prenda> prendas = new List<Prenda>();
                DataTable DT = PrendaDAO.consultarPrendas();

                foreach (DataRow row in DT.Rows)
                {
                    Prenda nPrenda = new Prenda(
                            row.Field<string>(0),
                            row.Field<string>(1),
                            (Categoria)row.Field<int>(2),
                            (ColorPrenda)row.Field<int>(3),
                            (Talle)row.Field<int>(4),
                            row.Field<decimal>(5),
                            row.Field<int>(6)
                        );

                    prendas.Add(nPrenda);
                }
                return prendas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void agregarPrenda(Prenda pPrenda)
        {
            PrendaDAO.agregarPrenda(pPrenda);
        }

        public void modificarPrenda(Prenda pPrenda)
        {
            PrendaDAO.modificarPrenda(pPrenda);
        }

        public void eliminarPrenda(string pCodigo)
        {
            PrendaDAO.eliminarPrenda(pCodigo);
        }
    }
}
