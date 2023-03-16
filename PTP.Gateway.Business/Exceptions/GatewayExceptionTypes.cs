using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTP.Gateway.Business.Exceptions
{
    public class GatewayExceptionType
    {
        internal static GatewayExceptionType InvalidCredentials()
        {
            return new GatewayExceptionType
            {
                ErrorKey = "Login.InvalidCredentials",
                ErrorCode = ErrorCodes.AccountError,
                ErrorSubCode = ErrorSubCodes.InvalidCredentials,
                ErrorMessage = "Invalid credentials."
            };
        }
        public string ErrorKey { get; private set; } = string.Empty;
        public ErrorCodes ErrorCode { get; private set; }
        public ErrorSubCodes ErrorSubCode { get; private set; }
        public string ErrorMessage { get; private set;} = string.Empty;
    }

    public class GatewayExceptionTypes
    {
        public static GatewayExceptionType InvalidCredentials => GatewayExceptionType.InvalidCredentials();
    }
}
