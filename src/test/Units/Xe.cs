using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyCoTuong.Units
{
    class Xe: Unit
    {
        public Xe(int ID)
        {
            this.int_ID = ID;
            this.int_side = (ID) / 16;
            this.str_name = "Xe";
            int x = (ID % 2 == 1) ? 0 : 8;
            int y = (int_side == 0) ? 0 : 9;
            this.pCurrentLocation = new Point(x, y);
            string s = (int_side == 0) ? "do":"den";
            this.img_unitImg = Image.FromFile(GameConstants.Res_UnitImg + "xe" + s + "3.png");
        }
        public override bool checkNextMove(Point currentPos, Point nextPos)
        {
            /*
             * 1. xe có đi đúng quy cách?
             * 2. xe có bị cản?
             * - Đếm số vật cản (obs)
             * - Nếu có vật cản thì không cho đi!
             */
            int x1 = currentPos.X;
            int y1 = currentPos.Y;
            int x2 = nextPos.X;
            int y2 = nextPos.Y;
            if (x1 != x2 && y1 != y2) return false;
            int obs = obstacle(x1, y1, x2, y2);
            if (obs > 0) return false;
            if (Game.isPossed(x2, y2) == int_side) return false;
            if (isAbleToWinFirst(x2, y2)) return true;
            if (isGameLostAfterThisMove(x1, y1, x2, y2)) return false;
            return true;
        }
        private int obstacle(int x1, int y1, int x2, int y2)
        {
            //Đếm số vật cản từ vị trí hiện tại (x1, y1) đến vị trí đích (x2, y2) (không tính 2 đầu)
            int obstacle = 0;
            if (x1 == x2)
            {
                for (int i = Math.Min(y1, y2) + 1; i < Math.Max(y1, y2); i++)
                {
                    if (Game.isPossed(x2, i) != GameConstants.NeitherSide) obstacle++;
                }

            }
            else if (y1 == y2)
            {
                for (int i = Math.Min(x1, x2) + 1; i < Math.Max(x1, x2); i++)
                {
                    if (Game.isPossed(i, y2) != GameConstants.NeitherSide) obstacle++;
                }
            }
            return obstacle;
        }
    }
}
