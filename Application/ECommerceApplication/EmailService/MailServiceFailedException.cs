using System;
using System.Runtime.Serialization;

namespace ECommerceWeb.Pages
{
    [Serializable]
    public class MailServiceFailedException : Exception
    {
        public MailServiceFailedException()
        {
        }

        public MailServiceFailedException(string message) : base(message)
        {
        }

        public MailServiceFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MailServiceFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}