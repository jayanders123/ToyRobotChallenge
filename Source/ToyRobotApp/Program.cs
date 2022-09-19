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

            //Initialization of program sets robot in the position 0,0,NORTH
            Dictionary<string,string> robotsCurrentPosition = new Dictionary<string,string>()
            {
                {"x-axis","0"},
                {"y-axis","0"},
                {"directionRobotisFacing","NORTH"}
            };

            while (applicationIsRunning)
            {
                Console.WriteLine("Please enter your 'X' position using a number 0 - 4");
                try
                {
                    xAxisPosition = HelperService.ValidateXAxisGiven(Convert.ToInt32(Console.ReadLine()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Use a number, not a letter. Try again");
                    continue;
                }



                
                Console.WriteLine("Please enter your 'Y' position");

                var yAxisPosition = Console.ReadLine();
                //if (!int.TryParse(yAxisPosition, out num))
                //{
                    Console.WriteLine("Please use a number when choosing your X position.");
                    continue;
                //}
                

                Console.WriteLine("Please enter the direction you'd like to face");
                var directionToyIsFacing = Console.ReadLine();

                //var tr = toyRobot.MoveRobot(xAxisPosition,yAxisPosition,directionToyIsFacing);

                //Show result
                Console.WriteLine(xAxisPosition + " " + yAxisPosition + " " + directionToyIsFacing);
                

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
