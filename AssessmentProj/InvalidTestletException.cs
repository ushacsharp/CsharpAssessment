using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProj
{
    public class InvalidTestletException : Exception
    {
        public InvalidTestletException(string Testlet)
        : base(String.Format("Invalid Testlet: {0}", Testlet))
        {

        }
    }
}
