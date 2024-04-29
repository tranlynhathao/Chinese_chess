using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyCoTuong.Units
{
    class Ma: Unit
    {
        public Ma(int ID)
        {
            this.int_ID = ID;
            this.int_side = (ID) / 16;
            this.str_name = "Mã";
            int x = (ID % 2 == 1) ? 1 : 7;
            int y = (int_side == 0) ? 0 : 9;
            this.pCurrentLocation = new Point(x, y);
            string s = (int_side == 0) ? "do":"den";
            this.img_unitImg = Image.FromFile(GameConstants.Res_UnitImg + "ma" + s + "3.png");
        }
        public override bool checkNextMove(Point currentPos, Point nextPos)
        {
            /*Gồm các bước:
             * 1. Kiểm tra xem mã đi có đúng đường không?
             * 2. Kiểm tra xem mã có bị chặn không?
             * 3. Kiểm tra xem mã có ăn quân bên mình không?
             * 3'. Kiểm tra xem có đi ra ngoài hay không?
             * 4. Kiểm tra xem tướng có nguy hiểm hay không?
             */
            int x1 = currentPos.X;
            int y1 = currentPos.Y;
            int x2 = nextPos.X;
            int y2 = nextPos.Y;
            //1
            //
            int s = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
            int d = Math.Abs(Math.Abs(x1 - x2) - Math.Abs(y1 - y2));
            if (s != 3 || d != 1)
                return false;
            //2
            if (isBlockedHorse(x1, y1, x2, y2)) return false;
            //3
            if (Game.isPossed(x2, y2) == int_side) return false;
            //4
            if (isAbleToWinFirst(x2, y2)) return true;
            if (isGameLostAfterThisMove(x1, y1, x2, y2)) return false;
            return true;
        }
        public bool isBlockedHorse(int x1, int y1, int x2, int y2)
        {
            if (Math.Abs(x1 - x2) == 1)
            {
                if (y2 > y1)
                {
                    if (Game.isPossed(x1, y1 + 1) == int_side) return true;
                }
                else if (Game.isPossed(x1, y1 - 1) != GameConstants.NeitherSide) return true;
            }
            else if (Math.Abs(y1 - y2) == 1)
            {
                if (x2 > x1)
                {
                    if (Game.isPossed(x1 + 1, y1) == int_side) return true;
                }
                else if (Game.isPossed(x1 - 1, y1) != GameConstants.NeitherSide) return true;
            }
            return false;
        }
    }
}
