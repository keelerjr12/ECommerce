using System;
using System.Runtime.Serialization;

namespace ECommerceData.User
{
    [Serializable]
    internal class UserInfoInvalidException : Exception
    {
        public UserInfoInvalidException()
        {
        }

        public UserInfoInvalidException(string message) : base(message)
        {
        }

        public UserInfoInvalidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserInfoInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}