using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyCoTuong
{
    class State
    {
        public int[] int_unitPosX;
        public int[] int_unitPosY;
        public int[,] intID_onCoordinates;
        public int redTime;
        public int blackTime;
        public State(int[] uX, int[] uY, int[,] ioc, int redTime, int blackTime)
        {
            this.int_unitPosX = uX;
            this.int_unitPosY = uY;
            this.intID_onCoordinates = ioc;
            this.redTime = redTime;
            this.blackTime = blackTime;
        }
    }
}
