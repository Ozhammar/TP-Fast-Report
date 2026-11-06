using Entidades.Enums;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Cliente
    {
        public Cliente() { }
        public Cliente(string pDocumento, TipoDocumento pTipoDoc, string pNombre, string pApellido, string pEmail, string pDomFact)
        {
            Documento = pDocumento;
            TipoDocumento = pTipoDoc;
            Nombre = pNombre;
            Apellido = pApellido;
            Email = pEmail;
            DomicilioFacturacion = pDomFact;
            Telefono = new List<Telefono>();
        }

        [DisplayName("Documento")]
        public string Documento { get; set; }
        [DisplayName("Tipo doc.")]
        public TipoDocumento TipoDocumento { get; set; }
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [DisplayName("Apellido")]
        public string Apellido { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Domicilio de facturación")]
        public string DomicilioFacturacion { get; set; }
        public List<Telefono> Telefono { get; set; }

        public string DescripcionCombo
        {
            get { return Apellido + " " + Nombre + " - " + Documento; }
        }

        public bool tieneTelefono(string pTelefono)
        {
            return Telefono.Exists(t => t.NumeroTelefonico == pTelefono);
        }

        // No se agregan números repetidos a la lista del cliente
        public void agregarTelefono(string pTelefono)
        {
            if (!tieneTelefono(pTelefono))
            {
                Telefono.Add(new Telefono(pTelefono));
            }
        }
        public void borrarTelefono(string pTelefono)
        {
            Telefono.RemoveAll(t => t.NumeroTelefonico == pTelefono);
        }

        
    }
}
