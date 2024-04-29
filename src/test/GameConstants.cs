using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MyCoTuong
{
    public static class GameConstants
    {
        #region Translator
        private static int redSide = 0;
        private static int blackSide = 1;
        private static int neitherSide = -1;
        private static int notDetermined = -3;
        private static int timeCoTieuChuan = 3600;
        private static int timeCoNhanh = 1500;
        private static int timeCoChopRed = 360;
        private static int timeCoChopBlack = 240;
        private static int timeGiaoHuu = -1;
        private static bool opt_ChoPhepUndo = true;
        private static bool opt_KhongChoPhepUndo = false;
        private static int typeCoTieuChuan = 1;
        private static int typeCoNhanh = 2;
        private static int typeCoChop = 3;
        private static int typeGiaoHuu = 4;
        private static int unselected = -1; //quy ước không chọn là -1.
        private static int noID = -1;
        #endregion


        #region Graphics
        private static int boldness_Regular = 2;
        private static int boldness_Bold = 3;
        private static int boldness_ExtremelyBold = 5;
        private static int cellSize = 65;
        private static int paddingX = 30;
        private static int paddingY = 35;
        #endregion

        #region Game Status And Resources
        private static int res_fullTimeAllowedRed = 3600;
        private static int res_fullTimeAllowedBlack = 3600;
        private static bool res_undoAllowance = true;
        private static int res_gameType = 1;

        private static bool endState = true;
        private static int boardWidth = 9;
        private static int boardHeight = 10;
        private static int maximumNumberOfUnits = 32;
        private static int maximumTurnWithoutEaten = 50;
        private static int redMinimumID = 0;
        private static int blackMinimumID = 16;
        private static int lbRedTimer_Y = 8;
        private static int lbBlackTimer_Y = 68;
        private static string res_UnitImg = Path.Combine(Environment.CurrentDirectory, @"units3\");
        #endregion
        #region Properties
        public static int RedSide
        {
            get
            {
                return redSide;
            }
        }
        public static int BlackSide
        {
            get
            {
                return blackSide;
            }
        }

        public static int NeitherSide
        {
            get
            {
                return neitherSide;
            }
        }

        public static int NotDetermined
        {
            get
            {
                return notDetermined;
            }
        }

        public static int TimeCoTieuChuan
        {
            get
            {
                return timeCoTieuChuan;
            }
        }

        public static int TimeCoNhanh
        {
            get
            {
                return timeCoNhanh;
            }
        }

        public static int TimeCoChopRed
        {
            get
            {
                return timeCoChopRed;
            }
        }

        public static int TimeCoChopBlack
        {
            get
            {
                return timeCoChopBlack;
            }
        }

        public static int TimeGiaoHuu
        {
            get
            {
                return timeGiaoHuu;
            }
        }

        public static bool Opt_ChoPhepUndo
        {
            get
            {
                return opt_ChoPhepUndo;
            }
        }

        public static bool Opt_KhongChoPhepUndo
        {
            get
            {
                return opt_KhongChoPhepUndo;
            }
        }

        public static int TypeCoTieuChuan
        {
            get
            {
                return typeCoTieuChuan;
            }
        }

        public static int TypeCoNhanh
        {
            get
            {
                return typeCoNhanh;
            }
        }

        public static int TypeCoChop
        {
            get
            {
                return typeCoChop;
            }
        }

        public static int TypeGiaoHuu
        {
            get
            {
                return typeGiaoHuu;
            }
        }

        public static int Unselected
        {
            get
            {
                return unselected;
            }
        }

        public static int NoID
        {
            get
            {
                return noID;
            }
        }

        public static int Boldness_Regular
        {
            get
            {
                return boldness_Regular;
            }

            set
            {
                boldness_Regular = value;
            }
        }

        public static int Boldness_Bold
        {
            get
            {
                return boldness_Bold;
            }

            set
            {
                boldness_Bold = value;
            }
        }

        public static int Boldness_ExtremelyBold
        {
            get
            {
                return boldness_ExtremelyBold;
            }

            set
            {
                boldness_ExtremelyBold = value;
            }
        }

        public static int CellSize
        {
            get
            {
                return cellSize;
            }

            set
            {
                cellSize = value;
            }
        }

        public static int PaddingX
        {
            get
            {
                return paddingX;
            }

            set
            {
                paddingX = value;
            }
        }

        public static int PaddingY
        {
            get
            {
                return paddingY;
            }

            set
            {
                paddingY = value;
            }
        }

        public static int Res_fullTimeAllowedRed
        {
            get
            {
                return res_fullTimeAllowedRed;
            }

            set
            {
                res_fullTimeAllowedRed = value;
            }
        }

        public static int Res_fullTimeAllowedBlack
        {
            get
            {
                return res_fullTimeAllowedBlack;
            }

            set
            {
                res_fullTimeAllowedBlack = value;
            }
        }

        public static bool Res_undoAllowance
        {
            get
            {
                return res_undoAllowance;
            }

            set
            {
                res_undoAllowance = value;
            }
        }

        public static int Res_gameType
        {
            get
            {
                return res_gameType;
            }

            set
            {
                res_gameType = value;
            }
        }

        public static bool EndState
        {
            get
            {
                return endState;
            }

            set
            {
                endState = value;
            }
        }

        public static int BoardWidth
        {
            get
            {
                return boardWidth;
            }

            set
            {
                boardWidth = value;
            }
        }

        public static int BoardHeight
        {
            get
            {
                return boardHeight;
            }

            set
            {
                boardHeight = value;
            }
        }

        public static int MaximumNumberOfUnits
        {
            get
            {
                return maximumNumberOfUnits;
            }

            set
            {
                maximumNumberOfUnits = value;
            }
        }

        public static int MaximumTurnWithoutEaten
        {
            get
            {
                return maximumTurnWithoutEaten;
            }

            set
            {
                maximumTurnWithoutEaten = value;
            }
        }

        public static int RedMinimumID
        {
            get
            {
                return redMinimumID;
            }

            set
            {
                redMinimumID = value;
            }
        }

        public static int BlackMinimumID
        {
            get
            {
                return blackMinimumID;
            }

            set
            {
                blackMinimumID = value;
            }
        }

        public static int LbRedTimer_Y
        {
            get
            {
                return lbRedTimer_Y;
            }

            set
            {
                lbRedTimer_Y = value;
            }
        }

        public static int LbBlackTimer_Y
        {
            get
            {
                return lbBlackTimer_Y;
            }

            set
            {
                lbBlackTimer_Y = value;
            }
        }

        public static string Res_UnitImg
        {
            get
            {
                return res_UnitImg;
            }

            set
            {
                res_UnitImg = value;
            }
        }
        #endregion
    }
}
