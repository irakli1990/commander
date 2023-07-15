using System;

namespace Commander.Src.Core.Errors
{
    public class AuthenticationFailure : Failure
    {
        public string _message;

        public AuthenticationFailure(string message)
        {
            _message = message;
        }
    }
}