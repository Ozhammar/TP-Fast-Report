using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Telefono
    {
        public Telefono(string pTelefono)
        {
            NumeroTelefonico = pTelefono;
        }
        public string NumeroTelefonico { get; set; }
    }
}
