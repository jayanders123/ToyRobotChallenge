using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotApp.Constants;
using ToyRobotApp.Constants.Exceptions;
using ToyRobotApp.Models;

namespace ToyRobotApp.Services
{
    public static class ValidationService
    {
        private static int xAxisPosition { get; set; }
        private static int yAxisPosition { get; set; }
        private static string directionRobotIsFacing { get; set; }


        public static Dictionary<string,string> ValidateUserInput()
        {
            Console.WriteLine("Please enter your 'X' position using a NUMBER 0 - 4");
            var input = Convert.ToInt32(Console.ReadLine());

            try
            {
                //Insertion and validation of the axis values user has selected for the robot to move to
                xAxisPosition = ValidateAxisGiven(input);

                Console.WriteLine("Please enter your 'Y' position using a NUMBER 0 - 4");

                input = Convert.ToInt32(Console.ReadLine());
                yAxisPosition = ValidateAxisGiven(input);
            }
            catch (Exception ex)
            {
                throw new ValueNotValidException(ex.Message);
            }
            Console.WriteLine("Please enter the direction you'd like to face");
            Console.WriteLine("1 = NORTH, 2 = EAST, 3 = SOUTH, 4 = WEST");

            //Insertion and validation of the direction value the user has selected for the robot to face
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
                directionRobotIsFacing = ValidateDirectionGiven(input);

                Dictionary<string, string> validInputs = new Dictionary<string, string>()
                {
                    {"xAxis", xAxisPosition.ToString() },
                    {"yAxis", yAxisPosition.ToString() },
                    {"directionRobotIsFacing", directionRobotIsFacing }
                };

                return validInputs;
            }
            catch (Exception ex)
            {
                throw new ValueNotValidException(ex.Message);
            }  
        }

        private static int ValidateAxisGiven(int axis)
        {
            if (axis < 0 || axis > 4)
            {
               throw new ValueNotValidException("Please use a number in the correct range");
            }
            return axis;
        }

        private static string ValidateDirectionGiven(int direction)
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
