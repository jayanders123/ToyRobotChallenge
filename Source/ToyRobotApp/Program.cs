using System;
using System.Collections.Generic;
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
            var robotService = new ToyRobotService();
            List<string> commandsGivenByUser = new List<string>();


            //This tracks the position of the robot while app is running.
            Robot toyRobot = new Robot()
            {
                XAxis = 0,
                YAxis = 0,
                DirectionRobotFacing = "NORTH"

            };

            while (applicationIsRunning)
            {
                var isSelectingCommands = true;
                Console.WriteLine("\nHey, I'm your Toy Robot! Your first command needs to be a 'PLACE' before you can do anything else.");
                var placeIsFirstCommand = false;

                while (isSelectingCommands)
                {
                    try
                    {
                        Console.WriteLine("\nEnter your command. If you're finished select 'REPORT'");
                        Console.WriteLine("1 = PLACE 2 = MOVE 3 = LEFT 4 = RIGHT 5 = REPORT");
                        var command = ValidationService.ValidateIfConsoleInputIsInteger(Console.ReadLine());

                        switch (command)
                        {
                            case 1:

                                placeIsFirstCommand = true;
                                commandsGivenByUser.Add(ValidationService.ReadAndValidateUserInput());
                                break;

                            case 2:
                                ValidationService.ValidateFirstCommandIsPlace(placeIsFirstCommand);
                                commandsGivenByUser.Add("MOVE");
                                break;

                            case 3:
                                ValidationService.ValidateFirstCommandIsPlace(placeIsFirstCommand);
                                commandsGivenByUser.Add("LEFT");
                                break;

                            case 4:
                                ValidationService.ValidateFirstCommandIsPlace(placeIsFirstCommand);
                                commandsGivenByUser.Add("RIGHT");
                                break;

                            case 5:

                                toyRobot = robotService.ProcessCommands(toyRobot,commandsGivenByUser).CurrentPosition;

                                Console.WriteLine($"\nOutput({toyRobot.XAxis},{toyRobot.YAxis},{toyRobot.DirectionRobotFacing})\n");

                                isSelectingCommands = false;
                                break;
                        }
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                }

                

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
