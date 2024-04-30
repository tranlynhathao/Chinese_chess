using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCoTuong
{
    public partial class CoTuongForm : Form
    {
        #region Members
        private Game game;
        private XqBoard xqBoard;
        #endregion


        #region private Methods

        private string fromSecondsToMinutes(int seconds)
        {
            int mins = seconds / 60;
            int secs = seconds % 60;
            return mins.ToString() + " : " + secs.ToString();
        }
        private void highlightCurrentlySelected(PaintEventArgs e)
        {
            if (game.Int_currentlySelected != GameConstants.Unselected)
            {
                xqBoard.highlightSelectedUnit(e, game.Int_currentlySelected, Color.FromArgb(200, 255, 215, 0));
            }
        }
        private void highlightAvailableMove(PaintEventArgs e)
        {
            if (game.Int_currentlySelected != GameConstants.Unselected)
            {
                xqBoard.highlightAvailableMove(e, game.Int_currentlySelected, Color.Gold, 150);
            }
        }
        private void highlightUnitIfInvalid(PaintEventArgs e)
        {
            if (game.IsLastMoveInvalid)
            {
                xqBoard.highlightSelectedUnit(e, game.Int_currentlySelected, Color.IndianRed);
            }
        }
        private void highlightGeneralIfChecked(PaintEventArgs e)
        {
            if (game.IsChecked != GameConstants.NeitherSide)
            {
                xqBoard.highlightSelectedUnit(e, 16 * game.IsChecked, Color.Orange);
            }
        }
        private void prepareBoard(PaintEventArgs e)
        {
            Point startPoint = new Point(0, 0);
            xqBoard.drawXqBoardAndSetupIntersection(e);
        }
        private void prepareNotificationLabel()
        {
            /*1. Set lbNotification transparent over its picturebox holder
             *2. Set coordinates for lbNotification
             *3. Make it wraps text (if needed)
             */
            //1
            lbNotification.Parent = pbNotification;
            lbNotification.BackColor = Color.Transparent;
            //2
            lbNotification.Location = new Point(18, 18);
            //3
            lbNotification.MaximumSize = new Size(300, 100);
            lbNotification.AutoSize = true;
        }
        private void prepareTimerLabel(Label l, int y)
        {
            //Make timer label transparent over its picturebox holder and set location for it.
            int x = 8;
            l.Parent = pbTime;
            l.BackColor = Color.Transparent;
            l.Location = new Point(x, y);
        }
        private void makeButtonCompletelyTransparent(Button bt)
        {
            bt.FlatAppearance.BorderSize = 0;
            bt.FlatAppearance.MouseDownBackColor = Color.Transparent;
            bt.FlatAppearance.MouseOverBackColor = Color.Transparent;
            bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        }
        #endregion
        public CoTuongForm()
        {
            InitializeComponent();
            xqBoard = new XqBoard();

            game = new Game(pbBoard, xqBoard, this);

            //Event initialization
            pbBoard.Paint += new PaintEventHandler(pbBoard_Paint);
            pbBoard.MouseDown += new MouseEventHandler(pbBoard_MouseDown);
            this.FormClosing += formClosing;


            //Prepare controls
            makeButtonCompletelyTransparent(btPauseResume);
            makeButtonCompletelyTransparent(btOptions);
            makeButtonCompletelyTransparent(btNewGame);
            makeButtonCompletelyTransparent(btUndo);

            prepareNotificationLabel();
            prepareTimerLabel(lbRedTimer, GameConstants.LbRedTimer_Y);
            prepareTimerLabel(lbBlackTimer, GameConstants.LbBlackTimer_Y);
        }
        #region Events Region

        private void pbBoard_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                prepareBoard(e);
                highlightCurrentlySelected(e);
                highlightUnitIfInvalid(e);
                highlightGeneralIfChecked(e);
                if (game.IsPaused == false)
                    xqBoard.drawUnits(e);
                highlightAvailableMove(e);
            }
            catch (Exception exp)
            {
                lbNotificationSetText("Đã có lỗi xảy ra khi vẽ bảng! Tên lỗi: " + exp.ToString());
                throw;
            }
        }

        private void pbBoard_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (game.IsGameStart && !game.IsEnded && !game.IsPaused)
                {
                    game.handlePickOrDropEvent(e);
                }
            }
            catch (Exception exp)
            {
                lbNotificationSetText("Đã có lỗi xảy ra khi click chuột! Tên lỗi: " + exp.ToString());
                throw;
            }
        }

        private void redTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (GameConstants.Res_gameType != GameConstants.TypeGiaoHuu)
                {
                    if (game.RedRemainingTime > 0)
                    {
                        game.RedRemainingTime--;
                        lbRedTimer.Text = "Red: " + fromSecondsToMinutes(game.RedRemainingTime);
                    }
                    else game.endGame();
                }
            }
            catch (Exception exp)
            {
                lbNotificationSetText("Đã có lỗi xảy ra đối với đồng hồ 1! Tên lỗi: " + exp.ToString());
                throw;
            }
        }
        private void blackTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (GameConstants.Res_gameType != GameConstants.TypeGiaoHuu)
                {
                    if (game.BlackRemainingTime > 0)
                    {
                        game.BlackRemainingTime--;
                        lbBlackTimer.Text = "Black: " + fromSecondsToMinutes(game.BlackRemainingTime);
                    }
                    else
                    {
                        game.endGame();
                    }
                }
            }
            catch (Exception exp)
            {
                lbNotificationSetText("Đã có lỗi xảy ra đối với đồng hồ 2! Tên lỗi: " + exp.ToString());
                throw;
            }
        }
        private void btPauseResume_Click(object sender, EventArgs e)
        {
            try
            {
                game.processPauseButton();
            }
            catch (Exception exp)
            {
                lbNotificationSetText("Đã có lỗi xảy ra với nút Pause/Resume. Tên lỗi: " + exp.ToString());
                throw;
            }
        }
        private void btOptions_Click(object sender, EventArgs e)
        {
            try
            {
                OptionsForm of = new OptionsForm();
                of.Show();
            }
            catch (Exception exp)
            {
                lbNotificationSetText("Đã có lỗi xảy ra với nút Options! Tên lỗi: " + exp.ToString());
                throw;
            }
        }

        private void btNewGame_Click(object sender, EventArgs e)
        {
            try
            {
                game = new Game(pbBoard, xqBoard, this);
                buttonPauseSetText("Pause");
                game.startGame();
            }
            catch (Exception exp)
            {
                lbNotificationSetText("Đã có lỗi xảy ra với nút New Game! Tên lỗi: " + exp.ToString());
                throw;
            }
        }

        private void btUndo_Click(object sender, EventArgs e)
        {
            try
            {
                if (GameConstants.Res_undoAllowance == GameConstants.Opt_ChoPhepUndo)
                {
                    game.undo();
                    btUndo.ForeColor = Color.Black;
                }
                else btUndo.ForeColor = Color.Gray;
            }
            catch (Exception exp)
            {
                lbNotificationSetText("Đã có lỗi xảy ra với nút Undo! Tên lỗi: " + exp.ToString());
                throw;
            }
        }

        #endregion

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                System.Windows.Forms.Application.Exit();
            }
            catch (Exception exp)
            {
                lbNotificationSetText("Đã có lỗi xảy ra khi đóng form! Tên lỗi: " + exp.ToString());
                throw;
            }
        }

        private void CoTuongForm_Load(object sender, EventArgs e)
        {

        }


        #region called from Game
        public void lbNotificationSetText(string s)
        {
            lbNotification.ResetText();
            lbNotification.Text = s;
            pbBoard.Invalidate();
        }
        public void buttonPauseSetText(string s)
        {
            btPauseResume.ResetText();
            btPauseResume.Text = s;
            pbBoard.Invalidate();
        }
        public void redTimerStart()
        {
            redTimer.Start();
        }
        public void blackTimerStart()
        {
            blackTimer.Start();
        }
        public void redTimerStop()
        {
            redTimer.Stop();
        }
        public void blackTimerStop()
        {
            blackTimer.Stop();
        }
        #endregion
    }
}
