using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotApp.Models
{
    public class PlacementRequest
    {
        public int XAxis { get; set; }
        public int YAxis { get; set; }
        public string DirectionRobotFacing { get; set; }
    }
}
