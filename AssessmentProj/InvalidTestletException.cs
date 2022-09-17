using System;

namespace AssessmentProj
{
    public class InvalidTestletException : Exception
    {
        public InvalidTestletException(string message)
        : base($"Invalid Testlet: {message}")
        {

        }
    }
}
