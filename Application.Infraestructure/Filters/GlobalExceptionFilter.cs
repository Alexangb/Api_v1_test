using Application.Core.Exeptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Application.Infraestructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType()==typeof(BussinesExceptions))
            {
                var exception=(BussinesExceptions)context.Exception;
                var validation = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = exception.Message,
                };
                var json = new
                {
                    erros = new[] { validation }
                };
                context.Result = BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
                

            }
        }

        private IActionResult BadRequestObjectResult(object json)
        {
            throw new NotImplementedException();
        }
    }
}
