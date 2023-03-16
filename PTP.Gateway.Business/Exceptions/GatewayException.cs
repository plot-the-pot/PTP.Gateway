using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTP.Gateway.Business.Exceptions
{
    public class GatewayException : Exception
    {
        public GatewayException(GatewayExceptionType gatewayExceptionType) 
            :this(gatewayExceptionType.ErrorKey, gatewayExceptionType.ErrorCode, gatewayExceptionType.ErrorSubCode, gatewayExceptionType.ErrorMessage)
        { 
        }

        public GatewayException(GatewayExceptionType gatewayExceptionType, Dictionary<string, string> data)
            : this(gatewayExceptionType.ErrorKey, gatewayExceptionType.ErrorCode, gatewayExceptionType.ErrorSubCode, gatewayExceptionType.ErrorMessage, data)
        {
        }

        public GatewayException(string key, ErrorCodes errorCode, ErrorSubCodes errorSubCode, string message)
            : this(key, errorCode, errorSubCode, message, new Dictionary<string, string>())
        {
        }

        public GatewayException(string key, ErrorCodes errorCode, ErrorSubCodes errorSubCode, string message, Dictionary<string, string> data) 
            : base(message)
        {
            this.ErrorKey = key;
            this.ErrorCode = errorCode;
            this.ErrorSubCode = errorSubCode;
            this.ErrorData = data;
        }

        public string ErrorKey { get; private set; } = string.Empty;  
        public ErrorCodes ErrorCode { get; private set; }
        public ErrorSubCodes ErrorSubCode { get; private set; }
        public Dictionary<string, string> ErrorData { get; private set; }
    }
}
