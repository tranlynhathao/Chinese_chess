using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyCoTuong.Units
{
    class Voi: Unit
    {
        public Voi(int ID)
        {
            this.int_ID = ID;
            this.int_side = (ID) / 16;
            this.str_name = "Voi";
            int x = (ID % 2 == 1) ? 2 : 6;
            int y = (int_side == 0) ? 0 : 9;
            this.pCurrentLocation = new Point(x, y);
            string s = (int_side == 0) ? "do":"den";
            this.img_unitImg = Image.FromFile(GameConstants.Res_UnitImg + "voi" + s + "3.png");
        }
        public override bool checkNextMove(Point currentPos, Point nextPos)
         {
             /* 1. Voi có đi đúng quy cách?
              * 2. Voi có bị cản không?
              */
             int x1 = currentPos.X;
             int y1 = currentPos.Y;
             int x2 = nextPos.X;
             int y2 = nextPos.Y;
             if (Math.Abs(x1 - x2) != 2 || Math.Abs(y1 - y2) != 2) return false;
             if (int_side == 0)
             {
                 if (y2 > 4) return false;
             }
             else
             {
                 if (y2 < 5) return false;
             }
             int obs = obstacle(x1, y1, x2, y2);
             if (obs > 0) return false;
             if (Game.isPossed(x2, y2) == int_side) return false;
             if (isAbleToWinFirst(x2, y2)) return true;
             if (isGameLostAfterThisMove(x1, y1, x2, y2)) return false;
             return true;
         }
        private int obstacle(int x1, int y1, int x2, int y2){
            if (Game.isPossed((x1 + x2) / 2, (y1 + y2) / 2) >= 0) return 1;
            return 0;
        }
    }
}
