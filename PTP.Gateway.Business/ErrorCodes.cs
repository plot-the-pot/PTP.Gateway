using PTP.Gateway.Business.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTP.Gateway.Business
{
    public enum ErrorCodes
    {
        [HttpStatusCode(System.Net.HttpStatusCode.BadRequest)]
        GenericFailure = -1,

        AccountError = 1000
    }

    public enum ErrorSubCodes
    {
        // Account Errors
        [HttpStatusCode(System.Net.HttpStatusCode.BadRequest)]
        InvalidEmailAddress = 1001,

        [HttpStatusCode(System.Net.HttpStatusCode.BadRequest)]
        InvalidPasswordFormat = 1002,

        [HttpStatusCode(System.Net.HttpStatusCode.Unauthorized)]
        InvalidCredentials = 1003
    }    
}
