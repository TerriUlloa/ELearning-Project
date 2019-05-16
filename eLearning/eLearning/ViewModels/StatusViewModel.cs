using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Models
{
   
        public enum eStatus
        {
            Unknown = 0,
            Error = 1,
            Success = 2
        }

        public class StatusViewModel
        {
            public string Status { get; }
            public string Message { get; }

            public StatusViewModel(eStatus status, string message = "Your looking good!")
            {
                Status = status.ToString();
                Message = message;
            }
        }
}
