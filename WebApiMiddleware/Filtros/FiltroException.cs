using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace WebApiMiddleware.Filtros
{
    public class FiltroException :ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //Control global de excepciones
            //Analiza la excepción y personaliza el mensaje de error.
            //Puede aquí también agregar excepciones personalizadas y nopropias del framework

            HttpStatusCode status = HttpStatusCode.InternalServerError;
            String message = String.Empty;
            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                message = "Acceso no autorizado!";
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                message = "Atención: Error en el servidor!";
                status = HttpStatusCode.NotImplemented;
            }
            else if (exceptionType == typeof(NullReferenceException))
            {
                message = "Valor nulo o desconocido!";
                status = HttpStatusCode.InternalServerError;
            }
            else
            {
                message = context.Exception.Message;
                status = HttpStatusCode.NotFound;
            }
            context.ExceptionHandled = true;
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            var err = message + " " + context.Exception.StackTrace;
            response.WriteAsync(err);
        }


    }
}
