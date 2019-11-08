using System;

namespace DDDTW.SharedModules.BaseClasses
{
    public class BaseException : Exception
    {
        private readonly string source;
        private readonly Enum errorCode;
        private readonly string errorMsg;

        public BaseException(string source, Enum errorCode, string errorMsg = null, Exception inner = null)
            : base(errorMsg, inner)
        {
            this.source = source;
            this.errorCode = errorCode;
            this.errorMsg = errorMsg;
        }

        public override string Message => $"Code: {this.source}-{this.errorCode}, Message: {this.errorMsg}";
    }
}