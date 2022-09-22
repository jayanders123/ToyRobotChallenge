using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotApp.Constants.Exceptions
{
    /// <summary>
    /// A custom exception class for notifying that an move results in the robot being out of bounds.
    /// </summary>
    public class RobotOutOfBoundsException : Exception
    {
        public RobotOutOfBoundsException()
        {
        }

        public RobotOutOfBoundsException(string message)
            : base(message)
        {
        }

        public RobotOutOfBoundsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
