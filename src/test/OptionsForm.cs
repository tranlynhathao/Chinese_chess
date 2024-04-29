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
    public partial class OptionsForm : Form
    {
        int rdValue1; //value of group button 1
        int rdValue2; //value of group button 2
        public OptionsForm()
        {
            InitializeComponent();
            initialUndoAllowanceChoice();
            initialGameTypeChoice();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            saveAllInformation();
            this.FindForm().Close();
        }
        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            rdValue1 = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            rdValue1 = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            rdValue1 = 3;
        }
        
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            rdValue1 = 4;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            rdValue2 = 1;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            rdValue2 = 2;
        }
        private void saveAllInformation()
        {
            saveUndoAllowance();
            saveGameType();
        }
        private void saveGameType()
        {
            switch (rdValue1)
            {
                case 1:
                    GameConstants.Res_fullTimeAllowedRed = GameConstants.TimeCoTieuChuan;
                    GameConstants.Res_fullTimeAllowedBlack = GameConstants.TimeCoTieuChuan;
                    GameConstants.Res_gameType = GameConstants.TypeCoTieuChuan;
                    break;
                case 2:
                    GameConstants.Res_fullTimeAllowedRed = GameConstants.TimeCoNhanh;
                    GameConstants.Res_fullTimeAllowedBlack = GameConstants.TimeCoNhanh;
                    GameConstants.Res_gameType = GameConstants.TypeCoNhanh;
                    break;
                case 3:
                    GameConstants.Res_fullTimeAllowedRed = GameConstants.TimeCoChopRed;
                    GameConstants.Res_fullTimeAllowedBlack = GameConstants.TimeCoChopBlack;
                    GameConstants.Res_gameType = GameConstants.TypeCoChop;
                    break;
                case 4:
                    GameConstants.Res_fullTimeAllowedRed = GameConstants.TimeGiaoHuu;
                    GameConstants.Res_fullTimeAllowedBlack = GameConstants.TimeGiaoHuu;
                    GameConstants.Res_gameType = GameConstants.TypeGiaoHuu;
                    break;
                default: break;
            }
        }
        private void saveUndoAllowance()
        {
            switch (rdValue2)
            {
                case 1:
                    GameConstants.Res_undoAllowance = GameConstants.Opt_ChoPhepUndo;
                    break;
                case 2:
                    GameConstants.Res_undoAllowance = GameConstants.Opt_KhongChoPhepUndo;
                    break;
                default: break;
            }
        }
        private void initialGameTypeChoice(){
            radioButton1.Checked = (GameConstants.Res_gameType == GameConstants.TypeCoTieuChuan);
            radioButton2.Checked = (GameConstants.Res_gameType == GameConstants.TypeCoNhanh);
            radioButton3.Checked = (GameConstants.Res_gameType == GameConstants.TypeCoChop);
            radioButton4.Checked = (GameConstants.Res_gameType == GameConstants.TypeGiaoHuu);
        }
        private void initialUndoAllowanceChoice(){
            radioButton5.Checked = (GameConstants.Res_undoAllowance == GameConstants.Opt_ChoPhepUndo);
            radioButton6.Checked = (GameConstants.Res_undoAllowance == GameConstants.Opt_KhongChoPhepUndo);
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
