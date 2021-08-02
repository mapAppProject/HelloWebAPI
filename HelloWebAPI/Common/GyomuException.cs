using System;
using System.Runtime.Serialization;

namespace TM2WEB.Common
{
    public class GyomuException : Exception
    {
        private string v1;
        private int v2;

        public int UserID { get; }

        public GyomuException()
        {
        }

        public GyomuException(string message) : base(message)
        {
        }

        public GyomuException(string v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public GyomuException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GyomuException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}