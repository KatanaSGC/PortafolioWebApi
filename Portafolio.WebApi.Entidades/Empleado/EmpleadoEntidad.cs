using Portafolio.WebApi.Entidades.Cargo;
using Portafolio.WebApi.Entidades.Departamento;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portafolio.WebApi.Entidades.Empleado
{
    public class EmpleadoEntidad
    {
        [Key]
        public int Id { get; set; }
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
        public bool Estado { get; set; }
        public int DepartamentoEntidadId { get; set; }
        public DepartamentoEntidad DepartamentoEntidad { get; set; }
        public int CargoEntidadId { get; set; }
        public CargoEntidad CargoEntidad { get; set; }
    }
}
