using Portafolio.WebApi.Transversal.DTO;
using Portafolio.WebApi.Transversal.Respuesta;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Portafolio.WebApi.Aplicacion.EmpleadoAplicacion
{
    public interface IEmpleadoAplicacion
    {
        Task<RespuestaDTO<ObtenerEmpleadoDTO>> ObtenerEmpleado(int id);
        Task<RespuestaDTO<IEnumerable<ObtenerEmpleadoDTO>>> ObtenerEmpleados();
        Task<RespuestaDTO<bool>> CrearEmpleado(CrearEmpleadoDTO crearEmpleadoDTO);
        Task<RespuestaDTO<bool>> EditarEmpleado(EditarEmpleadoDTO editarEmpleadoDTO);
        Task<RespuestaDTO<bool>> EditarEstadoEmpleado(int id);
    }
}
