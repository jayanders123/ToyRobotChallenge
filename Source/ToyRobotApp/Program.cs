using System;
using System.Collections.Generic;
using System.Linq;
using ToyRobotApp.Models;
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
            ToyRobotService toyRobotService = new ToyRobotService();

            var xAxisPosition = 0;
            var yAxisPosition = 0;
            var directionRobotIsFacing = "";



            while (applicationIsRunning)
            {
                //Initialization of program sets robot in the position 0,0,NORTH
                Robot toyRobot = new Robot();

                try
                {
                    var nextSelectedRobotPosition = ValidationService.ValidateUserInput();

                    xAxisPosition = Int32.Parse(nextSelectedRobotPosition["xAxis"]);
                    yAxisPosition = Int32.Parse(nextSelectedRobotPosition["xAxis"]);
                    directionRobotIsFacing = nextSelectedRobotPosition["directionRobotIsFacing"];

                    toyRobotService.MoveRobot(xAxisPosition,yAxisPosition,directionRobotIsFacing);
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
