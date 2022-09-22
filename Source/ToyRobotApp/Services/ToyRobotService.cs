using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotApp.Models;
using ToyRobotApp.Services.Interfaces;

namespace ToyRobotApp.Services
{
    /// <summary>
    /// This class file contains all of the ToyBot functionality methods for navigating around the board.
    /// </summary>
    public class ToyRobotService : IToyRobotService
    {
        private Robot PositionTrackingRobot { get; set; }

        public ToyRobotService()
        {
            this.PositionTrackingRobot = PositionTrackingRobot;
        }

        /// <summary>
        /// This function carries out all the commands given by the user on the robot. All the commands are executed, as long as none result in the robot falling off the table.
        /// All commands are in string format and parsed accordinly in their respective functions.
        /// </summary>
        /// <param name="robot">The robot that will be moved based on the given commands. Its state is stored in this object to ensure it stays within the bounds.</param>
        /// <param name="commandList">The given list of commands the user submitted.</param>
        /// <returns>NewPlacementResult containing the robots new placement on the board</returns>
        public NewPlacementResult ProcessCommands(Robot robot, List<string> commandList)
        {
            PositionTrackingRobot = robot;

            foreach(string command in commandList)
            {
                try
                {
                    if (command.Contains("PLACE"))
                    {
                        PositionTrackingRobot = PlaceRobot(command).CurrentPosition;
                    }
                    else if (command == "MOVE")
                    {
                        MoveRobot();
                    }
                    else if (command == "LEFT")
                    {
                        TurnLeft();
                    }
                    else if (command == "RIGHT")
                    {
                        TurnRight();
                    }

                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            return new NewPlacementResult { CurrentPosition = PositionTrackingRobot, Success = true };
        }

        /// <summary>
        /// This function moves the robot to the users desired position on the board.
        /// </summary>
        /// <param name="x">X-axis  position on the board.</param>
        /// <param name="y">Y-axis position on the board.</param>
        /// <param name="directionFacing">The direction user wants the robot to be facing once placed.</param>
        /// <returns>NewPlacementResult, containing the position of the robot after the placemnt by this function.</returns>
        private NewPlacementResult PlaceRobot(string command)
        {
            var interpretedCommand = command.Remove(0,7).Split(",");

            PositionTrackingRobot.XAxis = Int32.Parse(interpretedCommand[0]);
            PositionTrackingRobot.YAxis = Int32.Parse(interpretedCommand[1]);
            PositionTrackingRobot.DirectionRobotFacing = interpretedCommand[2];

            return new NewPlacementResult { CurrentPosition = PositionTrackingRobot, Success = true};
        }

        /// <summary>
        /// This function moves the robot 1 space forward.
        /// </summary>
        /// <returns></returns>
        private NewPlacementResult MoveRobot()
        {
            Dictionary<string, int> draftPlacement = new Dictionary<string, int>()
            {
                {"x",PositionTrackingRobot.XAxis },
                {"y",PositionTrackingRobot.YAxis}
            };

            switch (PositionTrackingRobot.DirectionRobotFacing)
            {
                case "NORTH":
                    draftPlacement["y"] += 1;
                    break;
                case "EAST":
                    draftPlacement["x"] += 1;
                    break;
                case "SOUTH":
                    draftPlacement["x"] -= 1;
                    break;
                case "WEST":
                    draftPlacement["x"] -= 1;
                    break;
            }

            if (ValidationService.ValidateIfMoveIsWithinBounds(draftPlacement) == true)
            {
                PositionTrackingRobot.XAxis = draftPlacement["x"];
                PositionTrackingRobot.YAxis = draftPlacement["y"];

                return new NewPlacementResult { CurrentPosition = PositionTrackingRobot, Success = true };
            }
            else
            {

                return new NewPlacementResult { CurrentPosition = null, Success = false };
            }
        }

        /// <summary>
        /// This function rotates the robot LEFT. Its outcome depends on the direction it was initally facing before the operation.
        /// </summary>
        /// <returns></returns>
        private void TurnLeft()
        {
            switch (PositionTrackingRobot.DirectionRobotFacing)
            {
                case "NORTH":
                    PositionTrackingRobot.DirectionRobotFacing = "WEST";
                    break;
                case "EAST":
                    PositionTrackingRobot.DirectionRobotFacing = "NORTH";
                    break;
                case "SOUTH":
                    PositionTrackingRobot.DirectionRobotFacing = "EAST";
                    break;
                case "WEST":
                    PositionTrackingRobot.DirectionRobotFacing = "SOUTH";
                    break;
            }
        }


        /// <summary>
        /// This function rotates the robot RIGHT. Its outcome depends on the direction it was initally facing before the operation.
        /// </summary>
        /// <returns></returns>
        private void TurnRight()
        {
            switch (PositionTrackingRobot.DirectionRobotFacing)
            {
                case "NORTH":
                    PositionTrackingRobot.DirectionRobotFacing = "EAST";
                    break;
                case "EAST":
                    PositionTrackingRobot.DirectionRobotFacing = "SOUTH";
                    break;
                case "SOUTH":
                    PositionTrackingRobot.DirectionRobotFacing = "WEST";
                    break;
                case "WEST":
                    PositionTrackingRobot.DirectionRobotFacing = "NORTH";
                    break;
            }
        }
    }
}
