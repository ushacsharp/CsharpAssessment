using System;

namespace AssessmentProj
{
    public  class InvalidTestletPresetAndOperationalException : Exception
    {
        public InvalidTestletPresetAndOperationalException(string message)
        : base($"Invalid Testlet: {message}")
        {

        }
    }
}
