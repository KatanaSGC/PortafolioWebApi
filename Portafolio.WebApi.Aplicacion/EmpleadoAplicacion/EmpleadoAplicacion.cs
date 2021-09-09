using AutoMapper;
using Portafolio.WebApi.Entidades.Empleado;
using Portafolio.WebApi.PersistenciaDatos.Repository;
using Portafolio.WebApi.Transversal.DTO;
using Portafolio.WebApi.Transversal.Expressions;
using Portafolio.WebApi.Transversal.Respuesta;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Portafolio.WebApi.Aplicacion.EmpleadoAplicacion
{
    public class EmpleadoAplicacion : IEmpleadoAplicacion
    {
        private readonly IRepository repository;
        private readonly IEmpleadoEx expresiones;
        private readonly IMapper mapper;

        public EmpleadoAplicacion(IRepository repository,
                                  IEmpleadoEx expresiones,
                                  IMapper mapper)
        {
            this.repository = repository;
            this.expresiones = expresiones;
            this.mapper = mapper;
        }

        public async Task<RespuestaDTO<bool>> CrearEmpleado(CrearEmpleadoDTO crearEmpleadoDTO)
        {
            var respuesta = new RespuestaDTO<bool>();
            try
            {
                var validarIdentidad = await repository.FindByEx(expresiones.ExEmpleadoPorIdentidad(crearEmpleadoDTO.Identificacion));
                if (validarIdentidad != null)
                {
                    respuesta.Codigo = HttpStatusCode.BadRequest;
                    respuesta.Mensaje = "Ya se ha registrado un empleado con la identidad ingresada";
                    return respuesta;
                }

                var crearEmpleado = mapper.Map<EmpleadoEntidad>(crearEmpleadoDTO);
                crearEmpleado.Estado = true;
                await repository.CreatedAsync(crearEmpleado);

                respuesta.Entidad = true;
                respuesta.Codigo = HttpStatusCode.Created;
                respuesta.Mensaje = "Se ha registrado el usuario";
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Codigo = HttpStatusCode.InternalServerError;
                respuesta.Mensaje = "Ocurrio un error interno";
                respuesta.Exception = e.Message;
                return respuesta;
            }
        }

        public async Task<RespuestaDTO<bool>> EditarEmpleado(EditarEmpleadoDTO editarEmpleadoDTO)
        {
            var respuesta = new RespuestaDTO<bool>();
            try
            {
                var validarEmpleado = await repository.FindByEx(expresiones.ExEmpleadoPorId(editarEmpleadoDTO.Id));
                if (validarEmpleado == null)
                {
                    respuesta.Codigo = HttpStatusCode.BadRequest;
                    respuesta.Mensaje = "No se encontro información del empleado";
                    return respuesta;
                }

                var editarEmpleado = mapper.Map<EmpleadoEntidad>(editarEmpleadoDTO);

                await repository.UpdateAsync(editarEmpleado, validarEmpleado);

                respuesta.Entidad = true;
                respuesta.Codigo = HttpStatusCode.OK;
                respuesta.Mensaje = "Se edito la información del empleado con éxito";
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Codigo = HttpStatusCode.InternalServerError;
                respuesta.Mensaje = "Ocurrio un error interno";
                respuesta.Exception = e.Message;
                return respuesta;
            }
        }

        public async Task<RespuestaDTO<bool>> EditarEstadoEmpleado(int id)
        {
            var respuesta = new RespuestaDTO<bool>();
            try
            {
                var validarEmpleado = await repository.FindByEx(expresiones.ExEmpleadoPorId(id));
                if (validarEmpleado == null)
                {
                    respuesta.Codigo = HttpStatusCode.BadRequest;
                    respuesta.Mensaje = "No se encontro información del empleado";
                    return respuesta;
                }

                var editarEmpleado = validarEmpleado;
                editarEmpleado.Estado = !editarEmpleado.Estado;

                await repository.UpdateAsync(editarEmpleado, validarEmpleado);

                respuesta.Entidad = true;
                respuesta.Codigo = HttpStatusCode.OK;
                respuesta.Mensaje = "Se edito el estado del empleado con éxito";
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Codigo = HttpStatusCode.InternalServerError;
                respuesta.Mensaje = "Ocurrio un error interno";
                respuesta.Exception = e.Message;
                return respuesta;
            }
        }

        public async Task<RespuestaDTO<ObtenerEmpleadoDTO>> ObtenerEmpleado(int id)
        {
            var respuesta = new RespuestaDTO<ObtenerEmpleadoDTO>();
            try
            {
                var obtenerEmpleado = await repository.FindByEx(expresiones.ExEmpleadoPorId(id));
                if (obtenerEmpleado == null)
                {
                    respuesta.Codigo = HttpStatusCode.BadRequest;
                    respuesta.Mensaje = "No se encontro información del empleado";
                    return respuesta;
                }

                var empleado = mapper.Map<ObtenerEmpleadoDTO>(obtenerEmpleado);

                respuesta.Entidad = empleado;
                respuesta.Codigo = HttpStatusCode.OK;
                respuesta.Mensaje = "Se cargo la información";
                return respuesta;
            }
            catch (System.Exception ex)
            {
                respuesta.Codigo = HttpStatusCode.InternalServerError;
                respuesta.Mensaje = "Ocurrio un error interno";
                respuesta.Exception = ex.Message;
                return respuesta;
            }
        }

        public async Task<RespuestaDTO<IEnumerable<ObtenerEmpleadoDTO>>> ObtenerEmpleados()
        {
            var respuesta = new RespuestaDTO<IEnumerable<ObtenerEmpleadoDTO>>();
            try
            {
                var obtenerEmpleados = await repository.GetAll<EmpleadoEntidad>();
                if (obtenerEmpleados == null)
                {
                    respuesta.Codigo = HttpStatusCode.BadRequest;
                    respuesta.Mensaje = "No se encontro información";
                    return respuesta;
                }
                var empleados = mapper.Map<IEnumerable<ObtenerEmpleadoDTO>>(obtenerEmpleados);

                respuesta.Entidad = empleados;
                respuesta.Mensaje = "Se cargo la información";
                respuesta.Codigo = HttpStatusCode.OK;
                return respuesta;
            }
            catch (System.Exception ex)
            {
                respuesta.Codigo = HttpStatusCode.InternalServerError;
                respuesta.Mensaje = "Ocurrio un error interno";
                respuesta.Exception = ex.Message;
                return respuesta;
            }
        }
    }
}
