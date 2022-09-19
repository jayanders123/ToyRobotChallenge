using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotApp.Services
{
    public static class HelperService
    {
        public static int ValidateXAxisGiven(int x)
        {
            if (x < 0 || x > 4)
            {
                throw 
            }
            return x;
        }

        public static int ValidateYAxisGiven(int y)
        {
            return y;
        }

    }
}
