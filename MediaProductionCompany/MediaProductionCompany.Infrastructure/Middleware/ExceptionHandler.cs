using MediaProductionCompany.Core.Exceptions;
using MediaProductionCompany.Core.ViewModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Infrastructure.Middleware
{
    public class ExceptionHandler
    {

        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public static async Task Invoke(HttpContext context)
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature.Error;
            var response = new APIResponseVM();

            switch (exception)
            {
                case InvalidUsernameException userNameNotFound:
                    response.Message = userNameNotFound.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case NotFoundException notFound:
                    response.Message = notFound.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    response.Message = "Exception!!!!!!!!!!";
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(
                JsonConvert.SerializeObject(response)
            );
        }
    }
}
