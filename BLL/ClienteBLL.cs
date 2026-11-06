using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ORM;
using Entidades;
using Entidades.Enums;

namespace BLL
{
    public class ClienteBLL
    {
        // Longitudes máximas de las columnas en la base
        public const int LARGO_MAX_DOCUMENTO = 11;   // Cliente.NRO_DOC_CLIENTE VARCHAR(11)
        public const int LARGO_MAX_TELEFONO = 14;    // Telefono.TELEFONO VARCHAR(14)
        public const int LARGO_MIN_TELEFONO = 6;

        static readonly Regex soloDigitos = new Regex(@"^\d+$");
        static readonly Regex formatoTelefono = new Regex(@"^\+?\d+$");
        static readonly Regex formatoEmail = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        ClienteMapper Mapper;
        public ClienteBLL()
        {
            Mapper = new ClienteMapper();
        }

        public List<Cliente> consultarClientes() => Mapper.consultarClientes();

        public void AgregarCliente(Cliente pCliente)
        {
            pCliente.Documento = NormalizarDocumento(pCliente.Documento, pCliente.TipoDocumento);
            validarDatosCliente(pCliente);
            Mapper.agregarCliente(pCliente);
        }

        public void ModificarCliente(Cliente pCliente)
        {
            // El documento es la clave: se valida pero no se reescribe
            NormalizarDocumento(pCliente.Documento, pCliente.TipoDocumento);
            validarDatosCliente(pCliente);
            Mapper.modificarCliente(pCliente);
        }

        public void EliminarCliente(string pDocumento) => Mapper.eliminarCliente(pDocumento);

        public void AgregarTelefono(Cliente pCliente, string pTelefono)
        {
            string telefono = NormalizarTelefono(pTelefono);
            if (pCliente.tieneTelefono(telefono))
            {
                throw new Exception("El teléfono " + telefono + " ya está cargado para este cliente");
            }
            Mapper.agregarTelefono(pCliente.Documento, telefono);
            pCliente.agregarTelefono(telefono);
        }

        public void EliminarTelefono(Cliente pCliente, string pTelefono)
        {
            string telefono = limpiarTelefono(pTelefono);
            if (!pCliente.tieneTelefono(telefono))
            {
                throw new Exception("El cliente no tiene cargado el teléfono " + telefono);
            }
            Mapper.eliminarTelefono(pCliente.Documento, telefono);
            pCliente.borrarTelefono(telefono);
        }

        // Quita guiones, puntos y espacios y controla que sean solo dígitos con el largo que corresponde
        public string NormalizarDocumento(string pDocumento, TipoDocumento pTipo)
        {
            string documento = (pDocumento ?? "").Replace("-", "").Replace(".", "").Replace(" ", "").Trim();

            if (documento.Length == 0)
            {
                throw new Exception("El documento no puede estar vacío");
            }
            if (!soloDigitos.IsMatch(documento))
            {
                throw new Exception("El documento solo puede contener números (sin signos, letras ni exponentes)");
            }
            if (documento.Length > LARGO_MAX_DOCUMENTO)
            {
                throw new Exception($"El documento no puede superar los {LARGO_MAX_DOCUMENTO} dígitos");
            }

            switch (pTipo)
            {
                case TipoDocumento.DNI:
                    if (documento.Length < 6 || documento.Length > 8)
                    {
                        throw new Exception("El DNI debe tener entre 6 y 8 dígitos");
                    }
                    break;
                case TipoDocumento.CUIT:
                case TipoDocumento.CUIL:
                    if (documento.Length != 11)
                    {
                        throw new Exception($"El {pTipo} debe tener 11 dígitos");
                    }
                    break;
                default:
                    throw new Exception("El tipo de documento no es válido");
            }
            return documento;
        }

        public void ValidarEmail(string pEmail)
        {
            if (string.IsNullOrWhiteSpace(pEmail))
            {
                throw new Exception("El email no puede estar vacío");
            }
            if (!formatoEmail.IsMatch(pEmail.Trim()))
            {
                throw new Exception("El email debe tener un formato válido (ej.: nombre@dominio.com)");
            }
        }

        // Acepta formatos como "+54 9 11 5555-1234" o "(011) 4555-1234" y los guarda compactos
        public string NormalizarTelefono(string pTelefono)
        {
            string telefono = limpiarTelefono(pTelefono);

            if (telefono.Length == 0)
            {
                throw new Exception("El teléfono no puede estar vacío");
            }
            if (!formatoTelefono.IsMatch(telefono))
            {
                throw new Exception("El teléfono solo puede contener números y un '+' inicial");
            }
            if (telefono.Length < LARGO_MIN_TELEFONO || telefono.Length > LARGO_MAX_TELEFONO)
            {
                throw new Exception($"El teléfono debe tener entre {LARGO_MIN_TELEFONO} y {LARGO_MAX_TELEFONO} caracteres sin contar espacios ni guiones (ingresado: {telefono})");
            }
            return telefono;
        }

        private string limpiarTelefono(string pTelefono)
        {
            return (pTelefono ?? "").Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace(".", "").Trim();
        }

        private void validarDatosCliente(Cliente pCliente)
        {
            if (!Enum.IsDefined(typeof(TipoDocumento), pCliente.TipoDocumento))
            {
                throw new Exception("El tipo de documento no es válido");
            }
            if (string.IsNullOrWhiteSpace(pCliente.Nombre))
            {
                throw new Exception("El nombre no puede estar vacío");
            }
            if (string.IsNullOrWhiteSpace(pCliente.Apellido))
            {
                throw new Exception("El apellido no puede estar vacío");
            }
            ValidarEmail(pCliente.Email);
            if (string.IsNullOrWhiteSpace(pCliente.DomicilioFacturacion))
            {
                throw new Exception("El domicilio no puede estar vacío");
            }
        }
    }

}
