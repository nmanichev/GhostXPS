using System;
using System.Runtime.Serialization;

namespace GhostXPS
{
    /// <summary>
    /// XPS converter exception.
    /// </summary>
    public class XpsConverterException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XpsConverterException"/> class.
        /// </summary>
        public XpsConverterException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XpsConverterException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public XpsConverterException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XpsConverterException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception <see cref="Exception"/>.</param>
        public XpsConverterException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XpsConverterException"/> class.
        /// </summary>
        /// <param name="info">Serialization information <see cref="SerializationInfo"/>.</param>
        /// <param name="context">Streaming context <see cref="StreamingContext"/>.</param>
        protected XpsConverterException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
