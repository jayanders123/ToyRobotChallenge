using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotApp.Models
{
    public class NewPlacementResult
    {
        public bool Success { get; set; }

        public Robot PreviousPosition {get; set;}

        public Robot CurrentPosition { get; set; }
    }
}
