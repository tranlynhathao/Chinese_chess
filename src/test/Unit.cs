using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MyCoTuong
{
    abstract class Unit
    {
        public int int_ID;
        //Each unit on boards have a unique ID (0-31)

        public int int_side; 
        //0: red, 1: black
        
        public string str_name;

        public Point pCurrentLocation;
        //represent the location (by coordinates) on board

        public bool bo_isAlive = true;
        //TRUE: alive, FALSE: dead

        public Image img_unitImg;
        //Image displayed on board

        private int int_oldUnitID = GameConstants.NoID;

        public virtual bool checkNextMove(Point currentPos, Point nextPos)
        {
            return true;
        }
        protected bool isGameLostAfterThisMove(int x1, int y1, int x2, int y2)
        {
            temporarilyPut(x1, y1, x2, y2);
            if (Game.isGameChecked(int_side))
            {
                rollBack(x1, y1, x2, y2);
                return true;
            }
            else rollBack(x1, y1, x2, y2);
            return false;
        }
        protected void temporarilyPut(int x1, int y1, int x2, int y2)
        {

            int_oldUnitID = Game.int_IDOnCoordinates[x2, y2];
            if (int_oldUnitID != -1)
            {
                Game.unitOnBoard[int_oldUnitID].bo_isAlive = false;
            }

            Game.int_IDOnCoordinates[x1, y1] = GameConstants.NoID;
            this.pCurrentLocation = new Point(x2, y2);

            Game.int_IDOnCoordinates[x2, y2] = this.int_ID;
        }
        protected void rollBack(int x1, int y1, int x2, int y2)
        {
            this.pCurrentLocation = new Point(x1, y1);
            Game.int_IDOnCoordinates[x1, y1] = this.int_ID;
            Game.int_IDOnCoordinates[x2, y2] = int_oldUnitID;
            if (int_oldUnitID != GameConstants.NoID)
                Game.unitOnBoard[int_oldUnitID].bo_isAlive = true;
            int_oldUnitID = GameConstants.NoID;
        }
        public bool isAbleToWinFirst(int x2, int y2)
        {
            Unit u;
            if (this.int_side == 0) u = Game.unitOnBoard[GameConstants.BlackMinimumID];
            else u = Game.unitOnBoard[GameConstants.RedMinimumID];
            if (u.pCurrentLocation.X == x2 && u.pCurrentLocation.Y == y2) return true;
            return false;
        }
    }
}
