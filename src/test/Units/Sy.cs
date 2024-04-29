using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyCoTuong.Units
{
    class Sy: Unit
    {
        public Sy(int ID)
        {
            this.int_ID = ID;
            this.int_side = (ID) / 16;
            this.str_name = "Sỹ";
            int x = (ID % 2 == 1) ? 3 : 5;
            int y = (int_side == 0) ? 0 : 9;
            this.pCurrentLocation = new Point(x, y);
            string s = (int_side == 0) ? "do":"den";
            this.img_unitImg = Image.FromFile(GameConstants.Res_UnitImg + "sy" + s + "3.png");
        }
        public override bool checkNextMove(Point currentPos, Point nextPos)
        {
            /*
             * 1. Sỹ có đi đúng quy cách?
             * 2. Sỹ có đi ra ngoài cung?
             * 3. Kiểm tra chung cho tất cả mọi quân cờ
             */

            int x1 = currentPos.X;
            int y1 = currentPos.Y;
            int x2 = nextPos.X;
            int y2 = nextPos.Y;
            //2
            if (Math.Abs(x1 - x2) != 1 || Math.Abs(y1 - y2) != 1) return false;
            //1
            if (int_side == 0)
            {
                if (x2 < 3 || x2 > 5 || y2 > 2) return false;
            }
            else
            {
                if (x2 < 3 || x2 > 5 || y2 < 7) return false;
            }

            //3
            if (Game.isPossed(x2, y2) == int_side) return false;
            if (isAbleToWinFirst(x2, y2)) return true;
            if (isGameLostAfterThisMove(x1, y1, x2, y2)) return false;
            return true;
        }
    }
}
