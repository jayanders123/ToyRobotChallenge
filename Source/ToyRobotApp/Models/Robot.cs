using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotApp.Models
{
    /// <summary>
    /// A class that represents a robot instance. It contains its placement on the board and direction, forward, the robot is facing.
    /// </summary>
    public class Robot
    {
        public int XAxis { get; set; }
        public int YAxis { get; set; }
        public string DirectionRobotFacing { get; set; }
    }
}
