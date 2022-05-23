using System;
using System.Runtime.Serialization;

namespace Sports.Domain.Exceptions
{
    [Serializable]
    public class DbException : Exception
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public DbException()
        {
        }

        /// <summary>
        /// Constructor with an error message
        /// </summary>
        /// <param name="message"></param>
        public DbException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor with innerException
        /// </summary>
        /// <param name="message"></param>
        public DbException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Serialization info
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected DbException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
