using System;
using System.Collections.Generic;
using System.Text;

namespace Portafolio.WebApi.Transversal.DTO
{
    public class ObtenerEmpleadoDTO
    {
        public int Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Identificacion { get; set; }
        public int DepartamentoEntidadId { get; set; }
        public int CargoEntidadId { get; set; }
    }
}
