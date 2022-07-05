using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaNetCore.RequestModel
{
    public class AlexaRequestValidationError
    {
        public string ErrorMessage { get; set; }
        public AlexaRequestValidationError(string msg)
        {
            ErrorMessage = msg;
        }
    }
}
