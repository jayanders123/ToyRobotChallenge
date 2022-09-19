using System;
using System.Collections.Generic;
using ToyRobotApp.Services;

namespace ToyRobotApp
{
    /// <summary>
    /// This Program.cs file is the entry point of the application. All application logic begins here.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            bool applicationIsRunning = true;
            ToyRobotService toyRobot = new ToyRobotService();

            var xAxisPosition = 0;
            var yAxisPosition = 0;
            var directionRobotIsFacing = "";

            //Initialization of program sets robot in the position 0,0,NORTH
            Dictionary<string,string> robotsCurrentPosition = new Dictionary<string,string>()
            {
                {"x-axis","0"},
                {"y-axis","0"},
                {"directionRobotisFacing","NORTH"}
            };

            //Insertion and validation of the axis values user has selected for the robot to move to
            while (applicationIsRunning)
            {
                Console.WriteLine("Please enter your 'X' position using a NUMBER 0 - 4");
                var input = Convert.ToInt32(Console.ReadLine());

                try
                {
                    xAxisPosition = ValidationService.ValidateAxisGiven(input);

                    Console.WriteLine("Please enter your 'Y' position using a NUMBER 0 - 4");

                    input = Convert.ToInt32(Console.ReadLine());
                    yAxisPosition = ValidationService.ValidateAxisGiven(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                Console.WriteLine("Please enter the direction you'd like to face");
                Console.WriteLine("1 = NORTH, 2 = EAST, 3 = SOUTH, 4 = WEST");

                //Insertion and validation of the direction value the user has selected for the robot to face
                try 
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    directionRobotIsFacing = ValidationService.ValidateDirectionGiven(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                //var tr = toyRobot.MoveRobot(xAxisPosition,yAxisPosition,directionToyIsFacing);

                //Show result
                Console.WriteLine(xAxisPosition + " " + yAxisPosition + " " + directionRobotIsFacing);
                

                Console.WriteLine("Would you like to make another move? Type 'Y' or 'N'.");

                var isUserDecidingNextMove = true;
                while (isUserDecidingNextMove)
                {
                    var callToContinue = Console.ReadLine();

                    if (callToContinue == "y")
                    {
                        isUserDecidingNextMove = false;
                    }
                    else if (callToContinue == "n")
                    {
                        applicationIsRunning = false;
                        break;
                    }
                    //If invalid values are keyed
                    else
                    {
                        Console.WriteLine("Please only enter the value 'Y' or 'N': ");
                        Console.WriteLine("Would you like to make another move?");
                        callToContinue = null;
                    }
                }

            }
        }
    }
}
