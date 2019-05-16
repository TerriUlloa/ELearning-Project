using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Exceptions
{
    public class EnrollmentFailedException : Exception
    {

        /// <summary>
        /// Constructor needed to create custom exception
        /// </summary>
        /// <param name="message">Custom error message for the exception</param>
        public EnrollmentFailedException(string message = "") : base(message)
        {

        }
    }
}

