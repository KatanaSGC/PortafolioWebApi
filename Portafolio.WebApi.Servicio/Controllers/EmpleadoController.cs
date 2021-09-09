using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portafolio.WebApi.Aplicacion.EmpleadoAplicacion;
using Portafolio.WebApi.Transversal.DTO;
using Portafolio.WebApi.Transversal.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portafolio.WebApi.Servicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoAplicacion empleadoAplicacion;

        public EmpleadoController(IEmpleadoAplicacion empleadoAplicacion)
        {
            this.empleadoAplicacion = empleadoAplicacion;
        }

        [HttpGet("obtener-empleado/{id}")]
        public async Task<RespuestaDTO<ObtenerEmpleadoDTO>> ObtenerEmpleado(int id)
            => await empleadoAplicacion.ObtenerEmpleado(id);

        [HttpGet("obtener-empleados")]
        public async Task<RespuestaDTO<IEnumerable<ObtenerEmpleadoDTO>>> ObtenerEmpleados()
            => await empleadoAplicacion.ObtenerEmpleados();

        [HttpPost("crear-empleado")]
        public async Task<RespuestaDTO<bool>> CrearEmpleado(CrearEmpleadoDTO crearEmpleadoDTO)
            => await empleadoAplicacion.CrearEmpleado(crearEmpleadoDTO);

        [HttpPut("editar-empleado")]
        public async Task<RespuestaDTO<bool>> EditarEmpleado(EditarEmpleadoDTO editarEmpleadoDTO)
            => await empleadoAplicacion.EditarEmpleado(editarEmpleadoDTO);

        [HttpPut("editar-empleado-estado/{id}")]
        public async Task<RespuestaDTO<bool>> EditarEstadoEmpleado(int id)
            => await empleadoAplicacion.EditarEstadoEmpleado(id);
    }
}
