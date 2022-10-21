using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AeropuertoG2.Models
{
    public class Aeronave
    {
        public Guid Id { get; set; }
        public string CodAeronave { get; set; }
              
       
        //[Required(ErrorMessage = "La Marca es requerida")]
        [Required]
        [Display(Name = "Marca de la Aeronave")]
        public string Marca { get; set; }

       
        [Required(ErrorMessage = "El Modelo es requerido")]
        [Display(Name = "Modelo de la Aeronave")]
        public string Modelo { get; set; }

        
        [Required(ErrorMessage = "El Nro de asientos es requerido")]
        [Display(Name = "Numero de Asientos")]
        public int NroAsientos { get; set; }


        [Display(Name = "Capacidad de Carga")]
        public decimal CapacidadCarga { get; set; }

        [Display(Name = "Capacidad Tanque de Combustible")]
        public decimal CapTanqueCombustible { get; set; }

        [Display(Name = "Aeropuerto de Estacionamiento")]
        public string AereopuertoEstacionamiento { get; set; }
        public string EstadoAeronave { get; set; }
    }
}


