using System;

namespace applestore.Utilities.Exceptions
{
    public class AppleException : Exception {
        public AppleException() {}

        public AppleException(string message) : base(message) {}

        public AppleException(string message, Exception inner) : base(message, inner) {}
    }
}