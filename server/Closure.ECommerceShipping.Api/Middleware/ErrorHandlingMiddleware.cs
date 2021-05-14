using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Closure.ECommerceShipping.Api.Application.Common;
using Microsoft.AspNetCore.Http;
using NewtonsoftJson = Newtonsoft.Json;

namespace Closure.ECommerceShipping.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(HttpStatusCode.NotFound, context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(HttpStatusCode.InternalServerError, context, ex);
            }
            finally
            {
                context.SetEndpoint(null);
            }
        }

        private static Task HandleExceptionAsync(HttpStatusCode code, HttpContext context, Exception ex, IDictionary<string, string[]> errors = null)
        {

            var result = NewtonsoftJson.JsonConvert.SerializeObject(Response.Error(ex.Message, errors));
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}