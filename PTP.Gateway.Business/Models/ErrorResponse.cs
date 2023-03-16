using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTP.Gateway.Business.Models
{
    public sealed class ErrorResponse
    {
        public string ErrorCode { get; set; } = string.Empty;
        public string ErrorSubCode { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string TraceId { get; set;} = string.Empty;  
        public string RequestId { get; set;} = string.Empty;    
    }
}
