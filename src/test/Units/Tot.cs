using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyCoTuong.Units
{
    class Tot: Unit
    {
        public Tot(int ID, Game g)
        {
            this.int_ID = ID;
            this.int_side = (ID) / 16;
            this.str_name = "Tốt";
            int x = -1;

            //Có 5 con tốt. Tốt này ở vị trí nào?
            switch (ID % 16)
            {
                case 11:
                    x = 0;
                    break;
                case 12:
                    x = 2;
                    break;
                case 13:
                    x = 4;
                    break;
                case 14:
                    x = 6;
                    break;
                case 15:
                    x = 8;
                    break;
            }
            int y = (int_side == 0) ? 3 : 6;
            this.pCurrentLocation = new Point(x, y);
            string s = (int_side == 0) ? "do":"den";
            this.img_unitImg = Image.FromFile(GameConstants.Res_UnitImg + "tot" + s + "3.png");
        }
        public override bool checkNextMove(Point currentPos, Point nextPos)
        {
            /*1. Tốt có đi đúng quy cách?
             *2. Kiểm tra chung cho mọi quân cờ
             */
            //1
            int x1 = currentPos.X;
            int y1 = currentPos.Y;
            int x2 = nextPos.X;
            int y2 = nextPos.Y;
            //1
            if (int_side == 0)
            {
                if (y1 < 5) // Khi còn ở sân mình
                {
                    if (x2 != x1 || y2 != (y1 + 1)) return false; // Không tiến lên trước là sai!
                }
                else //Khi đã sang sông
                {
                    bool moveVertically = ((y1 == y2) && Math.Abs(x1 - x2) == 1);
                    bool moveHorizontally = ((y2 == y1 + 1) && (x1 == x2));
                    if (!moveVertically && !moveHorizontally)
                        return false;
                }
            }
            else
            {
                if (y1 > 4) // Khi còn ở sân mình
                {
                    if (x2 != x1 || y2 != (y1 - 1)) return false; // Không tiến lên trước là sai!
                }
                else //Khi đã sang sông
                {
                    bool moveVertically = ((y1 == y2) && Math.Abs(x1 - x2) == 1);
                    bool moveHorizontally = ((y2 == y1 - 1) && (x1 == x2));
                    if (!moveVertically && !moveHorizontally)
                        return false;
                }
            }
            //2
            if (Game.isPossed(x2, y2) == int_side) return false;
            if (isAbleToWinFirst(x2, y2)) return true;
            if (isGameLostAfterThisMove(x1, y1, x2, y2)) return false;
            return true;
        }
    }
}
