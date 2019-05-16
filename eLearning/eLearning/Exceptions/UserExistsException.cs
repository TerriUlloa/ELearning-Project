using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.Exceptions
{
    /// <summary>
        /// Specifies that the desired user does not exist
        /// </summary>
    public class UserExistsException : Exception
    {
            /// <summary>
            /// Constructor needed to create custom exception
            /// </summary>
            /// <param name="message">Custom error message for the exception</param>
            public UserExistsException(string message = "") : base(message)
            {

            }
        }
}
