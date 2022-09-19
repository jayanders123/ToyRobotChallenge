using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotApp.Models;

namespace ToyRobotApp.Services.Interfaces
{
    public interface IToyRobotService
    {
        /// <summary>
        /// This function moves the robot to the users desired position on the board.
        /// </summary>
        /// <param name="x">X-axis  position on the board.</param>
        /// <param name="y">Y-axis position on the board.</param>
        /// <param name="directionFacing">The direction user wants the robot to be facing once placed.</param>
        /// <returns></returns>
        public NewPlacementResult MoveRobot(int x, int y, string directionFacing);

    }
}
