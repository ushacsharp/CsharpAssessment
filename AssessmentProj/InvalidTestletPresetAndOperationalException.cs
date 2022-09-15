using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProj
{
    public  class InvalidTestletPresetAndOperationalException : Exception
    {
        public InvalidTestletPresetAndOperationalException(string Testlet)
        : base(String.Format("Invalid Testlet: {0}", Testlet))
        {

        }
    }
}
