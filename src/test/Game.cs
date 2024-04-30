using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MyCoTuong
{
    class Game
    {
        #region Members

        private PictureBox pbBoard;
        private XqBoard xqBoard;
        private Stack<State> stackOfStates;
        private int redRemainingTime;
        private int blackRemainingTime;
        private bool isGameStart = false;
        public static Unit[] unitOnBoard;
        public static int [,] int_IDOnCoordinates;
        private int int_currentlySelected;
        private int int_turn;

        private bool isPaused = true;
        private bool isEnded = false;
        private int isChecked = GameConstants.NeitherSide;
        private int intWinner;
        private int int_NoOfTurnWithoutUnitLoss;
        private bool isLastMoveInvalid;

        public CoTuongForm MyCoTuongForm;

        public bool IsPaused
        {
            get
            {
                return isPaused;
            }
            private set
            {
                isPaused = value;
            }
        }

        public bool IsEnded
        {
            get
            {
                return isEnded;
            }
            private set
            {
                isEnded = value;
            }
        }

        public int IsChecked
        {
            get
            {
                return isChecked;
            }
            private set
            {
                isChecked = value;
            }
        }

        public int IntWinner
        {
            get
            {
                return intWinner;
            }
            private set
            {
                intWinner = value;
            }
        }

        public int Int_NoOfTurnWithoutUnitLoss
        {
            get
            {
                return int_NoOfTurnWithoutUnitLoss;
            }
            private set
            {
                int_NoOfTurnWithoutUnitLoss = value;
            }
        }

        public bool IsLastMoveInvalid
        {
            get
            {
                return isLastMoveInvalid;
            }
            private set
            {
                isLastMoveInvalid = value;
            }
        }

        public int Int_currentlySelected
        {
            get
            {
                return int_currentlySelected;
            }
            private set
            {
                int_currentlySelected = value;
            }
        }

        public int Int_turn
        {
            get
            {
                return int_turn;
            }
            private set
            {
                int_turn = value;
            }
        }

        public int RedRemainingTime
        {
            get
            {
                return redRemainingTime;
            }
            set
            {
                redRemainingTime = value;
            }
        }

        public int BlackRemainingTime
        {
            get
            {
                return blackRemainingTime;
            }
            set
            {
                blackRemainingTime = value;
            }
        }

        public bool IsGameStart
        {
            get
            {
                return isGameStart;
            }
            private set
            {
                isGameStart = value;
            }
        }
        #endregion

        #region Constructor
        public Game(PictureBox pb, XqBoard board, CoTuongForm ctf)
        {
            this.MyCoTuongForm = ctf;
            this.pbBoard = pb;
            this.xqBoard = board;
            int_IDOnCoordinates = new int[GameConstants.BoardWidth, GameConstants.BoardHeight];
            Int_currentlySelected = GameConstants.Unselected;
            Int_NoOfTurnWithoutUnitLoss = 0;
            IntWinner = GameConstants.NotDetermined;
            IsLastMoveInvalid = false;
            Int_turn = GameConstants.RedSide;

            stackOfStates = new Stack<State>();
            setTimeLimit();
            initUnits();
            saveState();
        }
        #endregion Constructor

        #region Khởi tạo bàn cờ, quân cờ
        public void initUnits()
        {
            initializeUnitOnBoard();

            for (int i = 0; i < GameConstants.BoardWidth; i++)
            {
                for (int j = 0; j < GameConstants.BoardHeight; j++)
                {
                    int_IDOnCoordinates[i, j] = -1;
                }
            }
            for (int i = 0; i < GameConstants.MaximumNumberOfUnits; i++)
            {
                Unit u = unitOnBoard[i];
                int_IDOnCoordinates[u.pCurrentLocation.X, u.pCurrentLocation.Y] = u.int_ID;
            }
        }
        private void initializeUnitOnBoard()
        {
            unitOnBoard = new Unit[GameConstants.MaximumNumberOfUnits];
            for (int i = 0; i <= 1; i++)
            {
                unitOnBoard[0 + 16 * i] = new Units.Tuong(16 * i);
                unitOnBoard[1 + 16 * i] = new Units.Sy(1 + 16 * i);
                unitOnBoard[2 + 16 * i] = new Units.Sy(2 + 16 * i);
                unitOnBoard[3 + 16 * i] = new Units.Voi(3 + 16 * i);
                unitOnBoard[4 + 16 * i] = new Units.Voi(4 + 16 * i);
                unitOnBoard[5 + 16 * i] = new Units.Ma(5 + 16 * i);
                unitOnBoard[6 + 16 * i] = new Units.Ma(6 + 16 * i);
                unitOnBoard[7 + 16 * i] = new Units.Xe(7 + 16 * i);
                unitOnBoard[8 + 16 * i] = new Units.Xe(8 + 16 * i);
                unitOnBoard[9 + 16 * i] = new Units.Phao(9 + 16 * i);
                unitOnBoard[10 + 16 * i] = new Units.Phao(10 + 16 * i);
                for (int j = 1; j <= 5; j++)
                {
                    unitOnBoard[10 + 16 * i + j] = new Units.Tot(10 + 16 * i + j, this);
                }
            }
        }
        #endregion

        #region
        public void handlePickOrDropEvent(MouseEventArgs e)
        {
            Point pInPixel = e.Location;
            Point pInCoordinates = xqBoard.getCoordinatesByLocation(pInPixel);
            if (Int_currentlySelected == GameConstants.Unselected)
            {
                handlePickEvent(pInCoordinates);
            }
            else
            {
                handleDropEventAndCheckGameEnd(pInCoordinates);
            }
        }

        private void handlePickEvent(Point prm_pInCoordinates)
        {
            try
            {
                Unit u = getPickedUnitByCoordinates(prm_pInCoordinates);
                Int_currentlySelected = u.int_ID;
                pbBoard.Invalidate();
            }
            catch (NullReferenceException expNullRef)
            {
                MyCoTuongForm.lbNotificationSetText("Bạn chưa chọn quân cờ");
            }
            catch (Exception e){
                MyCoTuongForm.lbNotificationSetText("Đã có lỗi xảy ra khi chọn quân cờ");
                throw e;
            }
        }

        private void handleDropEventAndCheckGameEnd(Point prm_pInCoordinates)
        {
            processMove(prm_pInCoordinates);
            if (isGameEndByOneSideHasNoMove())
            {
                endGame();
            }
        }

        private void processMove(Point pInCoordinates)
        {
            Unit u = unitOnBoard[Int_currentlySelected];
            if (u.int_side == Int_turn)
            {
                if (u.checkNextMove(u.pCurrentLocation, pInCoordinates))
                {
                    removeOldUnitIfExist(pInCoordinates);
                    updateNewPosition(u, pInCoordinates);
                    updateTurnAndTimer();
                    pbBoard.Invalidate();
                    Int_currentlySelected = GameConstants.Unselected;
                    processChecked();
                    tieCheck();
                    Int_NoOfTurnWithoutUnitLoss++;
                    saveState();
                }
                else notifyInvalidMove();
            }
            else notifyNotYourTurn();
        }
       
        private void removeOldUnitIfExist(Point pInCoordinates)
        {
            int intChecked = int_IDOnCoordinates[pInCoordinates.X, pInCoordinates.Y];
            if (intChecked != GameConstants.Unselected)
            {
                int_IDOnCoordinates[pInCoordinates.X, pInCoordinates.Y] = GameConstants.NoID;
                unitOnBoard[intChecked].bo_isAlive = false;
                Int_NoOfTurnWithoutUnitLoss = 0;
            }
        }

        private void updateNewPosition(Unit u, Point newCoordinates)
        {
            int_IDOnCoordinates[u.pCurrentLocation.X, u.pCurrentLocation.Y] = GameConstants.NoID;
            u.pCurrentLocation = newCoordinates;
            int_IDOnCoordinates[newCoordinates.X, newCoordinates.Y] = u.int_ID;
        }

        private Unit getPickedUnitByCoordinates(Point p)
        {
            int ID = int_IDOnCoordinates[p.X, p.Y];
            try
            {
                return unitOnBoard[ID];
            }
            catch (IndexOutOfRangeException expOutRange)
            {
                MyCoTuongForm.lbNotificationSetText("Không có quân cờ nào ở vị trí này cả");
            }
            catch (Exception exp)
            {
                MyCoTuongForm.lbNotificationSetText("Lỗi khi chọn quân cờ!");
                throw (exp);
            }
            return default(Unit);
        }
        #endregion

        #region
        private void notifyInvalidMove()
        {
            IsLastMoveInvalid = true;
            MyCoTuongForm.lbNotificationSetText("Nước đi không đúng quy cách!");
            IsLastMoveInvalid = false;
            Int_currentlySelected = GameConstants.Unselected;
        }

        private void notifyNotYourTurn()
        {
            IsLastMoveInvalid = true;
            MyCoTuongForm.lbNotificationSetText("Không phải lượt của bạn!");
            IsLastMoveInvalid = false;
            Int_currentlySelected = GameConstants.Unselected;
        }

        private void notifyChecked()
        {
            MyCoTuongForm.lbNotificationSetText("Bạn đang bị chiếu.");
        }
        #endregion

        #region
        public void resumeGame()
        {
            IsPaused = false;
            MyCoTuongForm.buttonPauseSetText("Pause");
            resumeTimer();
        }
        public void pauseGame()
        {
            IsPaused = true;
            MyCoTuongForm.buttonPauseSetText("Resume");
            pauseTimer();
        }
        public void startGame()
        {
            IsGameStart = true;
            IsPaused = false;
            MyCoTuongForm.buttonPauseSetText("Pause");
            setTimeLimit();
            if (Int_turn == GameConstants.RedSide)
                MyCoTuongForm.redTimerStart();
            else MyCoTuongForm.blackTimerStart();
        }
        public void processPauseButton()
        {
            if (!IsGameStart)
                startGame();
            else if (IsPaused)
                resumeGame();
            else if (!IsPaused)
                pauseGame();
        }

        public void resumeTimer()
        {
            if (Int_turn == GameConstants.RedSide)
                MyCoTuongForm.redTimerStart();
            else MyCoTuongForm.blackTimerStart();
        }
        public void pauseTimer()
        {
            if (Int_turn == GameConstants.RedSide)
                MyCoTuongForm.redTimerStop();
            else MyCoTuongForm.blackTimerStop();
        }
        #endregion

        #region
        public bool isGameEndByOneSideHasNoMove()
        {
            bool ended = true;
            int startIndex = GameConstants.BlackMinimumID;
            if (Int_turn == GameConstants.RedSide)
            {
                startIndex = GameConstants.RedMinimumID;
            }
            for (int i = startIndex; i < startIndex + GameConstants.BlackMinimumID; i++){
                if (!unitOnBoard[i].bo_isAlive) continue;
                if (isAbleToMove(unitOnBoard[i])){
                    ended = false;
                }
            }
            return ended;
        }
        
        public bool isAbleToMove(Unit u){
            for (int i = 0; i < GameConstants.BoardWidth; i++){
                for (int j = 0; j < GameConstants.BoardHeight; j++){
                    if (u.checkNextMove(u.pCurrentLocation, new Point(i, j))){
                        return true;
                    }
                }
            }
            return false;
        }
        
        public static bool isGameChecked(int param_side)
        {
            int startIndex = -1;
            Unit uGeneral;
            if (param_side == GameConstants.RedSide)
            {
                startIndex = 16;
                uGeneral = unitOnBoard[GameConstants.RedMinimumID];
            }
            else
            {
                startIndex = 0;
                uGeneral = unitOnBoard[GameConstants.BlackMinimumID];
            }
            for (int i = startIndex; i < startIndex + GameConstants.BlackMinimumID; i++)
            {
                Unit u = unitOnBoard[i];
                if (!u.bo_isAlive) continue;
                if (u.checkNextMove(u.pCurrentLocation, uGeneral.pCurrentLocation))
                {
                    return true;
                }
            }
            return false;
        }

        public void endGame()
        {
            string str_winner;
            //1
            MyCoTuongForm.redTimerStop();
            MyCoTuongForm.blackTimerStop();
            //2
            if (IntWinner == GameConstants.NeitherSide)
            {
                MyCoTuongForm.lbNotificationSetText("Hòa.");
                return;
            }
            IntWinner = nextTurn();
            if (IntWinner == GameConstants.RedSide) str_winner = "Đỏ";
            else str_winner = "Đen";
            //3
            MyCoTuongForm.lbNotificationSetText(str_winner + " thắng.");
            IsEnded = GameConstants.EndState;
        }

        private void processChecked()
        {
            if (isGameChecked(GameConstants.RedSide) || isGameChecked(GameConstants.BlackSide))
            {
                if (isGameChecked(0)) IsChecked = GameConstants.RedSide;
                else IsChecked = GameConstants.BlackSide;
                notifyChecked();
            }
            else IsChecked = GameConstants.NeitherSide;
        }

        private void tieCheck()
        {
            if (Int_NoOfTurnWithoutUnitLoss > GameConstants.MaximumTurnWithoutEaten)
            {
                IntWinner = GameConstants.NeitherSide;
                endGame();
            }
        }
        #endregion

       
        
        
        public static int isPossed(int x, int y)
        {
            try
            {
                if (int_IDOnCoordinates[x, y] == GameConstants.NoID) return GameConstants.NeitherSide;
                else
                {
                    if (int_IDOnCoordinates[x, y] < GameConstants.BlackMinimumID) return GameConstants.RedSide;
                    else return GameConstants.BlackSide;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        #region
        private void saveState(){
            int[] unitPosX = new int[GameConstants.MaximumNumberOfUnits];
            int[] unitPosY = new int[GameConstants.MaximumNumberOfUnits];
            int[,] int_IDOnCoordinates = new int[GameConstants.BoardWidth, GameConstants.BoardHeight];
            saveUnitOnPosXYArray(unitPosX, unitPosY);
            saveOnCoordinatesArray(int_IDOnCoordinates);
            stackOfStates.Push(new State(unitPosX, unitPosY, int_IDOnCoordinates, RedRemainingTime, BlackRemainingTime));
        }

        private void saveOnCoordinatesArray(int[,] arrayToSave)
        {
            for (int i = 0; i < GameConstants.BoardWidth; i++)
            {
                for (int j = 0; j < GameConstants.BoardHeight; j++)
                {
                    arrayToSave[i, j] = int_IDOnCoordinates[i, j];
                }
            }
        }

        private void saveUnitOnPosXYArray(int[] arrayToSaveX, int[] arrayToSaveY)
        {
            for (int i = 0; i < GameConstants.MaximumNumberOfUnits; i++)
            {
                arrayToSaveX[i] = unitOnBoard[i].pCurrentLocation.X;
                arrayToSaveY[i] = unitOnBoard[i].pCurrentLocation.Y;
            }
        }

        public void undo()
        {
            if (stackOfStates.Count > 1)
            {
                stackOfStates.Pop();
                State prevState = stackOfStates.Peek();
                retrieveUnitOnBoard(prevState);
                int_IDOnCoordinates = prevState.intID_onCoordinates;
                retrieveTimers(prevState);
                switchTimer();
                Int_currentlySelected = GameConstants.Unselected;
                pbBoard.Invalidate();
            }
            else
            {
                MyCoTuongForm.lbNotificationSetText("Không thể undo thêm nữa");
            }
        }

        private void retrieveUnitOnBoard(State prevState)
        {
            for (int i = 0; i < GameConstants.MaximumNumberOfUnits; i++)
            {
                unitOnBoard[i].pCurrentLocation.X = prevState.int_unitPosX[i];
                unitOnBoard[i].pCurrentLocation.Y = prevState.int_unitPosY[i];
            }
        }

        private void retrieveTimers(State prevState)
        {
            if (Int_turn == GameConstants.RedSide)
            {
                this.RedRemainingTime = prevState.redTime;
            }
            else
            {
                this.BlackRemainingTime = prevState.blackTime;
            }
            Int_turn = nextTurn();
        }


        #endregion

        #region
        public void setTimeLimit()
        {
            RedRemainingTime = GameConstants.Res_fullTimeAllowedRed;
            BlackRemainingTime = GameConstants.Res_fullTimeAllowedBlack;
        }
        private void switchTimer()
        {
            if (Int_turn == GameConstants.RedSide)
            {
                MyCoTuongForm.redTimerStart();
                MyCoTuongForm.blackTimerStop();
            }
            else
            {
                MyCoTuongForm.redTimerStop();
                MyCoTuongForm.blackTimerStart();
            }
        }
        private void updateTurnAndTimer()
        {
            Int_turn = nextTurn();
            switchTimer();
        }
        private int nextTurn()
        {
            return (Int_turn + 1) % 2;
        }
        #endregion
    }
}
