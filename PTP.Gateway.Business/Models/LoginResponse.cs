using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTP.Gateway.Business.Models
{
    public class LoginResponse
    {
        /// <summary>
        /// JWT token
        /// </summary>
        public string Token { get; set; } = string.Empty;
    }
}
