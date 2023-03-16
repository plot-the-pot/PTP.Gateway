using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTP.Gateway.Business.Models
{
    public class LoginRequest
    {
        /// <summary>
        /// Account email address
        /// </summary>
        public string EmailAddress { get; set; } = string.Empty;

        /// <summary>
        /// Account password
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
