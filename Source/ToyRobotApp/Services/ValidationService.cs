using System;
using System.Collections.Generic;
using ToyRobotApp.Constants;
using ToyRobotApp.Constants.Exceptions;

namespace ToyRobotApp.Services
{
    /// <summary>
    /// This class contains all the functions related to validating user input and board positions before a new move is processed
    /// </summary>
    public static class ValidationService
    {
        private static int xAxisPosition { get; set; }
        private static int yAxisPosition { get; set; }
        private static string directionRobotIsFacing { get; set; }

        /// <summary>
        /// This function handles and orchestrates the users input when selecting a 'PLACE'.
        /// </summary>
        /// <returns>A string containing the coordinates selected by the user.</returns>
        public static string ReadAndValidateUserInput()
        {
            var input = 0;

            var isChoosingXPosition = true;
            while (isChoosingXPosition)
            {
                try
                {
                    Console.WriteLine("\nPlease enter your 'X' position using a NUMBER 0 - 4");
                    input = ValidateIfConsoleInputIsInteger(Console.ReadLine());

                    xAxisPosition = ValidateAxisGiven(input);
                    isChoosingXPosition = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

            }

            var isChoosingY = true;
            while (isChoosingY)
            {
                try
                {
                    Console.WriteLine("\nPlease enter your 'Y' position using a NUMBER 0 - 4");
                    input = ValidateIfConsoleInputIsInteger(Console.ReadLine());

                    yAxisPosition = ValidateAxisGiven(input);
                    isChoosingY = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            var isChoosingDirection = true;
            while (isChoosingDirection)
            {
                try
                {
                    Console.WriteLine("\nPlease enter the direction you'd like to face");
                    Console.WriteLine("\n1 = NORTH, 2 = EAST, 3 = SOUTH, 4 = WEST");
                    input =ValidateIfConsoleInputIsInteger(Console.ReadLine());


                    directionRobotIsFacing = ValidateDirectionGiven(input);
                    isChoosingDirection = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            return $"PLACE, {xAxisPosition},{yAxisPosition},{directionRobotIsFacing}";
        }

        /// <summary>
        /// This function validates whether the user inputs a number, as prompted, during command selection.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>A integer representing the command/axis selected.</returns>
        public static int ValidateIfConsoleInputIsInteger(string input)
        {
            if (!Int32.TryParse(input.ToString(), out int num))
            {
                throw new ValueNotValidException("\nPlease use a Number, as stated, to choose your next move.");
            }
            else
            {
                return Int32.Parse(input);
            }
        }

        /// <summary>
        /// This functions checks whether a MOVE command will result in the Robot falling off the board.
        /// If the robot does as a result, the move will not be processed.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns>True if the move is valid, if not, it simply doesnt process.</returns>
        public static bool ValidateIfMoveIsWithinBounds(Dictionary<string, int> currentPosition)
        {
            var xPosition = currentPosition["x"];
            var yPosition = currentPosition["y"];


            if (xPosition < 0 || xPosition > 4 || yPosition < 0 || yPosition > 4)
            {
                throw new RobotOutOfBoundsException("The move chosen will cause the robot to fall off the table. Choose another...");
            }

            return true;
        }

        /// <summary>
        /// This function checks to see if the first user command, during command selection, is a PLACE.
        /// </summary>
        /// <param name="validator"></param>
        /// <returns>True if the a PLACE commands has first occurred, if not, an error is thrown.</returns>
        public static bool ValidateFirstCommandIsPlace(bool validator)
        {
            if (validator == true)
            {
                return true;
            }
            else
            {
                throw new InvalidFirstCommandException("Please ensure your first command is a 'PLACE' command");
            }
        }

        /// <summary>
        /// This function validates whether the axis given is within the valid range.
        /// </summary>
        /// <param name="axis"></param>
        /// <returns>The integer value back if valid, if not, an error is thrown.</returns>
        private static int ValidateAxisGiven(int axis)
        {
            if (axis < 0 || axis > 4)
            {
                throw new ValueNotValidException("Please use a number in the correct range");
            }
            return axis;
        }

        /// <summary>
        /// This function validates the value given by the user to select the direction they would like the robot to face.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns>The relative string value if valid, if not, an error is thrown.</returns>
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
