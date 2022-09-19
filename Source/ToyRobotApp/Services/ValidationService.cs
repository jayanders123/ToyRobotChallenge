using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotApp.Constants;
using ToyRobotApp.Constants.Exceptions;

namespace ToyRobotApp.Services
{
    public static class ValidationService
    {
        public static int ValidateAxisGiven(int axis)
        {
            if (axis < 0 || axis > 4)
            {
               throw new ValueNotValidException("Please use a number in the correct range");
            }
            return axis;
        }

        public static string ValidateDirectionGiven(int direction)
        {
            if (direction < 1 || direction > 4)
            {
                throw new ValueNotValidException("Please use a number in the correct range");
            }

            Directions result = (Directions)direction;
            return result.ToString();
        }
    }
}
