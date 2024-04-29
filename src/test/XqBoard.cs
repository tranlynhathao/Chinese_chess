using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MyCoTuong
{
    class XqBoard
    {
        private Pen penRegular, penBold, penExtremelyBold;
        private Brush brushBlack;
        private Point[,] pCoordinates;
        private int int_sLength, intOriginalX, intOriginalY;
        public XqBoard(){
            penRegular = new Pen(Color.Black, GameConstants.Boldness_Regular);
            penBold = new Pen(Color.Black, GameConstants.Boldness_Bold);
            penExtremelyBold = new Pen(Color.Black, GameConstants.Boldness_ExtremelyBold);
            brushBlack = new SolidBrush(Color.Black);
            intOriginalX = GameConstants.PaddingX;
            intOriginalY = GameConstants.PaddingY;
            int_sLength = GameConstants.CellSize;
            pCoordinates = new Point[9, 10];
        }
        public void drawXqBoardAndSetupIntersection(PaintEventArgs e)
        {
            /*Vẽ bàn cờ. Gồm các công việc:
             * 1. Thiết lập tọa độ cho các giao điểm
             * 2. Vẽ các đường
             */
            setCoordinates();
            drawXqBoardLines(e);
            drawLLine(e);
            //drawChineseBoundary(e);

        }
        private void setCoordinates()
        {
            //Đặt tọa độ các giao điểm trên bàn cờ dựa trên tọa độ thực tế.
            for (int i = 0; i < GameConstants.BoardWidth; i++)
            {
                for (int j = 0; j < GameConstants.BoardHeight; j++)
                {
                    pCoordinates[i, j] = new Point(intOriginalX + int_sLength * i, intOriginalY + int_sLength * j);
                }
            }
        }
        private void drawXqBoardLines(PaintEventArgs e)
        {
            //Vẽ các đường trên bàn cờ
            e.Graphics.DrawLine(penRegular, pCoordinates[0, 0], pCoordinates[8, 0]);
            e.Graphics.DrawLine(penRegular, pCoordinates[0, 0], pCoordinates[0, 9]);
            e.Graphics.DrawLine(penRegular, pCoordinates[8, 0], pCoordinates[8, 9]);
            e.Graphics.DrawLine(penRegular, pCoordinates[0, 9], pCoordinates[8, 9]);
            Rectangle rectBoard = new Rectangle(pCoordinates[0, 0].X - 10, pCoordinates[0, 0].Y - 10, int_sLength * 8 + 20,
                int_sLength * 9 + 20);
            e.Graphics.DrawRectangle(penExtremelyBold, rectBoard);

            e.Graphics.DrawLine(penBold, pCoordinates[0, 5], pCoordinates[8, 5]);
            e.Graphics.DrawLine(penBold, pCoordinates[0, 4], pCoordinates[8, 4]);

            e.Graphics.DrawLine(penRegular, pCoordinates[3, 7], pCoordinates[5, 9]);
            e.Graphics.DrawLine(penRegular, pCoordinates[5, 7], pCoordinates[3, 9]);
            e.Graphics.DrawLine(penRegular, pCoordinates[3, 2], pCoordinates[5, 0]);
            e.Graphics.DrawLine(penRegular, pCoordinates[5, 2], pCoordinates[3, 0]);

            for (int i = 0; i < 9; i++)
            {
                e.Graphics.DrawLine(penRegular, pCoordinates[0, i], pCoordinates[8, i]);
            }
            for (int i = 0; i < 8; i++)
            {
                e.Graphics.DrawLine(penRegular, pCoordinates[i, 0], pCoordinates[i, 4]);
                e.Graphics.DrawLine(penRegular, pCoordinates[i, 5], pCoordinates[i, 9]);
            }
        }
        private void drawLLine(PaintEventArgs e)
        {
            //Vẽ các đường chữ L ở vị trí của pháo và tốt
            for (int i = 0; i < 9; i += 2)
            {
                if (i != 0)
                {
                    drawL_left(e, pCoordinates[i, 3]);
                    drawL_left(e, pCoordinates[i, 6]);
                }
                if (i != 8)
                {
                    drawL_right(e, pCoordinates[i, 3]);
                    drawL_right(e, pCoordinates[i, 6]);
                }
                if (i == 0 || i == 6)
                {
                    drawL_left(e, pCoordinates[i + 1, 2]);
                    drawL_right(e, pCoordinates[i + 1, 2]);
                    drawL_left(e, pCoordinates[i + 1, 7]);
                    drawL_right(e, pCoordinates[i + 1, 7]);
                }
            }
        }
        private void drawL_left(PaintEventArgs e,Point p)
        {
            Point A = new Point(p.X - int_sLength / 10, p.Y - int_sLength / 10);
            Point B = new Point(p.X - int_sLength / 10, p.Y + int_sLength / 10);
            e.Graphics.DrawLine(penRegular, A, new Point(A.X - int_sLength / 6, A.Y));
            e.Graphics.DrawLine(penRegular, A, new Point(A.X, A.Y - int_sLength / 6));
            e.Graphics.DrawLine(penRegular, B, new Point(B.X - int_sLength / 6, B.Y));
            e.Graphics.DrawLine(penRegular, B, new Point(B.X, B.Y + int_sLength / 6));
        }
        private void drawL_right(PaintEventArgs e, Point p)
        {
            Point C = new Point(p.X + int_sLength / 10, p.Y - int_sLength / 10);
            Point D = new Point(p.X + int_sLength / 10, p.Y + int_sLength/ 10);
            e.Graphics.DrawLine(penRegular, C, new Point(C.X + int_sLength / 6, C.Y));
            e.Graphics.DrawLine(penRegular, C, new Point(C.X, C.Y - int_sLength / 6));
            e.Graphics.DrawLine(penRegular, D, new Point(D.X + int_sLength / 6, D.Y));
            e.Graphics.DrawLine(penRegular, D, new Point(D.X, D.Y + int_sLength / 6));
        }
        private void drawChineseBoundary(PaintEventArgs e)
        {
            //Viết Sở hà- Hán giới
            string drawString = "楚河        漢界";
            Font drawFont = new Font("細明體_HKSCS", 25, FontStyle.Bold);
            StringFormat drawFormat = new StringFormat();
            e.Graphics.DrawString(drawString, drawFont, brushBlack, pCoordinates[2, 4].X - int_sLength / 3,
                pCoordinates[2, 4].Y + int_sLength / 4, drawFormat);
        }
        public void drawUnits(PaintEventArgs e)
        {
            //Hiện các quân cờ lên bàn cờ.
            for (int i = 0; i < 32; i++)
            {
                Unit u = Game.unitOnBoard[i];
                if (!u.bo_isAlive)
                    continue;
                Point p = u.pCurrentLocation;
                e.Graphics.DrawImage(u.img_unitImg, pCoordinates[p.X, p.Y].X - int_sLength * 3/7, pCoordinates[p.X, p.Y].Y - int_sLength * 3/7);
            }
        }
        public Point getCoordinatesByLocation(Point p)
        {
           //Tìm giao điểm có khoảng cách ngắn nhất tới điểm được click
            double minDistance = 1000000;
            int argminX = -1;
            int argminY = -1;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (distance(pCoordinates[i, j], p) < minDistance)
                    {
                        minDistance = distance(pCoordinates[i, j], p);
                        argminX = i;
                        argminY = j;
                    }
                }
            }
            return new Point(argminX, argminY);
        }
        private double distance(Point p1, Point p2)
        {
            //khoảng cách 2 điểm
            double x1 = p1.X;
            double y1 = p1.Y;
            double x2 = p2.X;
            double y2 = p2.Y;
            return (Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)));
        }
        public void highlightSelectedUnit(PaintEventArgs e, int selectedID, Color color)
        {
            //Tìm tọa độ quân cờ cần highlight rồi highlight
            Unit u = Game.unitOnBoard[selectedID];
            Point p = u.pCurrentLocation;
            int x = pCoordinates[p.X, p.Y].X;
            int y = pCoordinates[p.X, p.Y].Y;
            Rectangle rec = new Rectangle(x - int_sLength * 5 / 9, y - int_sLength * 5 / 9, int_sLength * 9 / 8, int_sLength * 9 / 8);
            e.Graphics.FillEllipse(new SolidBrush(color), rec);
        }
        public void highlightAvailableMove(PaintEventArgs e, int selectedID, Color color, int alpha)
        {
            //Highlight các vị trí có thể đi được
            Unit u = Game.unitOnBoard[selectedID];
            for (int i = 0; i < GameConstants.BoardWidth; i++)
            {
                for (int j = 0; j < GameConstants.BoardHeight; j++)
                {
                    if (u.checkNextMove(u.pCurrentLocation, new Point(i, j)))
                    {
                        highlightOnPosition(e, pCoordinates[i, j].X, pCoordinates[i, j].Y, Color.FromArgb(alpha, 152, 251, 152));
                    }
                }
            }
        }
        private void highlightOnPosition(PaintEventArgs e, int x, int y, Color color)
        {
            //Highlight 1 vị trí nào đó bởi 1 màu nào đó
            Rectangle rec = new Rectangle(x - int_sLength * 3 / 9, y - int_sLength * 3 / 9, int_sLength * 5 / 8, int_sLength * 5 / 8);
            e.Graphics.FillEllipse(new SolidBrush(color), rec);
        }
    }
}
