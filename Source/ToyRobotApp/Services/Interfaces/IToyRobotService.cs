using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotApp.Models;

namespace ToyRobotApp.Services.Interfaces
{
    /// <summary>
    /// This interface contains ToyBot functionality methods for navigating around the board.
    /// </summary>
    public interface IToyRobotService
    {
        /// <summary>
        /// This function carries out all the commands given by the user on the robot. All the commands are executed, as long as none result in the robot falling off the table.
        /// All commands are in string format and parsed accordinly in their respective functions.
        /// </summary>
        /// <param name="robot">The robot that will be moved based on the given commands. Its state is stored in this object to ensure it stays within the bounds.</param>
        /// <param name="commandList">The given list of commands the user submitted.</param>
        /// <returns>NewPlacementResult containing the robots new placement on the board</returns>
        NewPlacementResult ProcessCommands(Robot robot, List<string> commandList);

    }
}
