using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace AeropuertoG2.Models
{
    public class TripulacionViewModel
    {
        public Guid tripulacionGuid { get; set; }
        public int tripulacionId { get; set; }
        
        [Required]
        [Display(Name = "Nombre de la Tripulacion")]
        public string tripulacionNombre { get; set; }
        
        public int tripulacionEstado { get; set; }

        //public int TripulacionId { get; set; }
        public Guid IntegrantesGuid { get; set; }

    
        public int IntegranteId { get; set; }
        [Required]
        [Display(Name = "Nombre Completo")]
        public string IntegranteNombre { get; set; }
        [Display(Name = "Cargo")]
        public int CargoId { get; set; }
    }
}