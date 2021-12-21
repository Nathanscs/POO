using System.Net;
using Microsoft.AspNetCore.Mvc;
using Poo.Api.Controllers.Contracts;

namespace Poo.Api.Controllers.Extensions
{
    public static class ResponseExtensionMethod
    {
        public static IActionResult AsResponse(this object data, HttpStatusCode statusCode)
        {
            return new ObjectResult(new ResponseDto(data))
            {
                StatusCode = (int) statusCode
            };
        }
    }
}