using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotApp.Models
{
    /// <summary>
    /// A class containg the result for when a Robot has been moved on the board.
    /// </summary>
    public class NewPlacementResult
    {
        public bool Success { get; set; }

        public Robot CurrentPosition { get; set; }
    }
}
