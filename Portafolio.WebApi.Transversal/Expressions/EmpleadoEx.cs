using Portafolio.WebApi.Entidades.Empleado;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Portafolio.WebApi.Transversal.Expressions
{
    public class EmpleadoEx : IEmpleadoEx
    {
        public Expression<Func<EmpleadoEntidad, bool>> ExEmpleadoPorId(int id)
                    => m => m.Id == id;

        public Expression<Func<EmpleadoEntidad, bool>> ExEmpleadoPorIdentidad(string identidad)
            => m => m.Identificacion == identidad;
    }
}
