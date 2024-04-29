namespace MyCoTuong
{
    partial class CoTuongForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbBoard = new System.Windows.Forms.PictureBox();
            this.redTimer = new System.Windows.Forms.Timer(this.components);
            this.blackTimer = new System.Windows.Forms.Timer(this.components);
            this.lbRedTimer = new System.Windows.Forms.Label();
            this.lbBlackTimer = new System.Windows.Forms.Label();
            this.lbNotification = new System.Windows.Forms.Label();
            this.btPauseResume = new System.Windows.Forms.Button();
            this.pbNotification = new System.Windows.Forms.PictureBox();
            this.btOptions = new System.Windows.Forms.Button();
            this.pbTime = new System.Windows.Forms.PictureBox();
            this.btNewGame = new System.Windows.Forms.Button();
            this.btUndo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNotification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTime)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBoard
            // 
            this.pbBoard.BackColor = System.Drawing.Color.Transparent;
            this.pbBoard.Location = new System.Drawing.Point(12, 42);
            this.pbBoard.Name = "pbBoard";
            this.pbBoard.Size = new System.Drawing.Size(583, 674);
            this.pbBoard.TabIndex = 0;
            this.pbBoard.TabStop = false;
            // 
            // redTimer
            // 
            this.redTimer.Interval = 1000;
            this.redTimer.Tick += new System.EventHandler(this.redTimer_Tick);
            // 
            // blackTimer
            // 
            this.blackTimer.Interval = 1000;
            this.blackTimer.Tick += new System.EventHandler(this.blackTimer_Tick);
            // 
            // lbRedTimer
            // 
            this.lbRedTimer.AutoSize = true;
            this.lbRedTimer.BackColor = System.Drawing.Color.Transparent;
            this.lbRedTimer.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.lbRedTimer.ForeColor = System.Drawing.Color.Black;
            this.lbRedTimer.Location = new System.Drawing.Point(612, 238);
            this.lbRedTimer.Name = "lbRedTimer";
            this.lbRedTimer.Size = new System.Drawing.Size(97, 37);
            this.lbRedTimer.TabIndex = 3;
            this.lbRedTimer.Text = "60 : 00";
            // 
            // lbBlackTimer
            // 
            this.lbBlackTimer.AutoSize = true;
            this.lbBlackTimer.BackColor = System.Drawing.Color.Transparent;
            this.lbBlackTimer.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.lbBlackTimer.ForeColor = System.Drawing.Color.Black;
            this.lbBlackTimer.Location = new System.Drawing.Point(612, 290);
            this.lbBlackTimer.Name = "lbBlackTimer";
            this.lbBlackTimer.Size = new System.Drawing.Size(97, 37);
            this.lbBlackTimer.TabIndex = 5;
            this.lbBlackTimer.Text = "60 : 00";
            // 
            // lbNotification
            // 
            this.lbNotification.AutoSize = true;
            this.lbNotification.BackColor = System.Drawing.Color.Transparent;
            this.lbNotification.Font = new System.Drawing.Font("Segoe UI", 16.25F);
            this.lbNotification.Location = new System.Drawing.Point(631, 130);
            this.lbNotification.Name = "lbNotification";
            this.lbNotification.Size = new System.Drawing.Size(0, 30);
            this.lbNotification.TabIndex = 6;
            // 
            // btPauseResume
            // 
            this.btPauseResume.BackColor = System.Drawing.Color.Transparent;
            this.btPauseResume.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btPauseResume.Font = new System.Drawing.Font("Lucida Sans", 24F);
            this.btPauseResume.Image = global::MyCoTuong.Properties.Resources.rsznote3;
            this.btPauseResume.Location = new System.Drawing.Point(660, 467);
            this.btPauseResume.Margin = new System.Windows.Forms.Padding(0);
            this.btPauseResume.Name = "btPauseResume";
            this.btPauseResume.Size = new System.Drawing.Size(152, 102);
            this.btPauseResume.TabIndex = 7;
            this.btPauseResume.Text = "Start";
            this.btPauseResume.UseVisualStyleBackColor = false;
            this.btPauseResume.Click += new System.EventHandler(this.btPauseResume_Click);
            // 
            // pbNotification
            // 
            this.pbNotification.BackColor = System.Drawing.Color.Transparent;
            this.pbNotification.Image = global::MyCoTuong.Properties.Resources.rsz2note3;
            this.pbNotification.Location = new System.Drawing.Point(660, 52);
            this.pbNotification.Name = "pbNotification";
            this.pbNotification.Size = new System.Drawing.Size(302, 193);
            this.pbNotification.TabIndex = 8;
            this.pbNotification.TabStop = false;
            // 
            // btOptions
            // 
            this.btOptions.BackColor = System.Drawing.Color.Transparent;
            this.btOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btOptions.Font = new System.Drawing.Font("Lucida Sans", 24F);
            this.btOptions.Image = global::MyCoTuong.Properties.Resources.rsznote3;
            this.btOptions.Location = new System.Drawing.Point(660, 582);
            this.btOptions.Margin = new System.Windows.Forms.Padding(0);
            this.btOptions.Name = "btOptions";
            this.btOptions.Size = new System.Drawing.Size(157, 103);
            this.btOptions.TabIndex = 9;
            this.btOptions.Text = "Game Options";
            this.btOptions.UseVisualStyleBackColor = false;
            this.btOptions.Click += new System.EventHandler(this.btOptions_Click);
            // 
            // pbTime
            // 
            this.pbTime.BackColor = System.Drawing.Color.Transparent;
            this.pbTime.Image = global::MyCoTuong.Properties.Resources.rsz2note3;
            this.pbTime.Location = new System.Drawing.Point(660, 251);
            this.pbTime.Name = "pbTime";
            this.pbTime.Size = new System.Drawing.Size(302, 200);
            this.pbTime.TabIndex = 10;
            this.pbTime.TabStop = false;
            // 
            // btNewGame
            // 
            this.btNewGame.BackColor = System.Drawing.Color.Transparent;
            this.btNewGame.Font = new System.Drawing.Font("Lucida Sans", 24F);
            this.btNewGame.Image = global::MyCoTuong.Properties.Resources.rsznote3;
            this.btNewGame.Location = new System.Drawing.Point(817, 468);
            this.btNewGame.Name = "btNewGame";
            this.btNewGame.Size = new System.Drawing.Size(145, 102);
            this.btNewGame.TabIndex = 11;
            this.btNewGame.Text = "New Game";
            this.btNewGame.UseVisualStyleBackColor = false;
            this.btNewGame.Click += new System.EventHandler(this.btNewGame_Click);
            // 
            // btUndo
            // 
            this.btUndo.BackColor = System.Drawing.Color.Transparent;
            this.btUndo.Font = new System.Drawing.Font("Lucida Sans", 24F);
            this.btUndo.Image = global::MyCoTuong.Properties.Resources.rsznote3;
            this.btUndo.Location = new System.Drawing.Point(820, 581);
            this.btUndo.Name = "btUndo";
            this.btUndo.Size = new System.Drawing.Size(145, 103);
            this.btUndo.TabIndex = 12;
            this.btUndo.Text = "Undo";
            this.btUndo.UseVisualStyleBackColor = false;
            this.btUndo.Click += new System.EventHandler(this.btUndo_Click);
            // 
            // CoTuongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.BackgroundImage = global::MyCoTuong.Properties.Resources.wood_ipad_background;
            this.ClientSize = new System.Drawing.Size(998, 741);
            this.Controls.Add(this.btUndo);
            this.Controls.Add(this.btNewGame);
            this.Controls.Add(this.pbTime);
            this.Controls.Add(this.btOptions);
            this.Controls.Add(this.pbNotification);
            this.Controls.Add(this.btPauseResume);
            this.Controls.Add(this.lbNotification);
            this.Controls.Add(this.lbBlackTimer);
            this.Controls.Add(this.lbRedTimer);
            this.Controls.Add(this.pbBoard);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CoTuongForm";
            this.Text = "Cờ tướng";
            this.Load += new System.EventHandler(this.CoTuongForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNotification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBoard;
        private System.Windows.Forms.Timer redTimer;
        private System.Windows.Forms.Timer blackTimer;
        private System.Windows.Forms.Label lbRedTimer;
        private System.Windows.Forms.Label lbBlackTimer;
        private System.Windows.Forms.Label lbNotification;
        private System.Windows.Forms.Button btPauseResume;
        private System.Windows.Forms.PictureBox pbNotification;
        private System.Windows.Forms.Button btOptions;
        private System.Windows.Forms.PictureBox pbTime;
        private System.Windows.Forms.Button btNewGame;
        private System.Windows.Forms.Button btUndo;
    }
}

