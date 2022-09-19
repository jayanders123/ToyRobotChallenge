using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotApp.Constants.Exceptions
{
    /// <summary>
    /// A custom exception class for defining errors pertaining to Invalid values being passed as a input paremeter
    /// </summary>
    public class ValueNotValidException : Exception
    {
        public ValueNotValidException()
        {
        }

        public ValueNotValidException(string message)
            : base(message)
        {
        }

        public ValueNotValidException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
