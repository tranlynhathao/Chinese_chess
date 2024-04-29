using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyCoTuong.Units
{
    class Tuong: Unit
    {
        public Tuong(int ID)
        {
            this.int_ID = ID;
            this.int_side = (ID) / 16;
            this.str_name = "Tướng";
            int x = 4;
            int y = (int_side == 0) ? 0 : 9;
            this.pCurrentLocation = new Point(x, y);
            string s = (int_side == 0) ? "do":"den";
            this.img_unitImg = Image.FromFile(GameConstants.Res_UnitImg + "tuong" + s + "3.png");
        }
        public override bool checkNextMove(Point currentPos, Point nextPos)
        {
            /* 1. Tướng có đi đúng quy cách?
             * 2. Tướng có ra ngoài cung?
             * 3. Có đi vào vị trí bị chiếu hay không?
             */
            int x1 = currentPos.X;
            int y1 = currentPos.Y;
            int x2 = nextPos.X;
            int y2 = nextPos.Y;
            if (Math.Abs(x1 - x2) + Math.Abs(y1 - y2) != 1) return false;
            if (int_side == 0)
            {
                if (x2 < 3 || x2 > 5 || y2 > 2) return false;
            }
            else
            {
                if (x2 < 3 || x2 > 5 || y2 < 7) return false;
            }
            if (isLoMatTuong(x1, y1, x2, y2)) return false;
            if (Game.isPossed(x2, y2) == int_side) return false;
            if (isAbleToWinFirst(x2, y2)) return true;
            if (isGameLostAfterThisMove(x1, y1, x2, y2)) return false;
            return true;
        }
        public bool isLoMatTuong(int x1, int y1, int x2, int y2)
        {
            int enemyID;
            int onRoad = 0;
            if (int_side == GameConstants.RedSide)
            {
                enemyID = GameConstants.BlackMinimumID;
            }
            else enemyID = GameConstants.RedMinimumID;
            Unit enemyGeneral = Game.unitOnBoard[enemyID];
            if (x2 != enemyGeneral.pCurrentLocation.X) return false;
            else
            {
                int y = enemyGeneral.pCurrentLocation.Y;
                for (int i = Math.Min(y2, y) + 1; i < Math.Max(y2, y); i++)
                {
                    if (Game.int_IDOnCoordinates[x2, i] != -1)
                    {
                        onRoad++;
                    }
                }
            }
            if (onRoad == 0) return true;
            return false;
        }
    }
}
