using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portafolio.WebApi.Transversal.DTO
{
    public class CrearEmpleadoDTO
    {
        [Required]
        [MaxLength(15)]
        public string PrimerNombre { get; set; }
        [MaxLength(15)]
        public string SegundoNombre { get; set; }
        [Required]
        [MaxLength(15)]
        public string PrimerApellido { get; set; }
        [MaxLength(15)]
        public string SegundoApellido { get; set; }
        [MaxLength(20)]
        public string Identificacion { get; set; }
        public int DepartamentoEntidadId { get; set; }
        public int CargoEntidadId { get; set; }
    }
}
