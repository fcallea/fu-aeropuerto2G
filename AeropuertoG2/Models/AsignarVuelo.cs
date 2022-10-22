using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace AeropuertoG2.Models
{
    public class principales
    {
        public AsignacionTripulacionViewModel AsignacionTripulacionViewModel { get; set; }
        public AsignarVueloAeronaveModel AsignarVueloAeronaveModel { get; set; }
        public AsignarDestinosVueloModel AsignarDestinosVueloModel { get; set; }
    }

    public class AsignacionTripulacionViewModel
    {
        public Guid idTripulacion { get; set; }
        public Guid tripulacionGuid { get; set; }
        public string tripulacionNombre { get; set; }
        public int tripulacionEstado { get; set; }
    }

    public class AsignarVueloAeronaveModel
    {
        public Guid Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int NroAsientos { get; set; }
        public string EstadoAeronave { get; set; }
        public string Comentario { get; set; }
        public string AeronaveNombre { get; set; }

    }

    public class AsignarDestinosVueloModel
    {
        public Guid Id { get; set; }
        public string DepartamentoOrigen { get; set; }
        public Guid IdAeropuertoOrigen { get; set; }
        public string NombreAeropuertoOrigen { get; set; }
        public string DepartamentoDestino { get; set; }
        public Guid IdAeropuertoDestino { get; set; }
        public string NombreAeropuertoDestino { get; set; }
        public string DestinoVueloNombre { get; set; }
    }
}