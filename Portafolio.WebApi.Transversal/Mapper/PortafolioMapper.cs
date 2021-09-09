using AutoMapper;
using Portafolio.WebApi.Entidades.Empleado;
using Portafolio.WebApi.Transversal.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portafolio.WebApi.Transversal.Mapper
{
    public class PortafolioMapper : Profile
    {
        public PortafolioMapper()
        {
            CreateMap<EmpleadoEntidad, CrearEmpleadoDTO>().ReverseMap();
            CreateMap<EmpleadoEntidad, EditarEmpleadoDTO>().ReverseMap();
            CreateMap<EmpleadoEntidad, ObtenerEmpleadoDTO>().ReverseMap();
        }
    }
}
