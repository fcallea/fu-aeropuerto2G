using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace AeropuertoG2.Models
{
    public class AsignacionTripulacionViewModel
    {
        public Guid idTripulacion { get; set; }
        public Guid tripulacionGuid { get; set; }
        public string tripulacionNombre { get; set; }
        public int tripulacionEstado { get; set; }
    }
}