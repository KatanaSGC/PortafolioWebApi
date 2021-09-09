using Portafolio.WebApi.Entidades.Empleado;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Portafolio.WebApi.Transversal.Expressions
{
    public interface IEmpleadoEx
    {
        Expression<Func<EmpleadoEntidad, bool>> ExEmpleadoPorIdentidad(string identidad);
        Expression<Func<EmpleadoEntidad, bool>> ExEmpleadoPorId(int id);
    }
}
