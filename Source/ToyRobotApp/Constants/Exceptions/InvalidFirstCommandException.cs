using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotApp.Constants.Exceptions
{
    /// <summary>
    /// A custom exception class for defining errors pertaining to a Invalid first command being selected
    /// </summary>
    public class InvalidFirstCommandException : Exception
    {
        public InvalidFirstCommandException()
        {
        }

        public InvalidFirstCommandException(string message)
            : base(message)
        {
        }

        public InvalidFirstCommandException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
