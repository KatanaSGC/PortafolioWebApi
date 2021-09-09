using Portafolio.WebApi.Entidades.Empleado;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portafolio.WebApi.Entidades.Cargo
{
    public class CargoEntidad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public ICollection<EmpleadoEntidad> EmpleadoEntidad { get; set; }
    }
}
