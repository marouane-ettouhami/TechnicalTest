using System;
using System.Runtime.Serialization;

namespace Sports.Domain.Exceptions
{
    [Serializable]
    public class DataSeedException : Exception
    {
        // <summary>
        /// Default Constructor
        /// </summary>
        public DataSeedException()
        {
        }

        /// <summary>
        /// Constructor with an error message
        /// </summary>
        /// <param name="message"></param>
        public DataSeedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor with innerException
        /// </summary>
        /// <param name="message"></param>
        public DataSeedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Serialization info
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected DataSeedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
