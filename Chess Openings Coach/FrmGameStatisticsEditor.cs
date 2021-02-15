using System;
using System.Windows.Forms;

namespace Chess_Openings_Coach
{
    public partial class FrmGameStatisticsEditor : Form
    {
        public FrmGameStatisticsEditor(int gameCount, int whiteWon, int drawCount)
        {
            InitializeComponent();

            NupGameCount.Value = gameCount;
            NupWhiteWon.Value = whiteWon;
            NupDraw.Value = drawCount;
            NupBlackWon.Value = 100 - (whiteWon + drawCount);
            NupGameCount.Focus();
        }

        #region Properties

        public int GameCount { get { return (int)NupGameCount.Value; } }

        public int WhiteCount { get { return (int)NupWhiteWon.Value; } }

        public int DrawCount { get { return (int)NupDraw.Value; } }

        public int BlackCount { get { return (int)NupBlackWon.Value; } }


        #endregion Properties

        #region Events

        private void NupGameCount_ValueChanged(object sender, EventArgs e)
        {
            gameStatisticsControl1.SetStatistics((int)NupGameCount.Value, (int)NupWhiteWon.Value, (int)NupDraw.Value);
        }

        private void NupWhiteWon_ValueChanged(object sender, EventArgs e)
        {
            NupBlackWon.Value = 100 - (NupWhiteWon.Value + NupDraw.Value);
            gameStatisticsControl1.SetStatistics((int)NupGameCount.Value, (int)NupWhiteWon.Value, (int)NupDraw.Value);
        }

        private void NupDraw_ValueChanged(object sender, EventArgs e)
        {
            NupBlackWon.Value = 100 - (NupWhiteWon.Value + NupDraw.Value);
            gameStatisticsControl1.SetStatistics((int)NupGameCount.Value, (int)NupWhiteWon.Value, (int)NupDraw.Value);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void NupGameCount_Enter(object sender, EventArgs e)
        {
            (sender as NumericUpDown).Select(0, (sender as NumericUpDown).Text.Length);
        }

        #endregion Events
    }
}
