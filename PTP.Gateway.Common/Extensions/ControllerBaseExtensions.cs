using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTP.Gateway.Common.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static ObjectResult Created(this ControllerBase controllerBase)
        {
            var objectResult = new ObjectResult(null);

            objectResult.StatusCode = StatusCodes.Status201Created;

            return objectResult;
        }

        public static ObjectResult Created(this ControllerBase controllerBase, object obj)
        {
            var objectResult = new ObjectResult(obj);

            objectResult.StatusCode = StatusCodes.Status201Created;

            return objectResult;
        }
    }
}
