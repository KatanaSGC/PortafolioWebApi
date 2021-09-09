using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Portafolio.WebApi.Transversal.Respuesta
{
    public class RespuestaDTO<T>
    {
        public T Entidad { get; set; }
        public HttpStatusCode Codigo { get; set; }
        public string Mensaje { get; set; }
        public String Exception { get; set; }
    }
}
